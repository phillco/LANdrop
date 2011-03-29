using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;
using LANdrop.UI;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Net;
using LANdrop.UI.TransferForms;

namespace LANdrop.Networking
{
    public class IncomingTransfer : Transfer
    {
        public Peer Sender { get; private set; }

        private StreamWriter fileOutputStream;

        private static string DefaultSaveFolder = Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments );

        private Semaphore userResponseReceived = new Semaphore( 0, 1 );

        private bool Accepted = false;

        public NotificationForm Notification;        

        public IncomingTransfer( TcpClient client, BinaryReader netInStream, BinaryWriter netOutStream )
        {
            this.TcpClient = client;
            this.NetworkInStream = netInStream;
            this.NetworkOutStream = netOutStream;

            // Read in information about the sender.
            IPAddress peerAddress = ((IPEndPoint) client.Client.RemoteEndPoint).Address;
            string peerName= NetworkInStream.ReadString();

            // If we already know this peer, use our stored information. TODO: merge the information like we do elsewhere
            Sender = MulticastManager.GetPeerForAddress( peerAddress );
            if ( Sender == null ) // ...otherwise, add it!
            {
                Sender = new Peer { Name = peerName, EndPoint = new IPEndPoint( peerAddress, Protocol.DefaultServerPort ) };
                MulticastManager.ProcessPeer( Sender, true );
            }

            FileName = NetworkInStream.ReadString( );
            FileSize = NetworkInStream.ReadInt64( );

            // Ask the user if they want to receive this file.       
            MainForm.CreateIncomingNotification( this );

            // Wait for the user's response. (otherwise we dispose the streams)
            userResponseReceived.WaitOne( );

            if ( Accepted )
            {
                NetworkOutStream.Write( true );
                DoTransfer( );
            }
            else
                NetworkOutStream.Write( false );

        }

        public void Accept( )
        {
            Accepted = true;
            userResponseReceived.Release( );
            progressPane = new ProgressPane( this );
            Notification.ChangeContent( progressPane );
        }

        public void Reject( )
        {
            Accepted = false;
            userResponseReceived.Release( );
        }

        protected override void Connect( )
        {
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

            using ( Stream fileStream = new FileStream( Util.FindFreeFileName( Path.Combine( DefaultSaveFolder, FileName ) ), FileMode.Create ) )
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
                NetworkOutStream.Write( false );
                SetState( State.FAILED );
            }

            NetworkOutStream.Flush( );

            SetState( State.FINISHED );
            Trace.WriteLine( FileName + ": " + Util.FormatFileSize( FileSize ) + " received in " + ( StopTime - StartTime ) / 1000.0 + " seconds (" + Util.FormatFileSize( GetCurrentSpeed( ) * 1000 ) + ")." );
        }
    }
}
