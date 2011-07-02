using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HybridDSP.Net.HTTP;
using System.IO;
using LANdrop.Properties;
using System.Net.Sockets;

namespace LANdrop.Networking
{
    /// <summary>
    /// The built-in ad-hoc web server, which serves files to recipients who don't have LANdrop.
    /// </summary>
    class HostedFileHandler : IHTTPRequestHandler
    {
        private static readonly Regex UrlMatcher = new Regex( "/([^/]*)(/download)?" );

        public void HandleRequest( HTTPServerRequest request, HTTPServerResponse response )
        {
            var matcher = UrlMatcher.Match( request.URI );

            if ( matcher.Success )
            {
                WebServedFile file = WebServedFile.ActiveFiles.Find( find => find.UniqueId == matcher.Groups[1].Captures[0].Value );

                if ( matcher.Groups[2].Captures.Count > 0 && matcher.Groups[2].Captures[0].Value != "" )
                    sendFile( file, response );
                else
                    sendFileInfoPage( file, response );
            }
        }

        /// <summary>
        /// Writes an xhtml page with information about the given file, including a link to download it.
        /// (The file should download automatically using META REFRESH).
        /// </summary>
        private void sendFileInfoPage( WebServedFile file, HTTPServerResponse response )
        {
            response.ContentType = "text/html";
            try
            {
                using ( Stream ostr = response.Send( ) )
                using ( TextWriter tw = new StreamWriter( ostr ) )
                    tw.WriteLine( Resources.sendFilePage.Replace( "${fileUrl}", file.GetDownloadPath( ) )
                        .Replace( "${fileName}", file.File.Name ) // I should be shot for chaining these together...but with sendFile.html under 500 bytes, 
                        .Replace( "${sender}", Configuration.CurrentSettings.Username ) // the performance hit is pretty negligible.
                        .Replace( "${fileSize}", Util.FormatFileSize( file.File.Length ) ) );
            }
            catch ( IOException ) { }
            catch ( SocketException ) { } // User hung up (closed their browser).
        }

        /// <summary>
        /// Writes the file directly to the http client.
        /// </summary>
        private void sendFile( WebServedFile file, HTTPServerResponse response )
        {
            response.ContentLength = file.File.Length;
            response.Set( "Content-Disposition", "attachment; filename=\"" + file.File.Name + "\"" );

            try
            {
                using ( Stream outStream = response.Send( ) )
                using ( FileStream fileInStream = new FileStream( file.File.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite ) )
                {
                    // Iterate through the file in chunk-sized increments.
                    for ( long i = 0; i < file.File.Length; i += Protocol.TransferChunkSize )
                    {
                        // Calculate the number of bytes we're about to send.
                        int numBytes = (int) Math.Min( Protocol.TransferChunkSize, file.File.Length - i );

                        // Read in the chunk from a file, write it to the network.
                        byte[] chunk = new byte[numBytes];
                        fileInStream.Read( chunk, 0, numBytes );
                        outStream.Write( chunk, 0, chunk.Length );
                    }
                }
            }
            catch ( IOException ) { }
            catch ( SocketException ) { } // User hung up (closed their browser).
        }
    }

    /// <summary>
    /// Justs generates an instance of our request handler.
    /// </summary>
    class RequestHandlerFactory : IHTTPRequestHandlerFactory
    {
        public IHTTPRequestHandler CreateRequestHandler( HTTPServerRequest request )
        {
            return new HostedFileHandler( );
        }
    }

    /// <summary>
    /// Controls the web server.
    /// </summary>
    public class WebServer
    {
        private static HTTPServer server;

        public static void StartIfNotStarted( )
        {
            if ( server == null )
            {
                server = new HTTPServer( new RequestHandlerFactory( ), 8080 );
                server.Start( );
            }
        }

        public static void Stop( )
        {
            if ( server != null )
            {
                server.Stop( );
                server = null;
            }
        }
    }
}
