namespace LANdrop.UI
{
    partial class NotificationForm
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
            this.opacityTimer = new System.Windows.Forms.Timer( this.components );
            this.positionTimer = new System.Windows.Forms.Timer( this.components );
            this.SuspendLayout( );
            // 
            // opacityTimer
            // 
            this.opacityTimer.Enabled = true;
            this.opacityTimer.Interval = 15;
            this.opacityTimer.Tick += new System.EventHandler( this.opacityTimer_Tick );
            // 
            // positionTimer
            // 
            this.positionTimer.Interval = 15;
            this.positionTimer.Tick += new System.EventHandler( this.positionTimer_Tick );
            // 
            // NotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb( ( (int) ( ( (byte) ( 64 ) ) ) ), ( (int) ( ( (byte) ( 64 ) ) ) ), ( (int) ( ( (byte) ( 64 ) ) ) ) );
            this.ClientSize = new System.Drawing.Size( 494, 70 );
            this.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NotificationForm";
            this.Opacity = 0;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "IncomingTransferNotification";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler( this.NotificationForm_FormClosed );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Timer opacityTimer;
        private System.Windows.Forms.Timer positionTimer;
    }
}