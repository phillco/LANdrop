using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LANdrop.Networking;

namespace LANdrop.UI.TransferForms
{
    public partial class TransferNotificationForm : NotificationForm
    {
        private Transfer transfer;

        private ProgressPane progressPane;

        /// <summary>
        /// Creates the notification form for the given transfer on the UI thread.
        /// </summary>
        public static void CreateForTransfer( Transfer transfer )
        {
            MainForm.Instance.BeginInvoke( (MethodInvoker) delegate { new TransferNotificationForm( transfer ); } );            
        }

        public TransferNotificationForm( Transfer transfer )
        {            
            InitializeComponent( );
            this.transfer = transfer;

            if ( Util.IsIncoming( transfer ))
                ChangeContent( new AcceptOrDenyPane( (IncomingTransfer) transfer ) );
            else
                ChangeContent( new WaitingForAcceptPane( (OutgoingTransfer) transfer ) );

            transfer.StateChanged += new Transfer.StateChangeHandler( transfer_StateChanged );
            Show( );
        }

        void transfer_StateChanged( Transfer.State oldState, Transfer.State newState )
        {
            // If this method was called by a different thread, invoke it to run on the form thread.
            if ( InvokeRequired )
            {
                BeginInvoke( new MethodInvoker( delegate { transfer_StateChanged( oldState, newState ); } ) );
                return;
            }

            switch ( newState )
            {
                case Transfer.State.TRANSFERRING:
                    progressPane = new ProgressPane( transfer );
                    ChangeContent( progressPane );
                    break;
                case Transfer.State.VERIFYING:
                    if ( progressPane != null )
                        progressPane.SetVerifying( );
                    break;
                case Transfer.State.FAILED:
                    ChangeContent( new TransferFailedPane( transfer ) );
                    break;
                case Transfer.State.FINISHED:
                    ChangeContent( new TransferCompletePane( transfer ) );
                    break;
            }
        }
    }
}
