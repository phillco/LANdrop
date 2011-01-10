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
            LoadFromConfiguration( Configuration.Instance );
        }

        private void LoadFromConfiguration( Configuration config )
        {
            tbUserName.Text = config.Username;
            Refresh( );
        }

        private void SaveToConfiguration( Configuration config )
        {
            config.Username = tbUserName.Text;
        }

        private void btnSave_Click( object sender, EventArgs e )
        {
            SaveToConfiguration( Configuration.Instance );
            Configuration.Save( );
        }

        private void llblResetToDefaults_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            if ( MessageBox.Show( "Are you sure you want to load the default settings?", "LANdrop Configuration", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.Yes )
                LoadFromConfiguration( Configuration.DefaultSettings );
        }
    }
}
