using System;
using System.Collections.Generic;
using System.Text;
using LANdrop.Updates;

namespace LANdrop
{
    /// <summary>
    /// Information about the current LANdrop build.
    /// The landrop.net build server will update this files to tag deployed EXEs ("dev build #76", etc)
    /// 
    /// If you update this file, be sure to update BuildPrepare/Program.cs, too!
    /// </summary>
    class BuildInfo
    {
        /// <summary>
        /// Which channel this was created on. (None = hand-compiled, not made by the build server)
        /// </summary>
        public const Channel BuildChannel = Channel.None;

        /// <summary>
        /// Which build number this EXE was made for.
        /// </summary>
        public const int BuildNumber = 0;

        /// <summary>
        /// Does this LANdrop build receive automatic updates? (Not true if it was hand-compiled)
        /// </summary>
        public static bool DoesUpdate
        {
            get { return BuildInfo.BuildChannel != Channel.None; }
        }

        /// <summary>
        /// Returns a short summary about this build ("Beta build #50").
        /// </summary>
        /// <returns></returns>
        public static String ToString( )
        {
            if ( BuildChannel == Channel.None )
                return "Custom build";
            else if ( BuildChannel == Channel.Release )
                return "Release build";
            else
                return UpdateChannelToString( ) + " build #" + BuildNumber;
        }

        /// <summary>
        /// Returns a string version of this build's channel.
        /// </summary>
        /// <returns></returns>
        public static String UpdateChannelToString( )
        {
            switch ( BuildChannel )
            {
                case Channel.Dev:
                    return "Dev";
                case Channel.Beta:
                    return "Beta";
                case Channel.Release:
                    return "Release";
                default:
                    return "Custom";
            }
        }
    }
}
