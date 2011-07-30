using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;
using LANdrop.UI;
using System.Security.Cryptography;
using System.Net;
using LANdrop.UI.TransferForms;

namespace LANdrop.Networking
{
    public class IncomingTransfer : Transfer
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger( System.Reflection.MethodBase.GetCurrentMethod( ).DeclaringType );

        public Peer Sender { get; private set; }

        public string FileSaveLocation { get; private set; }

        private StreamWriter fileOutputStream;

        private static string DefaultSaveFolder = Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments );

        private Semaphore userResponseReceived = new Semaphore( 0, 1 );

        private bool Accepted = false;

        public IncomingTransfer( TcpClient client, BinaryReader netInStream, BinaryWriter netOutStream )
        {
            this.TcpClient = client;
            this.NetworkInStream = netInStream;
            this.NetworkOutStream = netOutStream;

            // Read in information about the sender.
            IPAddress peerAddress = ( (IPEndPoint) client.Client.RemoteEndPoint ).Address;
            string peerName = NetworkInStream.ReadString( );

            // If we already know this peer, use our stored information. TODO: merge the information like we do elsewhere
            Sender = PeerList.GetPeerForAddress( peerAddress );
            if ( Sender == null ) // ...otherwise, add it!
            {
                Sender = new Peer { Name = peerName, EndPoint = new IPEndPoint( peerAddress, Protocol.DefaultServerPort ) };
                PeerList.AddOrUpdate( Sender );
            }

            FileName = NetworkInStream.ReadString( );
            FileSize = NetworkInStream.ReadInt64( );

            // Ask the user if they want to receive this file.       
            TransferNotificationForm.CreateForTransfer( this );

            // Wait for the user's response. (otherwise we dispose the streams)
            userResponseReceived.WaitOne( );

            try
            {
                if ( Accepted )
                {
                    NetworkOutStream.Write( true );
                    DoTransfer( );
                }
                else
                    NetworkOutStream.Write( false );
            }
            catch ( IOException )
            {
                SetState( State.FAILED );
                return;
            }
        }

        public void Accept( )
        {
            Accepted = true;
            userResponseReceived.Release( );
        }

        public void Reject( )
        {
            Accepted = false;
            userResponseReceived.Release( );
        }

        protected override void Connect( )
        {
            log.InfoFormat( "Incoming file transfer offerred: {0} wants to send us {1} ({2})", Sender, FileName, Util.FormatFileSize( FileSize ) );

            // Open handle to the file.
            SetState( State.TRANSFERRING );

            // Create the MD5 checksummer.
            HashAlgorithm hasher = MD5CryptoServiceProvider.Create( );
            hasher.Initialize( );

            FileSaveLocation = Util.FindFreeFileName( Path.Combine( DefaultSaveFolder, FileName ) );
            using ( Stream fileStream = new FileStream( FileSaveLocation, FileMode.Create ) )
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
            log.DebugFormat( "Incoming: Finished receiving data, with hash of: {0}", Util.HashToHexString( hasher.Hash ) );

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
            log.InfoFormat( "Incoming file transfer succeeded! {0} ({1}) was received from {2} in {3} seconds ({4}/s) ", FileName, Util.FormatFileSize( FileSize ), Sender, ( StopTime - StartTime ) / 1000.0, Util.FormatFileSize( GetCurrentSpeed( ) * 1000 ) );
        }
    }
}
