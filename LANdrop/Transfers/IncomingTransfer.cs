﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;
using LANdrop.UI;
using System.Diagnostics;
using System.Security.Cryptography;

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

            // Create the MD5 checksummer.
            HashAlgorithm hasher = MD5CryptoServiceProvider.Create( );
            hasher.Initialize( );

            using ( Stream fileStream = new FileStream( Path.Combine( DefaultSaveFolder, FileName ), FileMode.Create ) )
            {
                // Transfer chunks.
                while ( NumBytesTransferred < FileSize )
                {
                    byte[] chunk = new byte[Protocol.TransferChunkSize * 10];
                    int numBytes = TcpClient.GetStream( ).Read( chunk, 0, chunk.Length );
                    hasher.TransformBlock( chunk, 0, numBytes, null, 0 );

                    if ( chunk.Length > 0 )
                    {
                        fileStream.Write( chunk, 0, numBytes );
                        fileStream.Flush( );
                        UpdateNumBytesTransferred( NumBytesTransferred + numBytes );
                    }
                }
            }

            SetState( State.VERIFYING );

            // Finalize the hash.
            hasher.TransformFinalBlock( new byte[0], 0, 0 );
            Console.WriteLine( "Incoming: Finished receiving data, with hash of: " + Util.HashToHexString( hasher.Hash ) );

            // Wait for the senders's hash code.
            if ( NetworkInStream.ReadString( ) == Util.HashToHexString( hasher.Hash ) )
            {
                NetworkOutStream.Write( true );
                SetState( State.FINISHED );
            }
            else
            {
                NetworkOutStream.Write( false);
                SetState( State.FAILED );
            }
            
            NetworkOutStream.Flush( );

            SetState( State.FINISHED );
            Trace.WriteLine( FileName + ": " + Util.FormatFileSize( FileSize ) + " received in " + ( StopTime - StartTime ) / 1000.0 + " seconds (" + Util.FormatFileSize( GetCurrentSpeed( ) * 1000 ) + ")." );
        }
    }
}
