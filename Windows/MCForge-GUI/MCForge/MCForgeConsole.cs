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
 * Time: 2:32 PM
 * 
 */
#endregion
using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using net.mcforge.groups;
using net.mcforge.API;
using net.mcforge.API.io;
using net.mcforge.sql;
using net.mcforge.server;
using MCForge.Gui.SQL_PORT;
using net.mcforge.chat;
using MCForge.Gui.Dialogs;
using net.mcforge.world;
using System.Collections.Generic;
using java.lang;
using java.io;

namespace MCForge.Gui
{
    /// <summary>
    /// The console for the server
    /// </summary>
    public class MCForgeConsole : net.mcforge.system.Console, Listener
    {
        private Server server;
        private ISQL sql;
        private Messages chat;
        private string lastmessage;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Start()
        {
            server = new Server("[MCForge] Default", 25565, "Welcome!");
            server.Start(this, false);
            if (server.getSystemProperties().getValue("SQL-Driver") == "net.mcforge.sql.SQLite")
                sql = new MCForge.Gui.SQL_PORT.SQLite();
            else
            {
                sql = new MCForge.Gui.SQL_PORT.MySQL();
                ((MCForge.Gui.SQL_PORT.MySQL)sql).setUsername(server.getSystemProperties().getValue("MySQL-username"));
                ((MCForge.Gui.SQL_PORT.MySQL)sql).setPassword(server.getSystemProperties().getValue("MySQL-password"));
                ((MCForge.Gui.SQL_PORT.MySQL)sql).setDatabase(server.getSystemProperties().getValue("MySQL-database-name"));
            }
            server.getEventSystem().registerEvents(this);
            server.startSQL(sql);
            chat = new Messages(server);
            Program.running = true;
        }

        public void SendOpMessage(string message)
        {
            for (int i = 0; i < Program.console.getServer().players.size(); i++)
            {
                net.mcforge.iomodel.Player player = (net.mcforge.iomodel.Player)Program.console.getServer().players.get(i);
                if (player.getGroup().isOP)
                    chat.sendMessage(message, player.getName());
            }
        }

        public List<string> getUnloadedLevelList()
        {
            List<string> levels = new List<string>();
            File levelList = new File("levels");
            File[] list = levelList.listFiles();
            foreach (File f in list)
            {
                string name = f.getName().Split('.')[0];
                if (getServer().getLevelHandler().findLevel(name) == null)
                    levels.Add(name);
            }
            return levels;
        }

        public void SendGlobalMessage(string message)
        {
            chat.serverBroadcast(message);
            sendMessage(message);
        }

        public int getPlayerCount(Level l)
        {
            int total = 0;
            for (int i = 0; i < Program.console.getServer().players.size(); i++)
            {
                net.mcforge.iomodel.Player player = (net.mcforge.iomodel.Player)Program.console.getServer().players.get(i);
                if (player.getLevel() == l)
                    total++;
            }
            return total;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public override net.mcforge.groups.Group getGroup()
        {
            return net.mcforge.groups.Group.getDefault();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public override string getName()
        {
            return "Console";
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public override void sendMessage(string s)
        {
            lastmessage = s;
            server.Log(s);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public override string next()
        {
            return InputDialog.showDialog("Question", lastmessage, "Submit");
        }

        public override bool nextBoolean()
        {
            DialogResult result = MessageBox.Show(lastmessage, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            return result == DialogResult.Yes;
        }

        internal void restart()
        {
            server.Stop();
            System.Threading.Thread.Sleep(100);
            Start();
        }
    }
}
