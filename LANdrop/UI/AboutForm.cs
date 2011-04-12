using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LANdrop.Networking;
using LANdrop.Updates;

namespace LANdrop.UI
{
    public partial class AboutForm : Form
    {
        public AboutForm( )
        {
            InitializeComponent( );

            Util.UseProperSystemFont( this );
            lblProgramVersion.Text = Util.GetProgramVersion( );
            lblBuildInfo.Text = BuildInfo.ToString( );
            panelReadyToApply.Top = panelUpToDate.Top = panelUpdateError.Top = panelUpdateProgress.Top;

            // Update the state of the "update" panel.
            if ( BuildInfo.BUILD_TYPE != BuildInfo.UpdateChannels.NONE )
                UpdateChecker.StateChanged += UpdateChecker_StateChanged;

            UpdateState( );
        }

        private void UpdateState( )
        {
            panelUpToDate.Visible = panelUpdateProgress.Visible = panelUpdateError.Visible = panelReadyToApply.Visible = false;

            // Don't show any of the panels in local-dev mode.
            if ( BuildInfo.BUILD_TYPE == BuildInfo.UpdateChannels.NONE )
                return;

            llblCheckUpdate.Enabled = UpdateChecker.CanRefreshServer( );
            if ( !UpdateChecker.CanRefreshServer( ) )
                updateRefreshLinkTimer.Start( );

            switch ( UpdateChecker.CurrentState )
            {
                case UpdateChecker.State.SLEEPING:
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
                case UpdateChecker.State.ERROR:
                    panelUpdateError.Show( );
                    break;
            }
        }

        private void UpdateChecker_StateChanged( UpdateChecker.State oldState, UpdateChecker.State newState )
        {
            // This event is sent from the updater thread, so switch to the UI thread.
            BeginInvoke( (MethodInvoker) delegate { UpdateState( ); } );
        }

        private void llblCheckUpdate_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            UpdateChecker.CheckNowAsync( );
        }

        private void updateTimer_Tick( object sender, EventArgs e )
        {
            if ( UpdateChecker.CanRefreshServer( ) )
            {
                UpdateState( );
                updateRefreshLinkTimer.Stop( );
            }
        }

        private void AboutForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            UpdateChecker.StateChanged -= UpdateChecker_StateChanged;
        }

        private void llblApplyUpdate_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            Util.RestartApplication( );
            Application.Exit( );
        }
    }
}
