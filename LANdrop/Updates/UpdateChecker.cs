using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace LANdrop.Updates
{
    /// <summary>
    /// Polls landrop.net every so often to check for updates.
    /// </summary>
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
            READY_TO_APPLY,
            ERROR
        }

        /// <summary>
        /// The current update channel we're using.
        /// </summary>
        public static Channel CurrentChannel
        {
            get { return BuildInfo.DoesUpdate ? Channel.DEV : Channel.NONE; }
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
                if ( oldState != value && StateChanged != null )
                    StateChanged( oldState, _state );
            }
        }

        public static event StateChangeHandler StateChanged;

        public delegate void StateChangeHandler( State oldState, State newState );

        // Thread which runs the update logic.
        private static Thread updateThread = new Thread( UpdateLogic );

        private static State _state = State.CHECKING;

        /// <summary>
        /// Starts up the update engine, which checks for updates and downloads them in the background.
        /// Use UpdateChecker.CurrentState and StateChanged to get the current status.
        /// </summary>
        public static void Initialize( )
        {
            if ( BuildInfo.DoesUpdate )
            {
                updateThread.Priority = ThreadPriority.BelowNormal;
                updateThread.Start( );
            }
        }

        /// <summary>
        /// Tells the update checker to immediately check for updates.
        /// </summary>
        public static void CheckNowAsync( )
        {
            if ( CurrentState == State.SLEEPING && BuildDownloader.CanRefreshServer )
                updateThread.Interrupt( );
        }

        /// <summary>
        /// The engine's loop.
        /// </summary>
        private static void UpdateLogic( )
        {
            while ( true )
            {
                // By default, we check for updates every 15 minutes.
                int secondsToSleep = 15 * 60;                

                // Check landrop.net to see if an update is available.
                CurrentState = State.CHECKING;
                if ( BuildDownloader.IsNewerBuildAvailable( CurrentChannel ) )
                {
                    // Download the update to /Update.
                    CurrentState = State.DOWNLOADING;
                    if ( BuildDownloader.DownloadLatestVersion( CurrentChannel ) )
                    {
                        CurrentState = State.READY_TO_APPLY;
                        return;
                    }
                    else
                    {
                        // Failed to download the latest; retry in 30 seconds.
                        CurrentState = State.ERROR;
                        secondsToSleep = 30;
                    }
                }
                else
                    CurrentState = State.SLEEPING;

                // Wait to refresh again.
                try
                {
                    Thread.Sleep( secondsToSleep * 1000 );
                }
                catch ( ThreadInterruptedException ) { } // Called whenever we refresh manually, so just continue.
            }
        }
    }
}
