using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;

namespace LANdrop.Updates
{
    /// <summary>
    /// Applies newly downloaded versions of LANdrop. This is a three step process:
    ///     1. We're the old version, and we sense a newer build in /Update. Launch it with instructions to upgrade us.
    ///     2. We're the update, running in /Update. Copy us over the old version, then launch it.
    ///     3. We're the updated version. Clean up and run normally.
    /// </summary>
    class UpdateApplier
    {
        /// <summary>
        /// Whether this process has just been updated. Useful for displaying UI cues ("what's new" screen, etc).
        /// </summary>
        public static bool RunningNewVersion { get; private set; }

        /// <summary>
        /// Checks if we're in the middle of an update process, applying the update if needed.
        /// </summary>
        /// <returns>Whether the program should exit after calling this.</returns>
        public static bool Run( )
        {
            if ( !Configuration.Instance.UpdateAutomatically )
                return false;

            // See if we've been updated (show a message).
            if ( Program.CommandLineArgs.Contains( "/completeUpdate" ) )
                RunningNewVersion = true;

            // See if we're the new build in /Update and need to update the old version.
            if ( Program.CommandLineArgs.Contains( "/applyUpdate" ) )
            {
                OverwriteOldVersion( );
                return true;
            }

            // Otherwise, just see if there's a new build to update to.
            if ( CheckForNewVersion( ) )
                return true;

            // Clean up old update files.
            try
            {
                foreach ( var file in new DirectoryInfo( @"LANdrop\Update" ).GetFiles( "LANdrop*.exe" ) )
                    File.Delete( file.FullName );
                Directory.Delete( @"LANdrop\Update", true );
            }
            catch ( IOException ) { }
            return false;
        }

        /// <summary>
        /// Searches for newly downloaded updates to apply.
        /// </summary>
        /// <returns>Whether one was found (and launched)</returns>
        private static bool CheckForNewVersion( )
        {
            try
            {
                foreach ( string path in Directory.GetFiles( @"LANdrop\Update" ) )
                {
                    FileInfo file = new FileInfo( path );

                    // Extract the build info from the update's filename.
                    Match match = new Regex( "LANdrop_([a-zA-z]+)([0-9]+).exe$" ).Match( file.Name );
                    if ( match.Success )
                    {
                        Channel buildChannel = ChannelFunctions.Parse( match.Groups[1].Value );
                        int buildNumber = int.Parse( match.Groups[2].Value );

                        // Skip builds that aren't on the chanel we want to upgrade to.
                        if ( buildChannel != Configuration.Instance.UpdateChannel )
                            continue;

                        // Skip builds that aren't newer than the current build. (Unless they're on a different channel).
                        if ( Configuration.Instance.UpdateChannel == BuildInfo.Version.Channel && buildNumber <= BuildInfo.Version.BuildNumber )
                            continue;

                        using ( Process proc = new Process( ) )
                        {
                            proc.StartInfo.FileName = file.FullName;
                            proc.StartInfo.Arguments = "/applyUpdate";
                            proc.Start( );
                            return true;
                        }
                    }
                }
            }
            catch ( DirectoryNotFoundException ) { }
            return false;
        }

        /// <summary>
        /// Finds the old version that spawned this instance, and updates it.
        /// </summary>
        private static void OverwriteOldVersion( )
        {
            // Find the parent build.
            string parent = Path.Combine( new FileInfo( Application.ExecutablePath ).Directory.Parent.Parent.FullName, "LANdrop.exe" );

            // Copy this file over the old version (wait as necessary for it to exit).
            for ( int i = 0; i < 1500; i++ )
            {
                try
                {
                    File.Copy( Application.ExecutablePath, parent, true );
                    break;
                }
                catch ( IOException ) { Thread.Sleep( 10 ); } // Thrown when the file is in use.
            }

            // Launch it with instructions to clean up.
            using ( Process proc = new Process( ) )
            {
                proc.StartInfo.FileName = parent;
                proc.StartInfo.Arguments = "/completeUpdate";
                proc.Start( );
            }
        }
    }
}
