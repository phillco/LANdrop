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
using System.Text.RegularExpressions;
using LANdrop.Updates;

namespace LANdrop
{
    static class Program
    {
        // Convert command line arguments to a list.
        public static readonly List<String> CommandLineArgs = new List<string>( Environment.GetCommandLineArgs( ) );

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main( )
        {
            try
            {
                // Set up crucial modules.
                Application.EnableVisualStyles( );
                Application.SetCompatibleTextRenderingDefault( false );
                SetupLog( );
                ErrorHandler.Initialize( );

                // See if we're applying an update. (and if so, quit if needed).
                if ( UpdateApplier.Run() )
                    return;

                // Finish initialization.
                Configuration.Initialize( );
                UpdateChecker.Initialize( );
                MainForm mainForm = new MainForm( );
                Server.Start( );

                // Run the application, starting on the main form.                
                Application.Run( mainForm );
                Shutdown( );

            }
            catch ( Exception ex ) // Just in case.
            {
                ErrorHandler.HandleUncaughtException( ex, true );
            }
        }

        /// <summary>
        /// Nicely terminates the application.
        /// </summary>
        public static void Shutdown( )
        {
            MulticastManager.Disconnect( );
            WebServer.Stop( );
            Trace.Flush( );
            Environment.Exit( 0 ); // Kill all remaining threads.
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
