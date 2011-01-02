using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using LANdrop.Peering;
using LANdrop.UI;
using System.Threading;

namespace LANdrop.Transfers
{
    public class OutgoingTransfer : Transfer
    {
        public FileInfo File { get; protected set; }

        public Peer Recipient { get; protected set; }

        public OutgoingTransfer( FileInfo file, Peer recipient )
        {
            this.File = file;
            this.Recipient = recipient;
            this.FileSize = file.Length;

            // Create and show the form.
            Form = new OutgoingTransferForm( this );

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

            SendInvitation( );
        }

        private void SendInvitation( )
        {
            // Send the file information.
            NetworkOutStream.Write( (Int32) Protocol.ProtocolVersion );
            NetworkOutStream.Write( File.Name );
            NetworkOutStream.Write( File.Length );
            TcpClient.GetStream( ).Flush( );

            // Wait for the response.
            if ( NetworkInStream.ReadBoolean() )
                SendFile( );
            else
                SetState( State.REJECTED );
        }       

        private void SendFile( )
        {
            SetState( State.TRANSFERRING );

            FileStream fileInStream = new FileStream( File.FullName, FileMode.Open );

            // Iterate through the file in chunk-sized increments.
            for ( long i = 0; i < FileSize; i += Protocol.TransferChunkSize )
            {
                // Calculate the number of bytes we're about to send.
                int numBytes = (int) Math.Min( Protocol.TransferChunkSize, FileSize - i );

                // Read in the chunk from a file, write it to the network.
                byte[] chunk = new byte[numBytes];
                fileInStream.Read( chunk, 0, numBytes );
                NetworkOutStream.Write( chunk );
                TcpClient.GetStream( ).Flush( );
                
                UpdateNumBytesTransferred( NumBytesTransferred + numBytes);
            }

            // ...and we're done.
            fileInStream.Close( );
            SetState( State.FINISHED );
        }
    }
}
