using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LANdrop.Networking;

namespace LANdrop.UI
{
    public partial class IncomingTransferNotification : Form
    {
        private IncomingTransfer transfer;

        private int secondsToReject = 15;

        public IncomingTransferNotification( IncomingTransfer transfer )
        {
            this.transfer = transfer;
            InitializeComponent( );

            lblTitle.Text = String.Format( "Would you like to receive {0} ({1})?", transfer.FileName, Util.FormatFileSize( transfer.FileSize ) );
            lblReject.Text = "Reject (" + secondsToReject + ")";

            // Align to the bottom-right of the screen.
            Rectangle workingArea = Screen.GetWorkingArea( this );
            Width = lblTitle.Width + lblTitle.Left + 16;        
            Left = Screen.GetWorkingArea( this ).Width - Width - 10;
            Top = Screen.GetWorkingArea( this ).Height - Height - 10;

            Show( );
        }

        private void Reject( )
        {
            transfer.Reject( );
            Close( );
        }

        private void opacityTimer_Tick( object sender, EventArgs e )
        {
            if ( this.Opacity < 0.85 )
            {
                Opacity = Math.Min( 0.85, Opacity + 0.1 );
                Refresh( );
            }
            else
                opacityTimer.Stop( );
        }

        private void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            transfer.Accept( );
            Close( );
        }

        private void rejectCountdownTimer_Tick( object sender, EventArgs e )
        {
            secondsToReject--;
            lblReject.Text = "Reject (" + secondsToReject + ")";
            if ( secondsToReject == 0 )
                Reject( );
        }

        private void lblReject_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            Reject( );
        }
    }
}
