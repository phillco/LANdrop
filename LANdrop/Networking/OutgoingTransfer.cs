using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using LANdrop.UI;
using System.Threading;
using System.Windows.Forms;
using System.Security.Cryptography;
using LANdrop.UI.TransferForms;

namespace LANdrop.Networking
{
    public class OutgoingTransfer : Transfer
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger( System.Reflection.MethodBase.GetCurrentMethod( ).DeclaringType );

        public FileInfo File { get; protected set; }

        public Peer Recipient { get; protected set; }

        public OutgoingTransfer( FileInfo file, Peer recipient )
        {
            this.File = file;
            this.Recipient = recipient;
            this.FileSize = file.Length;
            this.FileName = file.Name;
            this.Partner = recipient.Name;

            // Create a progress notification for this form.
            TransferNotificationForm.CreateForTransfer( this );

            new Thread( new ThreadStart( DoTransfer ) ).Start( );
        }

        protected override void Connect( )
        {
            // Connect to the peer's listening server.
            TcpClient = new TcpClient( Recipient.EndPoint.AddressFamily );

            try
            {
                TcpClient.Connect( Recipient.EndPoint );
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
            log.InfoFormat( "Outgoing file transfer started: Offering {0} ({1}) to {2}", File.Name, Util.FormatFileSize( File.Length ), Recipient );

            // Send our header with the file information.
            var header = new Header( File );

            if ( Recipient.ShouldSendPeers ) // Send our peer list too, if it's time.
            {
                header.IncludePeerList( );
                Recipient.LastSentPeers = DateTime.Now;
            }

            NetworkOutStream.Write( header.ToString( ) );
            NetworkOutStream.Flush( );

            // Wait for the response.            
            if ( NetworkInStream.ReadBoolean( ) )
                SendFile( );
            else
            {
                log.DebugFormat( "Outgoing file transfer ({0}) was denied!", File.Name );
                SetState( State.REJECTED );
            }
        }

        private void SendFile( )
        {
            log.DebugFormat( "Outgoing file transfer ({0}) was accepted!", File.Name );
            SetState( State.TRANSFERRING );

            // Create the MD5 checksummer.
            HashAlgorithm hasher = MD5CryptoServiceProvider.Create( );
            hasher.Initialize( );

            using ( FileStream fileInStream = new FileStream( File.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite ) )
            {
                // Iterate through the file in chunk-sized increments.
                for ( long i = 0; i < FileSize; )
                {
                    // Calculate the number of bytes we're about to send.
                    int numBytesRead = (int) Math.Min( Protocol.TransferChunkSize, FileSize - i );

                    // Read in the chunk from a file, write it to the network.
                    byte[] chunk = new byte[numBytesRead];
                    fileInStream.Read( chunk, 0, numBytesRead );
                    NetworkOutStream.Write( chunk );
                    hasher.TransformBlock( chunk, 0, numBytesRead, null, 0 );
                    UpdateNumBytesTransferred( NumBytesTransferred + numBytesRead );
                    i += numBytesRead;
                }
            }

            // Finalize the hash.
            hasher.TransformFinalBlock( new byte[0], 0, 0 );
            log.DebugFormat( "Outgoing: Finished sending data, with hash of: {0}", Util.HashToHexString( hasher.Hash ) );
            
            SetState( State.VERIFYING );
            NetworkOutStream.Write( Util.HashToHexString( hasher.Hash ) );
            NetworkOutStream.Flush( );
            bool success = NetworkInStream.ReadBoolean( );
            SetState( success ? State.FINISHED : State.FAILED );            

            log.InfoFormat( "Outgoing file transfer succeeded! {0} ({1}) was sent to {2} in {3} seconds ({4}/s)", FileName, Util.FormatFileSize( FileSize ), Recipient, ( StopTime - StartTime ) / 1000.0, Util.FormatFileSize( GetCurrentSpeed( ) * 1000 ) );
        }
    }
}
