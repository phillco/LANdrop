using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LANdrop.Networking
{
    /// <summary>
    /// A file being served by the built-in ad-hoc HTTP server.
    /// </summary>
    public class WebServedFile
    {
        public static List<WebServedFile> ActiveFiles { get; private set; }

        public FileInfo File { get; private set; }

        public DateTime DateExpires { get; private set; }

        public string UniqueId { get; private set; }

        public bool Expired { get { return DateExpires.CompareTo( DateTime.Now ) < 0; } }

        static WebServedFile( )
        {
            ActiveFiles = new List<WebServedFile>( );
        }

        public static void PruneExpiredFiles( )
        {
            ActiveFiles.RemoveAll( file => file.Expired );
        }

        public WebServedFile( string filename )
        {
            File = new FileInfo( filename );
            UniqueId = Util.Base36Encode( new Random( ).Next( Int32.MaxValue - 512 ) + 512 ); // Start at 512
            DateExpires = DateTime.Now.AddMinutes( 30 );
            ActiveFiles.Add( this );
        }

        public string GetLink( )
        {
            return "http://" + Util.GetLocalAddress( ) + ":8080/" + GetInfoPagePath( );
        }

        public string GetInfoPagePath( )
        {
            return UniqueId;
        }

        public string GetDownloadPath( )
        {
            return UniqueId + "/download";
        }
    }
}
