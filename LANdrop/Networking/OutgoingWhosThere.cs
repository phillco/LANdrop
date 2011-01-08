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
        private Peer Peer;

        public OutgoingWhosThere( Peer peerToUpdate )
        {
            this.Peer = peerToUpdate;
            ThreadPool.QueueUserWorkItem( delegate { SendAsync(); } );
        }

        private void SendAsync( )
        {
            TcpClient client = new TcpClient( );

            try
            {
                client.SendTimeout = 30;
                client.Connect( Peer.Address );
            }
            catch ( SocketException )
            {                
                return;
            }

            using ( BinaryReader NetworkInStream = new BinaryReader( client.GetStream( ) ) )
            using ( BinaryWriter NetworkOutStream = new BinaryWriter( client.GetStream( ) ) )
            {
                // Send protocol information.
                NetworkOutStream.Write( (Int32) Protocol.Version );
                NetworkOutStream.Write( (Int32) Protocol.IncomingCommunicationTypes.WhosThere );
                NetworkOutStream.Flush( );

                // First send our information...
                NetworkOutStream.Write( Environment.UserName );
                NetworkOutStream.Write( Dns.GetHostName( ) );
                NetworkOutStream.Write( (Int32) IncomingTransferListener.Port );

                // ...and then read in theirs.
                Peer.Name = NetworkInStream.ReadString( ) + " on " + NetworkInStream.ReadString();
                Peer.LastLookedUp = Peer.LastSeen = DateTime.Now;
            }
        }
    }
}
