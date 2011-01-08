using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using LANdrop.Networking;
using LANdrop.UI;

namespace LANdrop.Networking
{
    /// <summary>
    /// Handles the broadcasting and listening for LANdrop multicast messages.
    /// These messages allows LANdrop clients to self-announce, without entering each others' IP addresses.
    /// </summary>
    class MulticastManager
    {
        private static List<Peer> discoveredPeers = new List<Peer>();

        private static List<Peer> manuallyAddedUsers = new List<Peer>();

        private static IPAddress multicastAddress = IPAddress.Parse( Protocol.MulticastGroupAddress );

        private static MainForm form;

        private static bool connected;

        /// <summary>
        /// Starts announcing and listening for other clients.
        /// </summary>
        public static void Init( MainForm mainForm )
        {
            form = mainForm;
            connected = true;
            discoveredPeers = new List<Peer>( );
            new Thread( new ThreadStart( SendLoop ) ).Start( );
            new Thread( new ThreadStart( ListenLoop ) ).Start( );
        }

        /// <summary>
        /// Returns a list of all users available to send to (includes discovered and manually added ones).
        /// </summary>
        public static List<Peer> GetAllUsers( )
        {
            List<Peer> list = new List<Peer>( discoveredPeers );
            list.AddRange( manuallyAddedUsers );
            return list;
        }

        /// <summary>
        /// Adds the user at the given address to the list.
        /// </summary>
        /// <param name="address"></param>
        public static void AddUserManually( string address )
        {
            Peer p = new Peer
            {
                Name = "User at " + address,
                Address = new IPEndPoint( IPAddress.Parse( address), Protocol.TransferPortNumber )
            };

            manuallyAddedUsers.Add( p );
            new OutgoingWhosThere( p );
        }

        /// <summary>
        /// Stops the announce & listening loops and sends a "goodbye" message to the other peers.
        /// </summary>
        public static void Disconnect( )
        {
            connected = false;
        }

        /// <summary>
        /// Perpetually announces our information every second.
        /// </summary>
        public static void SendLoop( )
        {
            // Connect to the multicast group.
            Socket socket = new Socket( AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp );
            int sendPort = Util.BindToFirstPossiblePort( socket, Protocol.MulticastPortNumber + 50 );
            if ( sendPort == -1 )
            {
                MessageBox.Show( "Failed to bind the multicast sender.\nAnother instance of LANdrop might be running.", "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                Environment.Exit( -1 );
            }
            else
                Trace.WriteLine( "Multicast sender bound to port " + sendPort + "." );

            socket.SetSocketOption( SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption( multicastAddress ) );
            socket.SetSocketOption( SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, 8 );
            socket.Connect( new IPEndPoint( multicastAddress, Protocol.MulticastPortNumber ) );

            // Perpetually announce every second.
            while ( connected )
            {
                SendAnnouncement( socket );

                // Remove timed-out peers while we're at it.
                RemoveOldPeers( );
                Thread.Sleep( 1000 );
            }

            // Send a goodbye message so we're removed immediately.
            SendAnnouncement( socket );

            socket.Close( );
        }

        private static void SendAnnouncement( Socket socket )
        {
            BinaryWriter message = new BinaryWriter( new MemoryStream( ) );

            // Send our name, protocol versions and IP.
            message.Write( (Int32) Protocol.ProtocolVersion );
            message.Write( Environment.UserName );
            message.Write( Dns.GetHostName( ) );
            message.Write( Util.GetLocalAddress( ).ToString( ) );
            message.Write( connected );

            socket.Send( ( (MemoryStream) message.BaseStream ).ToArray( ) );
        }

        /// <summary>
        /// Perpetually listens for another LANdrop clients' announcements.
        /// </summary>
        public static void ListenLoop( )
        {
            // Connect to the multicast group (for listening).
            Socket listenSocket = new Socket( AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp );
            int listenPort = Util.BindToFirstPossiblePort( listenSocket, Protocol.MulticastPortNumber ); // Must get this one to receive the multicast messages.
            if ( listenPort == -1 )
            {
                MessageBox.Show( "Failed to bind the multicast listener.\nAnother instance of LANdrop might be running.", "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                Environment.Exit( -1 );
            }
            else if ( listenPort != Protocol.MulticastPortNumber )
                MessageBox.Show( "The multicast listener was unable to bind to port " + Protocol.MulticastPortNumber + " (instead, it got " + listenPort + ")." +
                    "\n\nLANdrop will still work, but you won't probably won't see any clients to connect to.", "Startup Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
            
            Trace.WriteLine( "Multicast listener bound to port " + listenPort + "." );
            listenSocket.SetSocketOption( SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption( multicastAddress, IPAddress.Any ) );

            // Perpetually listen for announcements.
            while ( connected )
            {
                byte[] bytes = new byte[1024];
                listenSocket.Receive( bytes ); // Halt here until a packet is received.

                BinaryReader message = new BinaryReader( new MemoryStream( bytes ) );

                if ( message.ReadInt32( ) == Protocol.ProtocolVersion ) // Can only peer with the same version of LANdrop.
                {
                    // Parse in the peer, and add it to the list (or update an existing one).
                    ProcessPeer( new Peer
                    {
                        Name = message.ReadString( ) + " on " + message.ReadString( ),
                        Address = new IPEndPoint( IPAddress.Parse( message.ReadString( ) ), Protocol.TransferPortNumber ),
                        LastSeen = DateTime.Now
                    }, message.ReadBoolean( ) );
                }

                // Update the UI.
                form.UpdatePeerList( );
            }
        }

        /// <summary>
        /// Adds the peer to the list if it is new (or updates the existing one).
        /// </summary>
        private static void ProcessPeer( Peer newPeer, bool connected )
        {
            // If this peer is saying goodbye, simply remove it.
            if ( !connected )
            {
                Debug.WriteLine( newPeer + " disconnected (goodbye)." );
                discoveredPeers.Remove( newPeer );
                return;
            }

            foreach ( Peer p in discoveredPeers )
            {
                if ( p.Equals( newPeer ) )
                {
                    p.UpdateLastSeen( );
                    return;
                }
            }

            discoveredPeers.Add( newPeer );
        }

        private static void RemoveOldPeers( )
        {
            discoveredPeers.RemoveAll( ( Peer p ) =>
            {
                return ( DateTime.Now.Subtract( p.LastSeen ).Seconds > 10 );
            } );
        }        
    }
}
