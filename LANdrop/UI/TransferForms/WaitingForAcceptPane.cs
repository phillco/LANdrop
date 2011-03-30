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
    public partial class WaitingForAcceptPane : NotificationPane
    {     
        private OutgoingTransfer transfer;

        public WaitingForAcceptPane( OutgoingTransfer transfer )
        {
            InitializeComponent( );
            this.transfer = transfer;
            lblTitle.Text = String.Format( "Waiting for {0} to accept...", transfer.Recipient.Name );
            Width = lblTitle.Width + lblTitle.Left + 16;        
            OnHideTimeChanged(  );
        }       
    }
}
