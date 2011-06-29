using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using LANdrop.Updates;
using System.ComponentModel;

namespace LANdrop
{
    class Configuration
    {
        public static Configuration Instance { get; private set; }

        public static Configuration DefaultSettings
        {
            get
            {
                return new Configuration
                {
                    Username = Environment.UserName + " on " + Dns.GetHostName( ),
                    UpdateChannel = Channel.Dev,
                    UpdateAutomatically = true
                };
            }
        }

        public string Username { get; set; }

        public bool UpdateAutomatically { get; set; }

        public Channel UpdateChannel { get; set; }

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
            Instance = DefaultSettings;
            Save( );
        }

        public static void Save( )
        {
            ThreadPool.QueueUserWorkItem( delegate { Instance.SaveToFile( ); } );
        }

        private void SaveToFile( )
        {
            using ( StreamWriter file = new StreamWriter( "LANdrop.json" ) )
                file.Write( JsonConvert.SerializeObject( Instance, Formatting.Indented ) );
        }
    }
}
