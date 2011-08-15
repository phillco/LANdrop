using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;

namespace LANdrop.Networking
{
    /// <summary>
    /// The JSON header sent at the beginning of all LANdrop communication.
    /// </summary>
    public class Header
    {
        // The Sender field contains information about the sender. (duh). It's always sent.
        public SenderDetails Sender { get; set; }

        // The Transfer field is sent if the sender's offering us a file transfer.
        public TransferDetails Transfer { get; set; }

        // The sender's peer list is sent occasionally, to aid with discovery.
        public List<Peer> Peers { get; set; }

        public Header( )
        {
            IncludeSenderDetails( );
        }

        public Header( bool includePeerList )
            : this( )
        {
            if ( includePeerList )
                IncludePeerList( );
        }

        public Header( FileInfo file, bool includePeerList = false )
            : this( includePeerList )
        {
            IncludeFileDetails( file );
        }

        public static Header Parse( string json )
        {
            return JsonConvert.DeserializeObject<Header>( json );
        }

        public override string ToString( )
        {
            return JsonConvert.SerializeObject( this );
        }

        public void IncludeSenderDetails( )
        {
            Sender = new SenderDetails
            {
                Username = Configuration.CurrentSettings.Username,
                ComputerName = Dns.GetHostName( ),
                ListenPort = Server.Port
            };
        }

        public void IncludeFileDetails( FileInfo file )
        {
            Transfer = new TransferDetails
            {
                FileName = file.Name,
                FileSizeBytes = file.Length
            };
        }

        public void IncludePeerList( )
        {
            Peers = PeerList.Peers;
        }

        //===============================================
        //
        //  SUBCLASSES
        //
        //===============================================

        public class TransferDetails
        {
            public string FileName { get; set; }

            public long FileSizeBytes { get; set; }
        }

        public class SenderDetails
        {
            public string Username { get; set; }

            public string ComputerName { get; set; }

            public int ListenPort { get; set; }
        }
    }
}
