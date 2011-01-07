using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net.Sockets;

namespace LANdrop.Networking
{
    public class OutgoingTextSnippet : Transfer
    {
        private string message;

        private Peer Recipient;

        public OutgoingTextSnippet( string message, Peer recipient )
        {
            this.message = message;
            this.Recipient = recipient;           
            this.Partner = recipient.Name;

            new Thread( new ThreadStart( DoTransfer ) ).Start( );
        }

        protected override void Connect( )
        {
            // Connect to the peer's listening server.
            TcpClient = new TcpClient( );

            try
            {
                TcpClient.Connect( Recipient.Address );
            }
            catch ( SocketException )
            {
                SetState( State.FAILED_CONNECTION );
                return;
            }

            // Hook up data streams.
            SetupStreams( TcpClient.GetStream( ) );
            
            // Send the file information.
            NetworkOutStream.Write( (Int32) Protocol.ProtocolVersion );
            NetworkOutStream.Write( (Int32) Protocol.IncomingCommunicationTypes.TextSnippet );
            NetworkOutStream.Write( message );
            TcpClient.GetStream( ).Flush( );
        }
    }
}
