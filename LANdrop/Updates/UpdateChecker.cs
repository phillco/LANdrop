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
        /// 
        /// </summary>
        public static void Initialize( )
        {
            if ( BuildInfo.DoesUpdate )
            {
                updateThread.Priority = ThreadPriority.BelowNormal;
                updateThread.Start( );
            }
        }

        public static void CheckNowAsync( )
        {
            if ( CurrentState == State.SLEEPING && BuildDownloader.CanRefreshServer )
                updateThread.Interrupt( );
        }

        private static void UpdateLogic( )
        {
            while ( true )
            {
                int secondsToSleep = 15;

                CurrentState = State.CHECKING;
                if ( BuildDownloader.IsNewerBuildAvailable( CurrentChannel ) )
                {
                    CurrentState = State.DOWNLOADING;
                    if ( BuildDownloader.DownloadLatestVersion( CurrentChannel ) )
                    {
                        CurrentState = State.READY_TO_APPLY;
                        return;
                    }
                    else
                    {
                        CurrentState = State.ERROR;
                        secondsToSleep = 3;
                    }
                }
                else
                    CurrentState = State.SLEEPING;

                try
                {
                    Thread.Sleep( secondsToSleep * 1000 );
                }
                catch ( ThreadInterruptedException ) { }
            }
        }
    }
}
