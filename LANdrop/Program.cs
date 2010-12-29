﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LANdrop.Peering;
using LANdrop.UI;

namespace LANdrop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main( )
        {
            Application.EnableVisualStyles( );
            Application.SetCompatibleTextRenderingDefault( false );

            MainForm mainForm = new MainForm( );

            MulticastManager.Init( mainForm );

            Application.Run( mainForm );
            Environment.Exit( 0 );
        }
    }
}
