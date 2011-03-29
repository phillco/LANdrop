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
    public partial class ProgressPane : UserControl
    {
        // The notification form that this lives in.
        public NotificationForm ParentNotification { get; private set; }

        private IncomingTransfer transfer;

        private int lastRefreshTime = 0;

        public ProgressPane( IncomingTransfer transfer )
        {
            InitializeComponent( );
            this.transfer = transfer;
            transfer.NewBytesTransferred += new Transfer.BytesChangedHandler( transfer_NewBytesTransferred );
            lblTitle.Text = String.Format( "Receiving {0}...", transfer.FileName );
            Width = pbFileProgress.Width + pbFileProgress.Left + 16;
        }

        private void TransferPane_Load( object sender, EventArgs e )
        {
            this.ParentNotification = (NotificationForm) Parent;
        }

        void transfer_NewBytesTransferred( long bytesTransferred )
        {
            // If this method was called by a different thread, invoke it to run on the form thread.
            if ( InvokeRequired )
            {
                BeginInvoke( new MethodInvoker( delegate { transfer_NewBytesTransferred( bytesTransferred ); } ) );
                return;
            }

            // Don't refresh so frequently that the form flickers.
            if ( Environment.TickCount - lastRefreshTime < 50 )
                return;

            int progressPercent = (int) Math.Round( 100.0 * transfer.NumBytesTransferred / transfer.FileSize );
            lblProgress.Text = String.Format( "({0}%) - {1} of {2}", progressPercent,
                                              Util.FormatFileSize( transfer.NumBytesTransferred ),
                                              Util.FormatFileSize( transfer.FileSize ) );
            lblSpeed.Text = Util.FormatFileSize( transfer.GetCurrentSpeed( ) * 1000 ) + "/s";
            pbFileProgress.Value = progressPercent;
            lastRefreshTime = Environment.TickCount;
        }

        private void lblCancel_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            this.ParentNotification.StartClose( );
            // TODO: Cancel the actual transfer
        }
    }
}
