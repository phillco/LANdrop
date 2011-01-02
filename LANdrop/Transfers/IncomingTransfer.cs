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
            this.TcpClient = client;
            new Thread( new ThreadStart( DoTransfer ) ).Start( );
        }

        protected override void Connect( )
        {
            SetupStreams( TcpClient.GetStream( ) );

            // Read in the transfer info.
            int protocolVersion = NetworkInStream.ReadInt32( );
            FileName = NetworkInStream.ReadString( );
            FileSize = NetworkInStream.ReadInt64( );

            // Ask the user if they want to receive the file.
            if ( MessageBox.Show( String.Format( "Would you like to receive {0} ({1})?", FileName, Util.FormatFileSize( FileSize ) ), "Incoming Transfer", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.Yes )
                NetworkOutStream.Write( true );
            else
            {
                NetworkOutStream.Write( false );
                return;
            }

            // Create and show the form.
            Form = new TransferForm( this );

            // Open handle to the file.
            fileOutputStream = new StreamWriter( Path.Combine( DefaultSaveFolder, "/" + FileName ) );

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
