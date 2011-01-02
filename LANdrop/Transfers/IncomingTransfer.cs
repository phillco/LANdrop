using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;
using LANdrop.UI;

namespace LANdrop.Transfers
{
    class IncomingTransfer : Transfer
    {
        private StreamWriter fileOutputStream;

        private static string DefaultSaveFolder = Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments );

        public IncomingTransfer( TcpClient client )
        {
            this.Form = new IncomingTransferForm( );
            this.TcpClient = client;
            new Thread( new ThreadStart( Connect ) ).Start( );
        }

        public void Connect()
        {
            SetupStreams( TcpClient.GetStream( ) );

            // Read in the transfer info.
            int protocolVersion = NetworkInStream.ReadInt32( );
            string fileName = NetworkInStream.ReadString( );
            FileSize = NetworkInStream.ReadInt64( );

            // Auto-accept for now.
            Thread.Sleep( 1000 );
            NetworkOutStream.Write( true );

            // Open handle to the file.
            fileOutputStream = new StreamWriter( Path.Combine( DefaultSaveFolder, "/" + fileName ) );

            // Transfer chunks.
            while ( NumBytesTransferred < FileSize )
            {
                byte[] chunk = NetworkInStream.ReadBytes( Protocol.TransferChunkSize );

                if ( chunk.Length > 0 )
                {
                    fileOutputStream.Write( chunk );
                    UpdateNumBytesTransferred( NumBytesTransferred + chunk.Length );
                }
            }

        }
    }
}
