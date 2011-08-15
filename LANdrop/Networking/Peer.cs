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

        public DateTime LastSeen { get; set; }

        public DateTime LastLookedUp { get; set; }

        public DateTime LastSentPeers { get; set; }

        public DateTime LastReceivedPeers { get; set; }

        public int NumTimesSentPeers { get; set; }

        public int NumTimesReceivedPeers { get; set; }

        public bool ShouldSendPeers { get { return DateTime.Now.Subtract( LastSentPeers ).TotalMinutes > 2.0; }}

        public bool ShouldLookUp { get { return ( ShouldSendPeers || DateTime.Now.Subtract( LastLookedUp ).TotalSeconds > 30 ); } }

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
