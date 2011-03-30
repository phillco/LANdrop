using System;
using System.Collections.Generic;
using System.Text;
using FogCreek;
using LANdrop.UI;
using System.Diagnostics;
using System.Windows.Forms;

namespace LANdrop
{
    /// <summary>
    /// Handles any uncaught exceptions the program generates.
    /// </summary>
    class ErrorHandler
    {
        public const string DEFAULT_BUGZSCOUT_MESSAGE = "Thanks - the report was sent successfully.";

        public static void HandleUncaughtException( Exception e, bool fatal )
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
            report.Description += "Application version: " + Util.GetProgramVersion( ) + " (built on " + Util.GetProgramBuildDate( ).ToShortDateString( ) + ")" + Environment.NewLine;
            report.Description += "OS: " + Util.GetWindowsVersion( ) + Environment.NewLine;

            // Show the error form with the report.
            ErrorForm form = new ErrorForm( e, report, fatal );
            form.ShowDialog( );
        }

        public static void RestartApplication( )
        {
            using ( Process proc = new Process( ) )
            {
                proc.StartInfo.FileName = Application.ExecutablePath;
                proc.Start( );
            }
        }
    }
}
