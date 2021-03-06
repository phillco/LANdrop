﻿using System;
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
    /// <summary>
    /// Stores LANdrop's user-controlled settings, which is written to an INI file.
    /// </summary>
    class Configuration
    {
        //=======================================================
        //
        // The settings themselves.
        //
        //=======================================================

        public string Username { get; set; }

        public bool UpdateAutomatically { get; set; }

        public Channel UpdateChannel { get; set; }

        //=======================================================
        //
        // Static variables & events.
        //
        //=======================================================

        /// <summary>
        /// Where the configuration file is stored.
        /// </summary>
        public const string ConfigFileName = "LANdrop.ini";

        /// <summary>
        /// The latest version of the config file format. Used to detect and update older configurations when we rearrange things.
        /// </summary>
        public const int ConfigFileVersion = 1;

        /// <summary>
        /// LANdrop's current, active settings.
        /// </summary>
        public static Configuration CurrentSettings { get; private set; }

        /// <summary>
        /// LANdrop's factory-default settings.
        /// </summary>
        public static Configuration DefaultSettings
        {
            get
            {
                return new Configuration
                {
                    Username = Environment.UserName + " (" + Dns.GetHostName( ) + ")",
                    UpdateAutomatically = true,
                    UpdateChannel = BuildInfo.Version.Channel,
                };
            }
        }

        /// <summary>
        /// The last set of settings that LANdrop saved - used for diffing.
        /// </summary>
        public static Configuration LastSavedSettings { get; private set; }

        /// <summary>
        /// Called whenever the configuration is saved.
        /// </summary>
        public static event ChangeHandler Changed;

        public delegate void ChangeHandler( Configuration oldVersion );

        /// <summary>
        /// Initializes the configuration module and loads the user's settings.
        /// </summary>
        public static void Initialize( )
        {
            CurrentSettings = LastSavedSettings = DefaultSettings;
            if ( File.Exists( ConfigFileName ) )
                Load( ConfigFileName );
            CurrentSettings.Save( );
        }

        /// <summary>
        /// Loads the current configuration from the given file.
        /// </summary>
        /// <param name="filename"></param>
        public static void Load( string filename )
        {
            IConfigSource source = new IniConfigSource( filename );

            try
            {
                int configVersion = source.Configs["General"].GetInt( "ConfigVersion", ConfigFileVersion );
                CurrentSettings.Username = source.Configs["General"].Get( "Username", DefaultSettings.Username );
                CurrentSettings.UpdateAutomatically = source.Configs["Updates"].GetBoolean( "Enabled", DefaultSettings.UpdateAutomatically );
                CurrentSettings.UpdateChannel = ChannelFunctions.Parse( source.Configs["Updates"].Get( "Channel", DefaultSettings.UpdateChannel.ToString( ) ) );
                CurrentSettings.Repair( );
            }
            catch ( ArgumentException )
            {
                CurrentSettings = DefaultSettings;
                MessageBox.Show( "There was an error reading the configuration file. The default settings have been loaded.", "LANdrop", MessageBoxButtons.OK, MessageBoxIcon.Warning );
            }
        }

        /// <summary>
        /// Corrects any inconsistencies in this configuration.
        /// </summary>
        public void Repair( )
        {
            // The channel really shouldn't be set to "none"; doing so really means UpdateAutomatically is false. 
            if ( UpdateChannel == Channel.None )
            {
                UpdateChannel = BuildInfo.Version.Channel;
                UpdateAutomatically = false;
            }
        }

        /// <summary>
        /// Returns a deep copy of this configuration.
        /// </summary>
        public Configuration Clone( )
        {
            return new Configuration
            {
                Username = Username,
                UpdateAutomatically = UpdateAutomatically,
                UpdateChannel = UpdateChannel
            };
        }

        /// <summary>
        /// Saves the current configuration to disk.
        /// </summary>
        public void Save( )
        {
            Repair( );

            IniConfigSource source = new IniConfigSource( );

            IConfig config = source.AddConfig( "General" );
            config.Set( "Username", Username );
            config.Set( "ConfigVersion", ConfigFileVersion );

            config = source.AddConfig( "Updates" );
            config.Set( "Enabled", UpdateAutomatically );
            config.Set( "Channel", UpdateChannel.ToString( ) );

            source.Save( ConfigFileName );
            
            if ( Changed != null )
                Changed( LastSavedSettings );
            
            LastSavedSettings = Clone();
        }

        /// <summary>
        /// Loads the factory-default settings and saves them.
        /// </summary>
        public static void ResetToDefaultSettings( )
        {
            CurrentSettings = DefaultSettings;
            CurrentSettings.Save( );
        }
    }
}
