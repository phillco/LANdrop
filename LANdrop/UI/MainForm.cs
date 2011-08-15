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
using LANdrop.UI.TransferForms;
using LANdrop.Updates;

namespace LANdrop.UI
{
    public partial class MainForm : Form
    {
        // A cache 
        private ListViewItem lastItemHovered;

        public static MainForm Instance { get; private set; }

        private ListViewItem notUsingLandrop = new ListViewItem { Text = "(someone not using LANdrop)", ImageIndex = (int) OnlineIconStates.Offline };

        enum OnlineIconStates
        {
            Offline = 0,
            Online = 1
        }

        public MainForm( )
        {
            InitializeComponent( );
            Instance = this;
        }

        private void MainForm_Load( object sender, EventArgs e )
        {
            Util.UseProperSystemFont( this );
            Random r = new Random( );
            foreach ( ListViewItem i in receipientList.Items )
                i.ImageIndex = r.Next( 2 );

            UpdateState( );

            // When an update is ready to be applied, show some UI cues...
            UpdateChecker.StateChanged += ( oldState, newState ) =>
            {
                if ( newState == UpdateChecker.State.READY_TO_APPLY && !panelApplyUpdate.Visible && Configuration.CurrentSettings.UpdateAutomatically )
                {
                    BeginInvoke( (MethodInvoker) delegate
                    {
                        UpdateState( );
                    } );
                }
            };

            // Update the UI when the configuration changes...
            Configuration.Changed += ( oldSettings ) => UpdateState( );

            PeerList.ListChanged += ( peers ) => UpdatePeerList( );

            // Show a little notification when builds get updated.
            if ( UpdateApplier.RunningNewVersion )
                new NotificationForm( new UpdateAppliedNotification( ) ).Show( );
        }

        /// <summary>
        /// Displays (and starts the message loop of) the given form on the UI thread, the thread MainForm is using.
        /// In C#, all new forms must be created on the UI thread.
        /// </summary>
        public static void ShowFormOnUIThread( Form form )
        {
            Instance.BeginInvoke( new MethodInvoker( delegate { form.Show( ); } ) );
        }

        private void UpdateButtons( )
        {
            showLANdropToolStripMenuItem.Text = Visible ? "Hide LANdrop" : "Show LANdrop";
            btnSend.Enabled = receipientList.SelectedItems.Count > 0;
        }

        private void UpdateState( )
        {
            UpdatePeerList( );
            UpdateButtons( );

            // Hide or show the little "update ready!" banner as needed.
            if ( !panelApplyUpdate.Visible && Configuration.CurrentSettings.UpdateAutomatically && UpdateChecker.CurrentState == UpdateChecker.State.READY_TO_APPLY )
                ShowUpdateCues( );
            else if ( panelApplyUpdate.Visible && ( !Configuration.CurrentSettings.UpdateAutomatically || UpdateChecker.CurrentState == UpdateChecker.State.SLEEPING ) )
                HideUpdateCues( );
        }

        public void UpdatePeerList( )
        {
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
            foreach ( Peer p in PeerList.Peers )
            {
                receipientList.Items.Add( new ListViewItem
                {
                    Tag = p,
                    Text = p.Name,
                    ImageIndex = p.IsOnline( ) ? (int) OnlineIconStates.Online : (int) OnlineIconStates.Offline
                } );
            }
            receipientList.Items.Add( notUsingLandrop );

            // Restore the selected items.
            foreach ( ListViewItem item in receipientList.Items )
            {
                if ( item.Tag != null && selectedPeers.Contains( (Peer) item.Tag ) )
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
            if ( itemUnderMouse != null && itemUnderMouse != lastItemHovered )
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
            {
                if ( hoverItem == notUsingLandrop )
                    new WebHostedFileReadyForm( new WebServedFile( files[0].FullName ) ).Show( );
                else
                    new OutgoingTransfer( files[0], (Peer) hoverItem.Tag );

            }
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
            // Don't show the menu if there's nothing selected.
            if ( receipientList.SelectedItems.Count == 0 )
            {
                e.Cancel = true;
                return;
            }

            // Hide certain elements when click on the "not using LANdrop" item.
            if ( receipientList.SelectedItems[0] == notUsingLandrop )
            {
                copyIPAddressToolStripMenuItem.Visible = recipientContextSeparator1.Visible = false;
                return;
            }
            else
                copyIPAddressToolStripMenuItem.Visible = recipientContextSeparator1.Visible = true;
        }

        private void optionsToolStripMenuItem_Click( object sender, EventArgs e )
        {
            new SettingsForm( ).ShowDialog( );
        }

        private void MainForm_Resize( object sender, EventArgs e )
        {
            if ( this.WindowState == FormWindowState.Minimized )
                HideToTray( );
        }

        private void HideToTray( )
        {
            Hide( );
            UpdateState( );
        }

        private void ShowFromTray( )
        {
            Show( );
            WindowState = FormWindowState.Normal;
            BringToFront( );
            UpdateState( );
        }

        private void ToggleVisibility( )
        {
            if ( Visible )
                HideToTray( );
            else
                ShowFromTray( );
        }

        private void ShowUpdateCues( )
        {
            applyUpdateToolStripMenuItem.Visible = panelApplyUpdate.Visible = true;
            contentPanel.Padding = new Padding( contentPanel.Padding.Left, contentPanel.Padding.Top + panelApplyUpdate.Height + 8, contentPanel.Padding.Right, contentPanel.Padding.Bottom );
        }

        private void HideUpdateCues( )
        {
            applyUpdateToolStripMenuItem.Visible = panelApplyUpdate.Visible = false;
            contentPanel.Padding = new Padding( contentPanel.Padding.Left, contentPanel.Padding.Top - panelApplyUpdate.Height - 8, contentPanel.Padding.Right, contentPanel.Padding.Bottom );
        }

        private void showLANdropToolStripMenuItem_Click( object sender, EventArgs e )
        {
            ToggleVisibility( );
        }

        private void trayIcon_MouseClick( object sender, MouseEventArgs e )
        {
            if ( e.Button == MouseButtons.Left )
                ToggleVisibility( );
        }

        private void exitToolStripMenuItem1_Click( object sender, EventArgs e )
        {
            Close( );
        }

        private void trayIconMenu_Opening( object sender, CancelEventArgs e )
        {
            UpdateState( );

            // Populate the "Send to" menu with a list of the recipients.
            sendToToolStripMenuItem.DropDownItems.Clear( );
            foreach ( Peer peer in PeerList.Peers )
            {
                // Set up the entry's properties.
                ToolStripMenuItem item = new ToolStripMenuItem( peer.Name, onlineIcons.Images[peer.IsOnline( ) ? (int) OnlineIconStates.Online : (int) OnlineIconStates.Offline] );
                item.Click += ( altSender, altE ) => promptForFileAndSend( peer );

                sendToToolStripMenuItem.DropDownItems.Add( item );
            }
        }

        /// <summary>
        /// Show the "select file" dialog and if accepted, start the transfer.
        /// </summary>
        /// <param name="p"></param>
        private void promptForFileAndSend( Peer peer )
        {
            selectFileToSendDialog.Title = "Select a file to send to " + peer.Name + "..";
            if ( selectFileToSendDialog.ShowDialog( ) == DialogResult.OK )
                new OutgoingTransfer( new FileInfo( selectFileToSendDialog.FileName ), peer );
        }

        /// <summary>
        /// Called whenever a "send" button is pushed. 
        /// </summary>
        private void sendLogic( )
        {
            if ( receipientList.SelectedItems.Count > 0 )
            {
                if ( receipientList.SelectedItems[0] == notUsingLandrop )
                {
                    selectFileToSendDialog.Title = "Select a file to send...";
                    if ( selectFileToSendDialog.ShowDialog( ) == DialogResult.OK )
                        new WebHostedFileReadyForm( new WebServedFile( selectFileToSendDialog.FileName ) ).Show( );
                }
                else
                    promptForFileAndSend( (Peer) receipientList.SelectedItems[0].Tag );
            }
        }

        private void btnSend_Click( object sender, EventArgs e )
        {
            sendLogic( );
        }

        private void sendFileToToolStripMenuItem_Click( object sender, EventArgs e )
        {
            sendLogic( );
        }

        private void receipientList_MouseDoubleClick( object sender, MouseEventArgs e )
        {
            sendLogic( );
        }

        private void receipientList_ItemSelectionChanged( object sender, ListViewItemSelectionChangedEventArgs e )
        {
            UpdateButtons( );
        }

        private void testErrorToolStripMenuItem_Click( object sender, EventArgs e )
        {
            throw new Exception( "Test message here" );
        }

        private void applyUpdateToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if ( UpdateApplier.Run( ) )
                Application.Exit( );
        }

        private void llblApplyUpdate_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            if ( UpdateApplier.Run( ) )
                Application.Exit( );
        }

        private void sendFeedbackToolStripMenuItem_Click( object sender, EventArgs e )
        {
            new SendFeedbackForm( ).ShowDialog( this );
        }

        private void informationToolStripMenuItem_Click( object sender, EventArgs e )
        {
            new PeerInfoForm( (Peer) receipientList.SelectedItems[0].Tag ).ShowDialog( this );
        }
    }
}
