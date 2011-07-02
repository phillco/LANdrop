using System;
using System.Collections.Generic;
using System.Text;
using LANdrop.Updates;

namespace LANdrop
{
    /// <summary>
    /// Contains constants about the current LANdrop build (i.e., "dev build #76").
    /// Builds are tagged here by the build server during deployment.
    /// 
    /// If you rearrange things in this file, be sure to update BuildPrepare/Program.cs, too!
    /// </summary>
    class BuildInfo
    {
        /// <summary>
        /// This build's number and the channel it was made on.
        /// "Channel.None" are development builds that aren't released publicly. (They don't update).
        /// </summary>
        public readonly static VersionInfo Version = new VersionInfo
        {
            Channel = Channel.None,
            BuildNumber = 0
        };

        /// <summary>
        /// Does this LANdrop build receive automatic updates?
        /// </summary>
        public static bool DoesUpdate
        {
            get { return Version.Channel != Channel.None; }
        }
    }
}
