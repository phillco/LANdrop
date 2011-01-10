using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;
using System.Net;

namespace LANdrop
{
    class Configuration
    {
        public static Configuration Instance { get; private set; }

        public string Username { get; set; }

        public static void Initialize( )
        {
            if ( File.Exists( "LANdrop.json" ) )
            {
                using ( StreamReader file = new StreamReader( "LANdrop.json" ) )
                    Instance = JsonConvert.DeserializeObject<Configuration>( file.ReadToEnd( ) );
            }
            else
                LoadDefaultSettings( );
        }

        public static void LoadDefaultSettings( )
        {
            Instance = new Configuration
            {
                Username = Environment.UserName + " on " + Dns.GetHostName( ),
            };

            Save( );
        }

        public static void Save( )
        {
            using ( StreamWriter file = new StreamWriter( "LANdrop.json" ) )
            {
                string data = JsonConvert.SerializeObject( Instance, Formatting.Indented );
                MessageBox.Show( "Save: \n" + data );
                file.Write( data );
            }
        }
    }
}
