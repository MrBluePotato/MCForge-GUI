#region License
/*
Permission is hereby granted, free of 
charge, to any person obtaining a copy of 
this software and associated documentation
 files (the "Software"), to deal in the 
Software without restriction, including 
without limitation the rights to use, copy,
 modify, merge, publish, distribute, 
sublicense, and/or sell copies of the 
Software, and to permit persons to whom the
 Software is furnished to do so, subject to 
the following conditions:


The above copyright notice and this 
permission notice shall be included in all
 copies or substantial portions of the 
Software.


THE SOFTWARE IS PROVIDED "AS IS", WITHOUT 
WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 OF MERCHANTABILITY, FITNESS FOR A 
PARTICULAR PURPOSE AND NONINFRINGEMENT. IN 
NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
 OTHER LIABILITY, WHETHER IN AN ACTION OF 
CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR
 THE USE OR OTHER DEALINGS IN THE SOFTWARE.

 * User: Eddie
 * Date: 10/7/2012
 * Time: 2:26 PM
 * 
 */
#endregion
using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MCForge.Gui.Forms;
using System.IO;
using MCForge.Gui.Dialogs;

namespace MCForge.Gui
{
	internal sealed class Program
	{
		private static MCForgeConsole mc = new MCForgeConsole();
        public static GUISettings guisettings = new GUISettings();
		public static MCForgeConsole console {
			get {
				return mc;
			}
		}
        public static bool running = true;

        public static string ChangeLogDownload = "http://www.mcforge.net/changelog.txt";
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		internal static void Start(string[] args)
		{
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            File.Delete("url.txt");
            SplashScreen ss = new SplashScreen();
			Application.Run(ss);
            ss.Dispose();
            while (running) 
                LaunchConsole();

            if (mc.getServer().Running && mc.getServer() != null)
                mc.getServer().stop();
            Environment.Exit(0);
		}

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            handleException(e.Exception);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            handleException((System.Exception)e.ExceptionObject);
        }

        static void handleException(Exception e)
        {
            DialogResult d;
            if (hasCrashedBefore(e))
            {
                d = MessageBox.Show("It seems this is the second time this crash has occured. Would you like me to send a crash report?", "Onoes", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (d == DialogResult.Yes)
                {
                    using (ErrorDialog ed = new ErrorDialog(e, true))
                        ed.ShowDialog();
                    MessageBox.Show("This crash has been reported to the MCForge team.\nTry restarting MCForge to fix this problem,\nif the problem is still present, try going to\nhttp://report.mcforge.net and submit a ticket.", "Report sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Environment.Exit(2);
                    return;
                }
                else
                    File.Delete("system/crash.log");
            }
            using (ErrorDialog ed = new ErrorDialog(e))
                d = ed.ShowDialog();
            if (d == DialogResult.Cancel)
            {
                running = false;
                saveCrash(e);
                Environment.Exit(1);
            }
            else if (d == DialogResult.Ignore)
                return;
            else if (d == DialogResult.Retry)
            {
                running = false;
                saveCrash(e);
                Application.Restart();
            }
            else
            {
                MessageBox.Show("This crash has been reported to the MCForge team.\nTry restarting MCForge to fix this problem,\nif the problem is still present, try going to\nhttp://report.mcforge.net and submit a ticket.", "Report sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(2);
            }
        }

        static void saveCrash(Exception e)
        {
            if (!Directory.Exists("system"))
                Directory.CreateDirectory("system");
            File.WriteAllText("system/crash.log", e.ToString());
        }

        static bool hasCrashedBefore(Exception e)
        {
            if (!File.Exists("system/crash.log"))
                return false;
            string text = File.ReadAllText("system/crash.log");
            return text == e.ToString();
        }

        [STAThread]
        public static void LaunchConsole()
        {
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.Run(new FormMainScreen());
        }
	}
}
