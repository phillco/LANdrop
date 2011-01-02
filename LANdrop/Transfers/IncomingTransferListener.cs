﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.IO;
using LANdrop.Peering;

namespace LANdrop.Transfers
{
    /// <summary>
    /// Perpetually listens for new incoming transfers, then defers them to the UI.
    /// </summary>
    class IncomingTransferListener
    {
        public static int Port { get; private set; }

        private static TcpListener listener;

        public static void Start( )
        {
            new Thread( new ThreadStart( ListenForClients ) ).Start( );
        }

        public static void ListenForClients( )
        {
            bool secondInstance = false;

            for ( int port = Protocol.TransferPortNumber; port < Protocol.TransferPortNumber + 100; port++ )
            {
                try
                {
                    listener = new TcpListener( IPAddress.Any, port );
                    listener.Start( );
                    break;
                }
                catch ( SocketException ) { secondInstance = true; }
            }

            if ( secondInstance )
                StartDummyTransfer( );

            while ( true )
            {
                TcpClient client = listener.AcceptTcpClient( ); // Halt until a client connects.
                new IncomingTransfer( client ); // Create the transfer.
            }
        }

        private static void StartDummyTransfer( )
        {
            new OutgoingTransfer( new FileInfo( "GitExtensions208.msi" ), new Peer
            {
                Name = "First Client",
                Address = new IPEndPoint( IPAddress.Parse( "127.0.0.1" ), Protocol.TransferPortNumber )
            } );
        }
    }
}
