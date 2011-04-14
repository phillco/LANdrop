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
    }
}
