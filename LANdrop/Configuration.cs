using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using LANdrop.Updates;
using System.ComponentModel;
using Nini;
using Nini.Config;

namespace LANdrop
{
    class Configuration
    {
        public static Configuration CurrentSettings { get; private set; }

        public static Configuration DefaultSettings
        {
            get
            {
                var config = new Configuration
                {
                    Username = Environment.UserName + " (" + Dns.GetHostName( ) + ")",
                    UpdateAutomatically = true,
                    UpdateChannel = Channel.Dev,
                };

                return config;
            }
        }

        public string Username { get; set; }

        public bool UpdateAutomatically { get; set; }

        public Channel UpdateChannel { get; set; }

        /// <summary>
        /// Called when the configuration is modified (and saved to disk).
        /// </summary>
        public static event ChangeHandler Changed;

        public delegate void ChangeHandler( );

        public static void Initialize( )
        {
            CurrentSettings = DefaultSettings;
            if ( File.Exists( "LANdrop.ini" ) )
                Load( "LANdrop.ini" );
        }


        public static void Load( string filename )
        {
            IConfigSource source = new IniConfigSource( filename );

            try
            {
                CurrentSettings.Username = source.Configs["General"].Get( "Username", DefaultSettings.Username );
                CurrentSettings.UpdateAutomatically = source.Configs["Updates"].GetBoolean( "Enabled", DefaultSettings.UpdateAutomatically );
                CurrentSettings.UpdateChannel = ChannelFunctions.Parse( source.Configs["Updates"].Get( "Channel", DefaultSettings.UpdateChannel.ToString( ) ) );
            }
            catch ( ArgumentException )
            {
                CurrentSettings = DefaultSettings;
                MessageBox.Show( "There was an error reading the configuration file. The default settings have been loaded.", "LANdrop", MessageBoxButtons.OK, MessageBoxIcon.Warning );
            }
        }

        public void Save( )
        {
            IniConfigSource source = new IniConfigSource( );

            IConfig config = source.AddConfig( "General" );
            config.Set( "Username", Username );

            config = source.AddConfig( "Updates" );
            config.Set( "Enabled", UpdateAutomatically );
            config.Set( "Channel", UpdateChannel.ToString( ) );

            source.Save( "LANdrop.ini" );

            if ( Changed != null )
                Changed( );
        }

        public static void ResetToDefaultSettings( )
        {
            CurrentSettings = DefaultSettings;
            CurrentSettings.Save( );
        }
    }
}
