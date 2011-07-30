using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LANdrop.Networking;
using System.Net;

namespace LANdrop.UI
{
    public partial class AddUserForm : Form
    {
        public AddUserForm( )
        {
            InitializeComponent( );
            UpdateState( );

            // If there's a valid IP address in the clipboard, pre-fill it in the IP address box to save the user's very valuable time.
            string clipboard = Util.GetClipboardTextSafely( false );
            if ( clipboard != null )
            {
                clipboard = clipboard.Trim( );
                if ( Util.IsValidAddress( clipboard ) )
                    tbTheirIP.Text = clipboard;
            }
        }

        private void UpdateState( )
        {
            btnAdd.Enabled = ( tbTheirIP.Text.Length > 0 );
            btnPaste.Enabled = ( Util.GetClipboardTextSafely( false ) != null );
        }

        private void AddUser( )
        {
            string ip = tbTheirIP.Text.Trim( );

            // Make sure the IP is valid.
            if ( !Util.IsValidAddress( ip ) )
            {
                MessageBox.Show( ip + " is not a valid IP address.", "Add user", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                return;
            }

            // Don't let the user add themself.
            if ( ip == Util.GetLocalAddress( ).ToString( ) || ip == "127.0.0.1" )
            {
                MessageBox.Show( "You cannot add yourself!", "Add user", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                tbTheirIP.Text = "";
                return;
            }

            PeerList.AddOrUpdate( new Peer
            {
                Name = "User at " + tbTheirIP.Text,
                EndPoint = new IPEndPoint( IPAddress.Parse( tbTheirIP.Text ), Protocol.DefaultServerPort )
            } );
            Close( );
        }

        private void btnAdd_Click( object sender, EventArgs e )
        {
            AddUser( );
        }

        private void tbTheirIP_TextChanged( object sender, EventArgs e )
        {
            UpdateState( );
        }

        private void lblCopyYourIP_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            string ip = Util.GetLocalAddress( ).ToString( );
            if ( Util.SetClipboardTextSafely( ip, true ) )
            {
                string message = String.Format( "Your IP is: {0}\n\nThis has been copied to your clipboard.\nSend it to your friend so that he can add you.", ip );
                MessageBox.Show( message, "IP Copied", MessageBoxButtons.OK, MessageBoxIcon.Information );
                Close( );
            }
        }

        private void btnPaste_Click( object sender, EventArgs e )
        {
            tbTheirIP.Text = Util.GetClipboardTextSafely( true );
            if ( Util.IsValidAddress( tbTheirIP.Text ) )
                AddUser( );
        }

        private void updateStateTimer_Tick( object sender, EventArgs e )
        {
            // Need to refresh every so often to update the state of the "Paste" button.
            UpdateState( );
        }
    }
}
