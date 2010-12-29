using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;

namespace LANdrop.Transfers
{
    class IncomingTransfer
    {
        public IncomingTransfer( TcpClient client )
        {
            BinaryReader message = new BinaryReader( client.GetStream( ) );

            // Read in the transfer info.
            int protocolVersion = message.ReadInt32( );
            string fileName = message.ReadString( );
            long fileSize = message.ReadInt64( );

            MessageBox.Show( fileSize + " " + fileSize );
        }
    }
}
