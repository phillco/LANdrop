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

        public IPEndPoint EndPoint { get; set; }

        public DateTime LastSeen { get; set; }

        public DateTime LastLookedUp { get; set; }

        public DateTime LastExchangedPeers { get; set; }

        public Peer( )
        {
            LastSeen = DateTime.Now;
        }

        public bool IsOnline( )
        {
            return ( DateTime.Now.Subtract( LastSeen ).TotalSeconds < 60 );
        }

        public override String ToString( )
        {
            return Name + " (" + EndPoint + ")";
        }

        public override bool Equals( object other )
        {
            if ( other.GetType( ) != typeof( Peer ) )
                return false;

            return EndPoint.Equals( ( (Peer) other ).EndPoint );
        }

        public bool ShouldDoPeerExchange( )
        {
            return ( DateTime.Now.Subtract( LastExchangedPeers ).TotalMinutes > 2.0 );
        }

        public bool ShouldLookUp( )
        {
            return ( ShouldDoPeerExchange( ) || DateTime.Now.Subtract( LastLookedUp ).TotalSeconds > 30 );
        }

        public void ToStream( BinaryWriter output )
        {
            output.Write( Name );
            output.Write( EndPoint.Address.ToString() );
            output.Write( (Int32) EndPoint.Port );
        }

        public Peer( BinaryReader input )
        {
            Name = input.ReadString( );
            EndPoint = new IPEndPoint( IPAddress.Parse( input.ReadString( ) ), input.ReadInt32( ) );
        }
    }
}
