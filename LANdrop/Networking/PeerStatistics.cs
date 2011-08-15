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

        private Dictionary<EventType, int> Counts = new Dictionary<EventType, int>( );

        private Dictionary<EventType, DateTime> LastTimeOccurred = new Dictionary<EventType, DateTime>( );

        public event StatisticsChangedHandler StatisticsChanged;

        public delegate void StatisticsChangedHandler( EventType type );

        public PeerStatistics( )
        {
            // Initialize the maps so we don't have to worry about missing keys.
            foreach ( EventType type in Enum.GetValues( typeof( EventType ) ) )
            {
                LastTimeOccurred[type] = DateTime.MinValue;
                Counts[type] = 0;
            }

            RegisterEvent( EventType.Any );
        }

        public int NumOccurrences( EventType type )
        {
            lock ( Counts )
                return Counts[type];
        }

        public DateTime LastOccurred( EventType type )
        {
            lock ( LastTimeOccurred )
                return LastTimeOccurred[type];
        }

        public TimeSpan TimeSince( EventType type )
        {
            return DateTime.Now.Subtract( LastOccurred( type ) );
        }

        public void RegisterEvent( EventType type )
        {
            lock ( Counts )
                Counts[type]++;

            lock ( LastTimeOccurred )
                LastTimeOccurred[type] = DateTime.Now;

            // Fire the event.
            if ( StatisticsChanged != null )
                StatisticsChanged( type );

            // Update the "Any" statistic.
            if ( type != EventType.Any )
                RegisterEvent( EventType.Any );
        }
    }
}
