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
            bool sendPeers = false;

            if ( Peer.ShouldSendPeers )
            {
                log.InfoFormat( "Sending {0} peers to {1}", PeerList.Peers.Count, Peer );
                sendPeers = true;
                Peer.LastSentPeers = DateTime.Now;
            }
            Peer.LastLookedUp = DateTime.Now;
            TcpClient client = new TcpClient( Peer.EndPoint.AddressFamily );

            try
            {
                client.SendTimeout = 30;
                client.Connect( Peer.EndPoint );

                using ( BinaryReader NetworkInStream = new BinaryReader( client.GetStream( ) ) )
                using ( BinaryWriter NetworkOutStream = new BinaryWriter( client.GetStream( ) ) )
                {
                    var header = new Header( sendPeers );
                    NetworkOutStream.Write( header.ToString( ) );
                    NetworkOutStream.Flush( );
                }
            }
            catch ( SocketException e ) { log.Info( "Error during outgoing who's-there: " + e ); }
            catch ( IOException e ) { log.Info( "Error during outgoing who's-there: " + e ); }
        }
    }
}
