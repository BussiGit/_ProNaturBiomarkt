using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProNaturBiomarkt_GmbH
{
    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            //LoadingScreen anzeigen
            Application.Run(new LoadingScreen());

            //Hauptmenü anzeigen
            Application.Run(new MainMenuScreen());
        }
    }
}
