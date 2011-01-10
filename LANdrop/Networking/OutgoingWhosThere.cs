using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;

namespace LANdrop.Networking
{
    /// <summary>
    /// Queries a LANdrop peer to get its information. Only needed for peers whose announcement's we can't detect.
    /// </summary>
    class OutgoingWhosThere
    {
        private Peer Peer;

        public OutgoingWhosThere( Peer peerToUpdate )
        {
            this.Peer = peerToUpdate;
            ThreadPool.QueueUserWorkItem( delegate { SendAsync( ); } );
        }

        private void SendAsync( )
        {
            TcpClient client = new TcpClient( );

            try
            {
                client.SendTimeout = 30;
                client.Connect( Peer.EndPoint );

                using ( BinaryReader NetworkInStream = new BinaryReader( client.GetStream( ) ) )
                using ( BinaryWriter NetworkOutStream = new BinaryWriter( client.GetStream( ) ) )
                {
                    // Send protocol information.
                    NetworkOutStream.Write( (Int32) Protocol.Version );
                    NetworkOutStream.Write( (Int32) Protocol.IncomingCommunicationTypes.WhosThere );
                    NetworkOutStream.Write( (Int32) Protocol.TransferPortNumber );
                    NetworkOutStream.Flush( );

                    // Is it time to do a peer exchange?
                    bool doPeerExchange = Peer.ShouldDoPeerExchange();
                    NetworkOutStream.Write( doPeerExchange );
                    Trace.WriteLine( String.Format( "Sending a who's-there request to {0}{1}.", Peer, doPeerExchange ? " (with peer list request)" : "" ) );

                    // Read in their attributes...
                    Peer.Name = NetworkInStream.ReadString( ) + " on " + NetworkInStream.ReadString( );
                    Peer.LastLookedUp = Peer.LastSeen = DateTime.Now;
                    MulticastManager.ProcessPeer( Peer, true );

                    // ...and their peer list!
                    if ( NetworkInStream.ReadBoolean( ) )
                    {
                        for ( int i = 0, num = NetworkInStream.ReadInt32( ); i < num; i++ )
                        {
                            Peer newPeer = new Peer( NetworkInStream );
                            Trace.WriteLine( "Received " + newPeer + " from " + Peer + "'s peer exchange..." );
                            MulticastManager.ProcessPeer( newPeer, true );
                        }
                    }
                }
            }
            catch ( SocketException ) { }
            catch ( IOException ) { }
        }
    }
}
