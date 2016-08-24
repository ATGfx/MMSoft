using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MMSoft
{
    static class Program
    {
        /// <summary>
        /// Main entry point of application, run the GUI at start
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormConnexion());
        }
    }
}



