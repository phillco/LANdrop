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
            try
            {
                btnPaste.Enabled = ( Clipboard.ContainsText( ) );
            }
            catch ( System.Runtime.InteropServices.ExternalException ) { }
            btnSend.Enabled = ( tbSnippet.Text.Length > 0 );
        }

        private void btnPaste_Click( object sender, EventArgs e )
        {          
            while ( true )
            {
                try
                {
                    string clipboard = Clipboard.GetText( );

                    // If there's already text, start a new line.
                    if ( tbSnippet.Text.Length > 0 )
                        tbSnippet.Text += Environment.NewLine;

                    tbSnippet.Text += clipboard;
                    return;
                }
                catch ( System.Runtime.InteropServices.ExternalException )
                {
                    if ( MessageBox.Show( "Another program is using the clipboard. Would you like to try again?", "Clipboard Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning ) != DialogResult.Yes )
                        return;
                }
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
