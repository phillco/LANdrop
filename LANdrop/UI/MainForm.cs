using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LANdrop.UI
{
    public partial class MainForm : Form
    {
        // A cache 
        private ListViewItem lastItemHovered;

        public MainForm( )
        {
            InitializeComponent( );

            Random r = new Random( );
            foreach ( ListViewItem i in receipientList.Items )
                i.ImageIndex = r.Next( 2 );
        }

        /// <summary>
        /// Item dragged over the list - decide whether we'll accept it.
        /// </summary>
        private void receipientList_DragEnter( object sender, DragEventArgs e )
        {
            if ( e.Data.GetDataPresent( DataFormats.FileDrop, false ) ) // Files are OK.
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        /// <summary>
        /// Called when the mouse is moved while an item is being dragged.
        /// We use this to "hot-select" the item under the cursor.
        /// </summary>
        private void receipientList_DragOver( object sender, DragEventArgs e )
        {
            // Select the item under the cursor.
            ListViewItem itemUnderMouse = getItemUnderMouse( receipientList, e.X, e.Y );
            if ( itemUnderMouse != lastItemHovered )
            {
                foreach ( ListViewItem i in receipientList.Items )
                    i.Selected = false;

                itemUnderMouse.Selected = true;
                lastItemHovered = itemUnderMouse; // Cache this to prevent rapid refreshes.
            }

            // Set the status bar text.
            if ( itemUnderMouse != null && getDraggedFiles( e ).Count > 0 )
                lblStatus.Text = "Sending " + getDraggedFiles( e )[0].Name + " to " + itemUnderMouse.Text;
            else
                lblStatus.Text = "Ready";
        }

        /// <summary>
        /// The dragged item has been moved away from the list (canceling).
        /// </summary>
        private void receipientList_DragLeave( object sender, EventArgs e )
        {
            lblStatus.Text = "Ready";
        }

        /// <summary>
        /// Drag completed! Start the transfer.
        /// </summary>
        private void receipientList_DragDrop( object sender, DragEventArgs e )
        {
            ListViewItem hoverItem = getItemUnderMouse( receipientList, e.X, e.Y );
            List<FileInfo> files = getDraggedFiles( e );

            if ( files.Count > 0 && hoverItem != null )
                MessageBox.Show( "Send " + files[0].Name + " to " + hoverItem.Text, "Next Step", MessageBoxButtons.OK, MessageBoxIcon.Information );
        }

        /// <summary>
        /// Returns the item in the given ListView under the cursor.
        /// </summary>
        private ListViewItem getItemUnderMouse( ListView list, int x, int y )
        {
            // Get the coordinates relative to the control.
            Point localPoint = list.PointToClient( new Point( x, y ) );

            return list.GetItemAt( localPoint.X, localPoint.Y );
        }

        /// <summary>
        /// Extracts the list of files from the given drag arguments.
        /// </summary>
        private List<FileInfo> getDraggedFiles( DragEventArgs e )
        {
            List<FileInfo> files = new List<FileInfo>( );

            string[] fileNames = (string[]) e.Data.GetData( DataFormats.FileDrop );            
            foreach ( string file in fileNames )
                files.Add( new FileInfo( file ) );

            return files;
        }
    }
}
