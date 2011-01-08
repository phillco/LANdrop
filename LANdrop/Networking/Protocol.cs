﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LANdrop.Networking
{
    /// <summary>
    /// The universal LANdrop network protocol.
    /// </summary>
    class Protocol
    {
        public const int ProtocolVersion = 103;

        public enum IncomingCommunicationTypes
        {
            FileTransfer = 0,
            TextSnippet = 1
        }

        public const int TransferPortNumber = 50900;

        public const int MulticastPortNumber = 60900;

        public const string MulticastGroupAddress = "239.76.65.78"; // Surprise inside.
      
        public const int TransferChunkSize = ( 1024 * 4 );
    }
}