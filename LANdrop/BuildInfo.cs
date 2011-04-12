using System;
using System.Collections.Generic;
using System.Text;
using LANdrop.Updates;

namespace LANdrop
{
    class BuildInfo
    {
        public const Channel BUILD_TYPE = Channel.NONE;

        public const int BUILD_NUMBER = 0;

        public static bool DoesUpdate
        {
            get { return BuildInfo.BUILD_TYPE != Channel.NONE; }
        }

        public static String ToString( )
        {
            if ( BUILD_TYPE == Channel.NONE )
                return "Custom build";
            else if ( BUILD_TYPE == Channel.RELEASE )
                return "Release build";
            else
                return UpdateChannelToString( ) + " build #" + BUILD_NUMBER;
        }

        public static String UpdateChannelToString( )
        {
            switch ( BUILD_TYPE )
            {
                case Channel.DEV:
                    return "Dev";
                case Channel.BETA:
                    return "Beta";
                case Channel.RELEASE:
                    return "Release";
                default:
                    return "Custom";
            }
        }
    }
}
