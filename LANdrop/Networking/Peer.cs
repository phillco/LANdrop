using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

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

        public DateTime LastExchangedPeers { get; set; }

        public Peer( ) { }

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

        public void ToStream( BinaryWriter output )
        {
            output.Write( Name );
            output.Write( Address.Address.ToString() );
            output.Write( (Int32) Address.Port );
        }

        public Peer( BinaryReader input )
        {
            Name = input.ReadString( );
            Address = new IPEndPoint( IPAddress.Parse( input.ReadString( ) ), input.ReadInt32( ) );
        }
    }
}
