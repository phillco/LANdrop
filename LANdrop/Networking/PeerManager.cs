using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Diagnostics;
using System.Threading;

namespace LANdrop.Networking
{
    /// <summary>
    /// Manages the master list of other LANdrop clients (peers).
    /// Peers are added to this list manually (through the UI) as well as via the automatic discovery methods (see the PeerDiscovery namespace).
    /// </summary>
    static class PeerManager
    {
        public static event ListChangedHandler ListChanged;

        public delegate void ListChangedHandler( List<Peer> peers );

        private static Thread MaintenanceThread = new Thread( MaintainLoop );

        /// <summary>
        /// Returns a thread-safe copy of the current peer list.
        /// </summary>
        public static List<Peer> PeerList
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

        static PeerManager( )
        {
            _masterList = new List<Peer>( );
            MaintenanceThread.Name = "PeerManager Maitenance";
            MaintenanceThread.IsBackground = true;
            MaintenanceThread.Priority = ThreadPriority.BelowNormal;
            MaintenanceThread.Start( );
        }

        public static List<Peer> GetList( bool freshPeersOnly )
        {
            lock ( _masterList )
                return _masterList.FindAll( p => !freshPeersOnly || DateTime.Now.Subtract( p.LastSeen ).TotalMinutes < 1.0 );
        }

        public static void Add( Peer peer )
        {
            // Ignore our own announcements.
            if ( Server.Connected && peer.EndPoint.Equals( Server.LocalServerEndpoint ) )
                return;

            lock ( _masterList )
            {
                // First see if an existing entry exists and update that one instead.
                foreach ( Peer p in _masterList )
                {
                    if ( p.Equals( peer ) )
                    {
                        p.Name = peer.Name;
                        p.LastSeen = DateTime.Now;
                        p.LastLookedUp = DateTime.Now;
                        NotifyChangedEvent( );
                        return;
                    }
                }

                // Otherwise, add it as a new entry.
                _masterList.Add( peer );
                NotifyChangedEvent( );
            }
        }

        public static void Add( IEnumerable<Peer> peers )
        {
            foreach ( Peer p in peers )
                Add( p );
        }

        public static void Remove( Peer peer )
        {
            lock ( _masterList )
                _masterList.Remove( peer );
        }

        public static Peer GetPeerForAddress( IPEndPoint address )
        {
            lock ( _masterList )
                return _masterList.Find( p => p.EndPoint.Equals( address ) );
        }

        /// <summary>
        /// This one's port-insensitive.
        /// </summary>
        public static Peer GetPeerForAddress( IPAddress address )
        {
            lock ( _masterList )
                return _masterList.Find( p => p.EndPoint.Address.Equals( address ) );
        }

        public static void RemoveOldPeers( )
        {
            lock ( _masterList )
                _masterList.RemoveAll( ( Peer p ) => DateTime.Now.Subtract( p.LastSeen ).TotalMinutes > 2.0 );
        }

        private static void MaintainLoop()
        {
            while ( true )
            {
                RemoveOldPeers( );

                // Look up peers we haven't looked up in a while.                
                List<Peer> peersToLookUp;
                lock ( _masterList )
                    peersToLookUp = _masterList.FindAll( p => p.ShouldLookUp( ) );
                foreach ( Peer p in peersToLookUp )
                {
                    Trace.WriteLine( String.Format( "\nIt's been a while since we looked up {0} ({1} seconds since last looked up; {2} seconds since peer exchange); sending a who's-there.",
                        p, DateTime.Now.Subtract( p.LastLookedUp ).TotalSeconds, DateTime.Now.Subtract( p.LastExchangedPeers ).TotalSeconds ) );
                    new OutgoingWhosThere( p );
                }

                // [PC] TODO HACK: Might as well eliminate expired hosted files here, rather than have a new worker thread.
                WebServedFile.PruneExpiredFiles( );

                Thread.Sleep( 1000 );
            }
        }

        private static void NotifyChangedEvent( )
        {
            if ( ListChanged != null )
                ListChanged( PeerList );
        }
    }
}
