namespace LANdrop.UI
{
    partial class UpdateAppliedNotification
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            this.components = new System.ComponentModel.Container( );
            this.pictureBox1 = new System.Windows.Forms.PictureBox( );
            this.lblTitle = new System.Windows.Forms.Label( );
            this.lblUpdateDetails = new System.Windows.Forms.Label( );
            this.hideTimer = new System.Windows.Forms.Timer( this.components );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LANdrop.Properties.Resources.landropUpdated;
            this.pictureBox1.Location = new System.Drawing.Point( 13, 12 );
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size( 27, 32 );
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font( "Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point( 46, 10 );
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size( 156, 19 );
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "LANdrop updated!";
            // 
            // lblUpdateDetails
            // 
            this.lblUpdateDetails.AutoSize = true;
            this.lblUpdateDetails.ForeColor = System.Drawing.Color.DarkGray;
            this.lblUpdateDetails.Location = new System.Drawing.Point( 50, 31 );
            this.lblUpdateDetails.Name = "lblUpdateDetails";
            this.lblUpdateDetails.Size = new System.Drawing.Size( 111, 13 );
            this.lblUpdateDetails.TabIndex = 12;
            this.lblUpdateDetails.Text = "Welcome to dev #54.";
            // 
            // hideTimer
            // 
            this.hideTimer.Enabled = true;
            this.hideTimer.Interval = 5000;
            this.hideTimer.Tick += new System.EventHandler( this.hideTimer_Tick );
            // 
            // UpdateAppliedNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.lblUpdateDetails );
            this.Controls.Add( this.lblTitle );
            this.Controls.Add( this.pictureBox1 );
            this.Name = "UpdateAppliedNotification";
            this.Size = new System.Drawing.Size( 217, 57 );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).EndInit( );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUpdateDetails;
        private System.Windows.Forms.Timer hideTimer;
    }
}
