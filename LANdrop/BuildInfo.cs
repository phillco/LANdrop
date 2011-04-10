using System;
using System.Collections.Generic;
using System.Text;

namespace LANdrop
{
    class BuildInfo
    {
        public enum UpdateChannels
        {
            NONE, DEV, BETA, RELEASE
        }

        public const UpdateChannels BUILD_TYPE = UpdateChannels.NONE;

        public const int BUILD_NUMBER = 0;

        public static String ToString( )
        {
            if ( BUILD_TYPE == UpdateChannels.NONE )
                return "Custom build";
            else
                return UpdateChannelToString( ) + " build #" + BUILD_NUMBER;
        }

        public static String UpdateChannelToString( )
        {
            switch ( BUILD_TYPE )
            {
                case UpdateChannels.DEV:
                    return "Dev";
                case UpdateChannels.BETA:
                    return "Beta";
                case UpdateChannels.RELEASE:
                    return "Release";
                default:
                    return "Custom";
            }
        }
    }
}
