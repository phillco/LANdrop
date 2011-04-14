using System;
using System.Collections.Generic;
using System.Text;

namespace LANdrop.Updates
{
    public enum Channel
    {
        None, Dev, Beta, Release
    }

    public class ChannelFunctions
    {
        public static Channel Parse( string text )
        {
            try
            {
                return (Channel) Enum.Parse( typeof( Channel ), text, true );
            }
            catch ( ArgumentException )
            {
                // Thrown when the given string doesn't match a channel.
                return Channel.None;
            }
        }
    }
}
