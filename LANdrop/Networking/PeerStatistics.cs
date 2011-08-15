using System;
using System.Collections.Generic;
using System.Text;

namespace LANdrop.Networking
{
    public class PeerStatistics
    {
        public DateTime LastSeen { get; set; }

        public DateTime LastLookedUp { get; set; }

        public DateTime LastSentPeers { get; set; }

        public DateTime LastReceivedPeers { get; set; }

        public int NumTimesSentPeers { get; set; }

        public int NumTimesReceivedPeers { get; set; }
    }
}
