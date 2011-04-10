using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net;
using Newtonsoft.Json;
using System.IO;

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

        public static void Initialize( )
        {
            Thread updateThread = new Thread( UpdateLogic );
            updateThread.Name = "LANdrop updater";
            updateThread.Priority = ThreadPriority.BelowNormal;
            updateThread.Start( );
        }

        private static void UpdateLogic( )
        {
            while ( true )
            {
                CurrentState = State.WAITING;

                // Is it time to check for updates again?
                if ( DateTime.Now.Subtract( LastCheckTime ).TotalSeconds > 60.0 )
                {                    
                    if ( IsNewerBuildAvailable( ) )
                    {                        
                        CurrentState = State.DOWNLOADING;
                        Thread.Sleep( 5000 );
                        CurrentState = State.READY_TO_APPLY;
                        return;
                    }
                    else
                        CurrentState = State.WAITING;
                }             
                
                Thread.Sleep( 1000 ); // TODO: Use proper threading model
            }
        }

        public static VersionInfo GetServerVersionInfo( )
        {
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
                result.BuildDate = DateTime.SpecifyKind( result.BuildDate, DateTimeKind.Utc ).ToLocalTime(); // Convert server-side UTC times
                return result;
            }
            catch ( WebException ) { return null; }
        }

        public static bool IsNewerBuildAvailable( )
        {
            // Local developer builds never have updates.
            if ( BuildInfo.BUILD_TYPE == BuildInfo.UpdateChannels.NONE )
                return false;
            else
            {
                VersionInfo info = GetServerVersionInfo( );
                if ( info != null )
                    return ( info.BuildNumber > BuildInfo.BUILD_NUMBER );
                else
                    return false;
            }            
        }

    }
}
