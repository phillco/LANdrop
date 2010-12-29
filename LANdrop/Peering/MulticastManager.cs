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

        private static IPAddress multicastAddress = IPAddress.Parse( "224.5.6.7" );

        private static MainForm form;

        public static void Init( MainForm mainForm )
        {
            form = mainForm;
            Peers = new List<Peer>( );
            new Thread( new ThreadStart( SendToGroup ) ).Start( );
            new Thread( new ThreadStart( JoinGroup ) ).Start( );
        }

        public static void SendToGroup( )
        {
            Socket s = new Socket( AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp );
            s.SetSocketOption( SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption( multicastAddress ) );
            s.SetSocketOption( SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, 2 );
            IPEndPoint ipep = new IPEndPoint( multicastAddress, 4567 );
            s.Connect( ipep );

            while ( true )
            {
                BinaryWriter message = new BinaryWriter( new MemoryStream( ) );

                message.Write( Environment.UserName );
                message.Write( Dns.GetHostName( ) );
                message.Write( getLocalAddress( ).ToString( ) );

                byte[] array = ( (MemoryStream) message.BaseStream ).ToArray( );
                s.Send( array, array.Length, SocketFlags.None );

                Thread.Sleep( 1000 );
            }

            s.Close( );
        }

        public static void JoinGroup( )
        {
            Socket s = new Socket( AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp );
            IPEndPoint ipep = new IPEndPoint( IPAddress.Any, 4567 );
            s.Bind( ipep );

            s.SetSocketOption( SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption( multicastAddress, IPAddress.Any ) );

            while ( true )
            {
                byte[] b = new byte[1024];
                s.Receive( b );

                BinaryReader message = new BinaryReader( new MemoryStream( b ) );

                processPeer( new Peer
                {
                    Name = message.ReadString( ) + " on " + message.ReadString( ),
                    Address = new IPEndPoint( IPAddress.Parse( message.ReadString( ) ), Protocol.PORT_NUMBER ),
                    LastSeen = DateTime.Now
                } );

                form.UpdatePeerList( );
            }
        }

        private static void processPeer( Peer newPeer )
        {
            foreach ( Peer p in Peers )
            {
                if ( p.Equals( newPeer ) )
                {
                    p.See( );
                    return;
                }
            }

            Peers.Add( newPeer );
        }

        private static IPAddress getLocalAddress( )
        {
            return Dns.GetHostByName( Dns.GetHostName( ) ).AddressList[0];
        }
    }
}
