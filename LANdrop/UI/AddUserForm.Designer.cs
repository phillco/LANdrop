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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( AddUserForm ) );
            this.pictureBox1 = new System.Windows.Forms.PictureBox( );
            this.label1 = new System.Windows.Forms.Label( );
            this.label2 = new System.Windows.Forms.Label( );
            this.tbTheirIP = new System.Windows.Forms.TextBox( );
            this.label3 = new System.Windows.Forms.Label( );
            this.btnAdd = new System.Windows.Forms.Button( );
            this.lblYourIP = new System.Windows.Forms.Label( );
            this.btnCopy = new System.Windows.Forms.Button( );
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.panel1 = new System.Windows.Forms.Panel( );
            this.label4 = new System.Windows.Forms.Label( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).BeginInit( );
            this.groupBox1.SuspendLayout( );
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
            this.tbTheirIP.Location = new System.Drawing.Point( 139, 76 );
            this.tbTheirIP.Name = "tbTheirIP";
            this.tbTheirIP.Size = new System.Drawing.Size( 100, 21 );
            this.tbTheirIP.TabIndex = 3;
            this.tbTheirIP.TextChanged += new System.EventHandler( this.tbTheirIP_TextChanged );
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 42, 79 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 89, 13 );
            this.label3.TabIndex = 4;
            this.label3.Text = "Their IP address:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point( 245, 74 );
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size( 55, 23 );
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler( this.btnAdd_Click );
            // 
            // lblYourIP
            // 
            this.lblYourIP.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblYourIP.AutoSize = true;
            this.lblYourIP.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblYourIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblYourIP.Font = new System.Drawing.Font( "Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.lblYourIP.Location = new System.Drawing.Point( 27, 32 );
            this.lblYourIP.Name = "lblYourIP";
            this.lblYourIP.Size = new System.Drawing.Size( 130, 18 );
            this.lblYourIP.TabIndex = 7;
            this.lblYourIP.Text = "127.123.456.789";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point( 163, 30 );
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size( 55, 23 );
            this.btnCopy.TabIndex = 8;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler( this.btnCopy_Click );
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.lblYourIP );
            this.groupBox1.Controls.Add( this.btnCopy );
            this.groupBox1.Location = new System.Drawing.Point( 68, 124 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 240, 76 );
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Your IP address (for reference)";
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
            // AddUserForm
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 375, 230 );
            this.Controls.Add( this.panel1 );
            this.Controls.Add( this.groupBox1 );
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
            this.groupBox1.ResumeLayout( false );
            this.groupBox1.PerformLayout( );
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
        private System.Windows.Forms.Label lblYourIP;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
    }
}