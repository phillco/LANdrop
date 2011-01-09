using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LANdrop.Networking;
using LANdrop.Networking;

namespace LANdrop.UI
{
    public partial class SendTextSnippetForm : Form
    {
        private Peer recipient;

        public SendTextSnippetForm( Peer recipient )
        {
            InitializeComponent( );
            Util.UseProperSystemFont( this );

            this.recipient = recipient;
            this.Text = "Send text snippet to " + recipient.Name;
            UpdateState( );
        }

        private void UpdateState( )
        {
            btnPaste.Enabled = ( Util.GetClipboardTextSafely( false ) != null );            
            btnSend.Enabled = ( tbSnippet.Text.Length > 0 );
        }

        private void btnPaste_Click( object sender, EventArgs e )
        {
            string clipboard = Util.GetClipboardTextSafely( true );

            if ( clipboard != null )
            {
                // If there's already text, start a new line.
                if ( tbSnippet.Text.Length > 0 )
                    tbSnippet.Text += Environment.NewLine;

                tbSnippet.Text += clipboard;
            }
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
