﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTiemTapHoa
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new fLogin()); 
            //Application.Run(new fDashboard());
            //Application.Run(new fAdmin());
            Application.Run(new fCheckout("HD05"));
        }
    }
}
