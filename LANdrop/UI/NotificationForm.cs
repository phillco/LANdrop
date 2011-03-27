using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LANdrop.Networking;
using LANdrop.UI.TransferForms;

namespace LANdrop.UI
{
    /// <summary>
    /// A growl-like notification that lives in the corner of the screen. Supports fading.
    /// Construct it by passing in a control to display.
    /// </summary>
    public partial class NotificationForm : Form
    {
        // Are we fading away?
        private bool isClosing = false;

        // All the notifications that we're showing (used for positioning).
        private static List<NotificationForm> allNotifications = new List<NotificationForm>( );

        public NotificationForm( Control message )
        {
            InitializeComponent( );

            // Add in the wrapped message and show it.
            Controls.Add( message );
            Size = message.Size;

            lock ( allNotifications )
                allNotifications.Add( this );

            Align( );
            Show( );
        }

        /// <summary>
        /// Starts to fade this notification out; it will close when complete.
        /// </summary>
        public void StartClose( )
        {
            isClosing = true;
            opacityTimer.Start( );
        }

        /// <summary>
        /// Aligns the form to the bottom-right corner of the screen, on top of all the other notifications.
        /// </summary>
        private void Align( )
        {
            // Find the proper starting position.
            int startingPosition = Screen.GetWorkingArea( this ).Height - 5;

            // Move up the list of notifications to find the top.
            lock ( allNotifications )
                foreach ( var notification in allNotifications )
                    if ( !notification.Disposing && !notification.IsDisposed )
                        startingPosition -= notification.Height + 10;
            
            Top = startingPosition;
            Left = Screen.GetWorkingArea( this ).Width - this.Width - 10;
        }

        private void opacityTimer_Tick( object sender, EventArgs e )
        {
            if ( isClosing ) // Fading out...
            {
                Opacity -= 0.1;

                // Close when done.
                if ( Opacity <= 0 )
                    Close( );
            }
            else if ( this.Opacity < 0.85 ) // Fading in...
            {
                Opacity = Math.Min( 0.85, Opacity + 0.1 );
                Refresh( );
            }
            else
                opacityTimer.Stop( );
        }

        private void NotificationForm_FormClosed( object sender, FormClosedEventArgs e )
        {
            lock ( allNotifications )
            {
                // Remove us from the list of notifications.
                int index = allNotifications.IndexOf( this );
                allNotifications.RemoveAt( index );

                // Shift down all the notifications above us.
                for ( int i = index; i < allNotifications.Count; i++ )
                    allNotifications[i].Top += this.Height + 10;
            }
        }
    }
}
