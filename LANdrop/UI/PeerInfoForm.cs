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
            lblIncomingPeerExchanges.Text = String.Format( "{0} incoming (last was {1} seconds ago)", Peer.Statistics.NumOccurrences( PeerStatistics.EventType.ReceivedPeerList ), (int) Peer.Statistics.TimeSince( PeerStatistics.EventType.ReceivedPeerList ).TotalSeconds );
            lblOutgoingPeerExchanges.Text = String.Format( "{0} outgoing (last was {1} seconds ago)", Peer.Statistics.NumOccurrences( PeerStatistics.EventType.SentPeerList ), (int) Peer.Statistics.TimeSince( PeerStatistics.EventType.SentPeerList ).TotalSeconds );
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
