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
    public partial class AddUserForm : Form
    {
        public AddUserForm( )
        {
            InitializeComponent( );
            lblYourIP.Text = Util.GetLocalAddress( ).ToString( );
            lblYourIP.Left = btnCopy.Left - lblYourIP.Width - 5;
            UpdateState( );
        }

        private void UpdateState( )
        {
            btnAdd.Enabled = ( tbTheirIP.Text.Length > 0 );
        }

        private void btnCopy_Click( object sender, EventArgs e )
        {
            Util.SetClipboardTextSafely( lblYourIP.Text, true );          
        }

        private void btnAdd_Click( object sender, EventArgs e )
        {
            string ip = tbTheirIP.Text.Trim( );

            // Don't let the user add themself.
            if ( ip == lblYourIP.Text || ip == "127.0.0.1" )
            {
                MessageBox.Show( "You cannot add yourself!", "Add user", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                tbTheirIP.Text = "";
                return;
            }

            MulticastManager.AddUserManually( tbTheirIP.Text );
            Close( );
        }

        private void tbTheirIP_TextChanged( object sender, EventArgs e )
        {
            UpdateState( );
        }
    }
}
