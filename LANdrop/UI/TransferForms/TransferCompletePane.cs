using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LANdrop.Networking;

namespace LANdrop.UI.TransferForms
{
    /// <summary>
    /// Shown when somebody wants to send us a file; shows links to accept or reject it.
    /// </summary>
    public partial class TransferCompletePane : UserControl
    {
        // The notification form that this lives in.
        public NotificationForm ParentNotification { get; private set; }

        private IncomingTransfer transfer;

        private int secondsToReject = 15;

        public TransferCompletePane( IncomingTransfer transfer )
        {
            InitializeComponent( );
            this.transfer = transfer;

            lblTitle.Text = String.Format( "{0} received successfully!", transfer.FileName );
            lblHide.Text = "Hide (" + secondsToReject + ")";
            Width = lblTitle.Width + lblTitle.Left + 16;
        }

        private void TransferCompletePane_Load( object sender, EventArgs e )
        {
            this.ParentNotification = (NotificationForm) Parent;
        }

        private void rejectCountdownTimer_Tick( object sender, EventArgs e )
        {
            secondsToReject--;
            lblHide.Text = "Hide (" + secondsToReject + ")";
            if ( secondsToReject == 0 )
                ParentNotification.StartClose( );
        }

        private void lblHide_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            ParentNotification.StartClose( );
        }

        private void lblOpenFolder_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {

        }
    }
}
