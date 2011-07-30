using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Windows.Forms;
using System.IO;

namespace LANdrop.Networking.PeerDiscovery
{
    /// <summary>
    /// Discovers peers using IPv6 multicasting. This is the LANdrop's #1 way to detect peers on the network; it is reliable and works around routers.
    /// </summary>
    class MulticastPeerDiscoverer : IPeerDiscoverer
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger( System.Reflection.MethodBase.GetCurrentMethod( ).DeclaringType );

        private bool connected;

        private IPAddress multicastAddress = IPAddress.Parse( Protocol.MulticastGroupAddress );        

        private Thread sendThread, listenThread;

        public MulticastPeerDiscoverer( )
        {
            connected = true;

            // Set up the thread to send our announcements out periodically.
            sendThread = new Thread( SendLoop );
            sendThread.Name = "MulticastPeerDiscoverer Broadcast";
            sendThread.IsBackground = true;
            sendThread.Priority = ThreadPriority.BelowNormal;

            // Set up the thread to listen for new accouncements.
            listenThread = new Thread( ListenLoop );
            listenThread.Name = "MulticastPeerDiscoverer Listen";
            listenThread.IsBackground = true;
            listenThread.Priority = ThreadPriority.BelowNormal;
        }

        public void Start( )
        {
            sendThread.Start( );
            listenThread.Start( );
        }

        public void Refresh( )
        {
            sendThread.Interrupt( );
        }

        public void Stop( )
        {
            connected = false;
            Refresh( ); // Will send a "goodbye" message to remove us from other peer lists immediately.
            listenThread.Abort( );
        }

        /// <summary>
        /// Perpetually announces our information every second.
        /// </summary>
        protected void SendLoop( )
        {
            using ( Socket socket = new Socket( AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp ) )
            {
                InitializeOutgoingSocket( socket );

                while ( connected )
                {
                    SendAnnouncement( socket );

                    try
                    {
                        Thread.Sleep( 1000 );
                    }
                    catch ( ThreadInterruptedException ) { } // Occurs naturally when Refresh() is called.
                }

                // Send a goodbye message so we're removed immediately.
                SendAnnouncement( socket );
                socket.Close( );
            }
        }

        /// <summary>
        /// Perpetually listens for another LANdrop clients' announcements.
        /// </summary>
        protected void ListenLoop( )
        {
            using ( Socket listenSocket = new Socket( AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp ) )
            {
                InitializeIncomingSocket( listenSocket );

                while ( connected )
                {
                    byte[] packet = new byte[1024];
                    listenSocket.Receive( packet ); // Halt here until a packet is received.

                    ParseAnnouncement( packet );
                }
            }
        }

        /// <summary>
        /// Sends our multicast announcement to the given socket.
        /// </summary>
        protected void SendAnnouncement( Socket socket )
        {
            using ( BinaryWriter message = new BinaryWriter( new MemoryStream( ) ) )
            {
                // Send our name, protocol versions and IP.
                message.Write( (Int32) Protocol.Version );
                message.Write( Configuration.CurrentSettings.Username );
                message.Write( Util.GetLocalAddress( ).ToString( ) );
                message.Write( connected );

                try
                {
                    socket.Send( ( (MemoryStream) message.BaseStream ).ToArray( ) );
                }
                catch ( SocketException ) { }
            }
        }

        /// <summary>
        /// Parses the given multicast announcement.
        /// </summary>
        protected void ParseAnnouncement( byte[] packet )
        {
            using ( BinaryReader message = new BinaryReader( new MemoryStream( packet ) ) )
            {
                // First read the protocol version. We can only peer with LANdrop clients of the same version.
                if ( message.ReadInt32( ) != Protocol.Version )
                    return;

                // Parse in the peer, and forward it to the PeerManager.                
                var peer = new Peer
                {
                    Name = message.ReadString( ),
                    EndPoint = new IPEndPoint( IPAddress.Parse( message.ReadString( ) ), Protocol.DefaultServerPort ),
                    LastSeen = DateTime.Now,
                    LastLookedUp = DateTime.Now
                };

                log.Debug( "Received a multicast announcement from " + peer.Name + " (" + peer.EndPoint + ")" );

                if ( message.ReadBoolean( ) ) // Are they saying goodbye?
                    PeerList.Add( peer );
                else
                    PeerList.Remove( peer );
            }
        }

        /// <summary>
        /// Sets up the outgoing socket, which broadcasts to the multicast group.
        /// </summary>
        protected void InitializeOutgoingSocket( Socket socket )
        {
            int port = Util.BindToFirstPossiblePort( socket, Protocol.MulticastPort + 50 );
            if ( port == -1 )
            {
                // TODO: Smarter handling of this error.
                var message = "Failed to bind the multicast sender.\nAnother instance of LANdrop might be running.";
                log.Fatal( message );
                MessageBox.Show( message, "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                Environment.Exit( -1 );
            }
            else
                log.Info( "Multicast sender bound to port " + port + "." );

            socket.SetSocketOption( SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption( multicastAddress ) );
            socket.SetSocketOption( SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, 16 );
            socket.Connect( new IPEndPoint( multicastAddress, Protocol.MulticastPort ) );
        }

        /// <summary>
        /// Sets up the incoming socket, which listens to the multicast group.
        /// </summary>
        protected void InitializeIncomingSocket( Socket socket )
        {
            int port = Util.BindToFirstPossiblePort( socket, Protocol.MulticastPort );
            
            // Unlike the sending socket, we *must* get this port to receive any multicast messages.
            if ( port == -1 )
            {
                var message = "Failed to bind the multicast listener.\nAnother instance of LANdrop might be running.";
                log.Fatal( message );
                MessageBox.Show( message, "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                Environment.Exit( -1 );
            }
            else if ( port != Protocol.MulticastPort )
            {
                // TODO: Smarter handling of this error.
                // TODO: Detect other instances of LANdrop at startup.
                var message = String.Format( "The multicast listener was unable to bind to port {0} (instead, it got {1})." +
                    "\n\nLANdrop will still work, but you won't probably won't see any clients to connect to.", Protocol.MulticastPort, port );
                log.Warn( message );
                MessageBox.Show( message, "Startup Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
            }

            log.Info( "Multicast listener bound to port " + port + "." );
            socket.SetSocketOption( SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption( multicastAddress, IPAddress.Any ) );
        }
    }
}
