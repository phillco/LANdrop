using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using LANdrop.UI;
using System.Net.Sockets;
using LANdrop.UI.TransferForms;

namespace LANdrop.Networking
{
    public abstract class Transfer
    {
        public State CurrentState { get; private set; }

        public string FileName { get; protected set; }

        public string Partner { get; protected set; }

        public long NumBytesTransferred { get; private set; }

        public long FileSize { get; protected set; }

        public int StartTime { get; protected set; }

        public int StopTime { get; protected set; }

        protected TcpClient TcpClient { get; set; }

        protected BinaryReader NetworkInStream { get; set; }

        protected BinaryWriter NetworkOutStream { get; set; }

        protected TransferForm Form { get; set; }

        protected int LastRefreshTime = 0;

        protected ProgressPane progressPane;

        public enum State { WAITING, FAILED_CONNECTION, REJECTED, TRANSFERRING, VERIFYING, FINISHED, FAILED }

        public Transfer( )
        {
            this.CurrentState = State.WAITING;
            this.NumBytesTransferred = this.FileSize = 0;
        }

        protected void DoTransfer( )
        {
            try
            {
                Connect( );
            }
            catch ( IOException ex )
            {
                SetState( State.FAILED );
                return;
            }
        }

        protected abstract void Connect( );

        protected void SetupStreams( Stream dataStream )
        {
            NetworkInStream = new BinaryReader( dataStream );
            NetworkOutStream = new BinaryWriter( dataStream );
        }

        protected void SetState( State newState )
        {
            this.CurrentState = newState;
            if ( Form != null )
                Form.UpdateState( );

            // Start the clock.
            if ( newState == State.TRANSFERRING )
                StartTime = Environment.TickCount;
            else if ( newState == State.VERIFYING )
                StopTime = Environment.TickCount;
        }
       
        /// <summary>
        /// Returns the current speed of the transfer, in bytes/millisecond.
        /// </summary>
        public double GetCurrentSpeed( )
        {
            int endTime = ( CurrentState == State.TRANSFERRING ? Environment.TickCount : StopTime );
            if ( StartTime == endTime )
                return 0;
            return ( NumBytesTransferred / ( endTime - StartTime ));
        }

        protected void UpdateNumBytesTransferred( long bytesTransferred )
        {
            this.NumBytesTransferred = bytesTransferred;

            if ( Environment.TickCount - LastRefreshTime > 100 )
            {
                Form.UpdateState( );
                if ( progressPane != null )
                    progressPane.UpdateState();
                LastRefreshTime = Environment.TickCount;
            }
        }

        public bool IsComplete( )
        {
            switch ( CurrentState )
            {
                case State.FAILED_CONNECTION:
                case State.REJECTED:
                case State.FAILED:
                case State.FINISHED:
                    return true;
                default:
                    return false;
            }
        }
    }
}
