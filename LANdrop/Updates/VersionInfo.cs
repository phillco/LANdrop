using System;
using System.Collections.Generic;
using System.Text;

namespace LANdrop.Updates
{
    /// <summary>
    /// The format of version.json, which we get from landrop.net.
    /// </summary>
    public class VersionInfo
    {
        public int BuildNumber;
        public DateTime BuildDate;
        public Channel Channel;

        /// <summary>
        /// Returns a short summary about this build ("Beta build #50").
        /// </summary>
        /// <returns></returns>
        public override String ToString( )
        {
            if ( Channel == Channel.None )
                return "Custom build";
            else if ( Channel == Channel.Release )
                return "Release build";
            else
                return UpdateChannelToString( ) + " build #" + BuildNumber;
        }

        /// <summary>
        /// Returns a string version of this build's channel.
        /// </summary>
        /// <returns></returns>
        public String UpdateChannelToString( )
        {
            switch ( Channel )
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
