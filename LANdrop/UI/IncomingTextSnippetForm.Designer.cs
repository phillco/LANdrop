namespace LANdrop.UI
{
    partial class IncomingTextSnippetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( IncomingTextSnippetForm ) );
            this.pictureBox1 = new System.Windows.Forms.PictureBox( );
            this.lblTitle = new System.Windows.Forms.Label( );
            this.btnCopy = new System.Windows.Forms.Button( );
            this.tbSnippet = new System.Windows.Forms.TextBox( );
            this.btnDiscard = new System.Windows.Forms.Button( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LANdrop.Properties.Resources.add;
            this.pictureBox1.Location = new System.Drawing.Point( 12, 16 );
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size( 32, 32 );
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font( "Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTitle.Location = new System.Drawing.Point( 50, 16 );
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size( 176, 16 );
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Received from somebody:";
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnCopy.Location = new System.Drawing.Point( 286, 173 );
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size( 110, 25 );
            this.btnCopy.TabIndex = 7;
            this.btnCopy.Text = "Copy to Clipboard";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler( this.btnCopy_Click );
            // 
            // tbSnippet
            // 
            this.tbSnippet.Location = new System.Drawing.Point( 53, 42 );
            this.tbSnippet.Multiline = true;
            this.tbSnippet.Name = "tbSnippet";
            this.tbSnippet.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSnippet.Size = new System.Drawing.Size( 342, 121 );
            this.tbSnippet.TabIndex = 8;
            this.tbSnippet.TextChanged += new System.EventHandler( this.tbSnippet_TextChanged );
            // 
            // btnDiscard
            // 
            this.btnDiscard.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnDiscard.Location = new System.Drawing.Point( 211, 173 );
            this.btnDiscard.Name = "btnDiscard";
            this.btnDiscard.Size = new System.Drawing.Size( 69, 25 );
            this.btnDiscard.TabIndex = 9;
            this.btnDiscard.Text = "Discard";
            this.btnDiscard.UseVisualStyleBackColor = true;
            this.btnDiscard.Click += new System.EventHandler( this.btnDiscard_Click );
            // 
            // IncomingTextSnippetForm
            // 
            this.AcceptButton = this.btnCopy;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 417, 210 );
            this.Controls.Add( this.btnDiscard );
            this.Controls.Add( this.tbSnippet );
            this.Controls.Add( this.btnCopy );
            this.Controls.Add( this.lblTitle );
            this.Controls.Add( this.pictureBox1 );
            this.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ( (System.Drawing.Icon) ( resources.GetObject( "$this.Icon" ) ) );
            this.MaximizeBox = false;
            this.Name = "IncomingTextSnippetForm";
            this.Text = "Received text snippet";
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).EndInit( );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.TextBox tbSnippet;
        private System.Windows.Forms.Button btnDiscard;
    }
}