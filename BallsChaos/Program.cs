using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BallsChaos
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            List<Player> niza = new List<Player>(); ;
            
            Application.Run(new Begin(niza));
            
        }
    }
}
