using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LANdrop.Peering;
using LANdrop.Transfers;

namespace LANdrop.UI
{
    public partial class SendTextSnippetForm : Form
    {
        private Peer recipient;

        public SendTextSnippetForm( Peer recipient  )
        {            
            InitializeComponent( );
            Util.UseProperSystemFont( this );
            
            this.recipient = recipient;
            this.Text = "Send text snippet to " + recipient.Name;
            UpdateState( );
        }

        private void UpdateState( )
        {
            btnPaste.Enabled = ( Clipboard.ContainsText( ) );
            btnSend.Enabled = ( tbSnippet.Text.Length > 0 );
        }

        private void btnPaste_Click( object sender, EventArgs e )
        {
            if ( tbSnippet.Text.Length > 0 )
                tbSnippet.Text += Environment.NewLine;

            // TODO: Add error support...
            tbSnippet.Text += Clipboard.GetText( );
        }

        private void btnSend_Click( object sender, EventArgs e )
        {
            new OutgoingTextSnippet( tbSnippet.Text, recipient );
            Close( );
        }

        private void tbSnippet_TextChanged( object sender, EventArgs e )
        {
            UpdateState( );
        }

        private void updateClipboardStatusTimer_Tick( object sender, EventArgs e )
        {
            UpdateState( );
        }
    }
}
