using System;
using System.Collections.Generic;
using System.Text;

namespace LANdrop.Networking.PeerDiscovery
{
    interface IPeerDiscoverer
    {
        void Start( );

        void Stop( );

        /// <summary>
        /// Do whatever you can to get the latest batch of peers.
        /// </summary>
        void Refresh();
    }  
}
