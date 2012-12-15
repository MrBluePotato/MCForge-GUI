using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MCForge.Gui;
using System.Windows.Forms;
using MCForge.Gui.Dialogs;
using System.IO;

namespace MCForge
{
    internal sealed class Starter
    {
        /// <summary>
		/// Program entry point.
		/// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!File.Exists("system/ignore.dat"))
            {
                Updater u = new Updater();
                if (u.checkUpdates())
                {
                    Update up = new Update(u);
                    Application.Run(up);
                    if (up.DialogResult == DialogResult.None)
                        File.Create("system/ignore.dat");
                }
            }
            Program.Start(args);
        }
    }
}
