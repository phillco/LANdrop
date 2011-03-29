namespace LANdrop.UI.TransferForms
{
    partial class TransferFailedPane
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
            this.lblHide = new System.Windows.Forms.LinkLabel( );
            this.lblTitle = new System.Windows.Forms.Label( );
            this.pictureBox1 = new System.Windows.Forms.PictureBox( );
            this.label1 = new System.Windows.Forms.Label( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // lblHide
            // 
            this.lblHide.AutoSize = true;
            this.lblHide.LinkColor = System.Drawing.Color.FromArgb( ( (int) ( ( (byte) ( 160 ) ) ) ), ( (int) ( ( (byte) ( 212 ) ) ) ), ( (int) ( ( (byte) ( 255 ) ) ) ) );
            this.lblHide.Location = new System.Drawing.Point( 7, 56 );
            this.lblHide.Name = "lblHide";
            this.lblHide.Size = new System.Drawing.Size( 51, 13 );
            this.lblHide.TabIndex = 7;
            this.lblHide.TabStop = true;
            this.lblHide.Text = "Hide (10)";
            this.lblHide.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.lblHide_LinkClicked );
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font( "Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point( 48, 14 );
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size( 185, 19 );
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Failed to send <file>!";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LANdrop.Properties.Resources.exclamation;
            this.pictureBox1.Location = new System.Drawing.Point( 10, 16 );
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size( 32, 32 );
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point( 49, 35 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 239, 13 );
            this.label1.TabIndex = 8;
            this.label1.Text = "A communications error occured during transfer.";
            // 
            // TransferFailedPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb( ( (int) ( ( (byte) ( 64 ) ) ) ), ( (int) ( ( (byte) ( 64 ) ) ) ), ( (int) ( ( (byte) ( 64 ) ) ) ) );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.lblHide );
            this.Controls.Add( this.lblTitle );
            this.Controls.Add( this.pictureBox1 );
            this.MinimumSize = new System.Drawing.Size( 335, 81 );
            this.Name = "TransferFailedPane";
            this.Size = new System.Drawing.Size( 335, 81 );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).EndInit( );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblHide;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}
