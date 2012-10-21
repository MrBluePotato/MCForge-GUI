using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MCForge.Gui.Forms;
using net.mcforge.server;

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
        private static Server s = Program.console.getServer();
        public static void UniversalChatOps(string message)
        {
            java.util.ArrayList players = s.players;
            for (int i = 0; i < players.size(); i++) {
                net.mcforge.iomodel.Player p = (net.mcforge.iomodel.Player)players.get(i);
                if (p.getGroup().permissionlevel >= 50) {
                    p.sendMessage(message);
                }
            }
        }

        public static void UniversalChatAdmins(string message)
        {

        }

        public static void UniversalChat(string message)
        {
            
        }

        public static net.mcforge.iomodel.Player Find(string player)
        {
            return Program.console.getServer().findPlayer(player);
        }
    }
}
