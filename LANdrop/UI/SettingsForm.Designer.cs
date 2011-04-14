namespace LANdrop.UI
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( SettingsForm ) );
            this.panel1 = new System.Windows.Forms.Panel( );
            this.llblResetToDefaults = new System.Windows.Forms.LinkLabel( );
            this.btnCancel = new System.Windows.Forms.Button( );
            this.btnSave = new System.Windows.Forms.Button( );
            this.panel2 = new System.Windows.Forms.Panel( );
            this.tabControl1 = new System.Windows.Forms.TabControl( );
            this.tabPage1 = new System.Windows.Forms.TabPage( );
            this.tbUserName = new System.Windows.Forms.TextBox( );
            this.label1 = new System.Windows.Forms.Label( );
            this.tabPage2 = new System.Windows.Forms.TabPage( );
            this.cbReleaseChannel = new System.Windows.Forms.ComboBox( );
            this.cbAutomaticUpdates = new System.Windows.Forms.CheckBox( );
            this.label2 = new System.Windows.Forms.Label( );
            this.panel1.SuspendLayout( );
            this.panel2.SuspendLayout( );
            this.tabControl1.SuspendLayout( );
            this.tabPage1.SuspendLayout( );
            this.tabPage2.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // panel1
            // 
            this.panel1.Controls.Add( this.llblResetToDefaults );
            this.panel1.Controls.Add( this.btnCancel );
            this.panel1.Controls.Add( this.btnSave );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point( 8, 214 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 362, 43 );
            this.panel1.TabIndex = 1;
            // 
            // llblResetToDefaults
            // 
            this.llblResetToDefaults.AutoSize = true;
            this.llblResetToDefaults.Location = new System.Drawing.Point( 3, 13 );
            this.llblResetToDefaults.Name = "llblResetToDefaults";
            this.llblResetToDefaults.Size = new System.Drawing.Size( 102, 13 );
            this.llblResetToDefaults.TabIndex = 2;
            this.llblResetToDefaults.TabStop = true;
            this.llblResetToDefaults.Text = "Reset to defaults...";
            this.llblResetToDefaults.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.llblResetToDefaults_LinkClicked );
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point( 288, 7 );
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size( 75, 25 );
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.Location = new System.Drawing.Point( 207, 7 );
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size( 75, 25 );
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler( this.btnSave_Click );
            // 
            // panel2
            // 
            this.panel2.Controls.Add( this.tabControl1 );
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point( 8, 16 );
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size( 362, 198 );
            this.panel2.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add( this.tabPage1 );
            this.tabControl1.Controls.Add( this.tabPage2 );
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point( 0, 0 );
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size( 362, 198 );
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add( this.tbUserName );
            this.tabPage1.Controls.Add( this.label1 );
            this.tabPage1.Location = new System.Drawing.Point( 4, 22 );
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabPage1.Size = new System.Drawing.Size( 443, 136 );
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point( 101, 24 );
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size( 126, 21 );
            this.tbUserName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 32, 27 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 63, 13 );
            this.label1.TabIndex = 0;
            this.label1.Text = "Your Name:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add( this.label2 );
            this.tabPage2.Controls.Add( this.cbReleaseChannel );
            this.tabPage2.Controls.Add( this.cbAutomaticUpdates );
            this.tabPage2.Location = new System.Drawing.Point( 4, 22 );
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabPage2.Size = new System.Drawing.Size( 354, 172 );
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Advanced";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cbReleaseChannel
            // 
            this.cbReleaseChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReleaseChannel.FormattingEnabled = true;
            this.cbReleaseChannel.Items.AddRange( new object[] {
            "Release",
            "Beta",
            "Dev"} );
            this.cbReleaseChannel.Location = new System.Drawing.Point( 103, 40 );
            this.cbReleaseChannel.Name = "cbReleaseChannel";
            this.cbReleaseChannel.Size = new System.Drawing.Size( 65, 21 );
            this.cbReleaseChannel.TabIndex = 5;
            // 
            // cbAutomaticUpdates
            // 
            this.cbAutomaticUpdates.AutoSize = true;
            this.cbAutomaticUpdates.Location = new System.Drawing.Point( 21, 17 );
            this.cbAutomaticUpdates.Name = "cbAutomaticUpdates";
            this.cbAutomaticUpdates.Size = new System.Drawing.Size( 147, 17 );
            this.cbAutomaticUpdates.TabIndex = 4;
            this.cbAutomaticUpdates.Text = "Keep LANdrop up to date";
            this.cbAutomaticUpdates.UseVisualStyleBackColor = true;
            this.cbAutomaticUpdates.CheckedChanged += new System.EventHandler( this.cbAutomaticUpdates_CheckedChanged );
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 47, 43 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 50, 13 );
            this.label2.TabIndex = 6;
            this.label2.Text = "Channel:";
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size( 378, 257 );
            this.Controls.Add( this.panel2 );
            this.Controls.Add( this.panel1 );
            this.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ( (System.Drawing.Icon) ( resources.GetObject( "$this.Icon" ) ) );
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Padding = new System.Windows.Forms.Padding( 8, 16, 8, 0 );
            this.Text = "LANdrop Settings";
            this.panel1.ResumeLayout( false );
            this.panel1.PerformLayout( );
            this.panel2.ResumeLayout( false );
            this.tabControl1.ResumeLayout( false );
            this.tabPage1.ResumeLayout( false );
            this.tabPage1.PerformLayout( );
            this.tabPage2.ResumeLayout( false );
            this.tabPage2.PerformLayout( );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.LinkLabel llblResetToDefaults;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbReleaseChannel;
        private System.Windows.Forms.CheckBox cbAutomaticUpdates;
    }
}