using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.IO;
using System.Windows.Forms;
using LANdrop.UI;
using LANdrop.Networking.PeerDiscovery;

namespace LANdrop.Networking
{
    /// <summary>
    /// The listening server that every peer runs. All incoming communication is received here, then handed off to the appropiate processor (IncomingTransfer, IncomingWhosThere, etc).
    /// </summary>
    class Server
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger( System.Reflection.MethodBase.GetCurrentMethod( ).DeclaringType );

        /// <summary>
        /// Whether the server is active and listening for new connections.
        /// </summary>
        public static bool Connected { get; private set; }

        /// <summary>
        /// The local port the server is bound to.
        /// </summary>
        public static int Port { get; private set; }

        /// <summary>
        /// The local IPEndPoint that the server is bound to (ip+port).
        /// </summary>
        public static IPEndPoint LocalServerEndpoint
        {
            get
            {
                if ( Connected )
                    return new IPEndPoint( Util.GetLocalAddress( ), Port );
                else
                    return null;
            }
        }

        /// <summary>
        /// The TCP server which listens for new connections.
        /// </summary>
        private static TcpListener listener;

        private static Thread ListenThread;

        private static MulticastPeerDiscoverer multicastDiscoverer = new MulticastPeerDiscoverer( );

        static Server( )
        {
            ListenThread = new Thread( Connect );
        }

        /// <summary>
        /// Starts the listening server on a new thread, where it runs perpetually.
        /// </summary>
        public static void Start( )
        {
            ListenThread.Start( );
        }

        public static void Stop( )
        {
            ListenThread.Abort( );
            multicastDiscoverer.Stop( );
        }

        /// <summary>
        /// Creates the listener socket. If successful, also runs the listen loop.
        /// </summary>
        private static void Connect( )
        {
            // Start at the default port, but advance linearly if it's in use.
            for ( int port = Protocol.DefaultServerPort; port < Protocol.DefaultServerPort + 100; port++ )
            {
                try
                {
                    listener = new TcpListener( IPAddress.Any, port );
                    listener.Start( );
                    Port = port;
                    Connected = true;
                    log.Info( "Server started; address is " + LocalServerEndpoint + "." );
                    break;
                }
                catch ( SocketException ) { }
            }

            if ( Connected )
            {
                multicastDiscoverer.Start( );
                ListenForClients( );
            }
            else
            {
                var message = "Failed to bind the listener.\nAnother instance of LANdrop might be running.";
                log.Fatal( message );
                MessageBox.Show( message, "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                Environment.Exit( -1 );
            }
        }

        /// <summary>
        /// Perpetually listens for new connections.
        /// </summary>
        private static void ListenForClients( )
        {
            while ( true )
            {
                TcpClient client = listener.AcceptTcpClient( ); // Halt until a client connects.

                // Respond to the request in a new thread.
                Thread newThread = new Thread( new ParameterizedThreadStart( RespondToNewConnection ) );
                newThread.Start( client );
            }
        }

        /// <summary>
        /// Responds to a new connection (typically called in a new thread).
        /// </summary>
        private static void RespondToNewConnection( object parameter )
        {
            // Read in the transfer info.
            try
            {
                TcpClient client = (TcpClient) parameter;

                using ( BinaryReader NetworkInStream = new BinaryReader( client.GetStream( ) ) )
                using ( BinaryWriter NetworkOutStream = new BinaryWriter( client.GetStream( ) ) )
                {
                    // Process the header.
                    var header = Header.Parse( NetworkInStream.ReadString( ) );
                    var peerAddress = ( (IPEndPoint) client.Client.RemoteEndPoint ).Address;
                    ProcessHeader( peerAddress, header );
                    var peer = PeerList.GetPeerForAddress( peerAddress );

                    // Are they sending us a file?
                    if ( header.Transfer != null )
                        new IncomingTransfer( header, client, NetworkInStream, NetworkOutStream );
                    else
                        peer.RegisterEvent( PeerStatistics.EventType.ReceivedInfo );

                }
            }
            catch ( SocketException ) { }
        }

        private static void ProcessHeader( IPAddress sender, Header header )
        {
            var peer = new Peer
            {
                Name = header.Sender.Username,
                EndPoint = new IPEndPoint( sender, header.Sender.ListenPort )
            };

            PeerList.AddOrUpdate( peer );

            // Did they send their peer list, too?
            if ( header.Peers != null && header.Peers.Count > 0 )
            {
                PeerList.AddOrUpdate( header.Peers );
                peer.RegisterEvent(PeerStatistics.EventType.ReceivedPeerList);
                log.InfoFormat( "{0} peers received from {1} via peer exchange.", header.Peers.Count, peer );
            }
        }
    }
}
