namespace LANdrop.UI
{
    partial class SendTextSnippetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( SendTextSnippetForm ) );
            this.tbSnippet = new System.Windows.Forms.TextBox( );
            this.btnSend = new System.Windows.Forms.Button( );
            this.lblTitle = new System.Windows.Forms.Label( );
            this.btnPaste = new System.Windows.Forms.Button( );
            this.updateClipboardStatusTimer = new System.Windows.Forms.Timer( this.components );
            this.SuspendLayout( );
            // 
            // tbSnippet
            // 
            this.tbSnippet.Location = new System.Drawing.Point( 25, 44 );
            this.tbSnippet.Multiline = true;
            this.tbSnippet.Name = "tbSnippet";
            this.tbSnippet.Size = new System.Drawing.Size( 342, 121 );
            this.tbSnippet.TabIndex = 1;
            this.tbSnippet.TextChanged += new System.EventHandler( this.tbSnippet_TextChanged );
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point( 292, 176 );
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size( 75, 25 );
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler( this.btnSend_Click );
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font( "Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTitle.Location = new System.Drawing.Point( 12, 13 );
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size( 139, 16 );
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Enter text to send...";
            // 
            // btnPaste
            // 
            this.btnPaste.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.btnPaste.Location = new System.Drawing.Point( 25, 176 );
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size( 75, 25 );
            this.btnPaste.TabIndex = 4;
            this.btnPaste.Text = "Paste";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler( this.btnPaste_Click );
            // 
            // updateClipboardStatusTimer
            // 
            this.updateClipboardStatusTimer.Enabled = true;
            this.updateClipboardStatusTimer.Tick += new System.EventHandler( this.updateClipboardStatusTimer_Tick );
            // 
            // SendTextSnippetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 398, 217 );
            this.Controls.Add( this.btnPaste );
            this.Controls.Add( this.lblTitle );
            this.Controls.Add( this.btnSend );
            this.Controls.Add( this.tbSnippet );
            this.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ( (System.Drawing.Icon) ( resources.GetObject( "$this.Icon" ) ) );
            this.MaximizeBox = false;
            this.Name = "SendTextSnippetForm";
            this.Text = "Send text snippet";
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.TextBox tbSnippet;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.Timer updateClipboardStatusTimer;
    }
}