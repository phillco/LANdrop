using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LANdrop.UI
{
    /// <summary>
    /// Shows details about the given exception (or error text).
    /// </summary>
    public partial class ExceptionDetailsForm : Form
    {
        private Exception exception;

        private string errorText;

        public ExceptionDetailsForm( string errorText )
        {
            InitializeComponent( );
            this.errorText = errorText;
            tbStackTrace.Text = errorText;
        }

        public ExceptionDetailsForm( Exception exception )
        {
            InitializeComponent( );
            this.exception = exception;
            tbStackTrace.Text = exception.ToString( );
            btnClose.Select( );
        }

        private string getErrorText( )
        {
            if ( exception != null )
                return exception.ToString( );
            else
                return errorText;
        }

        private void btnClose_Click( object sender, EventArgs e )
        {
            Close( );
        }

        private void btnCopy_Click( object sender, EventArgs e )
        {
            tbStackTrace.SelectionFont = new Font( "Verdana", 10, FontStyle.Regular );
            Util.SetClipboardTextSafely( getErrorText( ), true );
        }

        private void ExceptionDetailsForm_Load( object sender, EventArgs e )
        {
            // Bold the first line of the error.
            tbStackTrace.SelectionStart = 0;
            tbStackTrace.SelectionLength = tbStackTrace.Text.IndexOf( "\n" );
            tbStackTrace.SelectionColor = SystemColors.WindowText;
            tbStackTrace.SelectionFont = new Font( tbStackTrace.Font, FontStyle.Bold );
        }
    }
}
