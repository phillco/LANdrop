﻿using System;
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
    /// The brains of the operation. Periodically checks landrop.net for updates, downloads them, and signals the rest of the application that they're ready.
    /// Use UpdateChecker.CurrentState and StateChanged to get the current status, and CheckNowAsync to force a refresh.
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
            DOWNLOADING, // Downloading latest builds
            READY_TO_APPLY, // Updates will be applied when we restart
            ERROR // Error during download
        }

        /// <summary>
        /// The current update channel we're using.
        /// </summary>
        public static Channel CurrentChannel
        {
            get { return BuildInfo.DoesUpdate ? Configuration.CurrentSettings.UpdateChannel : Channel.None; }
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

        private static State _state = State.SLEEPING;

        /// <summary>
        /// Called whenever we change state. (see State)
        /// </summary>
        public static event StateChangeHandler StateChanged;

        public delegate void StateChangeHandler( State oldState, State newState );

        /// <summary>
        /// Thread which runs the update logic.
        /// </summary>
        private static Thread updateThread = new Thread( UpdateLogic );

        /// <summary>
        /// Starts up the update thread in the background.
        /// </summary>
        public static void Initialize( )
        {
            if ( BuildInfo.DoesUpdate )
            {
                updateThread.IsBackground = true;
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
        /// Deletes all downloaded builds and resets the current state.
        /// </summary>
        public static void Reset( )
        {
            BuildDownloader.RemoveDownloadedBuilds( );
            CurrentState = State.SLEEPING;
            CheckNowAsync( );
        }

        /// <summary>
        /// The update engine's main loop.
        /// </summary>
        private static void UpdateLogic( )
        {
            Configuration.Changed += ( oldSettings ) =>
            {
                if ( !Configuration.CurrentSettings.UpdateAutomatically || ( Configuration.CurrentSettings.UpdateChannel != oldSettings.UpdateChannel ) )
                    Reset( );
                else
                    CheckNowAsync( );
            };

            while ( true )
            {
                // By default, we check for updates every 15 minutes.
                int secondsToSleep = 15;

                if ( Configuration.CurrentSettings.UpdateAutomatically )
                {
                    // Check landrop.net to see if an update is available.
                    CurrentState = State.CHECKING;
                    if ( BuildDownloader.IsNewerBuildAvailable( CurrentChannel ) )
                    {
                        // Download the update to /Update.
                        CurrentState = State.DOWNLOADING;
                        if ( BuildDownloader.DownloadLatestVersion( CurrentChannel ) )
                            CurrentState = State.READY_TO_APPLY;
                        else
                        {
                            // Failed to download the latest; retry in 30 seconds.
                            CurrentState = State.ERROR;
                            secondsToSleep = 30;
                        }
                    }
                    else
                        CurrentState = BuildDownloader.IsUpdateDownloaded() ? State.READY_TO_APPLY : State.SLEEPING;
                }

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
