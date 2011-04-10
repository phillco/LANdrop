using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BuildPrepare
{
    class Program
    {
        const string fileName = "LANdrop/BuildInfo.cs";
        const string tempFileName = "LANdrop/BuildInfo.old.cs";

        const string versionDef = @"public const int BUILD_NUMBER = ";
        const string channelDef = @"public const UpdateChannels BUILD_TYPE = UpdateChannels.";

        static void Main( string[] args )
        {
            if ( args.Length < 2 )
            {
                Console.WriteLine( "Usage: LDprepare buildNumber channel" );
                Environment.Exit( -1 );
                return;
            }

            if ( !File.Exists( fileName ) )
            {
                Console.WriteLine( fileName + " does not exist" );
                Environment.Exit( -2 );
                return;
            }

            File.Delete( tempFileName );
            File.Move( fileName, tempFileName );

            using ( StreamReader reader = new StreamReader( tempFileName ) )
            using ( StreamWriter writer = new StreamWriter( fileName ) )
            {
                while ( !reader.EndOfStream )
                {
                    string line = reader.ReadLine( );

                    if ( line.Trim( ).StartsWith( versionDef ) )
                        line = versionDef + args[0] + ";";
                    if ( line.Trim( ).StartsWith( channelDef ) )
                        line = channelDef + args[1] + ";";

                    Console.WriteLine( line );
                    writer.WriteLine( line );
                }
            }
        }
    }
}
