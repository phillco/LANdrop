﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LANdrop.UI
{
    public partial class IncomingTextSnippetForm : Form
    {
        public IncomingTextSnippetForm( string text )
        {
            InitializeComponent( );
            Util.UseProperSystemFont( this );

            tbSnippet.Text = text;
            lblTitle.Text = "Received:";
            UpdateState( );
        }

        private void UpdateState( )
        {
            btnCopy.Enabled = ( tbSnippet.Text.Length > 0 );
        }

        private void btnCopy_Click( object sender, EventArgs e )
        {
            Clipboard.SetText( tbSnippet.Text );
            Close( );
        }

        private void btnDiscard_Click( object sender, EventArgs e )
        {
            Close( );
        }

        private void tbSnippet_TextChanged( object sender, EventArgs e )
        {
            btnCopy.Enabled = ( tbSnippet.Text.Length > 0 );
        }
    }
}