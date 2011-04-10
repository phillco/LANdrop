using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;

namespace LANdrop
{
    class UpdateChecker
    {
        /// <summary>
        /// The different states of the local update checker.
        /// </summary>
        public enum State
        {
            WAITING,
            CHECKING,
            DOWNLOADING,
            READY_TO_APPLY
        }

        /// <summary>
        /// The server's build info for our channel.
        /// </summary>
        public class VersionInfo
        {
            public int BuildNumber;
            public DateTime BuildDate;
        }

        public static State CurrentState { get; private set; }

        public static DateTime LastCheckTime { get; private set; }

        private static Thread updateThread = new Thread( UpdateLogic );

        public static void Initialize( )
        {
            updateThread.Priority = ThreadPriority.BelowNormal;
            updateThread.Start( );
        }

        public static void CheckNowAsync( )
        {
            if ( CanRefreshServer( ) && CurrentState == State.WAITING )
                updateThread.Interrupt( );
        }

        public static bool CanRefreshServer( )
        {
            return ( DateTime.Now.Subtract( LastCheckTime ).TotalSeconds > 5.0 );
        }

        private static void UpdateLogic( )
        {
            while ( true )
            {
                CurrentState = State.WAITING;

                // Is it time to check for updates again?
                if ( CanRefreshServer( ) )
                {
                    if ( IsNewerBuildAvailable( ) )
                    {
                        CurrentState = State.DOWNLOADING;
                        Thread.Sleep( 5000 ); // Simulate download
                        CurrentState = State.READY_TO_APPLY;
                        return;
                    }
                    else
                        CurrentState = State.WAITING;
                }

                try
                {
                    Thread.Sleep( 15 * 1000 );
                }
                catch ( ThreadInterruptedException ) { }
            }
        }

        public static VersionInfo GetServerVersionInfo( )
        {
            if ( !CanRefreshServer( ) )
                return null;

            CurrentState = State.CHECKING;
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

                VersionInfo result = JsonConvert.DeserializeObject<VersionInfo>( ( new StreamReader( response.GetResponseStream( ) ).ReadToEnd( ).Trim( ) ) );
                result.BuildDate = DateTime.SpecifyKind( result.BuildDate, DateTimeKind.Utc ).ToLocalTime( ); // Convert server-side UTC times
                return result;
            }
            catch ( WebException ) { return null; }
        }

        public static bool IsNewerBuildAvailable( )
        {
            // Local developer builds never have updates.
            /* if ( BuildInfo.BUILD_TYPE == BuildInfo.UpdateChannels.NONE )
                 return false;
             else*/
            {
                VersionInfo info = GetServerVersionInfo( );
                if ( info != null )
                    return false;//( info.BuildNumber > BuildInfo.BUILD_NUMBER );
                else
                    return false;
            }
        }

    }
}
