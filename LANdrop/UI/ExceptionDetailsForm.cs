using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LANdrop.UI
{
    public partial class ExceptionDetailsForm : Form
    {
        private Exception exception;

        public ExceptionDetailsForm( Exception exception )
        {
            InitializeComponent( );
            this.exception = exception;
            lblExceptionName.Text = exception.GetType() + " in " + FogCreek.Util.GetExceptionSignature( exception, false );
            lblExceptionMessage.Text = exception.Message;
            tbStackTrace.Text = exception.ToString( );
            btnClose.Select( );
        }

        private void btnClose_Click( object sender, EventArgs e )
        {
            Close( );
        }

        private void btnCopy_Click( object sender, EventArgs e )
        {
            Util.SetClipboardTextSafely( e.ToString( ), true );
        }
    }
}
