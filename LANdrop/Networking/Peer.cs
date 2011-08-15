using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LANdrop.Networking
{
    /// <summary>
    /// Another LANdrop client on the network that we might interact with.
    /// </summary>
    [JsonObject( MemberSerialization.OptIn )]
    public class Peer
    {
        [JsonProperty]
        public string Name { get; set; }

        public IPEndPoint EndPoint { get; set; }

        [JsonProperty]
        public string EndPointString
        {
            get
            {
                if ( EndPoint != null )
                    return EndPoint.ToString( );
                return null;
            }
            set
            {
                EndPoint = Util.CreateIPEndPoint( value );
            }
        }

        public PeerStatistics Statistics { get; private set; }

        public bool ShouldSendPeers { get { return Statistics.TimeSince( PeerStatistics.EventType.SentPeerList ).TotalMinutes > 2.0; } }

        public bool ShouldLookUp { get { return ( ShouldSendPeers || Statistics.TimeSince( PeerStatistics.EventType.SentInfo ).TotalSeconds > 30 ); } }

        public Peer( )
        {
            Statistics = new PeerStatistics
            {
                LastSeen = DateTime.Now
            };
        }

        public bool IsOnline( )
        {
            return ( DateTime.Now.Subtract( Statistics.LastSeen ).TotalSeconds < 60 );
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

        public void RegisterEvent( PeerStatistics.EventType type ) // Just a simplifier
        {
            Statistics.RegisterEvent( type );
        }

        public void ToStream( BinaryWriter output )
        {
            output.Write( Name );
            output.Write( EndPoint.Address.ToString( ) );
            output.Write( (Int32) EndPoint.Port );
        }

        public Peer( BinaryReader input )
        {
            Name = input.ReadString( );
            EndPoint = new IPEndPoint( IPAddress.Parse( input.ReadString( ) ), input.ReadInt32( ) );
        }
    }
}
