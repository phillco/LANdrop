namespace LANdrop.UI.TransferForms
{
    partial class TransferCompletePane
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
            this.lblOpen = new System.Windows.Forms.LinkLabel( );
            this.lblTitle = new System.Windows.Forms.Label( );
            this.pictureBox1 = new System.Windows.Forms.PictureBox( );
            this.lblOpenFolder = new System.Windows.Forms.LinkLabel( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // lblHide
            // 
            this.lblHide.AutoSize = true;
            this.lblHide.LinkColor = System.Drawing.Color.FromArgb( ( (int) ( ( (byte) ( 160 ) ) ) ), ( (int) ( ( (byte) ( 212 ) ) ) ), ( (int) ( ( (byte) ( 255 ) ) ) ) );
            this.lblHide.Location = new System.Drawing.Point( 175, 37 );
            this.lblHide.Name = "lblHide";
            this.lblHide.Size = new System.Drawing.Size( 51, 13 );
            this.lblHide.TabIndex = 7;
            this.lblHide.TabStop = true;
            this.lblHide.Text = "Hide (10)";
            this.lblHide.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.lblHide_LinkClicked );
            // 
            // lblOpen
            // 
            this.lblOpen.AutoSize = true;
            this.lblOpen.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.lblOpen.LinkColor = System.Drawing.Color.FromArgb( ( (int) ( ( (byte) ( 160 ) ) ) ), ( (int) ( ( (byte) ( 212 ) ) ) ), ( (int) ( ( (byte) ( 255 ) ) ) ) );
            this.lblOpen.Location = new System.Drawing.Point( 55, 37 );
            this.lblOpen.Name = "lblOpen";
            this.lblOpen.Size = new System.Drawing.Size( 33, 13 );
            this.lblOpen.TabIndex = 6;
            this.lblOpen.TabStop = true;
            this.lblOpen.Text = "Open";
            this.lblOpen.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.lblOpen_LinkClicked );
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font( "Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point( 48, 14 );
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size( 166, 19 );
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Transfer Complete!";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LANdrop.Properties.Resources.accept;
            this.pictureBox1.Location = new System.Drawing.Point( 10, 16 );
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size( 32, 32 );
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // lblOpenFolder
            // 
            this.lblOpenFolder.AutoSize = true;
            this.lblOpenFolder.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.lblOpenFolder.LinkColor = System.Drawing.Color.FromArgb( ( (int) ( ( (byte) ( 160 ) ) ) ), ( (int) ( ( (byte) ( 212 ) ) ) ), ( (int) ( ( (byte) ( 255 ) ) ) ) );
            this.lblOpenFolder.Location = new System.Drawing.Point( 94, 37 );
            this.lblOpenFolder.Name = "lblOpenFolder";
            this.lblOpenFolder.Size = new System.Drawing.Size( 75, 13 );
            this.lblOpenFolder.TabIndex = 8;
            this.lblOpenFolder.TabStop = true;
            this.lblOpenFolder.Text = "Open in folder";
            this.lblOpenFolder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.lblOpenFolder_LinkClicked );
            // 
            // TransferCompletePane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb( ( (int) ( ( (byte) ( 64 ) ) ) ), ( (int) ( ( (byte) ( 64 ) ) ) ), ( (int) ( ( (byte) ( 64 ) ) ) ) );
            this.Controls.Add( this.lblOpenFolder );
            this.Controls.Add( this.lblHide );
            this.Controls.Add( this.lblOpen );
            this.Controls.Add( this.lblTitle );
            this.Controls.Add( this.pictureBox1 );
            this.Name = "TransferCompletePane";
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).EndInit( );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblHide;
        private System.Windows.Forms.LinkLabel lblOpen;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel lblOpenFolder;
    }
}
