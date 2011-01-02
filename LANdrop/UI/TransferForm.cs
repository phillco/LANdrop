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
    public partial class TransferForm : Form, ITransferForm
    {
        private Transfer transfer;

        private bool incoming;

        public TransferForm( Transfer transfer )
        {
            InitializeComponent( );

            this.transfer = transfer;
            this.incoming = ( typeof( IncomingTransfer ) == transfer.GetType( ) );

            if ( incoming )
                this.Text = "Receiving " + transfer.FileName + " from " + transfer.Partner;
            else
                this.Text = "Sending " + transfer.FileName + " to " + transfer.Partner;

            UpdateState( );
        }

        public void UpdateState( )
        {
            switch ( transfer.CurrentState )
            {
                case Transfer.State.WAITING:
                    lblStatus.Text = "Waiting for " + transfer.Partner + " to accept...";
                    break;
                case Transfer.State.FAILED_CONNECTION:
                    lblStatus.Text = "Failed to connect to " + transfer.Partner + ".";
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
