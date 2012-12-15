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
using net.mcforge.chat;
using MCForge.Gui.Dialogs;
using net.mcforge.world;
using System.Collections.Generic;
using java.lang;
using java.io;
using net.mcforge.API.player;
using System.Threading;

namespace MCForge.Gui
{
    /// <summary>
    /// The console for the server
    /// </summary>
    public class MCForgeConsole : net.mcforge.system.Console, Listener
    {
        private net.mcforge.server.Server server;
        private Messages chat;
        private string lastmessage;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Start()
        {
            server = new net.mcforge.server.Server("[MCForge] Default", 25565, "Welcome!");
            server.Start(this, true);
            server.getEventSystem().registerEvents(this);
            chat = new Messages(server);
            Program.running = true;
        }

        public override bool askForUpdate(net.mcforge.system.updater.Updatable u)
        {
            if (!Program.guisettings.showUpdateNotification)
                return false; 
            DialogResult answer;
            using (UpdateReadyDialog urd = new Dialogs.UpdateReadyDialog(u, getServer().getUpdateService()))
            {
                answer = urd.ShowDialog();
            }

            if (answer == DialogResult.Yes)
                return true;
            else if (answer == DialogResult.OK) 
            {
                server.getUpdateService().addToRestartQueue(u);
                return false; 
            }
            else
                return false;
        }

        public override void alertOfManualUpdate(net.mcforge.system.updater.Updatable u)
        {
            DialogResult answer;
            using (ManualUpdateReady mur = new Dialogs.ManualUpdateReady(u, getServer().getUpdateService()))
            {
                answer = mur.ShowDialog();
            }
            if (answer == DialogResult.No)
                getServer().getUpdateService().ignoreUpdate(u);
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
                if (name == "properties")
                    continue;
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

        public int getPlayerCount(net.mcforge.world.Level l)
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

        [EventHandler()]
        public void onCommand(PlayerCommandEvent eventargs)
        {
            string command = eventargs.getCommand();
            if (Command.all.Find(command) != null || isEasterEgg(command))
            {
                Player p = new Player(eventargs.getPlayer());
                string message = "";
                if (eventargs.getArgs().size() != 0)
                {
                    message = eventargs.getOrginalMessage();
                    message = message.Substring(message.IndexOf(' ') + 1);
                }
                HandleCommand(command, message, p);
                eventargs.setCancel(true);
                return;
            }
        }

        internal void restart()
        {
            server.Stop();
            System.Threading.Thread.Sleep(100);
            Start();
        }

        #region MCF5 Command
        private bool CanExecute(Command c, Player p)
        {
            if (Command.permission.ContainsKey(p.getParent().getGroup()))
                return Command.permission[p.getParent().getGroup()].commands.Contains(c);
            return false;
        }
        private bool isEasterEgg(string cmd)
        {
            cmd = cmd.ToLower();
            return cmd == "care" || cmd == "pony" || cmd == "facepalm" || cmd == "alpaca" || cmd == "rainbowdashlikescoolthings";
        }
        private void HandleCommand(string cmd, string message, Player p)
        {
            try
            {
                /*if (Server.verifyadmins)
                {
                    if (cmd.ToLower() == "setpass")
                    {
                        Command.all.Find(cmd).Use(this, message);
                        Server.s.CommandUsed(this.name + " used /setpass");
                        return;
                    }
                    if (cmd.ToLower() == "pass")
                    {
                        Command.all.Find(cmd).Use(this, message);
                        Server.s.CommandUsed(this.name + " used /pass");
                        return;
                    }
                }
                if (Server.agreetorulesonentry)
                {
                    if (cmd.ToLower() == "agree")
                    {
                        Command.all.Find(cmd).Use(this, String.Empty);
                        Server.s.CommandUsed(this.name + " used /agree");
                        return;
                    }
                    if (cmd.ToLower() == "rules")
                    {
                        Command.all.Find(cmd).Use(this, String.Empty);
                        Server.s.CommandUsed(this.name + " used /rules");
                        return;
                    }
                    if (cmd.ToLower() == "disagree")
                    {
                        Command.all.Find(cmd).Use(this, String.Empty);
                        Server.s.CommandUsed(this.name + " used /disagree");
                        return;
                    }
                }

                if (cmd == String.Empty) { SendMessage("No command entered."); return; }
                if (Server.agreetorulesonentry)
                {
                    if (jailed)
                    {
                        SendMessage("You must read /rules then agree to them with /agree!");
                        return;
                    }
                }
                if (jailed)
                {
                    SendMessage("You cannot use any commands while jailed.");
                    return;
                }
                if (Server.verifyadmins)
                {
                    if (this.adminpen)
                    {
                        this.SendMessage("&cYou must use &a/pass [Password]&c to verify!");
                        return;
                    }
                }*/
                if (cmd.ToLower() == "care") { Player.SendMessage(p, "Dmitchell94 now loves you with all his heart."); return; }
                if (cmd.ToLower() == "facepalm") { Player.SendMessage(p, "Fenderrock87's bot army just simultaneously facepalm'd at your use of this command."); return; }
                if (cmd.ToLower() == "alpaca") { Player.SendMessage(p, "Leitrean's Alpaca Army just raped your woman and pillaged your villages!"); return; }
                //DO NOT REMOVE THE TWO COMMANDS BELOW, /PONY AND /RAINBOWDASHLIKESCOOLTHINGS. -EricKilla
                if (cmd.ToLower() == "pony")
                {
                    if (p.ponycount < 2)
                    {
                        Player.GlobalMessage(p.color + p.name + ChatColor.White + " just so happens to be a proud brony! Everyone give " + p.color + p.name + ChatColor.White + " a brohoof!");
                        p.ponycount += 1;
                    }
                    else
                    {
                        Player.SendMessage(p, "You have used this command 2 times. You cannot use it anymore! Sorry, Brony!");
                    }
                    return;
                }
                if (cmd.ToLower() == "rainbowdashlikescoolthings")
                {
                    if (p.rdcount < 2)
                    {
                        Player.GlobalMessage("&1T&2H&3I&4S &5S&6E&7R&8V&9E&aR &bJ&cU&dS&eT &fG&0O&1T &22&30 &4P&CE&7R&DC&EE&9N&1T &5C&6O&7O&8L&9E&aR&b!");
                        p.rdcount += 1;
                    }
                    else
                    {
                        Player.SendMessage(p, "You have used this command 2 times. You cannot use it anymore! Sorry, Brony!");
                    }
                    return;
                }
                string foundShortcut = Command.all.FindShort(cmd);
                if (foundShortcut != "") cmd = foundShortcut;

                Command command = Command.all.Find(cmd);
                if (command != null)
                {
                    if (CanExecute(command, p))
                    {
                        p.commThread = new System.Threading.Thread(new ThreadStart(delegate
                        {
                            try
                            {
                                command.Use(p, message);
                            }
                            catch (System.Exception e)
                            {
                                getServer().Log(e.ToString());
                                Player.SendMessage(p, "An error occured when using the command!");
                                Player.SendMessage(p, e.GetType().ToString() + ": " + e.Message);
                            }
                        }));
                        p.commThread.Start();
                    }
                    else { Player.SendMessage(p, "You are not allowed to use \"" + cmd + "\"!"); }
                }
            }
            catch (System.Exception e) { getServer().Log(e.ToString()); Player.SendMessage(p, "Command failed."); }
        }
        #endregion
    }
}
