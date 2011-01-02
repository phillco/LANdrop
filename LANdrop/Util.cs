using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LANdrop
{
    class Util
    {
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
    }
}
