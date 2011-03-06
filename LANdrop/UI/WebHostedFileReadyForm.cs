using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LANdrop.Networking;
using System.Diagnostics;

namespace LANdrop.UI
{
    public partial class WebHostedFileReadyForm : Form
    {
        private WebServedFile file;

        public WebHostedFileReadyForm( WebServedFile file )
        {
            this.file = file;
            InitializeComponent( );
            this.Text = file.File.Name;            
            lblAddress.Text = file.GetLink( );
        }

        private void UpdateState()
        {
            lblExpiresIn.Text = "Expires in " + (int) Math.Ceiling(file.DateExpires.Subtract(DateTime.Now).TotalMinutes) +" minutes";

        }

        private void lblAddress_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            Process.Start( file.GetLink() );
        }

        private void btnCopy_Click( object sender, EventArgs e )
        {
            Util.SetClipboardTextSafely( file.GetLink( ), true );
            Close( );
        }

        private void updateExpirationTimer_Tick( object sender, EventArgs e )
        {
            UpdateState();
        }
    }
}
