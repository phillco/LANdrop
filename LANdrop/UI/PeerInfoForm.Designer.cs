namespace LANdrop.UI
{
    partial class PeerInfoForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox( );
            this.lblPeerName = new System.Windows.Forms.Label( );
            this.btnClose = new System.Windows.Forms.Button( );
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.lblOutgoingPeerExchanges = new System.Windows.Forms.Label( );
            this.lblIncomingPeerExchanges = new System.Windows.Forms.Label( );
            this.label1 = new System.Windows.Forms.Label( );
            this.updateInfoTimer = new System.Windows.Forms.Timer( this.components );
            this.lblLastSeen = new System.Windows.Forms.Label( );
            this.lblNumCommunications = new System.Windows.Forms.Label( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).BeginInit( );
            this.groupBox1.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LANdrop.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point( 12, 12 );
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size( 32, 32 );
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblPeerName
            // 
            this.lblPeerName.AutoSize = true;
            this.lblPeerName.Font = new System.Drawing.Font( "Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.lblPeerName.Location = new System.Drawing.Point( 44, 15 );
            this.lblPeerName.Name = "lblPeerName";
            this.lblPeerName.Size = new System.Drawing.Size( 164, 25 );
            this.lblPeerName.TabIndex = 1;
            this.lblPeerName.Text = "Albert Einstein";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point( 291, 216 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 75, 24 );
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.lblOutgoingPeerExchanges );
            this.groupBox1.Controls.Add( this.lblIncomingPeerExchanges );
            this.groupBox1.Controls.Add( this.label1 );
            this.groupBox1.Location = new System.Drawing.Point( 29, 97 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 321, 96 );
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // lblOutgoingPeerExchanges
            // 
            this.lblOutgoingPeerExchanges.AutoSize = true;
            this.lblOutgoingPeerExchanges.Location = new System.Drawing.Point( 31, 57 );
            this.lblOutgoingPeerExchanges.Name = "lblOutgoingPeerExchanges";
            this.lblOutgoingPeerExchanges.Size = new System.Drawing.Size( 150, 13 );
            this.lblOutgoingPeerExchanges.TabIndex = 2;
            this.lblOutgoingPeerExchanges.Text = "15 outgoing (20 seconds ago)";
            // 
            // lblIncomingPeerExchanges
            // 
            this.lblIncomingPeerExchanges.AutoSize = true;
            this.lblIncomingPeerExchanges.Location = new System.Drawing.Point( 31, 40 );
            this.lblIncomingPeerExchanges.Name = "lblIncomingPeerExchanges";
            this.lblIncomingPeerExchanges.Size = new System.Drawing.Size( 149, 13 );
            this.lblIncomingPeerExchanges.TabIndex = 1;
            this.lblIncomingPeerExchanges.Text = "25 incoming (20 seconds ago)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font( "Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point( 18, 19 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 116, 16 );
            this.label1.TabIndex = 0;
            this.label1.Text = "Peer exchanges:";
            // 
            // updateInfoTimer
            // 
            this.updateInfoTimer.Enabled = true;
            this.updateInfoTimer.Tick += new System.EventHandler( this.updateInfoTimer_Tick );
            // 
            // lblLastSeen
            // 
            this.lblLastSeen.AutoSize = true;
            this.lblLastSeen.Location = new System.Drawing.Point( 26, 57 );
            this.lblLastSeen.Name = "lblLastSeen";
            this.lblLastSeen.Size = new System.Drawing.Size( 137, 13 );
            this.lblLastSeen.TabIndex = 4;
            this.lblLastSeen.Text = "Last seen xxx seconds ago";
            // 
            // lblNumCommunications
            // 
            this.lblNumCommunications.AutoSize = true;
            this.lblNumCommunications.Location = new System.Drawing.Point( 26, 72 );
            this.lblNumCommunications.Name = "lblNumCommunications";
            this.lblNumCommunications.Size = new System.Drawing.Size( 126, 13 );
            this.lblNumCommunications.TabIndex = 5;
            this.lblNumCommunications.Text = "Communicated xxx times";
            // 
            // PeerInfoForm
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size( 378, 251 );
            this.Controls.Add( this.lblNumCommunications );
            this.Controls.Add( this.lblLastSeen );
            this.Controls.Add( this.groupBox1 );
            this.Controls.Add( this.btnClose );
            this.Controls.Add( this.lblPeerName );
            this.Controls.Add( this.pictureBox1 );
            this.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PeerInfoForm";
            this.Text = "About peer";
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).EndInit( );
            this.groupBox1.ResumeLayout( false );
            this.groupBox1.PerformLayout( );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblPeerName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblOutgoingPeerExchanges;
        private System.Windows.Forms.Label lblIncomingPeerExchanges;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer updateInfoTimer;
        private System.Windows.Forms.Label lblLastSeen;
        private System.Windows.Forms.Label lblNumCommunications;
    }
}