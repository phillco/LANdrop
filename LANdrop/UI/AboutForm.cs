using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LANdrop.Transfers;

namespace LANdrop.UI
{
    public partial class AboutForm : Form
    {
        public AboutForm( )
        {
            InitializeComponent( );
            Util.UseProperSystemFont( this );

            lblProtocolVersion.Text = "Protocol version: " + Protocol.ProtocolVersion;
        }
    }
}
