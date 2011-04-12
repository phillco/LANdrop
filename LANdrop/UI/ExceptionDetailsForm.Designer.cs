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
            this.btnClose = new System.Windows.Forms.Button( );
            this.btnCopy = new System.Windows.Forms.Button( );
            this.centerPanel = new System.Windows.Forms.Panel( );
            this.panel3 = new System.Windows.Forms.Panel( );
            this.panel2 = new System.Windows.Forms.Panel( );
            this.label2 = new System.Windows.Forms.Label( );
            this.tbStackTrace = new System.Windows.Forms.TextBox( );
            this.panel3.SuspendLayout( );
            this.panel2.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnClose.Location = new System.Drawing.Point( 581, 8 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 72, 25 );
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.btnCopy.Location = new System.Drawing.Point( 12, 8 );
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size( 96, 25 );
            this.btnCopy.TabIndex = 4;
            this.btnCopy.Text = "Copy details";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler( this.btnCopy_Click );
            // 
            // centerPanel
            // 
            this.centerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerPanel.Location = new System.Drawing.Point( 0, 0 );
            this.centerPanel.Name = "centerPanel";
            this.centerPanel.Padding = new System.Windows.Forms.Padding( 16, 64, 16, 48 );
            this.centerPanel.Size = new System.Drawing.Size( 665, 255 );
            this.centerPanel.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add( this.label2 );
            this.panel3.Controls.Add( this.btnCopy );
            this.panel3.Controls.Add( this.btnClose );
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point( 0, 213 );
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size( 665, 42 );
            this.panel3.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add( this.tbStackTrace );
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point( 0, 0 );
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding( 12, 16, 12, 48 );
            this.panel2.Size = new System.Drawing.Size( 665, 255 );
            this.panel2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point( -103, 0 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 1529, 2 );
            this.label2.TabIndex = 5;
            // 
            // tbStackTrace
            // 
            this.tbStackTrace.BackColor = System.Drawing.Color.White;
            this.tbStackTrace.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbStackTrace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbStackTrace.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbStackTrace.Location = new System.Drawing.Point( 12, 16 );
            this.tbStackTrace.Multiline = true;
            this.tbStackTrace.Name = "tbStackTrace";
            this.tbStackTrace.ReadOnly = true;
            this.tbStackTrace.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbStackTrace.Size = new System.Drawing.Size( 641, 191 );
            this.tbStackTrace.TabIndex = 51;
            this.tbStackTrace.WordWrap = false;
            // 
            // ExceptionDetailsForm
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 665, 255 );
            this.Controls.Add( this.panel3 );
            this.Controls.Add( this.panel2 );
            this.Controls.Add( this.centerPanel );
            this.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.Icon = ( (System.Drawing.Icon) ( resources.GetObject( "$this.Icon" ) ) );
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size( 1050, 530 );
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size( 400, 240 );
            this.Name = "ExceptionDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Error details";
            this.panel3.ResumeLayout( false );
            this.panel2.ResumeLayout( false );
            this.panel2.PerformLayout( );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Panel centerPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbStackTrace;

    }
}