using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LANdrop.Networking;

namespace LANdrop.UI
{
    public partial class PeerInfoForm : Form
    {
        private Peer Peer;

        public PeerInfoForm( Peer peer )
        {
            this.Peer = peer;
            InitializeComponent( );
            UpdateInformation( );
        }

        public void UpdateInformation( )
        {
            lblPeerName.Text = Peer.Name;
            lblIncomingPeerExchanges.Text = String.Format( "{0} incoming (last was {1} seconds ago)", Peer.Statistics.NumTimesReceivedPeers, (int) DateTime.Now.Subtract( Peer.Statistics.LastReceivedPeers ).TotalSeconds );
            lblOutgoingPeerExchanges.Text = String.Format( "{0} outgoing (last was {1} seconds ago)", Peer.Statistics.NumTimesSentPeers, (int) DateTime.Now.Subtract( Peer.Statistics.LastSentPeers ).TotalSeconds );
        }

        private void btnClose_Click( object sender, EventArgs e )
        {
            Close( );
        }

        private void updateInfoTimer_Tick( object sender, EventArgs e )
        {
            UpdateInformation( );
        }
    }
}
