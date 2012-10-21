using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCForge.Gui
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

    public class Player
    {
        public static void UniversalChatOps(string message)
        {

        }

        public static void UniversalChatAdmins(string message)
        {

        }

        public static void UniversalChat(string message)
        {

        }
    }
}
