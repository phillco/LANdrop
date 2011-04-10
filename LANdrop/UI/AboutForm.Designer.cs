namespace LANdrop.UI
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( AboutForm ) );
            this.panel1 = new System.Windows.Forms.Panel( );
            this.label3 = new System.Windows.Forms.Label( );
            this.lblTrademark = new System.Windows.Forms.Label( );
            this.label2 = new System.Windows.Forms.Label( );
            this.lblBuildInfo = new System.Windows.Forms.Label( );
            this.label1 = new System.Windows.Forms.Label( );
            this.lblProgramVersion = new System.Windows.Forms.Label( );
            this.pictureBox1 = new System.Windows.Forms.PictureBox( );
            this.btnClose = new System.Windows.Forms.Button( );
            this.checkBox1 = new System.Windows.Forms.CheckBox( );
            this.panel1.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add( this.label3 );
            this.panel1.Controls.Add( this.lblTrademark );
            this.panel1.Controls.Add( this.label2 );
            this.panel1.Controls.Add( this.lblBuildInfo );
            this.panel1.Controls.Add( this.label1 );
            this.panel1.Controls.Add( this.lblProgramVersion );
            this.panel1.Controls.Add( this.pictureBox1 );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point( 0, 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 408, 125 );
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point( 144, 24 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 82, 13 );
            this.label3.TabIndex = 4;
            this.label3.Text = "by Phillip Cohen";
            // 
            // lblTrademark
            // 
            this.lblTrademark.AutoSize = true;
            this.lblTrademark.Location = new System.Drawing.Point( 65, 41 );
            this.lblTrademark.Name = "lblTrademark";
            this.lblTrademark.Size = new System.Drawing.Size( 184, 13 );
            this.lblTrademark.TabIndex = 4;
            this.lblTrademark.Text = "Blazing-fast file transfers over LAN™";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font( "Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.label2.Location = new System.Drawing.Point( 64, 19 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 79, 19 );
            this.label2.TabIndex = 3;
            this.label2.Text = "LANdrop";
            // 
            // lblBuildInfo
            // 
            this.lblBuildInfo.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.lblBuildInfo.AutoSize = true;
            this.lblBuildInfo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblBuildInfo.Location = new System.Drawing.Point( 12, 100 );
            this.lblBuildInfo.Name = "lblBuildInfo";
            this.lblBuildInfo.Size = new System.Drawing.Size( 112, 13 );
            this.lblBuildInfo.TabIndex = 6;
            this.lblBuildInfo.Text = "Development build #5";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point( 0, 123 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 500, 2 );
            this.label1.TabIndex = 2;
            // 
            // lblProgramVersion
            // 
            this.lblProgramVersion.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.lblProgramVersion.AutoSize = true;
            this.lblProgramVersion.Font = new System.Drawing.Font( "Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.lblProgramVersion.Location = new System.Drawing.Point( 12, 84 );
            this.lblProgramVersion.Name = "lblProgramVersion";
            this.lblProgramVersion.Size = new System.Drawing.Size( 48, 16 );
            this.lblProgramVersion.TabIndex = 5;
            this.lblProgramVersion.Text = "v1.1.1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LANdrop.Properties.Resources.draw_calligraphic;
            this.pictureBox1.Location = new System.Drawing.Point( 26, 22 );
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size( 32, 32 );
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point( 321, 133 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 75, 25 );
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point( 12, 138 );
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size( 97, 17 );
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "I love LANdrop";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // AboutForm
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size( 408, 167 );
            this.Controls.Add( this.checkBox1 );
            this.Controls.Add( this.btnClose );
            this.Controls.Add( this.panel1 );
            this.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ( (System.Drawing.Icon) ( resources.GetObject( "$this.Icon" ) ) );
            this.MaximizeBox = false;
            this.Name = "AboutForm";
            this.Text = "About LANdrop";
            this.panel1.ResumeLayout( false );
            this.panel1.PerformLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).EndInit( );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label lblProgramVersion;
        private System.Windows.Forms.Label lblBuildInfo;
        private System.Windows.Forms.Label lblTrademark;
    }
}