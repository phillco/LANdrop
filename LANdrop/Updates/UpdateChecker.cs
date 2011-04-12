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
        /// Returns the current channel we update to.
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

        /// <summary>
        /// The last time we queried the server for updates.
        /// </summary>
        public static DateTime LastCheckTime { get; private set; }

        /// <summary>
        /// The last state of our current channel.
        /// </summary>
        public static ServerVersionInfo LastServerInfo { get; private set; }

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
                int secondsToSleep = 15;

                // Is it time to check for updates again?
                if ( CanRefreshServer( ) )
                {
                    if ( IsNewerBuildAvailable( ) )
                    {
                        CurrentState = State.DOWNLOADING;
                        if ( DownloadLatestVersion( ) )
                            return;
                        else
                        {
                            CurrentState = State.ERROR;
                            secondsToSleep = 3;
                        }
                    }
                    else
                        CurrentState = State.SLEEPING;
                }

                try
                {
                    Thread.Sleep( secondsToSleep * 1000 );
                }
                catch ( ThreadInterruptedException ) { }
            }
        }

        public static ServerVersionInfo GetServerVersionInfo( )
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

                ServerVersionInfo result = JsonConvert.DeserializeObject<ServerVersionInfo>( ( new StreamReader( response.GetResponseStream( ) ).ReadToEnd( ).Trim( ) ) );
                result.BuildDate = DateTime.SpecifyKind( result.BuildDate, DateTimeKind.Utc ).ToLocalTime( ); // Convert the server-side UTC time to local time.
                LastServerInfo = result;
                return result;
            }
            catch ( WebException ) { return null; }
        }

        public static bool DownloadLatestVersion( )
        {
            CurrentState = State.DOWNLOADING;

            try
            {
                Directory.CreateDirectory( @"LANdrop\Update" );
                string fileName = Path.Combine( @"LANdrop\Update", String.Format( "LANdrop_{0}{1}.exe", LastServerInfo.Channel, LastServerInfo.BuildNumber ) );
                string tempFileName = fileName + ".part";

                // Download the file to the "Update" folder.
                new WebClient( ).DownloadFile( "http://landrop.net/downloads/dev/" + LastServerInfo.BuildNumber + "/LANdrop.exe", tempFileName );

                // Rename it once complete.
                File.Delete( fileName );
                File.Move( tempFileName, fileName );
                CurrentState = State.READY_TO_APPLY; // We're done here.
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
