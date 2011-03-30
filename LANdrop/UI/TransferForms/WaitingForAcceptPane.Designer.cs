namespace LANdrop.UI.TransferForms
{
    partial class WaitingForAcceptPane
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
            this.lblHide = new System.Windows.Forms.LinkLabel( );
            this.lblTitle = new System.Windows.Forms.Label( );
            this.pictureBox1 = new System.Windows.Forms.PictureBox( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // lblCancel
            // 
            this.lblCancel.AutoSize = true;
            this.lblCancel.LinkColor = System.Drawing.Color.FromArgb( ( (int) ( ( (byte) ( 160 ) ) ) ), ( (int) ( ( (byte) ( 212 ) ) ) ), ( (int) ( ( (byte) ( 255 ) ) ) ) );
            this.lblCancel.Location = new System.Drawing.Point( 49, 37 );
            this.lblCancel.Name = "lblCancel";
            this.lblCancel.Size = new System.Drawing.Size( 39, 13 );
            this.lblCancel.TabIndex = 7;
            this.lblCancel.TabStop = true;
            this.lblCancel.Text = "Cancel";
            // 
            // lblHide
            // 
            this.lblHide.AutoSize = true;
            this.lblHide.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.lblHide.LinkColor = System.Drawing.Color.FromArgb( ( (int) ( ( (byte) ( 160 ) ) ) ), ( (int) ( ( (byte) ( 212 ) ) ) ), ( (int) ( ( (byte) ( 255 ) ) ) ) );
            this.lblHide.Location = new System.Drawing.Point( 94, 37 );
            this.lblHide.Name = "lblHide";
            this.lblHide.Size = new System.Drawing.Size( 28, 13 );
            this.lblHide.TabIndex = 6;
            this.lblHide.TabStop = true;
            this.lblHide.Text = "Hide";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font( "Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point( 48, 14 );
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size( 230, 19 );
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Waiting for {0} to accept...";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LANdrop.Properties.Resources.question;
            this.pictureBox1.Location = new System.Drawing.Point( 10, 16 );
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size( 32, 32 );
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // WaitingForAcceptPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb( ( (int) ( ( (byte) ( 64 ) ) ) ), ( (int) ( ( (byte) ( 64 ) ) ) ), ( (int) ( ( (byte) ( 64 ) ) ) ) );
            this.Controls.Add( this.lblCancel );
            this.Controls.Add( this.lblHide );
            this.Controls.Add( this.lblTitle );
            this.Controls.Add( this.pictureBox1 );
            this.Name = "WaitingForAcceptPane";
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).EndInit( );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblCancel;
        private System.Windows.Forms.LinkLabel lblHide;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
