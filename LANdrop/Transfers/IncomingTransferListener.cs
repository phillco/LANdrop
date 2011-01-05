using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.IO;
using LANdrop.Peering;
using System.Windows.Forms;
using System.Diagnostics;

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
            for ( int port = Protocol.TransferPortNumber; port < Protocol.TransferPortNumber + 100; port++ )
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
                new IncomingTransfer( client ); // Create the transfer.
            }
        }       
    }
}
