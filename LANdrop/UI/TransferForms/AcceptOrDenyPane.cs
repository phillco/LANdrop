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
    public partial class AcceptOrDenyPane : NotificationPane
    {     
        private IncomingTransfer transfer;

        public AcceptOrDenyPane( IncomingTransfer transfer )
        {
            InitializeComponent( );
            this.transfer = transfer;
            this.AutoHide = true;

            lblTitle.Text = String.Format( "{0} would like to send us {1} ({2})", transfer.Sender.Name, transfer.FileName, Util.FormatFileSize( transfer.FileSize ) );            
            Width = lblTitle.Width + lblTitle.Left + 16;        
            OnHideTimeChanged(  );
        }

        /// <summary>
        /// Called right when the timer runs out and the form is to be hidden. 
        /// </summary>
        protected override void OnAutoHide( )
        {
            base.OnAutoHide(  );
            transfer.Reject(  );
        }

        /// <summary>
        /// Called whenever the number of seconds until the form is hidden changes. Useful for setting labels, etc.
        /// </summary>
        protected override void OnHideTimeChanged( )
        {
            lblReject.Text = String.Format( "Reject ({0})", secondsToHide );
        }         

        private void lblAccept_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            transfer.Accept( );
        }

        private void lblReject_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            transfer.Reject(  );
            ParentNotification.StartClose(  );
        }

    }
}
