namespace LANdrop.UI
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( AboutForm ) );
            this.panel1 = new System.Windows.Forms.Panel( );
            this.panelUpdateError = new System.Windows.Forms.Panel( );
            this.label5 = new System.Windows.Forms.Label( );
            this.pictureBox3 = new System.Windows.Forms.PictureBox( );
            this.panelReadyToApply = new System.Windows.Forms.Panel( );
            this.llblApplyUpdate = new System.Windows.Forms.LinkLabel( );
            this.lblUpdateAvailable = new System.Windows.Forms.Label( );
            this.pictureBox2 = new System.Windows.Forms.PictureBox( );
            this.panelUpdateProgress = new System.Windows.Forms.Panel( );
            this.lblCheckingForUpdates = new System.Windows.Forms.Label( );
            this.pbUpdateProgress = new System.Windows.Forms.ProgressBar( );
            this.panelUpToDate = new System.Windows.Forms.Panel( );
            this.llblCheckUpdate = new System.Windows.Forms.LinkLabel( );
            this.lblUpdateStatus = new System.Windows.Forms.Label( );
            this.pbReportSentStatus = new System.Windows.Forms.PictureBox( );
            this.label3 = new System.Windows.Forms.Label( );
            this.lblTrademark = new System.Windows.Forms.Label( );
            this.label2 = new System.Windows.Forms.Label( );
            this.lblBuildInfo = new System.Windows.Forms.Label( );
            this.label1 = new System.Windows.Forms.Label( );
            this.lblProgramVersion = new System.Windows.Forms.Label( );
            this.pictureBox1 = new System.Windows.Forms.PictureBox( );
            this.btnClose = new System.Windows.Forms.Button( );
            this.checkBox1 = new System.Windows.Forms.CheckBox( );
            this.updateRefreshLinkTimer = new System.Windows.Forms.Timer( this.components );
            this.panel1.SuspendLayout( );
            this.panelUpdateError.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox3 ) ).BeginInit( );
            this.panelReadyToApply.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox2 ) ).BeginInit( );
            this.panelUpdateProgress.SuspendLayout( );
            this.panelUpToDate.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pbReportSentStatus ) ).BeginInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add( this.panelUpdateError );
            this.panel1.Controls.Add( this.panelReadyToApply );
            this.panel1.Controls.Add( this.panelUpdateProgress );
            this.panel1.Controls.Add( this.panelUpToDate );
            this.panel1.Controls.Add( this.label3 );
            this.panel1.Controls.Add( this.lblTrademark );
            this.panel1.Controls.Add( this.label2 );
            this.panel1.Controls.Add( this.lblBuildInfo );
            this.panel1.Controls.Add( this.label1 );
            this.panel1.Controls.Add( this.lblProgramVersion );
            this.panel1.Controls.Add( this.pictureBox1 );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point( 0, 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 408, 143 );
            this.panel1.TabIndex = 1;
            // 
            // panelUpdateError
            // 
            this.panelUpdateError.Controls.Add( this.label5 );
            this.panelUpdateError.Controls.Add( this.pictureBox3 );
            this.panelUpdateError.Location = new System.Drawing.Point( 255, 36 );
            this.panelUpdateError.Name = "panelUpdateError";
            this.panelUpdateError.Size = new System.Drawing.Size( 141, 22 );
            this.panelUpdateError.TabIndex = 21;
            this.panelUpdateError.Visible = false;
            // 
            // label5
            // 
            this.label5.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.label5.Location = new System.Drawing.Point( 21, 4 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 117, 13 );
            this.label5.TabIndex = 18;
            this.label5.Text = "Error during update";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.pictureBox3.Image = global::LANdrop.Properties.Resources.error16;
            this.pictureBox3.Location = new System.Drawing.Point( 4, 2 );
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size( 16, 16 );
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 17;
            this.pictureBox3.TabStop = false;
            // 
            // panelReadyToApply
            // 
            this.panelReadyToApply.Controls.Add( this.llblApplyUpdate );
            this.panelReadyToApply.Controls.Add( this.lblUpdateAvailable );
            this.panelReadyToApply.Controls.Add( this.pictureBox2 );
            this.panelReadyToApply.Location = new System.Drawing.Point( 209, 85 );
            this.panelReadyToApply.Name = "panelReadyToApply";
            this.panelReadyToApply.Size = new System.Drawing.Size( 187, 22 );
            this.panelReadyToApply.TabIndex = 21;
            this.panelReadyToApply.Visible = false;
            // 
            // llblApplyUpdate
            // 
            this.llblApplyUpdate.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.llblApplyUpdate.AutoSize = true;
            this.llblApplyUpdate.Location = new System.Drawing.Point( 127, 4 );
            this.llblApplyUpdate.Name = "llblApplyUpdate";
            this.llblApplyUpdate.Size = new System.Drawing.Size( 57, 13 );
            this.llblApplyUpdate.TabIndex = 19;
            this.llblApplyUpdate.TabStop = true;
            this.llblApplyUpdate.Text = "Apply now";
            this.llblApplyUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.llblApplyUpdate_LinkClicked );
            // 
            // lblUpdateAvailable
            // 
            this.lblUpdateAvailable.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.lblUpdateAvailable.AutoSize = true;
            this.lblUpdateAvailable.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.lblUpdateAvailable.Location = new System.Drawing.Point( 22, 4 );
            this.lblUpdateAvailable.Name = "lblUpdateAvailable";
            this.lblUpdateAvailable.Size = new System.Drawing.Size( 105, 13 );
            this.lblUpdateAvailable.TabIndex = 18;
            this.lblUpdateAvailable.Text = "Update available!";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.pictureBox2.Image = global::LANdrop.Properties.Resources.arrow_refresh;
            this.pictureBox2.Location = new System.Drawing.Point( 5, 3 );
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size( 16, 16 );
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // panelUpdateProgress
            // 
            this.panelUpdateProgress.Controls.Add( this.lblCheckingForUpdates );
            this.panelUpdateProgress.Controls.Add( this.pbUpdateProgress );
            this.panelUpdateProgress.Location = new System.Drawing.Point( 214, 109 );
            this.panelUpdateProgress.Name = "panelUpdateProgress";
            this.panelUpdateProgress.Size = new System.Drawing.Size( 182, 22 );
            this.panelUpdateProgress.TabIndex = 21;
            this.panelUpdateProgress.Visible = false;
            // 
            // lblCheckingForUpdates
            // 
            this.lblCheckingForUpdates.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.lblCheckingForUpdates.AutoSize = true;
            this.lblCheckingForUpdates.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.lblCheckingForUpdates.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblCheckingForUpdates.Location = new System.Drawing.Point( 1, 4 );
            this.lblCheckingForUpdates.Name = "lblCheckingForUpdates";
            this.lblCheckingForUpdates.Size = new System.Drawing.Size( 121, 13 );
            this.lblCheckingForUpdates.TabIndex = 20;
            this.lblCheckingForUpdates.Text = "Checking for updates...";
            // 
            // pbUpdateProgress
            // 
            this.pbUpdateProgress.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.pbUpdateProgress.Location = new System.Drawing.Point( 124, 4 );
            this.pbUpdateProgress.MarqueeAnimationSpeed = 600;
            this.pbUpdateProgress.Name = "pbUpdateProgress";
            this.pbUpdateProgress.Size = new System.Drawing.Size( 52, 13 );
            this.pbUpdateProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbUpdateProgress.TabIndex = 19;
            this.pbUpdateProgress.Value = 30;
            // 
            // panelUpToDate
            // 
            this.panelUpToDate.Controls.Add( this.llblCheckUpdate );
            this.panelUpToDate.Controls.Add( this.lblUpdateStatus );
            this.panelUpToDate.Controls.Add( this.pbReportSentStatus );
            this.panelUpToDate.Location = new System.Drawing.Point( 247, 62 );
            this.panelUpToDate.Name = "panelUpToDate";
            this.panelUpToDate.Size = new System.Drawing.Size( 149, 22 );
            this.panelUpToDate.TabIndex = 20;
            this.panelUpToDate.Visible = false;
            // 
            // llblCheckUpdate
            // 
            this.llblCheckUpdate.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.llblCheckUpdate.AutoSize = true;
            this.llblCheckUpdate.Location = new System.Drawing.Point( 87, 4 );
            this.llblCheckUpdate.Name = "llblCheckUpdate";
            this.llblCheckUpdate.Size = new System.Drawing.Size( 59, 13 );
            this.llblCheckUpdate.TabIndex = 19;
            this.llblCheckUpdate.TabStop = true;
            this.llblCheckUpdate.Text = "Check now";
            this.llblCheckUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.llblCheckUpdate_LinkClicked );
            // 
            // lblUpdateStatus
            // 
            this.lblUpdateStatus.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.lblUpdateStatus.AutoSize = true;
            this.lblUpdateStatus.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.lblUpdateStatus.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblUpdateStatus.Location = new System.Drawing.Point( 19, 4 );
            this.lblUpdateStatus.Name = "lblUpdateStatus";
            this.lblUpdateStatus.Size = new System.Drawing.Size( 66, 13 );
            this.lblUpdateStatus.TabIndex = 18;
            this.lblUpdateStatus.Text = "Up to date";
            // 
            // pbReportSentStatus
            // 
            this.pbReportSentStatus.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.pbReportSentStatus.Image = global::LANdrop.Properties.Resources.accept16;
            this.pbReportSentStatus.Location = new System.Drawing.Point( 2, 2 );
            this.pbReportSentStatus.Name = "pbReportSentStatus";
            this.pbReportSentStatus.Size = new System.Drawing.Size( 16, 16 );
            this.pbReportSentStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbReportSentStatus.TabIndex = 17;
            this.pbReportSentStatus.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point( 211, 24 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 82, 13 );
            this.label3.TabIndex = 4;
            this.label3.Text = "by Phillip Cohen";
            // 
            // lblTrademark
            // 
            this.lblTrademark.AutoSize = true;
            this.lblTrademark.Location = new System.Drawing.Point( 132, 41 );
            this.lblTrademark.Name = "lblTrademark";
            this.lblTrademark.Size = new System.Drawing.Size( 184, 13 );
            this.lblTrademark.TabIndex = 4;
            this.lblTrademark.Text = "Blazing-fast file transfers over LAN™";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font( "Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.label2.Location = new System.Drawing.Point( 131, 19 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 79, 19 );
            this.label2.TabIndex = 3;
            this.label2.Text = "LANdrop";
            // 
            // lblBuildInfo
            // 
            this.lblBuildInfo.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.lblBuildInfo.AutoSize = true;
            this.lblBuildInfo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblBuildInfo.Location = new System.Drawing.Point( 12, 118 );
            this.lblBuildInfo.Name = "lblBuildInfo";
            this.lblBuildInfo.Size = new System.Drawing.Size( 112, 13 );
            this.lblBuildInfo.TabIndex = 6;
            this.lblBuildInfo.Text = "Development build #5";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point( 0, 141 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 500, 2 );
            this.label1.TabIndex = 2;
            // 
            // lblProgramVersion
            // 
            this.lblProgramVersion.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.lblProgramVersion.AutoSize = true;
            this.lblProgramVersion.Font = new System.Drawing.Font( "Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.lblProgramVersion.Location = new System.Drawing.Point( 12, 102 );
            this.lblProgramVersion.Name = "lblProgramVersion";
            this.lblProgramVersion.Size = new System.Drawing.Size( 48, 16 );
            this.lblProgramVersion.TabIndex = 5;
            this.lblProgramVersion.Text = "v1.1.1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LANdrop.Properties.Resources.draw_calligraphic;
            this.pictureBox1.Location = new System.Drawing.Point( 93, 22 );
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size( 32, 32 );
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point( 321, 151 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 75, 25 );
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point( 12, 156 );
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size( 97, 17 );
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "I love LANdrop";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // updateRefreshLinkTimer
            // 
            this.updateRefreshLinkTimer.Tick += new System.EventHandler( this.updateTimer_Tick );
            // 
            // AboutForm
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size( 408, 185 );
            this.Controls.Add( this.checkBox1 );
            this.Controls.Add( this.btnClose );
            this.Controls.Add( this.panel1 );
            this.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ( (System.Drawing.Icon) ( resources.GetObject( "$this.Icon" ) ) );
            this.MaximizeBox = false;
            this.Name = "AboutForm";
            this.Text = "About LANdrop";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.AboutForm_FormClosing );
            this.panel1.ResumeLayout( false );
            this.panel1.PerformLayout( );
            this.panelUpdateError.ResumeLayout( false );
            this.panelUpdateError.PerformLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox3 ) ).EndInit( );
            this.panelReadyToApply.ResumeLayout( false );
            this.panelReadyToApply.PerformLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox2 ) ).EndInit( );
            this.panelUpdateProgress.ResumeLayout( false );
            this.panelUpdateProgress.PerformLayout( );
            this.panelUpToDate.ResumeLayout( false );
            this.panelUpToDate.PerformLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pbReportSentStatus ) ).EndInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).EndInit( );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label lblProgramVersion;
        private System.Windows.Forms.Label lblBuildInfo;
        private System.Windows.Forms.Label lblTrademark;
        private System.Windows.Forms.Panel panelUpToDate;
        private System.Windows.Forms.Label lblUpdateStatus;
        private System.Windows.Forms.PictureBox pbReportSentStatus;
        private System.Windows.Forms.Panel panelUpdateProgress;
        private System.Windows.Forms.Label lblCheckingForUpdates;
        private System.Windows.Forms.ProgressBar pbUpdateProgress;
        private System.Windows.Forms.Panel panelReadyToApply;
        private System.Windows.Forms.LinkLabel llblApplyUpdate;
        private System.Windows.Forms.Label lblUpdateAvailable;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.LinkLabel llblCheckUpdate;
        private System.Windows.Forms.Timer updateRefreshLinkTimer;
        private System.Windows.Forms.Panel panelUpdateError;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}