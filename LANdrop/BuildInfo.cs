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
        public readonly static VersionInfo Version = new VersionInfo
        {
            Channel = Channel.None,
            BuildNumber = 0
        };

        /// <summary>
        /// Does this LANdrop build receive automatic updates? (Not true if it was hand-compiled)
        /// </summary>
        public static bool DoesUpdate
        {
            get { return Version.Channel != Channel.None; }
        }
    }
}
