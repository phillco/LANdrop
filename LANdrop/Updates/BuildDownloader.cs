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
    /// </summary>
    public class BuildDownloader
    {
        /// <summary>
        /// The last time we queried the server for updates.
        /// </summary>
        public static DateTime LastCheckTime { get; private set; }

        /// <summary>
        /// The last state of our update channel that was received from the server.
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
        /// Queries the server for the latest build information.
        /// </summary>
        public static ServerVersionInfo GetServerVersionInfo( )
        {
            if ( !CanRefreshServer )
                return null;

            LastCheckTime = DateTime.Now;

            try
            {
                // Create the request.
                WebRequest request = WebRequest.Create( "http://landrop.net/version/dev.json" );
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

        public static bool DownloadLatestVersion( )
        {
            try
            {
                Directory.CreateDirectory( @"LANdrop\Update" );
                string fileName = Path.Combine( @"LANdrop\Update", String.Format( "LANdrop_{0}{1}.exe", LastVersionInfo.Channel, LastVersionInfo.BuildNumber ) );
                string tempFileName = fileName + ".part";

                // Download the file to the "Update" folder.
                new WebClient( ).DownloadFile( "http://landrop.net/downloads/dev/" + LastVersionInfo.BuildNumber + "/LANdrop.exe", tempFileName );

                // Rename it once complete.
                File.Delete( fileName );
                File.Move( tempFileName, fileName );
                return true;
            }
            catch ( WebException ) { return false; }
        }

        public static bool IsNewerBuildAvailable( )
        {
            // Local developer builds never have updates.
            if ( BuildInfo.BUILD_TYPE == Channel.NONE )
                return false;
            else
            {
                ServerVersionInfo info = GetServerVersionInfo( );
                if ( info != null )
                    return ( info.BuildNumber > BuildInfo.BUILD_NUMBER );
                else
                    return false;
            }
        }
    }
}
