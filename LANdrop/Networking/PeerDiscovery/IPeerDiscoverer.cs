using System;
using System.Collections.Generic;
using System.Text;

namespace LANdrop.Networking.PeerDiscovery
{
    interface IPeerDiscoverer
    {
        event DiscoveryUtils.PeersDiscoveredHandler  PeersDiscovered;

        void Start( );

        void Stop( );

        /// <summary>
        /// Do whatever you can to get the latest batch of peers.
        /// </summary>
        void Refresh();
    }

    sealed class DiscoveryUtils
    {
        // Phillip is very unhappy that he has to declare this in its own class.
        public delegate void PeersDiscoveredHandler(IList<Peer> peers);
    }
}
