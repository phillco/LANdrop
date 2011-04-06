using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FogCreek;

namespace LANdrop.UI
{
    public partial class ErrorForm : Form
    {
        private Exception Exception;

        private BugReport Report;

        private const string DefaultReportText = "What were you doing when the error occured?";

        private bool ErrorIsFatal;

        private int submissionAttempts = 0;

        private BugReport.Result submissionResults;

        public ErrorForm( Exception e, BugReport report, bool fatal )
        {
            InitializeComponent( );
            this.Exception = e;
            this.Report = report;

            // Style the form differently for fatal errors.
            this.ErrorIsFatal = fatal;
            if ( ErrorIsFatal )
            {
                pbIcon.Image = global::LANdrop.Properties.Resources.exclamation;
                lblTitle.Text = "We're sorry...";
                lblDescription.Text = "LANdrop has encountered a fatal error and must restart.";
                btnRestart.Text = "Restart";
            }


            Size = MinimumSize;
            UpdateState( );
            BringToFront( );
            runReporter( );
        }

        private void UpdateState( )
        {
            lblBottomDivide.Width = Width;
        }

        private void btnRestart_Click( object sender, EventArgs e )
        {
            if ( ErrorIsFatal )
            {
                ErrorHandler.RestartApplication( );
                Environment.Exit( 0 );
            }
            Close( );
        }

        private void btnExit_Click( object sender, EventArgs e )
        {
            Environment.Exit( -1 );
        }

        private void ErrorForm_Resize( object sender, EventArgs e )
        {
            UpdateState( );
        }

        private void bugReporter_DoWork( object sender, DoWorkEventArgs e )
        {
            e.Result = Report.Submit( );
        }

        private void runReporter( )
        {
            pbSubmitProgress.Show( );
            lblSubmitting.Show( );
            panelReportFailed.Hide( );
            bugReporter.RunWorkerAsync( );
        }

        private void bugReporter_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
        {
            BugReport.Result response = (BugReport.Result) e.Result;
            submissionResults = response;
            this.submissionAttempts++;

            // Hide the progress bar.
            pbSubmitProgress.Hide( );
            lblSubmitting.Hide( );

            if ( response.Succeeded )
            {
                panelReportSent.Show( );
                if ( response.Message.Length > 0 )
                {
                    Height += 30;
                    lblDeveloperResponse.Text = "Developer response: " + response.Message;
                    lblDeveloperResponse.Show( );
                }
            }
            else
            {
                resubmitReportTimer.Start( );
                panelReportFailed.Show( );
            }
        }

        private void llblRetrySend_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            runReporter( );
        }

        private void hideMainFormTimer_Tick( object sender, EventArgs e )
        {
            if ( ErrorIsFatal && MainForm.Instance != null && !MainForm.Instance.IsDisposed )
                MainForm.Instance.Hide( );
            else
                hideMainFormTimer.Stop( );
        }

        private void llblDetails_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            new ExceptionDetailsForm( Exception ).ShowDialog( this );
        }

        private void resubmitReportTimer_Tick( object sender, EventArgs e )
        {
            if ( submissionResults.Succeeded || submissionAttempts > 5 )
            {
                resubmitReportTimer.Stop( );
                return;
            }

            // Resubmit the report if we're not trying to.
            if ( !bugReporter.IsBusy )
                runReporter( );
        }

        private void llblReportSubmitDetails_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            if ( submissionResults != null )
                new ExceptionDetailsForm( submissionResults.Message ).ShowDialog( this );
            else
                MessageBox.Show( "There were no results.", "Bug report results", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
        }
    }
}
