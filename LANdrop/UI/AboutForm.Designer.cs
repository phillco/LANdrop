﻿namespace LANdrop.UI
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
            this.label2 = new System.Windows.Forms.Label( );
            this.label1 = new System.Windows.Forms.Label( );
            this.pictureBox1 = new System.Windows.Forms.PictureBox( );
            this.btnClose = new System.Windows.Forms.Button( );
            this.checkBox1 = new System.Windows.Forms.CheckBox( );
            this.lblProtocolVersion = new System.Windows.Forms.Label( );
            this.lblProgramVersion = new System.Windows.Forms.Label( );
            this.lblBuildInfo = new System.Windows.Forms.Label( );
            this.panel1.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).BeginInit( );
            this.SuspendLayout( );
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add( this.label3 );
            this.panel1.Controls.Add( this.label2 );
            this.panel1.Controls.Add( this.label1 );
            this.panel1.Controls.Add( this.pictureBox1 );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point( 0, 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 344, 69 );
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point( 51, 36 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 124, 13 );
            this.label3.TabIndex = 4;
            this.label3.Text = "Created by Phillip Cohen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font( "Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.label2.Location = new System.Drawing.Point( 50, 15 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 79, 19 );
            this.label2.TabIndex = 3;
            this.label2.Text = "LANdrop";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point( 0, 67 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 500, 2 );
            this.label1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LANdrop.Properties.Resources.draw_calligraphic;
            this.pictureBox1.Location = new System.Drawing.Point( 12, 17 );
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
            this.btnClose.Location = new System.Drawing.Point( 257, 140 );
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
            this.checkBox1.Location = new System.Drawing.Point( 12, 145 );
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size( 97, 17 );
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "I love LANdrop";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // lblProtocolVersion
            // 
            this.lblProtocolVersion.AutoSize = true;
            this.lblProtocolVersion.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblProtocolVersion.Location = new System.Drawing.Point( 223, 106 );
            this.lblProtocolVersion.Name = "lblProtocolVersion";
            this.lblProtocolVersion.Size = new System.Drawing.Size( 109, 13 );
            this.lblProtocolVersion.TabIndex = 4;
            this.lblProtocolVersion.Text = "Protocol version: 666";
            this.lblProtocolVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblProgramVersion
            // 
            this.lblProgramVersion.AutoSize = true;
            this.lblProgramVersion.Font = new System.Drawing.Font( "Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.lblProgramVersion.Location = new System.Drawing.Point( 284, 74 );
            this.lblProgramVersion.Name = "lblProgramVersion";
            this.lblProgramVersion.Size = new System.Drawing.Size( 48, 16 );
            this.lblProgramVersion.TabIndex = 5;
            this.lblProgramVersion.Text = "v1.1.1";
            this.lblProgramVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblBuildInfo
            // 
            this.lblBuildInfo.Location = new System.Drawing.Point( 120, 91 );
            this.lblBuildInfo.Name = "lblBuildInfo";
            this.lblBuildInfo.Size = new System.Drawing.Size( 212, 16 );
            this.lblBuildInfo.TabIndex = 6;
            this.lblBuildInfo.Text = "Development build #5";
            this.lblBuildInfo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // AboutForm
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size( 344, 174 );
            this.Controls.Add( this.lblBuildInfo );
            this.Controls.Add( this.lblProgramVersion );
            this.Controls.Add( this.lblProtocolVersion );
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
        private System.Windows.Forms.Label lblProtocolVersion;
        private System.Windows.Forms.Label lblProgramVersion;
        private System.Windows.Forms.Label lblBuildInfo;
    }
}