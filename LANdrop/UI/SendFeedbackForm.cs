using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FogCreek;
using System.Threading;

namespace LANdrop.UI
{
    public partial class SendFeedbackForm : Form
    {
        public SendFeedbackForm( )
        {
            InitializeComponent( );
        }

        private void pbHappyFace_Click( object sender, EventArgs e )
        {
            rbGreat.Checked = true;
        }

        private void pbAngryFace_Click( object sender, EventArgs e )
        {
            rbNeedsWork.Checked = true;
        }

        private void btnSubmit_Click( object sender, EventArgs e )
        {
            BugReport report = new BugReport
            {
                FogBugzUrl = "https://phillco.fogbugz.com/ScoutSubmit.asp",
                UserName = "Exception Reporter",
                Project = "LANdrop",
                Area = "Feedback",
                Title = "v" + Util.GetProgramVersion( ) + ( rbGreat.Checked ? " (Positive Feedback)" : " (Negative Feedback)" ), // Use version number to split feedback by version.
                DefaultMessage = "",
            };

            // Uncomment to have each report add a case entry (even if no comments were added).
            //report.Description += ( rbGreat.Checked ? "It's great!" : "It needs work..." ) + Environment.NewLine + Environment.NewLine;

            if ( tbAdditionalComments.Text.Trim( ).Length > 0 )
                report.Description += tbAdditionalComments.Text;

            ThreadPool.QueueUserWorkItem( delegate { report.Submit( ); } );
            Close( );
        }
    }
}
