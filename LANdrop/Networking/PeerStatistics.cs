using System;
using System.Collections.Generic;
using System.Text;

namespace LANdrop.Networking
{
    public class PeerStatistics
    {
        public enum EventType
        {
            ReceivedPeerList,
            SentPeerList,
            ReceivedInfo,
            SentInfo,
            SentFile,
            ReceivedFile
        }
        
        public DateTime LastSeen { get; set; }

        private Dictionary<EventType, int> Counts = new Dictionary<EventType, int>( );

        private Dictionary<EventType, DateTime> LastTimeOccurred = new Dictionary<EventType, DateTime>( );

        public PeerStatistics( )
        {
            foreach ( EventType type in Enum.GetValues(typeof(EventType)))
            {
                LastTimeOccurred[type] = DateTime.MinValue;
                Counts[type] = 0;
            }
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
            LastSeen = DateTime.Now;
        }
    }
}
