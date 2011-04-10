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
    public partial class AboutForm : Form
    {
        public AboutForm( )
        {
            InitializeComponent( );

            Util.UseProperSystemFont( this );
            lblProgramVersion.Text = Util.GetProgramVersion( );
            lblBuildInfo.Text = BuildInfo.ToString();
            panelReadyToApply.Top = panelUpToDate.Top = panelUpdateProgress.Top;
        }

        private void updateRefreshTimer_Tick( object sender, EventArgs e )
        {
            panelUpToDate.Visible = panelUpdateProgress.Visible = panelReadyToApply.Visible = false;
            llblCheckUpdate.Enabled = UpdateChecker.CanRefreshServer( );

            switch ( UpdateChecker.CurrentState )
            {
                case UpdateChecker.State.WAITING:
                    panelUpToDate.Show( );
                    break;
                case UpdateChecker.State.CHECKING:
                    lblCheckingForUpdates.Text = "Checking for updates...";
                    panelUpdateProgress.Show( );
                    break;
                case UpdateChecker.State.DOWNLOADING:
                    lblCheckingForUpdates.Text = "Downloading update...";
                    panelUpdateProgress.Show( );
                    break;
                case UpdateChecker.State.READY_TO_APPLY:
                    panelReadyToApply.Show( );
                    break;
            }
        }

        private void llblCheckUpdate_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            UpdateChecker.CheckNowAsync( );
        }
    }
}
