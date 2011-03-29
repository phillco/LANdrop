namespace LANdrop.UI.TransferForms
{
    partial class ProgressPane
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
            this.lblCancel = new System.Windows.Forms.LinkLabel( );
            this.lblTitle = new System.Windows.Forms.Label( );
            this.pictureBox1 = new System.Windows.Forms.PictureBox( );
            this.pbFileProgress = new System.Windows.Forms.ProgressBar( );
            this.lblProgress = new System.Windows.Forms.Label( );
            this.lblSpeed = new System.Windows.Forms.Label( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // lblCancel
            // 
            this.lblCancel.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.lblCancel.AutoSize = true;
            this.lblCancel.LinkColor = System.Drawing.Color.FromArgb( ( (int) ( ( (byte) ( 160 ) ) ) ), ( (int) ( ( (byte) ( 212 ) ) ) ), ( (int) ( ( (byte) ( 255 ) ) ) ) );
            this.lblCancel.Location = new System.Drawing.Point( 7, 58 );
            this.lblCancel.Name = "lblCancel";
            this.lblCancel.Size = new System.Drawing.Size( 39, 13 );
            this.lblCancel.TabIndex = 7;
            this.lblCancel.TabStop = true;
            this.lblCancel.Text = "Cancel";
            this.lblCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.lblCancel_LinkClicked );
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font( "Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point( 48, 14 );
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size( 160, 19 );
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Receiving <file>...";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LANdrop.Properties.Resources.document_page_next;
            this.pictureBox1.Location = new System.Drawing.Point( 10, 16 );
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size( 32, 32 );
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pbFileProgress
            // 
            this.pbFileProgress.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.pbFileProgress.Location = new System.Drawing.Point( 52, 60 );
            this.pbFileProgress.MarqueeAnimationSpeed = 60;
            this.pbFileProgress.Name = "pbFileProgress";
            this.pbFileProgress.Size = new System.Drawing.Size( 257, 13 );
            this.pbFileProgress.TabIndex = 8;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.ForeColor = System.Drawing.Color.DarkGray;
            this.lblProgress.Location = new System.Drawing.Point( 49, 37 );
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size( 165, 13 );
            this.lblProgress.TabIndex = 9;
            this.lblProgress.Text = "30 MB of 45 MB (12 seconds left)";
            // 
            // lblSpeed
            // 
            this.lblSpeed.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblSpeed.Location = new System.Drawing.Point( 315, 60 );
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size( 49, 13 );
            this.lblSpeed.TabIndex = 10;
            this.lblSpeed.Text = "987 KB/s";
            // 
            // ProgressPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb( ( (int) ( ( (byte) ( 64 ) ) ) ), ( (int) ( ( (byte) ( 64 ) ) ) ), ( (int) ( ( (byte) ( 64 ) ) ) ) );
            this.Controls.Add( this.lblSpeed );
            this.Controls.Add( this.lblProgress );
            this.Controls.Add( this.pbFileProgress );
            this.Controls.Add( this.lblCancel );
            this.Controls.Add( this.lblTitle );
            this.Controls.Add( this.pictureBox1 );
            this.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.MinimumSize = new System.Drawing.Size( 390, 82 );
            this.Name = "ProgressPane";
            this.Size = new System.Drawing.Size( 390, 85 );
            this.Load += new System.EventHandler( this.TransferPane_Load );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).EndInit( );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblCancel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar pbFileProgress;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label lblSpeed;
    }
}
