using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LANdrop.Networking;

namespace LANdrop.UI
{
    /// <summary>
    /// Shown when somebody wants to send us a file; shows links to accept or reject it.
    /// </summary>
    public partial class AutoHidePane : UserControl
    {
        // The notification form that this lives in.
        public NotificationForm ParentNotification { get { return Parent as NotificationForm; } }

        protected int secondsToHide = 15;

        public AutoHidePane( )
        {
            InitializeComponent( );
        }

        /// <summary>
        /// Called right when the timer runs out and the form is to be hidden. 
        /// </summary>
        protected virtual void OnAutoHide( )
        {
		if ( ParentNotification != null )
            ParentNotification.StartClose( );
        }

        /// <summary>
        /// Called whenever the number of seconds until the form is hidden changes. Useful for setting labels, etc.
        /// </summary>
        protected virtual void OnHideTimeChanged( )
        {

        }

        private void rejectCountdownTimer_Tick( object sender, EventArgs e )
        {
            secondsToHide--;
            if ( secondsToHide == 0 )
                OnAutoHide( );
            OnHideTimeChanged( );
        }
    }
}
