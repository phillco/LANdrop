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

            lblLastSeen.Text = String.Format( "Last seen {0} seconds ago", (int) Peer.Statistics.TimeSince( PeerStatistics.EventType.Any ).TotalSeconds );
            lblNumCommunications.Text = String.Format( "Communicated {0} times ({1} direct)", Peer.Statistics.NumOccurrences( PeerStatistics.EventType.Any ), Peer.Statistics.NumDirectOccurrences( ) );

            // Record general inquiries.            
            lblNumIncomingInquiries.Text = String.Format( "{0} incoming", Peer.Statistics.NumOccurrences( PeerStatistics.EventType.ReceivedInfo ) );
            lblNumOutgoingInquiries.Text = String.Format( "{0} outgoing", Peer.Statistics.NumOccurrences( PeerStatistics.EventType.SentInfo ) );

            // Record peer list exchanges.
            lblIncomingPeerExchanges.Text = String.Format( "{0} incoming", Peer.Statistics.NumOccurrences( PeerStatistics.EventType.ReceivedPeerList ) );
            lblOutgoingPeerExchanges.Text = String.Format( "{0} outgoing", Peer.Statistics.NumOccurrences( PeerStatistics.EventType.SentPeerList ) );

            // Record discovery announcements.
            lblNumMulticast.Text = String.Format( "{0} multicast", Peer.Statistics.NumOccurrences( PeerStatistics.EventType.ReceivedAnnouncement ) );
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
