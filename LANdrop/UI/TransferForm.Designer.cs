namespace LANdrop.UI
{
    partial class TransferForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( TransferForm ) );
            this.lblStatus = new System.Windows.Forms.Label( );
            this.progressBar = new System.Windows.Forms.ProgressBar( );
            this.btnCancel = new System.Windows.Forms.Button( );
            this.lblDataStatus = new System.Windows.Forms.Label( );
            this.groupDetails = new System.Windows.Forms.GroupBox( );
            this.groupDetails.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font( "Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.lblStatus.Location = new System.Drawing.Point( 12, 9 );
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size( 209, 21 );
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "A boring status label here.";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point( 18, 47 );
            this.progressBar.MarqueeAnimationSpeed = 30;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size( 181, 23 );
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 1;
            this.progressBar.Value = 20;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point( 317, 9 );
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size( 75, 25 );
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler( this.btnCancel_Click );
            // 
            // lblDataStatus
            // 
            this.lblDataStatus.AutoSize = true;
            this.lblDataStatus.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblDataStatus.Location = new System.Drawing.Point( 15, 22 );
            this.lblDataStatus.Name = "lblDataStatus";
            this.lblDataStatus.Size = new System.Drawing.Size( 153, 13 );
            this.lblDataStatus.TabIndex = 3;
            this.lblDataStatus.Text = "60 KB of 13.37 MB received...";
            // 
            // groupDetails
            // 
            this.groupDetails.Controls.Add( this.lblDataStatus );
            this.groupDetails.Controls.Add( this.progressBar );
            this.groupDetails.Location = new System.Drawing.Point( 12, 45 );
            this.groupDetails.Name = "groupDetails";
            this.groupDetails.Size = new System.Drawing.Size( 222, 88 );
            this.groupDetails.TabIndex = 4;
            this.groupDetails.TabStop = false;
            this.groupDetails.Text = "Details";
            this.groupDetails.Visible = false;
            // 
            // TransferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size( 404, 145 );
            this.Controls.Add( this.groupDetails );
            this.Controls.Add( this.btnCancel );
            this.Controls.Add( this.lblStatus );
            this.Font = new System.Drawing.Font( "Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ( (System.Drawing.Icon) ( resources.GetObject( "$this.Icon" ) ) );
            this.MaximizeBox = false;
            this.Name = "TransferForm";
            this.Text = "Transfer";
            this.groupDetails.ResumeLayout( false );
            this.groupDetails.PerformLayout( );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDataStatus;
        private System.Windows.Forms.GroupBox groupDetails;
    }
}