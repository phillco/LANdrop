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

        public NotificationForm( Control message )
        {
            InitializeComponent( );

            Controls.Add( message );
            Size = message.Size;

            // Align to the bottom-right of the screen.
            Rectangle workingArea = Screen.GetWorkingArea( this );

            Left = Screen.GetWorkingArea( this ).Width - Width - 10;
            Top = Screen.GetWorkingArea( this ).Height - Height - 10;

            Show( );
        }

        public void StartClose( )
        {
            isClosing = true;
            opacityTimer.Start( );
        }

        private void opacityTimer_Tick( object sender, EventArgs e )
        {
            if ( isClosing )
            {
                Opacity -= 0.1;
                if ( Opacity <= 0 )
                    Close( );
                return;
            }

            if ( this.Opacity < 0.85 )
            {
                Opacity = Math.Min( 0.85, Opacity + 0.1 );
                Refresh( );
            }
            else
                opacityTimer.Stop( );
        }
    }
}
