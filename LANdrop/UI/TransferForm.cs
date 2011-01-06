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
            Util.UseProperSystemFont( this );

            this.transfer = transfer;
            this.incoming = ( typeof( IncomingTransfer ) == transfer.GetType( ) );

            if ( incoming )
                this.Text = "Receiving " + transfer.FileName;
            else
                this.Text = "Sending " + transfer.FileName + " to " + transfer.Partner;

            UpdateState( );

            // Show the form, but make sure it happens on the main UI thread or there'll be hell to pay.
            MainForm.ShowFormOnUIThread( this );
        }

        public void UpdateState( )
        {
            // If this method was called by a different thread, invoke it to run on the form thread.
            if ( InvokeRequired )
            {
                BeginInvoke( new MethodInvoker( delegate { UpdateState( ); } ) );
                return;
            }

            switch ( transfer.CurrentState )
            {
                case Transfer.State.WAITING:
                    lblStatus.Text = "Waiting for " + transfer.Partner + " to accept...";
                    break;
                case Transfer.State.FAILED_CONNECTION:
                    lblStatus.Text = "Failed to connect to " + transfer.Partner + ".";
                    break;
                case Transfer.State.TRANSFERRING:
                    lblStatus.Text = ( incoming ? "Receiving" : "Sending" ) + " " + transfer.FileName;
                    lblDataStatus.Text = Util.FormatFileSize( transfer.NumBytesTransferred ) + " of " + Util.FormatFileSize( transfer.FileSize ) + " " + ( incoming ? "received" : "sent" )
                        + " (at " + Util.FormatFileSize( transfer.GetCurrentSpeed( ) * 1000 ) + "/s)";
                    progressBar.Value = (int) Math.Round( 100.0 * transfer.NumBytesTransferred / transfer.FileSize );
                    break;
                case Transfer.State.VERIFYING:
                    lblStatus.Text = "Verifying...";
                    break;
                case Transfer.State.FINISHED:
                    lblStatus.Text = "File " + ( incoming ? "received" : "sent" ) + " successfully!";
                    lblDataStatus.Text = Util.FormatFileSize( transfer.FileSize ) + " " + ( incoming ? "received" : "sent" )
                       + " (at " + Util.FormatFileSize( transfer.GetCurrentSpeed( ) * 1000 ) + "/s)";
                    progressBar.Value = 100;
                    break;
                case Transfer.State.FAILED:
                    lblStatus.Text = "Transmission failure!";
                    break;
            }

            if ( transfer.IsComplete( ) )
            {
                btnCancel.Text = "Close";
            }

            if ( transfer.CurrentState == Transfer.State.TRANSFERRING || transfer.CurrentState == Transfer.State.FINISHED )
            {
                groupDetails.Visible = true;
                this.Height = 173;
            }
            else
            {
                groupDetails.Visible = false;
                //  this.Height = 80;
            }

            Invalidate( );
        }

        private void btnCancel_Click( object sender, EventArgs e )
        {
            Close( );
        }
    }
}
