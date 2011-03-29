﻿using System;
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
    public partial class TransferFailedPane : AutoHidePane
    {
        private IncomingTransfer transfer;

        public TransferFailedPane( IncomingTransfer transfer )
        {
            InitializeComponent( );
            this.transfer = transfer;
            secondsToHide = 8;
            lblTitle.Text = String.Format( "Failed to receive {0}", transfer.FileName );
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
