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
            gbStackTrace.Text = "Error details";
            tbStackTrace.Text = errorText;
            btnClose.Select( );
        }

        public ExceptionDetailsForm( Exception exception )
        {
            InitializeComponent( );
            this.exception = exception;
            lblExceptionName.Text = exception.GetType( ) + " in " + FogCreek.Util.GetExceptionSignature( exception, false );
            lblExceptionMessage.Text = exception.Message;
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
            Util.SetClipboardTextSafely( getErrorText( ), true );
        }
    }
}
