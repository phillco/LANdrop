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
    public partial class AcceptOrDenyPane : UserControl
    {
        // The notification form that this lives in.
        public NotificationForm ParentNotification { get; private set; }

        private IncomingTransfer transfer;

        private int secondsToReject = 15;

        public AcceptOrDenyPane( IncomingTransfer transfer )
        {
            InitializeComponent( );
            this.transfer = transfer;

            lblTitle.Text = String.Format( "{0} would like to send us {1} ({2})", transfer.Sender.Name, transfer.FileName, Util.FormatFileSize( transfer.FileSize ) );
            lblReject.Text = "Reject (" + secondsToReject + ")";
            Width = lblTitle.Width + lblTitle.Left + 16;        
        }

        private void AcceptOrDenyTransfer_Load( object sender, EventArgs e )
        {
            this.ParentNotification = (NotificationForm) Parent;
        }

        private void Reject( )
        {
            transfer.Reject( );
            ParentNotification.StartClose();
        }

        private void rejectCountdownTimer_Tick( object sender, EventArgs e )
        {
            secondsToReject--;
            lblReject.Text = "Reject (" + secondsToReject + ")";
            if ( secondsToReject == 0 )
                Reject( );
        }

        private void lblAccept_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            transfer.Accept( );
            ParentNotification.StartClose();
        }

        private void lblReject_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            Reject();
        }

    }
}
