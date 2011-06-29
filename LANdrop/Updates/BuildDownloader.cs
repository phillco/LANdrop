using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace LANdrop.Updates
{
    /// <summary>
    /// Downloads builds and version info from LANdrop.net.
    /// Note: all methods are synchronous and will block until the download is complete.
    /// </summary>
    public class BuildDownloader
    {
        /// <summary>
        /// The web server that we download update information from.
        /// </summary>
        public const string ServerAddress = "http://landrop.net";

        /// <summary>
        /// The last time we queried the server for updates.
        /// </summary>
        public static DateTime LastCheckTime { get; private set; }

        /// <summary>
        /// The last version information we received from the server.
        /// </summary>
        public static Dictionary<Channel, VersionInfo> LastVersionInfo { get; private set; }

        public static Dictionary<Channel, VersionInfo> LastDownloadedBuild { get; private set; }

        static BuildDownloader( )
        {
            LastVersionInfo = new Dictionary<Channel, VersionInfo>( );
            LastDownloadedBuild = new Dictionary<Channel, VersionInfo>( );
        }

        /// <summary>
        /// Returns whether it's safe to re-check the server for updates.
        /// (Just imposing basic flood control; obviously it won't stop anything serious).
        /// </summary>
        public static bool CanRefreshServer
        {
            get { return ( DateTime.Now.Subtract( LastCheckTime ).TotalSeconds > 3.0 ); }
        }

        /// <summary>
        /// Queries the server for the latest build information for the given channel.
        /// </summary>
        public static VersionInfo GetServerVersionInfo( Channel channel )
        {
            // Return the cached copy of 
            if ( !CanRefreshServer )
                return LastVersionInfo[channel];

            LastCheckTime = DateTime.Now;

            try
            {
                // Create the request.
                WebRequest request = WebRequest.Create( ServerAddress + "/version/" + ChannelFunctions.ToUrlPart( channel ) + ".json" );
                request.Timeout = 10000;
                request.Proxy = null;

                // ...and submit it!
                WebResponse response = request.GetResponse( );
                if ( response == null )
                    return null;

                VersionInfo result = JsonConvert.DeserializeObject<VersionInfo>( ( new StreamReader( response.GetResponseStream( ) ).ReadToEnd( ).Trim( ) ) );
                result.BuildDate = DateTime.SpecifyKind( result.BuildDate, DateTimeKind.Utc ).ToLocalTime( ); // Convert the server-side UTC time to local time.
                LastVersionInfo[channel] = result;
                return result;
            }
            catch ( WebException ) { return null; }
        }

        /// <summary>
        /// Downloads the latest build for the given channel into the "/Update" folder.
        /// </summary>
        public static bool DownloadLatestVersion( Channel channel )
        {
            try
            {
                Directory.CreateDirectory( @"LANdrop\Update" );
                string fileName = Path.Combine( @"LANdrop\Update", String.Format( "LANdrop_{0}{1}.exe", ChannelFunctions.ToUrlPart( LastVersionInfo[channel].Channel ), LastVersionInfo[channel].BuildNumber ) );
                string tempFileName = fileName + ".part";

                // Download the file.
                new WebClient( ).DownloadFile( ServerAddress + "/downloads/" + channel.ToString( ).ToLower( ) + "/" + LastVersionInfo[channel].BuildNumber + "/LANdrop.exe", tempFileName );

                // Success! Remove other updates and the .part suffix.
                foreach ( var file in new DirectoryInfo( @"LANdrop\Update" ).GetFiles( "LANdrop_" + ChannelFunctions.ToUrlPart( channel ) + "*.exe" ) )
                    File.Delete( file.FullName );

                File.Move( tempFileName, fileName );
                LastDownloadedBuild[channel] = LastVersionInfo[channel];
                return true;
            }
            catch ( WebException ) { return false; }
        }

        /// <summary>
        /// Checks if there's a newer version on the server in the given channel.
        /// </summary>
        public static bool IsNewerBuildAvailable( Channel channel )
        {
            // Download the latest channel information from the server.
            VersionInfo latest = GetServerVersionInfo( channel );

            if ( latest == null )
                return false;

            // Check if this build has already been downloaded...
            else if ( LastDownloadedBuild.ContainsKey( channel ) && LastDownloadedBuild[channel].BuildNumber >= latest.BuildNumber )
                return false;

            // Or isn't newer than the current build... 
            else if ( channel == BuildInfo.Version.Channel && BuildInfo.Version.BuildNumber >= latest.BuildNumber )
                return false;

            // Otherwise, it's an update!
            return true;
        }

        public static bool IsUpdateDownloaded( )
        {
            return ( LastDownloadedBuild.ContainsKey( Configuration.Instance.UpdateChannel ) && ( Configuration.Instance.UpdateChannel != BuildInfo.Version.Channel
                || LastDownloadedBuild[Configuration.Instance.UpdateChannel].BuildNumber > BuildInfo.Version.BuildNumber ) );
        }


        /// <summary>
        /// Deletes all downloaded updates.
        /// </summary>
        public static void RemoveDownloadedBuilds( )
        {
            LastDownloadedBuild.Clear( );

            try
            {
                foreach ( var file in new DirectoryInfo( @"LANdrop\Update" ).GetFiles( "LANdrop*.exe" ) )
                    File.Delete( file.FullName );
                Directory.Delete( @"LANdrop\Update", true );
            }
            catch ( IOException ) { }
            catch ( UnauthorizedAccessException ) { }
        }
    }
}
