using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using Newtonsoft.Json;

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
        public static ServerVersionInfo LastVersionInfo { get; private set; }

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
        public static ServerVersionInfo GetServerVersionInfo( Channel channel )
        {
            // Return the cached copy of 
            if ( !CanRefreshServer )
                return LastVersionInfo;

            LastCheckTime = DateTime.Now;

            try
            {
                // Create the request.
                WebRequest request = WebRequest.Create( ServerAddress + "/version/" + channel.ToString().ToLower() + ".json" );
                request.Timeout = 10000;
                request.Proxy = null;

                // ...and submit it!
                WebResponse response = request.GetResponse( );
                if ( response == null )
                    return null;

                ServerVersionInfo result = JsonConvert.DeserializeObject<ServerVersionInfo>( ( new StreamReader( response.GetResponseStream( ) ).ReadToEnd( ).Trim( ) ) );
                result.BuildDate = DateTime.SpecifyKind( result.BuildDate, DateTimeKind.Utc ).ToLocalTime( ); // Convert the server-side UTC time to local time.
                LastVersionInfo = result;
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
                string fileName = Path.Combine( @"LANdrop\Update", String.Format( "LANdrop_{0}{1}.exe", LastVersionInfo.Channel, LastVersionInfo.BuildNumber ) );
                string tempFileName = fileName + ".part";

                // Download the file.
                new WebClient( ).DownloadFile( ServerAddress + "/downloads/" + channel.ToString().ToLower() + "/" + LastVersionInfo.BuildNumber + "/LANdrop.exe", tempFileName );

                // Rename it (to remove the .part suffix) once complete.
                File.Delete( fileName );
                File.Move( tempFileName, fileName );
                return true;
            }
            catch ( WebException ) { return false; }
        }

        /// <summary>
        /// Checks if there's a newer version on the server in the given channel.
        /// </summary>
        public static bool IsNewerBuildAvailable( Channel channel )
        {
            if ( !BuildInfo.DoesUpdate ) // Some builds (in-development builds) never update.
                return false;
            else if ( channel != BuildInfo.BuildChannel ) // If we're switching channels, the new version is always an "update".
                return true;
            else
            {
                ServerVersionInfo latest = GetServerVersionInfo( channel );
                if ( latest != null )
                    return ( latest.BuildNumber > BuildInfo.BuildNumber );
                else
                    return false;
            }
        }
    }
}
