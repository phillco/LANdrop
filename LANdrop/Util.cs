using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Net.Sockets;
using System.Net;

namespace LANdrop
{
    class Util
    {
        /// <summary>
        /// Corrects the given control (or form) to use the proper, OS-specific font (Segoe UI on Vista+, Tahoma on XP-).
        /// This relies on the fact that MessageBoxFont is always up-to-date, but DefaultFont isn't. (Microsoft...) 
        /// 
        /// Adapted from http://wyday.com/blog/2009/windows-vista-7-font-segoe-ui-in-windows-forms/
        /// </summary>
        public static void UseProperSystemFont( Control control )
        {
            // First correct the size for the control itself.
            if ( control.Font.FontFamily.ToString( ) == SystemFonts.DefaultFont.FontFamily.ToString( ) )
            {
                float size = control.Font.Size;

                // Use 8pt wherever possible.
                if ( control.Font.Size == SystemFonts.MessageBoxFont.Size )
                    size = SystemFonts.DefaultFont.Size;

                control.Font = new Font( SystemFonts.MessageBoxFont.FontFamily.Name, size, control.Font.Style );
            }

            // Fix the font on all of its subcontrols too.
            foreach ( Control subControl in control.Controls )
                UseProperSystemFont( subControl );
        }

        /// <summary>
        /// Formats the given number of bytes into human-readable format (e.g. "72.75 KB").
        /// </summary>
        public static String FormatFileSize( long numBytes )
        {
            string[] types = { "bytes", "KB", "MB", "GB", "TB", "PB", "XB", "ZB", "YB" };

            int index = 0;
            if ( numBytes > 0 )
                index = Math.Min( types.Length - 1, (int) ( Math.Log( numBytes ) / Math.Log( 1024 ) ) );
            return String.Format( "{0:0.##}", (double) numBytes / Math.Pow( 1024, index ) ) + " " + types[index];
        }

        /// <summary>
        /// Binds the socket to the given port. If that port is unavailable, the method will try up to the next 100 ports, sequentially, until one is free.
        /// Returns whether successful.
        /// </summary>
        public static bool BindToFirstPossiblePort( Socket socket, int startPort )
        {
            for ( int port = startPort; port < startPort + 100; port++ )
            {
                try
                {
                    socket.Bind( new IPEndPoint( IPAddress.Any, port ) );
                    return true;
                }
                catch ( SocketException ) { }
            }

            return false;
        }
    }
}
