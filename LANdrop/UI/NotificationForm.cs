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
        // The message we're carrying.
        public Control Content { get; private set; }

        // The y-position we're moving towards.
        public int DesiredTop { get; private set; }

        // Are we fading away?
        private bool isClosing = false;

        // All the notifications that we're showing (used for positioning).
        private static List<NotificationForm> allNotifications = new List<NotificationForm>( );

        public NotificationForm( )
        {
            InitializeComponent( );

            lock ( allNotifications )
                allNotifications.Add( this );
        }

        public NotificationForm( Control content ) : this()
        {
            ChangeContent( content );
        }

        public void ChangeContent( Control newContent )
        {
            // If this method was called by a different thread, invoke it to run on the form thread.
            if ( InvokeRequired )
            {
                BeginInvoke( new MethodInvoker( delegate { ChangeContent( newContent ); } ) );
                return;
            }

            bool firstItem = ( Content == null );
            if ( !firstItem )
            {
                Controls.Remove( Content );
                Content.Dispose( );
            }

            this.Content = newContent;
            Controls.Add( Content );
            Size = Content.Size;

            if ( firstItem )
                Align( );

            ReflowNotifications( );
            Left = Screen.GetWorkingArea( this ).Width - this.Width - 10;
        }

        private void ReflowNotifications( )
        {
            int y = Screen.GetWorkingArea( this ).Height - 15;

            lock ( allNotifications )
            {
                foreach ( var notification in allNotifications )
                {
                    if ( notification.Disposing || notification.IsDisposed )
                        continue;

                    notification.SetDesiredTop( y - notification.Height );
                    y -= notification.Height + 10;
                }
            }
        }

        /// <summary>
        /// Starts the form moving towards the given y-position.
        /// </summary>
        /// <param name="top"></param>
        public void SetDesiredTop( int top )
        {
            this.DesiredTop = top;
            positionTimer.Start( );
        }

        /// <summary>
        /// Starts to fade this notification out; it will close when complete.
        /// </summary>
        public void StartClose( )
        {
            isClosing = true;
            opacityTimer.Start( );

            // Slide down as we fade out.
            if ( !positionTimer.Enabled )
            {
                DesiredTop = Top + 15;
                positionTimer.Start( );
            }
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

            DesiredTop = startingPosition;
            Top = startingPosition + 30;
            Left = Screen.GetWorkingArea( this ).Width - this.Width - 10;
            positionTimer.Start( );
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
                Opacity = Math.Min( 0.85, Opacity + 0.1 );
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
                ReflowNotifications( );
            }
        }

        private void positionTimer_Tick( object sender, EventArgs e )
        {
            const int movementStep = 10;

            if ( Math.Abs( Top - DesiredTop ) < movementStep )
            {
                Top = DesiredTop;
                positionTimer.Stop( );
            }
            else
                Top += movementStep * ( Top > DesiredTop ? -1 : 1 );
        }
    }
}
