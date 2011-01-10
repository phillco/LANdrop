using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LANdrop.UI
{
    public partial class SettingsForm : Form
    {
        public SettingsForm( )
        {
            InitializeComponent( );

            tbUserName.Text = Configuration.Instance.Username;
        }

        private void btnSave_Click( object sender, EventArgs e )
        {
            Configuration.Instance.Username = tbUserName.Text;
            Configuration.Save( );
        }
    }
}
