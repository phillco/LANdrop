namespace LANdrop.UI
{
    partial class SendFeedbackForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( SendFeedbackForm ) );
            this.pbAngryFace = new System.Windows.Forms.PictureBox( );
            this.panel1 = new System.Windows.Forms.Panel( );
            this.label3 = new System.Windows.Forms.Label( );
            this.label2 = new System.Windows.Forms.Label( );
            this.rbNeedsWork = new System.Windows.Forms.RadioButton( );
            this.pbHappyFace = new System.Windows.Forms.PictureBox( );
            this.rbGreat = new System.Windows.Forms.RadioButton( );
            this.label1 = new System.Windows.Forms.Label( );
            this.btnSubmit = new System.Windows.Forms.Button( );
            this.btnCancel = new System.Windows.Forms.Button( );
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.tbAdditionalComments = new System.Windows.Forms.TextBox( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pbAngryFace ) ).BeginInit( );
            this.panel1.SuspendLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pbHappyFace ) ).BeginInit( );
            this.groupBox1.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // pbAngryFace
            // 
            this.pbAngryFace.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAngryFace.Image = global::LANdrop.Properties.Resources.RCTAngryGuest;
            this.pbAngryFace.Location = new System.Drawing.Point( 42, 77 );
            this.pbAngryFace.Name = "pbAngryFace";
            this.pbAngryFace.Size = new System.Drawing.Size( 27, 25 );
            this.pbAngryFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbAngryFace.TabIndex = 0;
            this.pbAngryFace.TabStop = false;
            this.pbAngryFace.Click += new System.EventHandler( this.pbAngryFace_Click );
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add( this.groupBox1 );
            this.panel1.Controls.Add( this.label3 );
            this.panel1.Controls.Add( this.label2 );
            this.panel1.Controls.Add( this.rbNeedsWork );
            this.panel1.Controls.Add( this.pbHappyFace );
            this.panel1.Controls.Add( this.rbGreat );
            this.panel1.Controls.Add( this.label1 );
            this.panel1.Controls.Add( this.pbAngryFace );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point( 0, 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 414, 313 );
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point( 0, 311 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 600, 2 );
            this.label3.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 39, 284 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 327, 13 );
            this.label2.TabIndex = 5;
            this.label2.Text = "Your comments will be read personally by the LANdrop developers.";
            // 
            // rbNeedsWork
            // 
            this.rbNeedsWork.AutoSize = true;
            this.rbNeedsWork.Location = new System.Drawing.Point( 77, 80 );
            this.rbNeedsWork.Name = "rbNeedsWork";
            this.rbNeedsWork.Size = new System.Drawing.Size( 81, 17 );
            this.rbNeedsWork.TabIndex = 4;
            this.rbNeedsWork.Text = "Needs work";
            this.rbNeedsWork.UseVisualStyleBackColor = true;
            // 
            // pbHappyFace
            // 
            this.pbHappyFace.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbHappyFace.Image = global::LANdrop.Properties.Resources.RCTHappyGuest;
            this.pbHappyFace.Location = new System.Drawing.Point( 42, 46 );
            this.pbHappyFace.Name = "pbHappyFace";
            this.pbHappyFace.Size = new System.Drawing.Size( 27, 25 );
            this.pbHappyFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbHappyFace.TabIndex = 3;
            this.pbHappyFace.TabStop = false;
            this.pbHappyFace.Click += new System.EventHandler( this.pbHappyFace_Click );
            // 
            // rbGreat
            // 
            this.rbGreat.AutoSize = true;
            this.rbGreat.Checked = true;
            this.rbGreat.Location = new System.Drawing.Point( 77, 50 );
            this.rbGreat.Name = "rbGreat";
            this.rbGreat.Size = new System.Drawing.Size( 56, 17 );
            this.rbGreat.TabIndex = 2;
            this.rbGreat.TabStop = true;
            this.rbGreat.Text = "Great!";
            this.rbGreat.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font( "Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point( 16, 14 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 141, 19 );
            this.label1.TabIndex = 1;
            this.label1.Text = "How\'s LANdrop?";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnSubmit.Location = new System.Drawing.Point( 224, 322 );
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size( 75, 23 );
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Send!";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler( this.btnSubmit_Click );
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point( 305, 322 );
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size( 97, 23 );
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Chicken out";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.tbAdditionalComments );
            this.groupBox1.Location = new System.Drawing.Point( 41, 131 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding( 12, 8, 12, 12 );
            this.groupBox1.Size = new System.Drawing.Size( 316, 138 );
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Additional comments";
            // 
            // tbAdditionalComments
            // 
            this.tbAdditionalComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAdditionalComments.Location = new System.Drawing.Point( 12, 22 );
            this.tbAdditionalComments.Multiline = true;
            this.tbAdditionalComments.Name = "tbAdditionalComments";
            this.tbAdditionalComments.Size = new System.Drawing.Size( 292, 104 );
            this.tbAdditionalComments.TabIndex = 0;
            // 
            // SendFeedbackForm
            // 
            this.AcceptButton = this.btnSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size( 414, 354 );
            this.Controls.Add( this.btnCancel );
            this.Controls.Add( this.btnSubmit );
            this.Controls.Add( this.panel1 );
            this.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ( (System.Drawing.Icon) ( resources.GetObject( "$this.Icon" ) ) );
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SendFeedbackForm";
            this.Text = "Send feedback";
            ( (System.ComponentModel.ISupportInitialize) ( this.pbAngryFace ) ).EndInit( );
            this.panel1.ResumeLayout( false );
            this.panel1.PerformLayout( );
            ( (System.ComponentModel.ISupportInitialize) ( this.pbHappyFace ) ).EndInit( );
            this.groupBox1.ResumeLayout( false );
            this.groupBox1.PerformLayout( );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.PictureBox pbAngryFace;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbHappyFace;
        private System.Windows.Forms.RadioButton rbGreat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbNeedsWork;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbAdditionalComments;
    }
}