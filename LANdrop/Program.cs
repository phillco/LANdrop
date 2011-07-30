using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LANdrop.UI;
using LANdrop.Networking;
using System.IO;
using System.Net;
using HybridDSP.Net.HTTP;
using System.Threading;
using System.Text.RegularExpressions;
using LANdrop.Updates;
using log4net.Config;
using LANdrop.Properties;
using System.Reflection;
using System.Text;

namespace LANdrop
{
    static class Program
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger( System.Reflection.MethodBase.GetCurrentMethod( ).DeclaringType );

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
                Configuration.Initialize( );

                // See if we're applying an update. (and if so, quit if needed).
                if ( UpdateApplier.Run( ) )
                    return;

                // Finish initialization.                
                UpdateChecker.Initialize( );
                MainForm mainForm = new MainForm( );
                Server.Start( );

                // Run the application, starting on the main form.                
                Application.Run( mainForm );
                Shutdown( );

            }
            catch ( Exception ex ) // Just in case.
            {
                try
                {
                    ErrorHandler.HandleUncaughtException( ex, true );
                }
                catch ( FileNotFoundException e )
                {
                    if ( e.Message.Contains( "BugzScout" ) ) // Occurs when the BugzScout assembly could not be loaded (the outer exception was probably that the JSON library couldn't be loaded, too).
                        MessageBox.Show( "There was an error loading some of LANdrop's components.\nPlease download a fresh version from www.landrop.net.", "LANdrop", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                }
            }
        }

        /// <summary>
        /// Nicely terminates the application.
        /// </summary>
        public static void Shutdown( )
        {
            Server.Stop( );            
            Environment.Exit( 0 ); // Kill all remaining threads.
        }

        /// <summary>
        /// Creates a logfile in the user's AppData folder.
        /// </summary>
        private static void SetupLog( )
        {
            if ( File.Exists( "LANdrop\\Logging.xml" ) )
                XmlConfigurator.ConfigureAndWatch( new FileInfo( "LANdrop\\Logging.xml" ) );
            else // Read the embedded configuration.
                XmlConfigurator.Configure( new MemoryStream( Encoding.UTF8.GetBytes( Resources.log4net ) ) );

            log.Info( "LANdrop started! v" + Util.GetProgramVersion( ) + " (" + BuildInfo.Version.ToString( ) + ")" );
            log.Info( "Host: " + Dns.GetHostName( ) );
            log.Info( "User: " + Environment.UserName );
            log.Info( "Protocol Version: " + Protocol.Version );
        }
    }
}
