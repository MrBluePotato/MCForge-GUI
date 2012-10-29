using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MCForge.Gui;
using net.mcforge.iomodel;

namespace MCForge
{
    public class Logger
    {
        public static void Log(string message)
        {
            Program.console.getServer().Log(message);
        }

        public static void LogError(Exception e)
        {
            Program.console.getServer().Log(e.ToString());
        }
    }
}
