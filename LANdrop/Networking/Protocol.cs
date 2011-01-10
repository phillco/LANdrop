using System;
using System.Collections.Generic;
using System.Text;

namespace LANdrop.Networking
{
    /// <summary>
    /// The universal LANdrop network protocol.
    /// </summary>
    class Protocol
    {
        /// <summary>
        /// What type of message this is. One of these is included after the protocol version.
        /// </summary>
        public enum IncomingCommunicationTypes
        {
            FileTransfer = 0,
            TextSnippet = 1,
            WhosThere = 2
        }

        /// <summary>
        /// The version of the protocol we're using. LANdrop is only compatible with clients running the same version.
        /// </summary>
        public const int Version = 107;

        /// <summary>
        /// The default port LANdrop peers use for their listening servers. To find the current port for this instance, use Server.Port.
        /// </summary>
        public const int DefaultServerPort = 50900;

        /// <summary>
        /// The port we join the multicast group on. We must bind our listener to this port to receive anything.
        /// </summary>
        public const int MulticastPort = 60900;

        /// <summary>
        /// The address of the IP Multicast group we join.
        /// </summary>
        public const string MulticastGroupAddress = "239.76.65.78"; // Surprise inside.
      
        /// <summary>
        /// During a transfer, blocks of bytes are pumped down to TCP in chunks of this size.
        /// </summary>
        public const int TransferChunkSize = ( 1024 * 4 );
    }
}
