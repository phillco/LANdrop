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
                var config = new Configuration
                {
                    Username = Environment.UserName + " on " + Dns.GetHostName( ),
                    UpdateChannel = Channel.Dev,
                    UpdateAutomatically = true
                };

                LastSavedVersion = config.Clone( );
                return config;
            }
        }

        public string Username { get; set; }

        public bool UpdateAutomatically { get; set; }

        public Channel UpdateChannel { get; set; }

        // The last version of the configuration that we saved; used for diffing.
        private static Configuration LastSavedVersion;

        /// <summary>
        /// Called when the configuration is modified (and saved to disk).
        /// </summary>
        public static event ChangeHandler Changed;

        public delegate void ChangeHandler( Configuration oldVersion, Configuration newVersion );


        public static void Initialize( )
        {
            if ( File.Exists( "LANdrop.json" ) )
            {
                using ( StreamReader file = new StreamReader( "LANdrop.json" ) )
                {
                    Instance = JsonConvert.DeserializeObject<Configuration>( file.ReadToEnd( ) );
                    LastSavedVersion = Instance.Clone( );
                }
            }
            else
                LoadDefaultSettings( );
        }

        public Configuration Clone( )
        {
            return JsonConvert.DeserializeObject<Configuration>( ToJsonString() );
        }

        public string ToJsonString( )
        {
            return JsonConvert.SerializeObject( this, Formatting.Indented );
        }

        public static void LoadDefaultSettings( )
        {
            Instance = DefaultSettings;
            Instance.Save( );
        }

        public void Save( )
        {
            if ( Instance.ToJsonString( ) != LastSavedVersion.ToJsonString() )
            {
                if ( Changed != null )
                    Changed( LastSavedVersion, this );

                LastSavedVersion = Clone( );
                ThreadPool.QueueUserWorkItem( delegate { Instance.SaveToFile( ); } );
            }
        }

        private void SaveToFile( )
        {            
            using ( StreamWriter file = new StreamWriter( "LANdrop.json" ) )
                file.Write( ToJsonString() );
        }
    }
}
