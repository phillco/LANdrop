using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using LANdrop.Networking;
using System.Net;

namespace LANdrop.UI
{
    public partial class MainForm : Form
    {
        // A cache 
        private ListViewItem lastItemHovered;

        private static MainForm instance;

        enum OnlineIconStates
        {
            Offline = 0,
            Online = 1
        }

        public MainForm( )
        {
            InitializeComponent( );
            Util.UseProperSystemFont( this );

            instance = this;

            Random r = new Random( );
            foreach ( ListViewItem i in receipientList.Items )
                i.ImageIndex = r.Next( 2 );

            UpdateState( );
        }

        /// <summary>
        /// Displays (and starts the message loop of) the given form on the UI thread, the thread MainForm is using.
        /// In C#, all new forms must be created on the UI thread.
        /// </summary>
        public static void ShowFormOnUIThread( Form form )
        {
            instance.Invoke( new MethodInvoker( delegate { form.Show( ); } ) );
        }

        private void UpdateState( )
        {
            UpdatePeerList( );

            sendClipboardToolStripMenuItem.Enabled = ( Util.GetClipboardTextSafely( false ) != null );
        }

        public void UpdatePeerList( )
        {
            // Only do this once the multicast manager has been set up.
            if ( MulticastManager.GetAllUsers( ) == null )
                return;

            // If this method was called by a different thread, invoke it to run on the form thread.
            if ( InvokeRequired )
            {
                BeginInvoke( new MethodInvoker( delegate { UpdatePeerList( ); } ) );
                return;
            }

            // Back up which peers are selected.
            List<Peer> selectedPeers = new List<Peer>( );
            foreach ( ListViewItem item in receipientList.Items )
            {
                if ( item.Selected )
                    selectedPeers.Add( (Peer) item.Tag );
            }

            // Recreate the listview from the peer list.
            receipientList.Items.Clear( );
            foreach ( Peer p in MulticastManager.GetAllUsers( ) )
            {
                receipientList.Items.Add( new ListViewItem
                {
                    Tag = p,
                    Text = p.Name,
                    ImageIndex = p.IsOnline( ) ? (int) OnlineIconStates.Online : (int) OnlineIconStates.Offline
                } );
            }

            // Restore the selected items.
            foreach ( ListViewItem item in receipientList.Items )
            {
                if ( selectedPeers.Contains( (Peer) item.Tag ) )
                    item.Selected = true;
            }
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
                new OutgoingTransfer( files[0], (Peer) hoverItem.Tag );
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

        private void refreshPeerListTimer_Tick( object sender, EventArgs e )
        {
            UpdateState( );
        }

        private void copyIPAddressToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if ( receipientList.SelectedItems.Count > 0 )
                Util.SetClipboardTextSafely( ( (Peer) receipientList.SelectedItems[0].Tag ).EndPoint.Address.ToString( ), true );
        }

        private void btnSendFile_Click( object sender, EventArgs e )
        {
            new AddUserForm( ).ShowDialog( );
            UpdateState( );

            /*new OutgoingTransfer( new FileInfo( "Seal.mp3" ), new Peer
            {
                Name = "Other Client",
                Address = new IPEndPoint( IPAddress.Parse( "127.0.0.1" ), IncomingTransferListener.Port )
            } );*/
        }

        private void sendClipboardContentsToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if ( receipientList.SelectedItems.Count > 0 )
            {
                string clipboard = Util.GetClipboardTextSafely( true );
                if ( clipboard != null )
                    new OutgoingTextSnippet( clipboard, (Peer) receipientList.SelectedItems[0].Tag );
            }
        }

        private void sendTextToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if ( receipientList.SelectedItems.Count > 0 )
                new SendTextSnippetForm( (Peer) receipientList.SelectedItems[0].Tag ).ShowDialog( );
        }

        private void exitToolStripMenuItem_Click( object sender, EventArgs e )
        {
            Close( );
        }

        private void aboutToolStripMenuItem_Click( object sender, EventArgs e )
        {
            new AboutForm( ).ShowDialog( );
        }

        private void recipientContextMenu_Opening( object sender, CancelEventArgs e )
        {
            // Update the "send clipboard" menu item to include a preview of what's in it.
            string clipboardText = Util.GetClipboardTextSafely( false );

            if ( clipboardText == null )
                sendClipboardToolStripMenuItem.Text = "Send clipboard";
            else
            {
                int previewCharacters = 25;
                clipboardText = clipboardText.Replace( Environment.NewLine, "" ).Trim( );

                if ( clipboardText.Length > previewCharacters + 3 )
                    sendClipboardToolStripMenuItem.Text = "Send clipboard (\"" + clipboardText.Substring( 0, previewCharacters ) + "...\")";
                else
                    sendClipboardToolStripMenuItem.Text = "Send clipboard (\"" + clipboardText + "\")";
            }
        }
    }
}
