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
        /// The different states of the update checker.
        /// </summary>
        public enum State
        {
            SLEEPING, // Just waiting to refresh
            CHECKING, // Querying landrop.net
            DOWNLOADING,
            READY_TO_APPLY
        }

        /// <summary>
        /// The format of version.json, which we get from landrop.net.
        /// </summary>
        public class VersionInfo
        {
            public int BuildNumber;
            public DateTime BuildDate;
        }

        /// <summary>
        /// Which state the update checker is in.
        /// </summary>
        public static State CurrentState
        {
            get
            {
                return _state;
            }

            private set
            {
                State oldState = CurrentState;
                _state = value;

                // Notify any registered UIs about the change.
                if ( StateChanged != null )
                    StateChanged( oldState, _state );
            }
        }

        /// <summary>
        /// The last time we queried the server for updates.
        /// </summary>
        public static DateTime LastCheckTime { get; private set; }

        /// <summary>
        /// The last 
        /// </summary>
        public static VersionInfo ServerVersionInfo { get; private set; }

        public delegate void StateChangeHandler( State oldState, State newState );

        public static event StateChangeHandler StateChanged;

        // Thread which runs the update logic.
        private static Thread updateThread = new Thread( UpdateLogic );

        private static State _state = State.CHECKING;

        public static void Initialize( )
        {
            updateThread.Priority = ThreadPriority.BelowNormal;
            updateThread.Start( );
        }

        public static void CheckNowAsync( )
        {
            if ( CanRefreshServer( ) && CurrentState == State.SLEEPING )
                updateThread.Interrupt( );
        }

        public static bool CanRefreshServer( )
        {
            return ( DateTime.Now.Subtract( LastCheckTime ).TotalSeconds > 3.0 );
        }

        private static void UpdateLogic( )
        {
            while ( true )
            {
                CurrentState = State.SLEEPING;

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
                        CurrentState = State.SLEEPING;
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
                result.BuildDate = DateTime.SpecifyKind( result.BuildDate, DateTimeKind.Utc ).ToLocalTime( ); // Convert the server-side UTC time to local time.
                ServerVersionInfo = result;
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
