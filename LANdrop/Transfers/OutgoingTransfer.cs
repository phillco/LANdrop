using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using LANdrop.Peering;

namespace LANdrop.Transfers
{
    class OutgoingTransfer
    {
        public OutgoingTransfer( FileInfo file, Peer recipient )
        {
            // Connect to the peer's listening server.
            TcpClient client = new TcpClient( );
            client.Connect( recipient.Address );

            // Send the file information.
            BinaryWriter message = new BinaryWriter( client.GetStream( ) );
            message.Write( (Int32) Protocol.ProtocolVersion );
            message.Write( file.Name );
            message.Write( file.Length );
            client.GetStream( ).Flush( );            
        }
    }
}
