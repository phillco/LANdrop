using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LANdrop.UI
{
    public partial class IncomingTransferForm : Form, ITransferForm
    {
        public IncomingTransferForm( )
        {
            InitializeComponent( );
        }

        public void UpdateState( )
        {

        }
    }
}
