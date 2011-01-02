using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LANdrop.Transfers;

namespace LANdrop.UI
{
    public partial class OutgoingTransferForm : Form, ITransferForm
    {
        private OutgoingTransfer transfer;

        public OutgoingTransferForm( OutgoingTransfer transfer )
        {
            InitializeComponent( );

            this.transfer = transfer;
            this.Text = "Sending " + transfer.File.Name + " to " + transfer.Recipient.Name;

            UpdateState( );
            Show( );
        }

        public void UpdateState( )
        {
            switch ( transfer.CurrentState )
            {
                case Transfer.State.WAITING:
                    lblStatus.Text = "Waiting for " + transfer.Recipient.Name + " to accept...";
                    break;
                case Transfer.State.FAILED_CONNECTION:
                    lblStatus.Text = "Failed to connect to " + transfer.Recipient.Name + ".";
                    break;
                case Transfer.State.TRANSFERRING:
                    lblDataStatus.Text = Util.FormatFileSize( transfer.NumBytesTransferred ) + " of " + Util.FormatFileSize( transfer.FileSize ) + " sent";
                    break;
                case Transfer.State.FINISHED:
                    lblStatus.Text = "File sent successfully!";
                    break;
            }

            if ( transfer.IsComplete( ) )
            {
                btnCancel.Text = "Close";
            }

            if ( transfer.CurrentState == Transfer.State.TRANSFERRING )
            {
                groupDetails.Visible = true;
                this.Height = 173;
            }
            else
            {
                groupDetails.Visible = false;
                this.Height = 80;
            }
        }

        private void btnCancel_Click( object sender, EventArgs e )
        {
            Close( );
        }
    }
}
