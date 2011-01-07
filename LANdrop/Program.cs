using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LANdrop.UI;
using LANdrop.Networking;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace LANdrop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main( )
        {
            Application.EnableVisualStyles( );
            Application.SetCompatibleTextRenderingDefault( false );

            // Start the log.                        
            Trace.Listeners.Add( new TextWriterTraceListener( new FileStream( Util.GetLogFileName( ), FileMode.Create ) ) );
            Trace.AutoFlush = true;
            Trace.WriteLine( "LANdrop started!" );
            Trace.Indent( );
            Trace.WriteLine( "Date: " + DateTime.Now.ToString( "MM/dd/yyyy h:mm:ss tt" ) );
            Trace.WriteLine( "Host: " + Dns.GetHostName( ) );
            Trace.WriteLine( "User: " + Environment.UserName );
            Trace.WriteLine( "Protocol Version: " + Protocol.ProtocolVersion );
            Trace.Unindent( );

            MainForm mainForm = new MainForm( );

            MulticastManager.Init( mainForm );
            IncomingTransferListener.Start( );

            Application.Run( mainForm );
            Trace.Flush( );
            MulticastManager.Disconnect( );
            Environment.Exit( 0 );
        }
    }
}
