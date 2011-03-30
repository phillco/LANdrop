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
    public partial class TransferFailedPane : NotificationPane
    {
        private Transfer transfer;

        public TransferFailedPane( Transfer transfer )
        {
            InitializeComponent( );
            this.transfer = transfer;
            this.AutoHide = true;
            secondsToHide = 8;
            lblTitle.Text = String.Format( "Failed to {0} {1}", Util.IsIncoming( transfer ) ? "receive" : "sending", transfer.FileName );
            Width = lblTitle.Width + lblTitle.Left + 16;
            OnHideTimeChanged( );
        }

        protected override void OnHideTimeChanged( )
        {
            lblHide.Text = String.Format( "Hide ({0})", secondsToHide );
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
