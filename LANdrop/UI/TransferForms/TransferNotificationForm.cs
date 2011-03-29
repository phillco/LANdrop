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
        private IncomingTransfer transfer;

        private ProgressPane progressPane;

        /// <summary>
        /// Creates the notification form for the given transfer on the UI thread.
        /// </summary>
        public static void CreateForTransfer( IncomingTransfer transfer )
        {
            MainForm.Instance.BeginInvoke( (MethodInvoker) delegate { new TransferNotificationForm( transfer ); } );
        }

        public TransferNotificationForm( IncomingTransfer transfer )
            : base( new AcceptOrDenyPane( transfer ) )
        {
            this.transfer = transfer;
            InitializeComponent( );
            transfer.notification = this;
            Show( );
        }

        public void ChangeToProgress( )
        {
            progressPane = new ProgressPane( transfer );
            ChangeContent( progressPane );
        }
        public void ChangeToCompleted( )
        {
            ChangeContent( new TransferCompletePane( transfer ) );
        }

        public void UpdateProgress( )
        {
            if ( progressPane != null )
                progressPane.UpdateState( );
        }
    }
}
