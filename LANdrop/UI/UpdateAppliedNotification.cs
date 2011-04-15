using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace LANdrop.UI
{
    public partial class UpdateAppliedNotification : NotificationPane
    {
        public UpdateAppliedNotification( ) : base()
        {
            InitializeComponent( );
            secondsToHide = 2;            
            lblUpdateDetails.Text = "Welcome to " + BuildInfo.Version + ".";
            Width = lblTitle.Left + Math.Max( lblTitle.Width, lblUpdateDetails.Width ) + 16;
        }

        private void hideTimer_Tick( object sender, EventArgs e )
        {
            ParentNotification.StartClose( );
        }
    }
}
