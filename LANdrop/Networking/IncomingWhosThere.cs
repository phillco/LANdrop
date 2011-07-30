using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;
using System.Net;

namespace LANdrop.Networking
{
    class IncomingWhosThere
    {
        private TcpClient client;
        private BinaryReader NetworkInStream;
        private BinaryWriter NetworkOutStream;

        public IncomingWhosThere( TcpClient client, BinaryReader netInStream, BinaryWriter netOutStream )
        {
            this.client = client;
            this.NetworkInStream = netInStream;
            this.NetworkOutStream = netOutStream;

            this.Respond( );
        }

        public void Respond( )
        {
            int port = NetworkInStream.ReadInt32( );
            IPEndPoint address = new IPEndPoint( ( (IPEndPoint) client.Client.RemoteEndPoint ).Address, port );
            Peer existingPeer = PeerList.GetPeerForAddress( address );

            // Send our basic information.
            Trace.WriteLine( String.Format( "\nREPLYING TO a who's there from {0}...", existingPeer == null ? "a new peer at " + address : existingPeer.ToString( ) ) );
            NetworkOutStream.Write( Configuration.CurrentSettings.Username );

            // ...and our peer list, if they want it.
            if ( NetworkInStream.ReadBoolean( ) )
            {
                NetworkOutStream.Write( true ); // Yes, we're sending the list (TODO: we might want to prevent flooding)

                // Only send fresh, active peers.
                List<Peer> peersToSend = PeerList.GetList( true );
                peersToSend.Remove( existingPeer );

                Trace.WriteLine( "Sending " + peersToSend.Count + " peers as part of the peer exchange...." );

                NetworkOutStream.Write( (Int32) peersToSend.Count );
                foreach ( Peer p in peersToSend )
                {
                    p.ToStream( NetworkOutStream );
                    Trace.WriteLine( "\tSent " + p );
                }
            }

            // If this is a brand new peer to us, immediately look them up, too.
            if ( existingPeer == null )
            {
                Trace.WriteLine( "\nUser is unknown, so we'll look them up too." );
                new OutgoingWhosThere( new Peer { EndPoint = address } );
            }
        }
    }
}
