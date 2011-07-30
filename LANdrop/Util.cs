using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using LANdrop.Networking;
using System.Reflection;

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
        public static String FormatFileSize( double numBytes )
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

            // Otherwise, keep trying sequential filenames.
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
        /// Returns the computer's IP list.
        /// TODO: This is a depreciated and overly simplistic method (computers can have multiple IPs).
        /// </summary>
        public static IPAddress GetLocalAddress( )
        {
            IPAddress[] results = Dns.GetHostEntry( Dns.GetHostName( ) ).AddressList;

            if ( results.Length == 0 )
                return null;

            // First try to get an IPv4 address. These are easier to type and seem to work better on campus.
            foreach ( IPAddress address in results )
                if ( address.AddressFamily == AddressFamily.InterNetwork )
                    return address;

            // No IPv4, so return the IPv6 address instead.
            return results[0];
        }

        /// <summary>
        /// Converts the given byte-array hash to a human-readible hex string.
        /// </summary>
        public static string HashToHexString( byte[] hash )
        {
            StringBuilder builder = new StringBuilder( );
            for ( int i = 0; i < hash.Length; i++ )
                builder.Append( hash[i].ToString( "X2" ) );

            return builder.ToString( );
        }

        /// <summary>
        /// Safely retrieves the clipboard's contents. Returns null if unsuccessful (or the clipboard doesn't contain text).
        /// </summary>
        /// <param name="offerToRetry">If true, the user is prompted to retry if another application is using the clipboard.</param>
        public static string GetClipboardTextSafely( bool offerToRetry )
        {
            while ( true )
            {
                try
                {
                    if ( !Clipboard.ContainsText( ) )
                        return null;

                    return Clipboard.GetText( );
                }
                catch ( System.Runtime.InteropServices.ExternalException )
                {
                    // If we don't want to bother asking the user, or they decline, just return null.
                    if ( !offerToRetry || MessageBox.Show( "Another program is using the clipboard. Would you like to try again?", "Clipboard Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning ) != DialogResult.Yes )
                        return null;
                }
            }
        }

        /// <summary>
        /// Safely sets the clipboard's contents. Returns whether successful.
        /// </summary>
        /// <param name="offerToRetry">If true, the user is prompted to retry if another application is using the clipboard.</param>
        public static bool SetClipboardTextSafely( string newText, bool offerToRetry )
        {
            while ( true )
            {
                try
                {
                    Clipboard.SetText( newText );
                    return true;
                }
                catch ( System.Runtime.InteropServices.ExternalException )
                {
                    // If we don't want to bother asking the user, or they decline, just return null.
                    if ( !offerToRetry || MessageBox.Show( "Another program is using the clipboard. Would you like to try again?", "Clipboard Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning ) != DialogResult.Yes )
                        return false;
                }
            }
        }

        /// <summary>
        /// Returns whether the given text is a valid network address.
        /// </summary>
        public static bool IsValidAddress( string entry )
        {
            IPAddress dummy;
            return IPAddress.TryParse( entry, out dummy );
        }

        // For the base36 encode/decode methods.
        private const string base36Chars = "0123456789abcdefghijklmnopqrstuvwxyz";

        /// <summary>
        /// Converts the given base36 string to a number.
        /// from http://www.stum.de/2008/10/20/base36-encoderdecoder-in-c/
        /// </summary>
        public static long Base36Decode( string inputString )
        {
            inputString = Reverse( inputString.ToLower( ) );
            long result = 0;
            int pos = 0;
            foreach ( char c in inputString )
                result += base36Chars.IndexOf( c ) * (long) Math.Pow( 36, pos++ );

            return result;
        }

        /// <summary>
        /// Encodes the given int in base36.
        /// from http://www.stum.de/2008/10/20/base36-encoderdecoder-in-c/
        /// </summary>
        public static string Base36Encode( long inputNumber )
        {
            StringBuilder sb = new StringBuilder( );
            while ( inputNumber != 0 )
            {
                sb.Append( base36Chars[(int) ( inputNumber % 36 )] );
                inputNumber /= 36;
            }
            return Reverse( sb.ToString( ) );
        }

        /// <summary>
        /// Reverses the given string, intelligently (using StringBuilder).
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string Reverse( string input )
        {
            Stack<char> resultStack = new Stack<char>( );
            foreach ( char c in input )
                resultStack.Push( c );

            StringBuilder sb = new StringBuilder( );
            while ( resultStack.Count > 0 )
                sb.Append( resultStack.Pop( ) );
            return sb.ToString( );
        }

        /// <summary>
        /// Returns true if the given transfer is incoming; false if outgoing.
        /// </summary>
        public static bool IsTransferIncoming( Transfer t )
        {
            return ( typeof( IncomingTransfer ) == t.GetType( ) );
        }

        /// <summary>
        /// Returns the current version of the calling assembly (eg "1.5.6.0").
        /// </summary>
        /// <returns></returns>
        public static string GetProgramVersion( )
        {
            Assembly entryAssembly = Assembly.GetEntryAssembly( );
            if ( entryAssembly != null )
            {
                AssemblyName entryAssemblyName = entryAssembly.GetName( );
                if ( entryAssemblyName != null && entryAssemblyName.Version != null )
                    return String.Format( "{0}.{1}.{2}", entryAssemblyName.Version.Major, entryAssemblyName.Version.Minor, entryAssemblyName.Version.Build );
            }

            return "Unknown";
        }

        /// <summary>
        /// Returns the version of Windows the local computer is running (ex: "Windows XP SP3 32-bit").
        /// Adapted from http://andrewensley.com/2009/06/c-detect-windows-os-part-1/
        /// </summary>
        public static string GetWindowsVersion( )
        {
            // Start with the Windows version.
            string operatingSystem = "Windows " + GetBaseWindowsVersion( );

            // Add the service pack, if any.
            if ( Environment.OSVersion.ServicePack.Length > 0 )
                operatingSystem += " " + Environment.OSVersion.ServicePack;

            // Add the architecture (32-bit/64-bit).
            operatingSystem += " " + GetOSArchitecture( ).ToString( ) + "-bit";

            return operatingSystem.Trim( );
        }

        /// <summary>
        /// Retuurns whether we're on a 32 or 64-bit architecture.
        /// </summary>
        /// <returns></returns>
        public static int GetOSArchitecture( )
        {
            string pa = Environment.GetEnvironmentVariable( "PROCESSOR_ARCHITECTURE" );
            return ( ( String.IsNullOrEmpty( pa ) || String.Compare( pa, 0, "x86", 0, 3, true ) == 0 ) ? 32 : 64 );
        }

        /// <summary>
        /// Returns just the raw version of windows we're running (no service packs or achitecture).
        /// </summary>
        /// <returns></returns>
        protected static string GetBaseWindowsVersion( )
        {
            OperatingSystem os = Environment.OSVersion;
            Version vs = os.Version;

            if ( os.Platform == PlatformID.Win32Windows ) // A pre-NT version of Windows.
            {
                switch ( vs.Minor )
                {
                    case 0:
                        return "95";
                    case 10:
                        if ( vs.Revision.ToString( ) == "2222A" )
                            return "98SE";
                        else
                            return "98";
                    case 90:
                        return "Me";
                }
            }
            else if ( os.Platform == PlatformID.Win32NT ) // NT-based windows.
            {
                switch ( vs.Major )
                {
                    case 3:
                        return "NT 3.51";
                    case 4:
                        return "NT 4.0";
                    case 5:
                        if ( vs.Minor == 0 )
                            return "2000";
                        else
                            return "XP";
                    case 6:
                        if ( vs.Minor == 0 )
                            return "Vista";
                        else
                            return "7";
                }
            }
            return "Unknown";
        }

        /// <summary>
        /// Restarts the local executable without any command-line arguments.
        /// </summary>
        public static void RestartApplication( )
        {
            using ( Process proc = new Process( ) )
            {
                proc.StartInfo.FileName = Application.ExecutablePath;
                proc.Start( );
            }
        }
    }
}
