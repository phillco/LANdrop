using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LANdrop.Updates;

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
            cbUpdateAutomatically.Checked = config.UpdateAutomatically;
            UpdateState( );
            Refresh( );
        }

        private void SaveToConfiguration( Configuration config )
        {
            config.UpdateAutomatically = cbUpdateAutomatically.Checked;
            config.Username = tbUserName.Text;
        }

        private void UpdateState( )
        {
        }

        private void btnSave_Click( object sender, EventArgs e )
        {
            SaveToConfiguration( Configuration.Instance );
            Configuration.Instance.Save( );
        }

        private void llblResetToDefaults_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            if ( MessageBox.Show( "Are you sure you want to load the default settings?", "LANdrop Configuration", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.Yes )
                LoadFromConfiguration( Configuration.DefaultSettings );
        }

        private void cbAutomaticUpdates_CheckedChanged( object sender, EventArgs e )
        {
            UpdateState( );
        }
    }
}
