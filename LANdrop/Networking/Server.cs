using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using LANdrop.UI;

namespace LANdrop.Networking
{
    /// <summary>
    /// The listening server that every peer runs. All incoming communication is received here, then handed off to the appropiate processor (IncomingTransfer, IncomingWhosThere, etc).
    /// </summary>
    class Server
    {
        public static int Port { get; private set; }

        private static TcpListener listener;

        public static void Start( )
        {
            new Thread( new ThreadStart( ListenForClients ) ).Start( );
        }

        /// <summary>
        /// Perpetually listens for new connections.
        /// </summary>
        public static void ListenForClients( )
        {
            for ( int port = Protocol.ServerPort; port < Protocol.ServerPort + 100; port++ )
            {
                try
                {
                    listener = new TcpListener( IPAddress.Any, port );
                    listener.Start( );
                    Port = port;
                    break;
                }
                catch ( SocketException ) { }
            }

            if ( Port == 0 )
            {
                MessageBox.Show( "Failed to bind the listener.\nAnother instance of LANdrop might be running.", "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                Environment.Exit( -1 );
            }

            Trace.WriteLine( "Listener bound to port " + Port + "." );

            while ( true )
            {
                TcpClient client = listener.AcceptTcpClient( ); // Halt until a client connects.

                // Respond to the request in a new thread.
                ThreadPool.QueueUserWorkItem( delegate( object state ) { RespondToNewConnection( client ); } );
            }
        }

        /// <summary>
        /// Responds to a new connection (typically called in a new thread).
        /// </summary>
        private static void RespondToNewConnection( TcpClient client )
        {
            // Read in the transfer info.
            using ( BinaryReader NetworkInStream = new BinaryReader( client.GetStream( ) ) )
            using ( BinaryWriter NetworkOutStream = new BinaryWriter( client.GetStream( ) ) )
            {
                // First check the protocol version. Don't accept requests from different protocol versions.
                int protocolVersion = NetworkInStream.ReadInt32( );
                if ( protocolVersion != Protocol.Version )
                    return;

                // Determine what kind of transfer this is.
                switch ( (Protocol.IncomingCommunicationTypes) NetworkInStream.ReadInt32( ) )
                {
                    case Protocol.IncomingCommunicationTypes.FileTransfer:
                        new IncomingTransfer( client, NetworkInStream, NetworkOutStream );
                        break;
                    case Protocol.IncomingCommunicationTypes.TextSnippet:
                        Form form = new IncomingTextSnippetForm( NetworkInStream.ReadString( ) );
                        MainForm.ShowFormOnUIThread( form );
                        break;
                    case Protocol.IncomingCommunicationTypes.WhosThere:
                        new IncomingWhosThere(client, NetworkInStream, NetworkOutStream);
                        break;
                }
            }
        }
    }
}
