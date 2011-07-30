using System;
using System.Collections.Generic;
using System.Text;
using FogCreek;
using LANdrop.UI;
using System.Windows.Forms;
using System.Threading;

namespace LANdrop
{
    /// <summary>
    /// Catches the program's uncaught exceptions, shows a nice dialog, and reports them.
    /// </summary>
    class ErrorHandler
    {
        public const string DEFAULT_BUGZSCOUT_MESSAGE = "Thanks - the report was sent successfully.";

        /// <summary>
        /// Reroutes all application exceptions to this error handler. Be sure Main() is wrapped in a try/catch block too.
        /// </summary>
        public static void Initialize( )
        {
            Application.SetUnhandledExceptionMode( UnhandledExceptionMode.CatchException );

            // UI thread exceptions (non fatal).
            Application.ThreadException += ( sender, e ) => HandleUncaughtException( e.Exception, false );

            // Other thread exceptions (fatal).
            AppDomain.CurrentDomain.UnhandledException += ( sender, e ) => HandleUncaughtException( (Exception) e.ExceptionObject, true );            
        }      
        
        /// <summary>
        /// Creates an error report and shows the error dialog for the given exception.
        /// </summary>
        /// <param name="fatal">Can the program execution continue after this exception?</param>
        public static void HandleUncaughtException( Exception e, bool fatal )
        {            
            new ErrorForm( e, CreateReportForException(e, fatal), fatal ).ShowDialog( );
        }

        /// <summary>
        /// Creates an error report for the given exception, suitable for sending to FogBugz.
        /// </summary>
        /// <param name="fatal">Can the program execution continue after this exception?</param>
        public static BugReport CreateReportForException( Exception e, bool fatal )
        {
            // Create an error report.            
            BugReport report = new BugReport
            {
                FogBugzUrl = "https://phillco.fogbugz.com/ScoutSubmit.asp",
                UserName = "Exception Reporter",
                Project = "LANdrop",
                Area = "Crash Reports",
                DefaultMessage = DEFAULT_BUGZSCOUT_MESSAGE,
            };

            if ( fatal )
                report.Description += "\n*** FATAL ERROR ***\n";

            report.AddMachineDetails( "\nDiscovered by" );
            report.AddExceptionDetails( e );
            report.Description += "Application version: " + Util.GetProgramVersion( ) + Environment.NewLine;
            report.Description += "OS: " + Util.GetWindowsVersion( ) + Environment.NewLine;
            return report;
        }
    }
}
