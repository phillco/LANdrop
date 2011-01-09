namespace LANdrop.UI
{
    partial class AddUserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( AddUserForm ) );
            this.pictureBox1 = new System.Windows.Forms.PictureBox( );
            this.label1 = new System.Windows.Forms.Label( );
            this.label2 = new System.Windows.Forms.Label( );
            this.tbTheirIP = new System.Windows.Forms.TextBox( );
            this.label3 = new System.Windows.Forms.Label( );
            this.btnAdd = new System.Windows.Forms.Button( );
            this.panel1 = new System.Windows.Forms.Panel( );
            this.label4 = new System.Windows.Forms.Label( );
            this.btnPaste = new System.Windows.Forms.Button( );
            this.lblCopyYourIP = new System.Windows.Forms.LinkLabel( );
            this.updateStateTimer = new System.Windows.Forms.Timer( this.components );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).BeginInit( );
            this.panel1.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LANdrop.Properties.Resources.user_add;
            this.pictureBox1.Location = new System.Drawing.Point( 12, 13 );
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size( 32, 32 );
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font( "Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.label1.Location = new System.Drawing.Point( 50, 12 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 67, 16 );
            this.label1.TabIndex = 1;
            this.label1.Text = "Add user";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point( 50, 31 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 291, 13 );
            this.label2.TabIndex = 2;
            this.label2.Text = "If a user doesn\'t appear in the list, you can add them here.";
            // 
            // tbTheirIP
            // 
            this.tbTheirIP.Location = new System.Drawing.Point( 173, 82 );
            this.tbTheirIP.Name = "tbTheirIP";
            this.tbTheirIP.Size = new System.Drawing.Size( 100, 21 );
            this.tbTheirIP.TabIndex = 3;
            this.tbTheirIP.TextChanged += new System.EventHandler( this.tbTheirIP_TextChanged );
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 76, 85 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 89, 13 );
            this.label3.TabIndex = 4;
            this.label3.Text = "Their IP address:";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnAdd.Location = new System.Drawing.Point( 279, 135 );
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size( 84, 25 );
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add user";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler( this.btnAdd_Click );
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add( this.label4 );
            this.panel1.Controls.Add( this.pictureBox1 );
            this.panel1.Controls.Add( this.label1 );
            this.panel1.Controls.Add( this.label2 );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point( 0, 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 375, 56 );
            this.panel1.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point( 0, 54 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 500, 2 );
            this.label4.TabIndex = 11;
            // 
            // btnPaste
            // 
            this.btnPaste.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnPaste.Location = new System.Drawing.Point( 199, 135 );
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size( 74, 25 );
            this.btnPaste.TabIndex = 11;
            this.btnPaste.Text = "Paste";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler( this.btnPaste_Click );
            // 
            // lblCopyYourIP
            // 
            this.lblCopyYourIP.AutoSize = true;
            this.lblCopyYourIP.Location = new System.Drawing.Point( 12, 141 );
            this.lblCopyYourIP.Name = "lblCopyYourIP";
            this.lblCopyYourIP.Size = new System.Drawing.Size( 82, 13 );
            this.lblCopyYourIP.TabIndex = 12;
            this.lblCopyYourIP.TabStop = true;
            this.lblCopyYourIP.Text = "Copy your IP...";
            this.lblCopyYourIP.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.lblCopyYourIP_LinkClicked );
            // 
            // updateStateTimer
            // 
            this.updateStateTimer.Enabled = true;
            this.updateStateTimer.Interval = 500;
            this.updateStateTimer.Tick += new System.EventHandler( this.updateStateTimer_Tick );
            // 
            // AddUserForm
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 375, 173 );
            this.Controls.Add( this.lblCopyYourIP );
            this.Controls.Add( this.btnPaste );
            this.Controls.Add( this.panel1 );
            this.Controls.Add( this.btnAdd );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.tbTheirIP );
            this.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ( (System.Drawing.Icon) ( resources.GetObject( "$this.Icon" ) ) );
            this.MaximizeBox = false;
            this.Name = "AddUserForm";
            this.Text = "Add user...";
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).EndInit( );
            this.panel1.ResumeLayout( false );
            this.panel1.PerformLayout( );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTheirIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.LinkLabel lblCopyYourIP;
        private System.Windows.Forms.Timer updateStateTimer;
    }
}