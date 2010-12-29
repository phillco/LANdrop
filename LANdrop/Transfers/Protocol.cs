using System;
using System.Collections.Generic;
using System.Text;

namespace LANdrop.Transfers
{
    /// <summary>
    /// The universal LANdrop network protocol.
    /// </summary>
    class Protocol
    {
        public const int ProtocolVersion = 100;

        public const int TransferPortNumber = 50900;

        public const int MulticastPortNumber = 60900;

        public const string MulticastGroupAddress = "239.76.65.78"; // Surprise inside.        
    }
}
