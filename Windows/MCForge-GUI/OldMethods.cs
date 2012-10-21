using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MCForge.Gui;

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

    public class Player
    {
        public static void UniversalChatOps(string message)
        {
            Program.console.SendOpMessage(message);
        }

        public static void UniversalChatAdmins(string message)
        {
            Program.console.SendOpMessage(message);
        }

        public static void UniversalChat(string message)
        {
            Program.console.SendGlobalMessage(message);
        }

        public static net.mcforge.iomodel.Player Find(string player)
        {
            return Program.console.getServer().findPlayer(player);
        }
    }
}
