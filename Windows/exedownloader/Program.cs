using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Diagnostics;

namespace exedownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0 || args[0] != "9ea582c00b878d5589a253d0863b1734")
            {
                Console.WriteLine("Downloader started wrong..");
                Thread.Sleep(1000);
                return;
            }
            Console.WriteLine("Closing MCForge..");
            if (Process.GetProcessesByName("MCForge_").Length != 1)
            {
                foreach (Process pr in Process.GetProcessesByName("MCForge_"))
                {
                    if (pr.MainModule.BaseAddress == Process.GetCurrentProcess().MainModule.BaseAddress)
                        if (pr.Id != Process.GetCurrentProcess().Id)
                            pr.Kill();
                }
            }
            using (WebClient wc = new WebClient())
            {
                Console.WriteLine("Getting download location..");
                string url = wc.DownloadString("http://update.mcforge.net/VERSION_2/GUI/exe.dat");
                Console.WriteLine("Downloading latest .exe ...");
                wc.DownloadFile(url, "MCForge_.exe");
            }
            Console.WriteLine("Done!");
            Process.Start("MCForge_.exe");
        }
    }
}
