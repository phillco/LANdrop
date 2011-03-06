using System;
using System.Collections.Generic;
using System.Text;
using HybridDSP.Net.HTTP;
using System.IO;

namespace LANdrop.Networking
{
    /// <summary>
    /// The built-in ad-hoc web server, which serves files to recipients who don't have LANdrop.
    /// </summary>
    class HostedFileHandler : IHTTPRequestHandler
    {
        public void HandleRequest( HTTPServerRequest request, HTTPServerResponse response )
        {
            foreach ( WebServedFile file in WebServedFile.ActiveFiles )
            {
                if ( file.Expired )
                    continue;

                // Does the user's request match this file's ID?
                if ( request.URI == "/" + file.GetInfoPagePath( ) ) // User wants the landing page.
                    sendFileInfoPage( file, response );
                else if ( request.URI == "/" + file.GetDownloadPath( ) ) // User wants the file!
                    sendFile( file, response );
            }
        }

        /// <summary>
        /// Writes an xhtml page with information about the given file, including a link to download it.
        /// (The file should download automatically using META REFRESH).
        /// </summary>
        private void sendFileInfoPage( WebServedFile file, HTTPServerResponse response )
        {
            response.ContentType = "text/html";
            using ( Stream ostr = response.Send( ) )
            using ( TextWriter tw = new StreamWriter( ostr ) )
            {
                tw.WriteLine( "<html>" );
                tw.WriteLine( "<head>" );
                tw.WriteLine( "<title>" + file.File.Name + "</title>" );
                tw.WriteLine( "<meta http-equiv=\"REFRESH\" content=\"0;url=" + file.GetDownloadPath( ) + "\" />" );
                tw.WriteLine( "</header>" );
                tw.WriteLine( "<body>" );
                tw.WriteLine( "<h1><a href='" + file.GetDownloadPath( ) + "'>" + file.File.Name + "</a></h1>" );
                tw.WriteLine( "<div>Sent to you from <i>" + Configuration.Instance.Username + "</i> using <a href=\"http://landrop.net\">LANdrop</a>.</div>" );
                tw.WriteLine( "</body>" );
                tw.WriteLine( "</html>" );
            }
        }

        /// <summary>
        /// Writes the file directly to the http client.
        /// </summary>
        private void sendFile( WebServedFile file, HTTPServerResponse response )
        {
            response.ContentLength = file.File.Length;
            response.Set( "Content-Disposition", "attachment; filename=\"" + file.File.Name + "\"" );

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
    }

    /// <summary>
    /// Justs spits out an instance of our request handler.
    /// </summary>
    class RequestHandlerFactory : IHTTPRequestHandlerFactory
    {
        public IHTTPRequestHandler CreateRequestHandler( HTTPServerRequest request )
        {
            return new HostedFileHandler( );
        }
    }
}
