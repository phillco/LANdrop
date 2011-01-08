using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace LANdrop.Networking
{
    /// <summary>
    /// Another LANdrop client on the network that we might interact with.
    /// </summary>
    public class Peer
    {
        public string Name { get; set; }

        public IPEndPoint Address { get; set; }

        public DateTime LastSeen { get; set; }

        public DateTime LastLookedUp { get; set; }

        public bool IsOnline( )
        {
            return ( DateTime.Now.Subtract( LastSeen ).Seconds < 60 );
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
