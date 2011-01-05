using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Net.Sockets;
using System.Net;
using System.IO;

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
        /// Returns the port number if successful, or -1.
        /// </summary>
        public static int BindToFirstPossiblePort( Socket socket, int startPort )
        {
            for ( int port = startPort; port < startPort + 100; port++ )
            {
                try
                {
                    socket.Bind( new IPEndPoint( IPAddress.Any, port ) );
                    return port;
                }
                catch ( SocketException ) { }
            }

            return -1;
        }

        /// <summary>
        /// If the given filename is in use, iteratively appends (#) to the end of the name until one is free. (ex "example" -> "example (2).txt")
        /// </summary>
        public static string FindFreeFileName( string fileName )
        {
            // If the file is free, just use it.
            if ( !File.Exists( fileName ) )
                return fileName;

            FileInfo fileInfo = new FileInfo( fileName );

            // Otherwise, keep trying files with new
            for ( int i = 1; i < 1000; i++ )
            {
                string newFilename = String.Format( "{0} ({1}){2}", fileInfo.FullName.Substring( 0, fileInfo.FullName.Length - fileInfo.Extension.Length ), i, fileInfo.Extension );
                if ( !File.Exists( newFilename ) )
                    return newFilename;
            }

            throw new IOException( "A free filename was not found." );
        }

        /// <summary>
        /// Returns a version of the given filename, but without any illegal characters (they'll be converted to underscores).
        /// Adapted from http://stackoverflow.com/questions/333175/is-there-a-way-of-making-strings-file-path-safe-in-c.
        /// </summary>
        public static string MakeFilenameSafe( string fileName )
        {
            string safeVersion = fileName;

            foreach ( char c in Path.GetInvalidFileNameChars( ) )
                safeVersion = safeVersion.Replace( c.ToString( ), "_" );

            return safeVersion;
        }

        /// <summary>
        /// Returns the path to use for the application's log file. The filename is based on the local computer name and the current time.
        /// </summary>
        public static string GetLogFileName( )
        {
            // The "Logs" folder is in LANdrop's application folder.
            string logFolder = Path.Combine( Environment.GetFolderPath( Environment.SpecialFolder.ApplicationData ), "LANdrop\\Logs\\" );
            Directory.CreateDirectory( logFolder );
            
            // Create the filename based on the information we have.
            string logFilename = "LANdrop_" + Dns.GetHostName( ) + "_" + DateTime.Now.ToString( "yyyy_MM_dd-H_MM_ss" ) + ".log";

            // Remove any naughty characters.
            logFilename = Util.MakeFilenameSafe( logFilename );

            // Put it in the logs directory.
            logFilename = Path.Combine( logFolder, logFilename );

            // Lastly, just in case there's already a file with this name, add a (2) to the end.
            return Util.FindFreeFileName( logFilename  );
        }

    }
}
