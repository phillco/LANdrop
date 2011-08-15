using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Threading;

namespace LANdrop.Networking
{
    /// <summary>
    /// Manages the master list of other LANdrop clients (peers).
    /// Peers are added to this list manually (through the UI) as well as via the automatic discovery methods (see the PeerDiscovery namespace).
    /// </summary>
    static class PeerList
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger( System.Reflection.MethodBase.GetCurrentMethod( ).DeclaringType );

        public static event ListChangedHandler ListChanged;

        public delegate void ListChangedHandler( List<Peer> peers );

        private static Thread MaintenanceThread = new Thread( MaintenanceLoop );

        /// <summary>
        /// Returns a thread-safe copy of the current peer list.
        /// </summary>
        public static List<Peer> Peers
        {
            get
            {
                lock ( _masterList )
                    return new List<Peer>( _masterList );
            }
        }

        /// <summary>
        /// The master list of peers.
        /// </summary>
        private static List<Peer> _masterList = new List<Peer>( );

        static PeerList( )
        {
            _masterList = new List<Peer>( );
            MaintenanceThread.Name = "PeerList Maintenance";
            MaintenanceThread.IsBackground = true;
            MaintenanceThread.Priority = ThreadPriority.BelowNormal;
            MaintenanceThread.Start( );
        }

        /// <summary>
        /// Returns the peer list (or a subset) based on the given parameters.
        /// </summary>
        public static List<Peer> GetList( bool freshPeersOnly )
        {
            lock ( _masterList )
                return _masterList.FindAll( p => !freshPeersOnly || DateTime.Now.Subtract( p.Statistics.LastSeen ).TotalMinutes < 1.0 );
        }

        /// <summary>
        /// Adds the given peer to the list (if its address is new), or updates the existing peer.
        /// </summary>
        public static void AddOrUpdate( Peer peer )
        {
            // Ignore our own announcements.
            if ( Server.Connected && peer.EndPoint.Address.Equals( Server.LocalServerEndpoint.Address ) )
                return;

            lock ( _masterList )
            {
                // First see if an existing entry exists and update that one instead.
                foreach ( Peer p in _masterList )
                {
                    if ( p.Equals( peer ) )
                    {
                        p.Name = peer.Name;
                        p.EndPoint = peer.EndPoint;
                        p.RegisterEvent( PeerStatistics.EventType.ReceivedInfo );
                        NotifyChangedEvent( );
                        return;
                    }
                }

                // Otherwise, add it as a new entry.
                _masterList.Add( peer );
                NotifyChangedEvent( );
            }
        }

        /// <summary>
        /// Adds/Updates the given collection of peers.
        /// </summary>
        public static void AddOrUpdate( IEnumerable<Peer> peers )
        {
            foreach ( Peer p in peers )
                AddOrUpdate( p );
        }

        /// <summary>
        /// Removes the given peer from the list (use with care!)
        /// </summary>
        public static void Remove( Peer peer )
        {
            lock ( _masterList )
                _masterList.Remove( peer );
        }

        /// <summary>
        /// Returns the peer at the given address and port.
        /// </summary>
        public static Peer GetPeerForAddress( IPEndPoint address )
        {
            lock ( _masterList )
                return _masterList.Find( p => p.EndPoint.Equals( address ) );
        }

        /// <summary>
        /// Returns the peer at the given address. (port-insensitive!)
        /// </summary>
        public static Peer GetPeerForAddress( IPAddress address )
        {
            lock ( _masterList )
                return _masterList.Find( p => p.EndPoint.Address.Equals( address ) );
        }

        /// <summary>
        /// Keeps the list in good shape.
        /// </summary>
        private static void MaintenanceLoop()
        {
            while ( true )
            {
                // Remove old peers.
                RemoveOldPeers( );

                // Look up peers we haven't looked up in a while.                
                List<Peer> peersToLookUp;
                lock ( _masterList )
                    peersToLookUp = _masterList.FindAll( p => p.ShouldLookUp );
                foreach ( Peer p in peersToLookUp )
                {
                    log.DebugFormat( "It's been a while since we looked up {0} ({1} seconds since sending info; {2} seconds since sending peers); sending a who's-there.",
                        p, p.Statistics.TimeSince(PeerStatistics.EventType.SentInfo).TotalSeconds, p.Statistics.TimeSince( PeerStatistics.EventType.SentPeerList ).TotalSeconds );
                    new OutgoingWhosThere( p );
                }

                // [PC] TODO HACK: Might as well eliminate expired hosted files here, rather than have a new worker thread.
                WebServedFile.PruneExpiredFiles( );

                Thread.Sleep( 1000 );
            }
        }

        /// <summary>
        /// Remove peers that have not been heard from recently.
        /// </summary>
        private static void RemoveOldPeers( )
        {
            lock ( _masterList )
                _masterList.RemoveAll( ( Peer p ) => DateTime.Now.Subtract( p.Statistics.LastSeen ).TotalMinutes > 2.0 );
        }

        /// <summary>
        /// Fires the "list changed" event.
        /// </summary>
        private static void NotifyChangedEvent( )
        {
            if ( ListChanged != null )
                ListChanged( Peers );
        }
    }
}
