using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace LANdrop.Peering
{
    /// <summary>
    /// Another LANdrop client on the network that we might interact with.
    /// </summary>
    public class Peer
    {
        public string Name { get; set; }

        public IPEndPoint Address { get; set; }

        public DateTime LastSeen { get; set; }

        public void UpdateLastSeen( )
        {
            LastSeen = DateTime.Now;
        }

        public bool IsOnline( )
        {
            return ( DateTime.Now.Subtract( LastSeen ).Seconds < 3 );
        }

        public override String ToString( )
        {
            return Name + " (" + Address + ")";
        }

        public override bool Equals( object other )
        {
            if ( other.GetType( ) != typeof( Peer ) )
                return false;

            return Address.Equals( ( (Peer) other ).Address );
        }
    }
}
