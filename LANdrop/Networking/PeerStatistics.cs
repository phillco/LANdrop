using System;
using System.Collections.Generic;
using System.Text;

namespace LANdrop.Networking
{
    public class PeerStatistics
    {
        public enum EventType
        {
            Any,
            ReceivedPeerList,
            SentPeerList,
            ReceivedInfo,
            SentInfo,
            SentFile,
            ReceivedFile
        }

        public DateTime LastSeen { get { return LastOccurred( EventType.Any ); } }

        private Dictionary<EventType, int> Counts = new Dictionary<EventType, int>( );

        private Dictionary<EventType, DateTime> LastTimeOccurred = new Dictionary<EventType, DateTime>( );

        public PeerStatistics( )
        {
            // Initialize the maps so we don't have to worry about missing keys.
            foreach ( EventType type in Enum.GetValues(typeof(EventType)))
            {
                LastTimeOccurred[type] = DateTime.MinValue;
                Counts[type] = 0;
            }

            RegisterEvent( EventType.Any );
        }

        public int NumOccurrences( EventType type )
        {
            return Counts[type];
        }

        public DateTime LastOccurred( EventType type )
        {
            return LastTimeOccurred[type];
        }

        public TimeSpan TimeSince( EventType type )
        {
            return DateTime.Now.Subtract( LastOccurred( type ) );
        }

        public void RegisterEvent( EventType type )
        {
            Counts[type]++;
            LastTimeOccurred[type] = DateTime.Now;

            // Update the master communication log.
            if ( type != EventType.Any )
                RegisterEvent( EventType.Any );
        }
    }
}
