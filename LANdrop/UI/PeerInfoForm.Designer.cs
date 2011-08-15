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
            this.btnClose = new System.Windows.Forms.Button( );
            this.updateInfoTimer = new System.Windows.Forms.Timer( this.components );
            this.panel1 = new System.Windows.Forms.Panel( );
            this.lblNumOutgoingInquiries = new System.Windows.Forms.Label( );
            this.lblNumIncomingInquiries = new System.Windows.Forms.Label( );
            this.label5 = new System.Windows.Forms.Label( );
            this.label2 = new System.Windows.Forms.Label( );
            this.lblOutgoingPeerExchanges = new System.Windows.Forms.Label( );
            this.lblIncomingPeerExchanges = new System.Windows.Forms.Label( );
            this.label1 = new System.Windows.Forms.Label( );
            this.lblNumCommunications = new System.Windows.Forms.Label( );
            this.lblLastSeen = new System.Windows.Forms.Label( );
            this.lblPeerName = new System.Windows.Forms.Label( );
            this.pictureBox1 = new System.Windows.Forms.PictureBox( );
            this.lblNumMulticast = new System.Windows.Forms.Label( );
            this.label6 = new System.Windows.Forms.Label( );
            this.panel1.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point( 369, 198 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 75, 24 );
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // updateInfoTimer
            // 
            this.updateInfoTimer.Enabled = true;
            this.updateInfoTimer.Interval = 1000;
            this.updateInfoTimer.Tick += new System.EventHandler( this.updateInfoTimer_Tick );
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add( this.lblNumMulticast );
            this.panel1.Controls.Add( this.label6 );
            this.panel1.Controls.Add( this.lblNumOutgoingInquiries );
            this.panel1.Controls.Add( this.lblNumIncomingInquiries );
            this.panel1.Controls.Add( this.label5 );
            this.panel1.Controls.Add( this.label2 );
            this.panel1.Controls.Add( this.lblOutgoingPeerExchanges );
            this.panel1.Controls.Add( this.lblIncomingPeerExchanges );
            this.panel1.Controls.Add( this.label1 );
            this.panel1.Controls.Add( this.lblNumCommunications );
            this.panel1.Controls.Add( this.lblLastSeen );
            this.panel1.Controls.Add( this.lblPeerName );
            this.panel1.Controls.Add( this.pictureBox1 );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point( 0, 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 456, 192 );
            this.panel1.TabIndex = 9;
            // 
            // lblNumOutgoingInquiries
            // 
            this.lblNumOutgoingInquiries.AutoSize = true;
            this.lblNumOutgoingInquiries.Location = new System.Drawing.Point( 165, 147 );
            this.lblNumOutgoingInquiries.Name = "lblNumOutgoingInquiries";
            this.lblNumOutgoingInquiries.Size = new System.Drawing.Size( 64, 13 );
            this.lblNumOutgoingInquiries.TabIndex = 19;
            this.lblNumOutgoingInquiries.Text = "15 outgoing";
            // 
            // lblNumIncomingInquiries
            // 
            this.lblNumIncomingInquiries.AutoSize = true;
            this.lblNumIncomingInquiries.Location = new System.Drawing.Point( 165, 130 );
            this.lblNumIncomingInquiries.Name = "lblNumIncomingInquiries";
            this.lblNumIncomingInquiries.Size = new System.Drawing.Size( 63, 13 );
            this.lblNumIncomingInquiries.TabIndex = 18;
            this.lblNumIncomingInquiries.Text = "25 incoming";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font( "Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point( 155, 109 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 138, 16 );
            this.label5.TabIndex = 17;
            this.label5.Text = "General salutations:";
            // 
            // label2
            // 
            this.label2.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point( -51, 190 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 600, 2 );
            this.label2.TabIndex = 16;
            // 
            // lblOutgoingPeerExchanges
            // 
            this.lblOutgoingPeerExchanges.AutoSize = true;
            this.lblOutgoingPeerExchanges.Location = new System.Drawing.Point( 26, 147 );
            this.lblOutgoingPeerExchanges.Name = "lblOutgoingPeerExchanges";
            this.lblOutgoingPeerExchanges.Size = new System.Drawing.Size( 64, 13 );
            this.lblOutgoingPeerExchanges.TabIndex = 15;
            this.lblOutgoingPeerExchanges.Text = "15 outgoing";
            // 
            // lblIncomingPeerExchanges
            // 
            this.lblIncomingPeerExchanges.AutoSize = true;
            this.lblIncomingPeerExchanges.Location = new System.Drawing.Point( 26, 130 );
            this.lblIncomingPeerExchanges.Name = "lblIncomingPeerExchanges";
            this.lblIncomingPeerExchanges.Size = new System.Drawing.Size( 63, 13 );
            this.lblIncomingPeerExchanges.TabIndex = 14;
            this.lblIncomingPeerExchanges.Text = "25 incoming";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font( "Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point( 13, 109 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 116, 16 );
            this.label1.TabIndex = 13;
            this.label1.Text = "Peer exchanges:";
            // 
            // lblNumCommunications
            // 
            this.lblNumCommunications.AutoSize = true;
            this.lblNumCommunications.Location = new System.Drawing.Point( 272, 57 );
            this.lblNumCommunications.Name = "lblNumCommunications";
            this.lblNumCommunications.Size = new System.Drawing.Size( 126, 13 );
            this.lblNumCommunications.TabIndex = 12;
            this.lblNumCommunications.Text = "Communicated xxx times";
            // 
            // lblLastSeen
            // 
            this.lblLastSeen.AutoSize = true;
            this.lblLastSeen.Location = new System.Drawing.Point( 26, 57 );
            this.lblLastSeen.Name = "lblLastSeen";
            this.lblLastSeen.Size = new System.Drawing.Size( 137, 13 );
            this.lblLastSeen.TabIndex = 11;
            this.lblLastSeen.Text = "Last seen xxx seconds ago";
            // 
            // lblPeerName
            // 
            this.lblPeerName.AutoSize = true;
            this.lblPeerName.Font = new System.Drawing.Font( "Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.lblPeerName.Location = new System.Drawing.Point( 44, 15 );
            this.lblPeerName.Name = "lblPeerName";
            this.lblPeerName.Size = new System.Drawing.Size( 164, 25 );
            this.lblPeerName.TabIndex = 10;
            this.lblPeerName.Text = "Albert Einstein";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LANdrop.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point( 12, 12 );
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size( 32, 32 );
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // lblNumMulticast
            // 
            this.lblNumMulticast.AutoSize = true;
            this.lblNumMulticast.Location = new System.Drawing.Point( 331, 130 );
            this.lblNumMulticast.Name = "lblNumMulticast";
            this.lblNumMulticast.Size = new System.Drawing.Size( 64, 13 );
            this.lblNumMulticast.TabIndex = 22;
            this.lblNumMulticast.Text = "25 multicast";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font( "Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point( 321, 109 );
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size( 77, 16 );
            this.label6.TabIndex = 21;
            this.label6.Text = "Discovery:";
            // 
            // PeerInfoForm
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size( 456, 231 );
            this.Controls.Add( this.panel1 );
            this.Controls.Add( this.btnClose );
            this.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PeerInfoForm";
            this.Text = "About peer";
            this.panel1.ResumeLayout( false );
            this.panel1.PerformLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).EndInit( );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Timer updateInfoTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblOutgoingPeerExchanges;
        private System.Windows.Forms.Label lblIncomingPeerExchanges;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNumCommunications;
        private System.Windows.Forms.Label lblLastSeen;
        private System.Windows.Forms.Label lblPeerName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblNumOutgoingInquiries;
        private System.Windows.Forms.Label lblNumIncomingInquiries;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblNumMulticast;
        private System.Windows.Forms.Label label6;
    }
}