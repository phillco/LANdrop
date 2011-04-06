namespace LANdrop.UI
{
    partial class ExceptionDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( ExceptionDetailsForm ) );
            this.lblExceptionName = new System.Windows.Forms.Label( );
            this.lblExceptionMessage = new System.Windows.Forms.Label( );
            this.gbStackTrace = new System.Windows.Forms.GroupBox( );
            this.tbStackTrace = new System.Windows.Forms.TextBox( );
            this.btnClose = new System.Windows.Forms.Button( );
            this.btnCopy = new System.Windows.Forms.Button( );
            this.centerPanel = new System.Windows.Forms.Panel( );
            this.panel2 = new System.Windows.Forms.Panel( );
            this.label1 = new System.Windows.Forms.Label( );
            this.panel3 = new System.Windows.Forms.Panel( );
            this.gbStackTrace.SuspendLayout( );
            this.centerPanel.SuspendLayout( );
            this.panel2.SuspendLayout( );
            this.panel3.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // lblExceptionName
            // 
            this.lblExceptionName.AutoEllipsis = true;
            this.lblExceptionName.AutoSize = true;
            this.lblExceptionName.Font = new System.Drawing.Font( "Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.lblExceptionName.Location = new System.Drawing.Point( 12, 12 );
            this.lblExceptionName.Name = "lblExceptionName";
            this.lblExceptionName.Size = new System.Drawing.Size( 126, 16 );
            this.lblExceptionName.TabIndex = 0;
            this.lblExceptionName.Text = "An error occurred";
            // 
            // lblExceptionMessage
            // 
            this.lblExceptionMessage.AutoSize = true;
            this.lblExceptionMessage.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblExceptionMessage.Location = new System.Drawing.Point( 28, 29 );
            this.lblExceptionMessage.Name = "lblExceptionMessage";
            this.lblExceptionMessage.Size = new System.Drawing.Size( 0, 13 );
            this.lblExceptionMessage.TabIndex = 1;
            // 
            // gbStackTrace
            // 
            this.gbStackTrace.Controls.Add( this.tbStackTrace );
            this.gbStackTrace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbStackTrace.Location = new System.Drawing.Point( 16, 64 );
            this.gbStackTrace.Name = "gbStackTrace";
            this.gbStackTrace.Padding = new System.Windows.Forms.Padding( 12, 8, 12, 12 );
            this.gbStackTrace.Size = new System.Drawing.Size( 452, 130 );
            this.gbStackTrace.TabIndex = 2;
            this.gbStackTrace.TabStop = false;
            this.gbStackTrace.Text = "Stack trace";
            // 
            // tbStackTrace
            // 
            this.tbStackTrace.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbStackTrace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbStackTrace.Font = new System.Drawing.Font( "Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.tbStackTrace.Location = new System.Drawing.Point( 12, 22 );
            this.tbStackTrace.Multiline = true;
            this.tbStackTrace.Name = "tbStackTrace";
            this.tbStackTrace.ReadOnly = true;
            this.tbStackTrace.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbStackTrace.Size = new System.Drawing.Size( 428, 96 );
            this.tbStackTrace.TabIndex = 50;
            this.tbStackTrace.WordWrap = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnClose.Location = new System.Drawing.Point( 400, 7 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 72, 25 );
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "OK";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.btnCopy.Location = new System.Drawing.Point( 12, 7 );
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size( 96, 25 );
            this.btnCopy.TabIndex = 4;
            this.btnCopy.Text = "Copy details";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler( this.btnCopy_Click );
            // 
            // centerPanel
            // 
            this.centerPanel.Controls.Add( this.gbStackTrace );
            this.centerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerPanel.Location = new System.Drawing.Point( 0, 0 );
            this.centerPanel.Name = "centerPanel";
            this.centerPanel.Padding = new System.Windows.Forms.Padding( 16, 64, 16, 48 );
            this.centerPanel.Size = new System.Drawing.Size( 484, 242 );
            this.centerPanel.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add( this.label1 );
            this.panel2.Controls.Add( this.lblExceptionName );
            this.panel2.Controls.Add( this.lblExceptionMessage );
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point( 0, 0 );
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size( 484, 55 );
            this.panel2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point( -79, 53 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 900, 2 );
            this.label1.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add( this.btnCopy );
            this.panel3.Controls.Add( this.btnClose );
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point( 0, 200 );
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size( 484, 42 );
            this.panel3.TabIndex = 6;
            // 
            // ExceptionDetailsForm
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 484, 242 );
            this.Controls.Add( this.panel3 );
            this.Controls.Add( this.panel2 );
            this.Controls.Add( this.centerPanel );
            this.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.Icon = ( (System.Drawing.Icon) ( resources.GetObject( "$this.Icon" ) ) );
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size( 950, 530 );
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size( 400, 240 );
            this.Name = "ExceptionDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Error details";
            this.gbStackTrace.ResumeLayout( false );
            this.gbStackTrace.PerformLayout( );
            this.centerPanel.ResumeLayout( false );
            this.panel2.ResumeLayout( false );
            this.panel2.PerformLayout( );
            this.panel3.ResumeLayout( false );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Label lblExceptionName;
        private System.Windows.Forms.Label lblExceptionMessage;
        private System.Windows.Forms.GroupBox gbStackTrace;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.TextBox tbStackTrace;
        private System.Windows.Forms.Panel centerPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;

    }
}