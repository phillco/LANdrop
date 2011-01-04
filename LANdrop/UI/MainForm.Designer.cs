namespace LANdrop.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            this.components = new System.ComponentModel.Container( );
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( MainForm ) );
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem( "Phillip", 0 );
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem( "Jim", 1 );
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem( "Simon", 1 );
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem( "Will", 0 );
            this.onlineIcons = new System.Windows.Forms.ImageList( this.components );
            this.statusStrip = new System.Windows.Forms.StatusStrip( );
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel( );
            this.contentPanel = new System.Windows.Forms.Panel( );
            this.btnSend = new System.Windows.Forms.Button( );
            this.btnSendFile = new System.Windows.Forms.Button( );
            this.label1 = new System.Windows.Forms.Label( );
            this.receipientList = new System.Windows.Forms.ListView( );
            this.recipientContextMenu = new System.Windows.Forms.ContextMenuStrip( this.components );
            this.sendFileToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
            this.sendClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
            this.copyIPAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
            this.refreshPeerListTimer = new System.Windows.Forms.Timer( this.components );
            this.sendTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator( );
            this.statusStrip.SuspendLayout( );
            this.contentPanel.SuspendLayout( );
            this.recipientContextMenu.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // onlineIcons
            // 
            this.onlineIcons.ImageStream = ( (System.Windows.Forms.ImageListStreamer) ( resources.GetObject( "onlineIcons.ImageStream" ) ) );
            this.onlineIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.onlineIcons.Images.SetKeyName( 0, "status_offline.png" );
            this.onlineIcons.Images.SetKeyName( 1, "status_online.png" );
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus} );
            this.statusStrip.Location = new System.Drawing.Point( 0, 304 );
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size( 244, 22 );
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size( 229, 17 );
            this.lblStatus.Spring = true;
            this.lblStatus.Text = "Ready";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add( this.btnSend );
            this.contentPanel.Controls.Add( this.btnSendFile );
            this.contentPanel.Controls.Add( this.label1 );
            this.contentPanel.Controls.Add( this.receipientList );
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point( 0, 0 );
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding( 16, 42, 16, 48 );
            this.contentPanel.Size = new System.Drawing.Size( 244, 304 );
            this.contentPanel.TabIndex = 6;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point( 144, 267 );
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size( 84, 25 );
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // btnSendFile
            // 
            this.btnSendFile.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.btnSendFile.Location = new System.Drawing.Point( 14, 267 );
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size( 91, 25 );
            this.btnSendFile.TabIndex = 3;
            this.btnSendFile.Text = "Send file";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler( this.btnSendFile_Click );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font( "Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point( 16, 14 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 169, 16 );
            this.label1.TabIndex = 0;
            this.label1.Text = "Select a user to send to:";
            // 
            // receipientList
            // 
            this.receipientList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.receipientList.AllowDrop = true;
            this.receipientList.ContextMenuStrip = this.recipientContextMenu;
            this.receipientList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.receipientList.FullRowSelect = true;
            this.receipientList.GridLines = true;
            this.receipientList.HideSelection = false;
            this.receipientList.Items.AddRange( new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4} );
            this.receipientList.Location = new System.Drawing.Point( 16, 42 );
            this.receipientList.Name = "receipientList";
            this.receipientList.Size = new System.Drawing.Size( 212, 214 );
            this.receipientList.SmallImageList = this.onlineIcons;
            this.receipientList.TabIndex = 2;
            this.receipientList.UseCompatibleStateImageBehavior = false;
            this.receipientList.View = System.Windows.Forms.View.List;
            this.receipientList.DragDrop += new System.Windows.Forms.DragEventHandler( this.receipientList_DragDrop );
            this.receipientList.DragEnter += new System.Windows.Forms.DragEventHandler( this.receipientList_DragEnter );
            this.receipientList.DragLeave += new System.EventHandler( this.receipientList_DragLeave );
            this.receipientList.DragOver += new System.Windows.Forms.DragEventHandler( this.receipientList_DragOver );
            // 
            // recipientContextMenu
            // 
            this.recipientContextMenu.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.sendFileToToolStripMenuItem,
            this.sendTextToolStripMenuItem,
            this.sendClipboardToolStripMenuItem,
            this.toolStripSeparator1,
            this.copyIPAddressToolStripMenuItem} );
            this.recipientContextMenu.Name = "recipientConextMenu";
            this.recipientContextMenu.Size = new System.Drawing.Size( 156, 120 );
            // 
            // sendFileToToolStripMenuItem
            // 
            this.sendFileToToolStripMenuItem.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.sendFileToToolStripMenuItem.Name = "sendFileToToolStripMenuItem";
            this.sendFileToToolStripMenuItem.Size = new System.Drawing.Size( 155, 22 );
            this.sendFileToToolStripMenuItem.Text = "Send file...";
            // 
            // sendClipboardToolStripMenuItem
            // 
            this.sendClipboardToolStripMenuItem.Name = "sendClipboardToolStripMenuItem";
            this.sendClipboardToolStripMenuItem.Size = new System.Drawing.Size( 155, 22 );
            this.sendClipboardToolStripMenuItem.Text = "Send clipboard";
            this.sendClipboardToolStripMenuItem.Click += new System.EventHandler( this.sendClipboardContentsToolStripMenuItem_Click );
            // 
            // copyIPAddressToolStripMenuItem
            // 
            this.copyIPAddressToolStripMenuItem.Name = "copyIPAddressToolStripMenuItem";
            this.copyIPAddressToolStripMenuItem.Size = new System.Drawing.Size( 155, 22 );
            this.copyIPAddressToolStripMenuItem.Text = "Copy IP";
            this.copyIPAddressToolStripMenuItem.Click += new System.EventHandler( this.copyIPAddressToolStripMenuItem_Click );
            // 
            // refreshPeerListTimer
            // 
            this.refreshPeerListTimer.Enabled = true;
            this.refreshPeerListTimer.Interval = 1000;
            this.refreshPeerListTimer.Tick += new System.EventHandler( this.refreshPeerListTimer_Tick );
            // 
            // sendTextToolStripMenuItem
            // 
            this.sendTextToolStripMenuItem.Name = "sendTextToolStripMenuItem";
            this.sendTextToolStripMenuItem.Size = new System.Drawing.Size( 155, 22 );
            this.sendTextToolStripMenuItem.Text = "Send text...";
            this.sendTextToolStripMenuItem.Click += new System.EventHandler( this.sendTextToolStripMenuItem_Click );
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size( 152, 6 );
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 244, 326 );
            this.Controls.Add( this.contentPanel );
            this.Controls.Add( this.statusStrip );
            this.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.Icon = ( (System.Drawing.Icon) ( resources.GetObject( "$this.Icon" ) ) );
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size( 300, 600 );
            this.MinimumSize = new System.Drawing.Size( 230, 250 );
            this.Name = "MainForm";
            this.Text = "LANdrop";
            this.statusStrip.ResumeLayout( false );
            this.statusStrip.PerformLayout( );
            this.contentPanel.ResumeLayout( false );
            this.contentPanel.PerformLayout( );
            this.recipientContextMenu.ResumeLayout( false );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.ImageList onlineIcons;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView receipientList;
        private System.Windows.Forms.ContextMenuStrip recipientContextMenu;
        private System.Windows.Forms.ToolStripMenuItem sendFileToToolStripMenuItem;
        private System.Windows.Forms.Timer refreshPeerListTimer;
        private System.Windows.Forms.ToolStripMenuItem copyIPAddressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

