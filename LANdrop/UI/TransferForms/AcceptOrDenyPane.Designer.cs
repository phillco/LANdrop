namespace LANdrop.UI.TransferForms
{
    partial class AcceptOrDenyPane
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
            this.lblReject = new System.Windows.Forms.LinkLabel( );
            this.lblAccept = new System.Windows.Forms.LinkLabel( );
            this.lblTitle = new System.Windows.Forms.Label( );
            this.pictureBox1 = new System.Windows.Forms.PictureBox( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // lblReject
            // 
            this.lblReject.AutoSize = true;
            this.lblReject.LinkColor = System.Drawing.Color.FromArgb( ( (int) ( ( (byte) ( 160 ) ) ) ), ( (int) ( ( (byte) ( 212 ) ) ) ), ( (int) ( ( (byte) ( 255 ) ) ) ) );
            this.lblReject.Location = new System.Drawing.Point( 103, 37 );
            this.lblReject.Name = "lblReject";
            this.lblReject.Size = new System.Drawing.Size( 55, 13 );
            this.lblReject.TabIndex = 7;
            this.lblReject.TabStop = true;
            this.lblReject.Text = "Reject (5)";
            this.lblReject.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.lblReject_LinkClicked );
            // 
            // lblAccept
            // 
            this.lblAccept.AutoSize = true;
            this.lblAccept.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.lblAccept.LinkColor = System.Drawing.Color.FromArgb( ( (int) ( ( (byte) ( 160 ) ) ) ), ( (int) ( ( (byte) ( 212 ) ) ) ), ( (int) ( ( (byte) ( 255 ) ) ) ) );
            this.lblAccept.Location = new System.Drawing.Point( 55, 37 );
            this.lblAccept.Name = "lblAccept";
            this.lblAccept.Size = new System.Drawing.Size( 40, 13 );
            this.lblAccept.TabIndex = 6;
            this.lblAccept.TabStop = true;
            this.lblAccept.Text = "Accept";
            this.lblAccept.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.lblAccept_LinkClicked );
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font( "Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point( 48, 14 );
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size( 321, 19 );
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "<Name> would like to send us <file>.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LANdrop.Properties.Resources.add;
            this.pictureBox1.Location = new System.Drawing.Point( 10, 16 );
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size( 32, 32 );
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // AcceptOrDenyPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb( ( (int) ( ( (byte) ( 64 ) ) ) ), ( (int) ( ( (byte) ( 64 ) ) ) ), ( (int) ( ( (byte) ( 64 ) ) ) ) );
            this.Controls.Add( this.lblReject );
            this.Controls.Add( this.lblAccept );
            this.Controls.Add( this.lblTitle );
            this.Controls.Add( this.pictureBox1 );
            this.Name = "AcceptOrDenyPane";
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).EndInit( );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblReject;
        private System.Windows.Forms.LinkLabel lblAccept;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
