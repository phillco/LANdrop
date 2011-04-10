using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LANdrop.UI;
using LANdrop.Networking;
using System.Diagnostics;
using System.IO;
using System.Net;
using HybridDSP.Net.HTTP;
using System.Threading;

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
            try
            {
                // Initialization.
                Application.EnableVisualStyles( );
                Application.SetCompatibleTextRenderingDefault( false );
                ErrorHandler.Initialize( );
                Configuration.Initialize( );
                SetupLog( );        
                UpdateChecker.Initialize();

                MainForm mainForm = new MainForm( );
                Server.Start( );

                // Run the application, starting on the main form.                
                Application.Run( mainForm );

                // The user closed the main form; shut it all down.
                MulticastManager.Disconnect( );
                WebServer.Stop( );
                Trace.Flush( );
                Environment.Exit( 0 );
            }
            catch ( Exception ex ) // Just in case.
            {
                ErrorHandler.HandleUncaughtException( ex, true );
            }
        }

        /// <summary>
        /// Creates a logfile in the user's AppData folder.
        /// </summary>
        private static void SetupLog( )
        {
            Trace.Listeners.Add( new TextWriterTraceListener( new FileStream( Util.GetLogFileName( ), FileMode.Create ) ) );
            Trace.AutoFlush = true;
            Trace.WriteLine( "LANdrop started!" );
            Trace.Indent( );
            Trace.WriteLine( "Date: " + DateTime.Now.ToString( "MM/dd/yyyy h:mm:ss tt" ) );
            Trace.WriteLine( "Host: " + Dns.GetHostName( ) );
            Trace.WriteLine( "User: " + Environment.UserName );
            Trace.WriteLine( "Protocol Version: " + Protocol.Version );
            Trace.Unindent( );
        }
    }
}
