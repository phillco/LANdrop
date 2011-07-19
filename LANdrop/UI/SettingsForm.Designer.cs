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
            this.comboUpdateChannel = new System.Windows.Forms.ComboBox( );
            this.lblChannel = new System.Windows.Forms.Label( );
            this.cbUpdateAutomatically = new System.Windows.Forms.CheckBox( );
            this.tbUserName = new System.Windows.Forms.TextBox( );
            this.label1 = new System.Windows.Forms.Label( );
            this.panel1.SuspendLayout( );
            this.panel2.SuspendLayout( );
            this.tabControl1.SuspendLayout( );
            this.tabPage1.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // panel1
            // 
            this.panel1.Controls.Add( this.llblResetToDefaults );
            this.panel1.Controls.Add( this.btnCancel );
            this.panel1.Controls.Add( this.btnSave );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point( 8, 174 );
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
            this.panel2.Size = new System.Drawing.Size( 362, 158 );
            this.panel2.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add( this.tabPage1 );
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point( 0, 0 );
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size( 362, 158 );
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add( this.comboUpdateChannel );
            this.tabPage1.Controls.Add( this.lblChannel );
            this.tabPage1.Controls.Add( this.cbUpdateAutomatically );
            this.tabPage1.Controls.Add( this.tbUserName );
            this.tabPage1.Controls.Add( this.label1 );
            this.tabPage1.Location = new System.Drawing.Point( 4, 22 );
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabPage1.Size = new System.Drawing.Size( 354, 132 );
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // comboUpdateChannel
            // 
            this.comboUpdateChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboUpdateChannel.FormattingEnabled = true;
            this.comboUpdateChannel.Items.AddRange( new object[] {
            "Release",
            "Beta",
            "Dev"} );
            this.comboUpdateChannel.Location = new System.Drawing.Point( 130, 81 );
            this.comboUpdateChannel.Name = "comboUpdateChannel";
            this.comboUpdateChannel.Size = new System.Drawing.Size( 72, 21 );
            this.comboUpdateChannel.TabIndex = 7;
            // 
            // lblChannel
            // 
            this.lblChannel.AutoSize = true;
            this.lblChannel.Location = new System.Drawing.Point( 74, 84 );
            this.lblChannel.Name = "lblChannel";
            this.lblChannel.Size = new System.Drawing.Size( 50, 13 );
            this.lblChannel.TabIndex = 6;
            this.lblChannel.Text = "Channel:";
            // 
            // cbUpdateAutomatically
            // 
            this.cbUpdateAutomatically.AutoSize = true;
            this.cbUpdateAutomatically.Location = new System.Drawing.Point( 35, 62 );
            this.cbUpdateAutomatically.Name = "cbUpdateAutomatically";
            this.cbUpdateAutomatically.Size = new System.Drawing.Size( 147, 17 );
            this.cbUpdateAutomatically.TabIndex = 5;
            this.cbUpdateAutomatically.Text = "Keep LANdrop up to date";
            this.cbUpdateAutomatically.UseVisualStyleBackColor = true;
            this.cbUpdateAutomatically.CheckedChanged += new System.EventHandler( this.cbUpdateAutomatically_CheckedChanged );
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
            // SettingsForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size( 378, 217 );
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
        private System.Windows.Forms.CheckBox cbUpdateAutomatically;
        private System.Windows.Forms.ComboBox comboUpdateChannel;
        private System.Windows.Forms.Label lblChannel;
    }
}