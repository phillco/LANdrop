using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.IO;

namespace LANdrop.Networking
{
    /// <summary>
    /// Queries a LANdrop peer to get its information. Only needed for peers whose announcement's we can't detect.
    /// </summary>
    class OutgoingWhosThere
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger( System.Reflection.MethodBase.GetCurrentMethod( ).DeclaringType );

        private Peer Peer;

        public OutgoingWhosThere( Peer peerToUpdate )
        {
            this.Peer = peerToUpdate;
            ThreadPool.QueueUserWorkItem( delegate { SendAsync( ); } );
        }

        private void SendAsync( )
        {
            TcpClient client = new TcpClient( Peer.EndPoint.AddressFamily );

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
                    NetworkOutStream.Write( (Int32) Protocol.DefaultServerPort );
                    NetworkOutStream.Flush( );

                    // Is it time to do a peer exchange?
                    bool doPeerExchange = Peer.ShouldDoPeerExchange();
                    NetworkOutStream.Write( doPeerExchange );
                    log.DebugFormat( "Sending a who's-there request to {0}{1}.", Peer.EndPoint, ( doPeerExchange ? " (with peer list request)" : "" ) );

                    // Read in their attributes...
                    Peer.Name = NetworkInStream.ReadString( );
                    Peer.LastLookedUp = Peer.LastSeen = DateTime.Now;
                    PeerList.Add( Peer );

                    // ...and their peer list!
                    if ( NetworkInStream.ReadBoolean( ) )
                    {
                        Peer.LastExchangedPeers = DateTime.Now;
                        int numPeers = NetworkInStream.ReadInt32( );
                        for ( int i = 0; i < numPeers; i++ )
                            PeerList.Add( new Peer( NetworkInStream ) );

                        log.InfoFormat( "{0} peers received from {1} via peer exchange.", numPeers, Peer );
                    }
                }
            }
            catch ( SocketException e ) { log.Info( "Error during outgoing who's-there: " + e ); }
            catch ( IOException e ) { log.Info( "Error during outgoing who's-there: " + e ); }
        }
    }
}
