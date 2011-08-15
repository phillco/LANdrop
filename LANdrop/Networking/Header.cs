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
            : this( false )
        {
        }

        public Header( bool includePeerList = false )
        {
            SetSenderDetails( );

            if ( includePeerList )
                SetPeerList( );
        }

        public Header( FileInfo file )
            : this( )
        {
            SetFileDetails( file );
        }

        public static Header Parse( string json )
        {
            return JsonConvert.DeserializeObject<Header>( json );
        }

        public override string ToString( )
        {
            return JsonConvert.SerializeObject( this );
        }

        private void SetSenderDetails( )
        {
            Sender = new SenderDetails
            {
                Username = Configuration.CurrentSettings.Username,
                ComputerName = Dns.GetHostName( ),
                ListenPort = Server.Port
            };
        }

        private void SetFileDetails( FileInfo file )
        {
            Transfer = new TransferDetails
            {
                FileName = file.Name,
                FileSizeBytes = file.Length
            };
        }

        private void SetPeerList( )
        {
            Peers = PeerList.Peers;
        }

        //===============================================
        //
        //  SPECIFIC CLASSES BELOW
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
