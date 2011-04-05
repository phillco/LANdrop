namespace LANdrop.UI
{
    partial class ErrorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( ErrorForm ) );
            this.panel2 = new System.Windows.Forms.Panel( );
            this.lblBottomDivide = new System.Windows.Forms.Label( );
            this.btnExit = new System.Windows.Forms.Button( );
            this.btnRestart = new System.Windows.Forms.Button( );
            this.lblDescription = new System.Windows.Forms.Label( );
            this.lblTitle = new System.Windows.Forms.Label( );
            this.pbSubmitProgress = new System.Windows.Forms.ProgressBar( );
            this.lblSubmitting = new System.Windows.Forms.Label( );
            this.bugReporter = new System.ComponentModel.BackgroundWorker( );
            this.lblDeveloperResponse = new System.Windows.Forms.Label( );
            this.pbReportSentStatus = new System.Windows.Forms.PictureBox( );
            this.pbIcon = new System.Windows.Forms.PictureBox( );
            this.lblReportSent = new System.Windows.Forms.Label( );
            this.panelReportSent = new System.Windows.Forms.Panel( );
            this.hideMainFormTimer = new System.Windows.Forms.Timer( this.components );
            this.panelReportFailed = new System.Windows.Forms.Panel( );
            this.llblRetrySend = new System.Windows.Forms.LinkLabel( );
            this.label1 = new System.Windows.Forms.Label( );
            this.pbReportSentErrorIcon = new System.Windows.Forms.PictureBox( );
            this.panel2.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pbReportSentStatus ) ).BeginInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pbIcon ) ).BeginInit( );
            this.panelReportSent.SuspendLayout( );
            this.panelReportFailed.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pbReportSentErrorIcon ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add( this.lblBottomDivide );
            this.panel2.Controls.Add( this.btnExit );
            this.panel2.Controls.Add( this.btnRestart );
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point( 0, 153 );
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size( 437, 47 );
            this.panel2.TabIndex = 10;
            // 
            // lblBottomDivide
            // 
            this.lblBottomDivide.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBottomDivide.Location = new System.Drawing.Point( -2, 0 );
            this.lblBottomDivide.Name = "lblBottomDivide";
            this.lblBottomDivide.Size = new System.Drawing.Size( 500, 2 );
            this.lblBottomDivide.TabIndex = 14;
            this.lblBottomDivide.Text = " ";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point( 350, 10 );
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size( 75, 25 );
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler( this.btnExit_Click );
            // 
            // btnRestart
            // 
            this.btnRestart.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnRestart.Location = new System.Drawing.Point( 271, 10 );
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size( 75, 25 );
            this.btnRestart.TabIndex = 4;
            this.btnRestart.Text = "Continue";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler( this.btnRestart_Click );
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDescription.Location = new System.Drawing.Point( 60, 41 );
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size( 236, 13 );
            this.lblDescription.TabIndex = 12;
            this.lblDescription.Text = "LANdrop had a slight hickup, but should be fine.";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font( "Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point( 60, 21 );
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size( 132, 16 );
            this.lblTitle.TabIndex = 11;
            this.lblTitle.Text = "Just so you know...";
            // 
            // pbSubmitProgress
            // 
            this.pbSubmitProgress.Location = new System.Drawing.Point( 179, 81 );
            this.pbSubmitProgress.MarqueeAnimationSpeed = 20;
            this.pbSubmitProgress.Name = "pbSubmitProgress";
            this.pbSubmitProgress.Size = new System.Drawing.Size( 129, 13 );
            this.pbSubmitProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbSubmitProgress.TabIndex = 15;
            this.pbSubmitProgress.Value = 30;
            // 
            // lblSubmitting
            // 
            this.lblSubmitting.AutoSize = true;
            this.lblSubmitting.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.lblSubmitting.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblSubmitting.Location = new System.Drawing.Point( 14, 81 );
            this.lblSubmitting.Name = "lblSubmitting";
            this.lblSubmitting.Size = new System.Drawing.Size( 159, 13 );
            this.lblSubmitting.TabIndex = 15;
            this.lblSubmitting.Text = "Submitting bug to developers...";
            // 
            // bugReporter
            // 
            this.bugReporter.DoWork += new System.ComponentModel.DoWorkEventHandler( this.bugReporter_DoWork );
            this.bugReporter.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler( this.bugReporter_RunWorkerCompleted );
            // 
            // lblDeveloperResponse
            // 
            this.lblDeveloperResponse.Location = new System.Drawing.Point( 14, 103 );
            this.lblDeveloperResponse.Name = "lblDeveloperResponse";
            this.lblDeveloperResponse.Size = new System.Drawing.Size( 411, 36 );
            this.lblDeveloperResponse.TabIndex = 16;
            this.lblDeveloperResponse.Text = "Developer Response: oops";
            this.lblDeveloperResponse.Visible = false;
            // 
            // pbReportSentStatus
            // 
            this.pbReportSentStatus.Image = global::LANdrop.Properties.Resources.accept16;
            this.pbReportSentStatus.Location = new System.Drawing.Point( 3, 2 );
            this.pbReportSentStatus.Name = "pbReportSentStatus";
            this.pbReportSentStatus.Size = new System.Drawing.Size( 16, 16 );
            this.pbReportSentStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbReportSentStatus.TabIndex = 17;
            this.pbReportSentStatus.TabStop = false;
            // 
            // pbIcon
            // 
            this.pbIcon.Image = global::LANdrop.Properties.Resources.landropError;
            this.pbIcon.Location = new System.Drawing.Point( 17, 21 );
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size( 32, 32 );
            this.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbIcon.TabIndex = 13;
            this.pbIcon.TabStop = false;
            // 
            // lblReportSent
            // 
            this.lblReportSent.AutoSize = true;
            this.lblReportSent.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.lblReportSent.Location = new System.Drawing.Point( 20, 4 );
            this.lblReportSent.Name = "lblReportSent";
            this.lblReportSent.Size = new System.Drawing.Size( 77, 13 );
            this.lblReportSent.TabIndex = 18;
            this.lblReportSent.Text = "Report sent!";
            // 
            // panelReportSent
            // 
            this.panelReportSent.Controls.Add( this.lblReportSent );
            this.panelReportSent.Controls.Add( this.pbReportSentStatus );
            this.panelReportSent.Location = new System.Drawing.Point( 13, 76 );
            this.panelReportSent.Name = "panelReportSent";
            this.panelReportSent.Size = new System.Drawing.Size( 102, 22 );
            this.panelReportSent.TabIndex = 19;
            this.panelReportSent.Visible = false;
            // 
            // hideMainFormTimer
            // 
            this.hideMainFormTimer.Enabled = true;
            this.hideMainFormTimer.Tick += new System.EventHandler( this.hideMainFormTimer_Tick );
            // 
            // panelReportFailed
            // 
            this.panelReportFailed.Controls.Add( this.llblRetrySend );
            this.panelReportFailed.Controls.Add( this.label1 );
            this.panelReportFailed.Controls.Add( this.pbReportSentErrorIcon );
            this.panelReportFailed.Location = new System.Drawing.Point( 12, 76 );
            this.panelReportFailed.Name = "panelReportFailed";
            this.panelReportFailed.Size = new System.Drawing.Size( 371, 22 );
            this.panelReportFailed.TabIndex = 20;
            this.panelReportFailed.Visible = false;
            // 
            // llblRetrySend
            // 
            this.llblRetrySend.AutoSize = true;
            this.llblRetrySend.Location = new System.Drawing.Point( 246, 4 );
            this.llblRetrySend.Name = "llblRetrySend";
            this.llblRetrySend.Size = new System.Drawing.Size( 34, 13 );
            this.llblRetrySend.TabIndex = 19;
            this.llblRetrySend.TabStop = true;
            this.llblRetrySend.Text = "Retry";
            this.llblRetrySend.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.llblRetrySend_LinkClicked );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.label1.Location = new System.Drawing.Point( 20, 4 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 225, 13 );
            this.label1.TabIndex = 18;
            this.label1.Text = "There was an error sending the report.";
            // 
            // pbReportSentErrorIcon
            // 
            this.pbReportSentErrorIcon.Image = global::LANdrop.Properties.Resources.error16;
            this.pbReportSentErrorIcon.Location = new System.Drawing.Point( 3, 2 );
            this.pbReportSentErrorIcon.Name = "pbReportSentErrorIcon";
            this.pbReportSentErrorIcon.Size = new System.Drawing.Size( 16, 16 );
            this.pbReportSentErrorIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbReportSentErrorIcon.TabIndex = 17;
            this.pbReportSentErrorIcon.TabStop = false;
            // 
            // ErrorForm
            // 
            this.AcceptButton = this.btnRestart;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size( 437, 200 );
            this.Controls.Add( this.panelReportFailed );
            this.Controls.Add( this.panelReportSent );
            this.Controls.Add( this.lblDeveloperResponse );
            this.Controls.Add( this.lblSubmitting );
            this.Controls.Add( this.pbSubmitProgress );
            this.Controls.Add( this.pbIcon );
            this.Controls.Add( this.lblDescription );
            this.Controls.Add( this.lblTitle );
            this.Controls.Add( this.panel2 );
            this.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ( (System.Drawing.Icon) ( resources.GetObject( "$this.Icon" ) ) );
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size( 430, 190 );
            this.Name = "ErrorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LANdrop Error";
            this.Resize += new System.EventHandler( this.ErrorForm_Resize );
            this.panel2.ResumeLayout( false );
            ( (System.ComponentModel.ISupportInitialize) ( this.pbReportSentStatus ) ).EndInit( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pbIcon ) ).EndInit( );
            this.panelReportSent.ResumeLayout( false );
            this.panelReportSent.PerformLayout( );
            this.panelReportFailed.ResumeLayout( false );
            this.panelReportFailed.PerformLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pbReportSentErrorIcon ) ).EndInit( );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Label lblBottomDivide;
        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubmitting;
        private System.Windows.Forms.ProgressBar pbSubmitProgress;
        private System.ComponentModel.BackgroundWorker bugReporter;
        private System.Windows.Forms.Label lblDeveloperResponse;
        private System.Windows.Forms.PictureBox pbReportSentStatus;
        private System.Windows.Forms.Label lblReportSent;
        private System.Windows.Forms.Panel panelReportSent;
        private System.Windows.Forms.Timer hideMainFormTimer;
        private System.Windows.Forms.Panel panelReportFailed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbReportSentErrorIcon;
        private System.Windows.Forms.LinkLabel llblRetrySend;
    }
}