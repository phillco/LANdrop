using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using LANdrop.Transfers;
using LANdrop.UI;

namespace LANdrop.Peering
{
    /// <summary>
    /// Handles the broadcasting and listening for LANdrop multicast messages.
    /// These messages allows LANdrop clients to self-announce, without entering each others' IP addresses.
    /// </summary>
    class MulticastManager
    {
        public static List<Peer> Peers { get; private set; }

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
            Peers = new List<Peer>( );
            new Thread( new ThreadStart( SendLoop ) ).Start( );
            new Thread( new ThreadStart( ListenLoop ) ).Start( );
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
            if ( Util.BindToFirstPossiblePort( socket, Protocol.MulticastPortNumber ) == -1 )
            {
                MessageBox.Show( "Failed to bind the multicast sender.\nAnother instance of LANdrop might be running.", "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                Environment.Exit( -1 );
            }
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
            message.Write( GetLocalAddress( ).ToString( ) );
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
            if ( Util.BindToFirstPossiblePort( listenSocket, Protocol.MulticastPortNumber ) == -1 )
            {
                MessageBox.Show( "Failed to bind the multicast listener.\nAnother instance of LANdrop might be running.", "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                Environment.Exit( -1 );
            }
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
                Peers.Remove( newPeer );
                return;
            }

            foreach ( Peer p in Peers )
            {
                if ( p.Equals( newPeer ) )
                {
                    p.UpdateLastSeen( );
                    return;
                }
            }

            Peers.Add( newPeer );
        }

        private static void RemoveOldPeers( )
        {
            Peers.RemoveAll( ( Peer p ) =>
            {
                return ( DateTime.Now.Subtract( p.LastSeen ).Seconds > 10 );
            } );
        }

        /// <summary>
        /// Returns the computer's IP list.
        /// TODO: This is a depreciated and overly simplistic method (computers can have multiple IPs).
        /// </summary>
        private static IPAddress GetLocalAddress( )
        {
            return Dns.GetHostByName( Dns.GetHostName( ) ).AddressList[0];
        }
    }
}
