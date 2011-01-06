using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;
using LANdrop.UI;
using System.Diagnostics;

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
            if ( protocolVersion != Protocol.ProtocolVersion )
                return;

            // Determine what kind of transfer this is.
            switch ( (Protocol.IncomingCommunicationTypes) NetworkInStream.ReadInt32( ) )
            {
                case Protocol.IncomingCommunicationTypes.FileTransfer:
                    break;
                case Protocol.IncomingCommunicationTypes.TextSnippet:
                    Form form = new IncomingTextSnippetForm( NetworkInStream.ReadString( ));
                    MainForm.ShowFormOnUIThread( form );
                    return;
            }

            FileName = NetworkInStream.ReadString( );
            FileSize = NetworkInStream.ReadInt64( );

            // Ask the user if they want to receive the file.
          //  if ( MessageBox.Show( String.Format( "Would you like to receive {0} ({1})?", FileName, Util.FormatFileSize( FileSize ) ), "Incoming Transfer", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.Yes )
                NetworkOutStream.Write( true );
           /* else
            {
                NetworkOutStream.Write( false );
                return;
            }*/

            Debug.WriteLine( "INCOMING FILE TRANSFER!" );
            Debug.Indent( );
            Debug.WriteLine( "Name: " + FileName );
            Debug.WriteLine( "Size: " + Util.FormatFileSize( FileSize ) );
            Debug.Unindent( );

            // Create and show the form.                
            Form = new TransferForm( this );

            // Open handle to the file.
            SetState( State.TRANSFERRING );
            Stream fileStream = new FileStream( Path.Combine( DefaultSaveFolder, FileName ), FileMode.Create );

            // Transfer chunks.
            while ( NumBytesTransferred < FileSize )
            {
                byte[] chunk = new byte[Protocol.TransferChunkSize * 10];
                TcpClient.GetStream( ).Read( chunk, 0, chunk.Length ); 

                if ( chunk.Length > 0 )
                {
                    fileStream.Write( chunk, 0, chunk.Length );
                    fileStream.Flush( );                    
                    UpdateNumBytesTransferred( NumBytesTransferred + chunk.Length );
                }
            }

            SetState( State.VERIFYING );
            Debug.WriteLine( "Complete, sending final signal..." );

            NetworkOutStream.Write( true );
            NetworkOutStream.Flush( );

            SetState( State.FINISHED );
            Trace.WriteLine( FileName + ": " + Util.FormatFileSize( FileSize ) + " received in " + ( StopTime - StartTime ) / 1000.0 + " seconds (" + Util.FormatFileSize( GetCurrentSpeed( ) * 1000 ) + ")." );
        }
    }
}
