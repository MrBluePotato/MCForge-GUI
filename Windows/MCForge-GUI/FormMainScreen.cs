﻿using MCForge.Gui.Components;
using MCForge.Gui.Components.Interfaces;
using MCForge.Gui.Dialogs;
using MCForge.Gui.Dialogs.Plugins;
using MCForge.Gui.Dialogs.Ranks;
using MCForge.Gui.WindowsAPI;
using net.mcforge.API;
using net.mcforge.API.io;
using net.mcforge.API.level;
using net.mcforge.API.player;
using net.mcforge.chat;
using net.mcforge.groups;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace MCForge.Gui.Forms {
    public partial class  FormMainScreen : AeroForm, IFormSharer, Listener {
        private net.mcforge.iomodel.Player _current;

        public net.mcforge.iomodel.Player CurrentPlayer
        {
            get
            {
                return _current;
            }
            set
            {
                if (value == null)
                    resetToolbar();
                else
                    updateToolbar();
                _current = value;
            }
        }
                    
        private static net.mcforge.server.Server Server
        {
            get
            {
                return Program.console.getServer();
            }
        }
        private bool _restarting;

        public FormMainScreen() {
            InitializeComponent();
            ExternalInitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e) {
            if (AeroAPI.CanUseAero) {
                base.OnPaint(e);
                return;
            }
        }

        #region Gui Event Handlers


        private void FormMainScreen_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.GlassArea = new Rectangle {
                X = 0,
                Y = glassMenu.Height,
                Width = 0,
                Height = 0
            };

            Program.console.getServer().getEventSystem().registerEvents(this);

            Invalidate();
            for (int i = 0; i < Program.console.getServer().getLevelHandler().getLevelList().size(); i++)
            {
                net.mcforge.world.Level level = (net.mcforge.world.Level)Program.console.getServer().getLevelHandler().getLevelList().get(i);
                lstLevels.Items.Add(level.getName());
            }

            for (int i = 0; i < Program.console.getServer().getPlayers().size(); i++)
            {
                net.mcforge.iomodel.Player player = (net.mcforge.iomodel.Player)Program.console.getServer().getPlayers().get(i);
                lstLevels.Items.Add(player.getDisplayColor() + player.getName());
            }


            Logger.Log("&0MCForge Version: &7" + net.mcforge.server.Server.CORE_VERSION + "  &0Start Time: &7" + DateTime.Now.ToString("T"));

#if DEBUG
            Logger.Log("&6Warning: Running MCForge in Debug mode. Results may vary.");
#endif

            if (!Program.console.getServer().getSystemProperties().getBool("Verify-Names"))
                Logger.Log(ChatColor.Dark_Red + "Warning: You are running this server in offline-mode (Verify-Names off), it is recommend you turn this option on. If you know what you are doing then ignore this message.");
            new System.Threading.Thread(waitForURL).Start();

        }

        private void waitForURL()
        {
            while (!System.IO.File.Exists("url.txt"))
            {
                System.Threading.Thread.Sleep(3000);
            }
            setURL(System.IO.File.ReadAllText("url.txt"));
        }

        private void setURL(string url)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate { setURL(url); });
                return;
            }
            txtUrl.Text = url;
            Logger.Log(ChatColor.Bright_Green + "URL Found: " + ChatColor.White + url);
        }

        private void FormMainScreen_Shown(object sender, EventArgs e)
        {
#if !DEBUG
            if (Program.guisettings.showNews)
                using (var news = new NewsDialog())
                    news.ShowDialog();
#endif
               
        }

        private void openServers()
        {
            using (ServerList sl = new ServerList())
            {
                sl.ShowDialog();
            }
        }


        private void textBox1_DoubleClick(object sender, System.EventArgs e)
        {
            txtUrl.SelectAll();
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e) {

            if ( e.KeyCode == Keys.Enter ) {

                if (txtMessage.Text.StartsWith("/"))
                {
                    net.mcforge.API.plugin.Command cmd = null;

                    var commandSplit = txtMessage.Text.Remove(0, 1).Split(' ');
                    var args = commandSplit.Where((val, index) => index != 0).ToArray();
                    cmd = Server.getCommandHandler().find(commandSplit[0]);

                    if (cmd == null)
                    {
                        Logger.Log("Command not found!");
                        return; // cannot run the command
                    }
                    try
                    {
                        Server.getCommandHandler().execute(Program.console, cmd.getName(), args);
                    }
                    catch (Exception ex) { Logger.LogError(ex); Logger.Log("Command aborted"); }
                    Logger.Log("CONSOLE used: /" + commandSplit[0]);
                    txtMessage.InHintState = true;
                    return;
                }

                if ( String.IsNullOrWhiteSpace(txtMessage.Text) ) {
                    Logger.Log("&4Please specify a valid message!");
                    txtMessage.InHintState = true;
                    return;
                }

                if ( cmbChatType.Text == "OpChat" ) {
                    Player.UniversalChatOps("&a<&fTo Ops&a> [&fConsole&a]:&f " + txtMessage.Text);
                    Logger.Log("<OpChat> &5[&1Console&5]: &1" + txtMessage.Text);
                    txtMessage.InHintState = true;
                }

                else if ( cmbChatType.Text == "AdminChat" ) {
                    Player.UniversalChatAdmins("&a<&fTo Admins&a> [&fConsole&a]:&f " + txtMessage.Text);
                    Logger.Log("<AdminChat> &5[&1Console&5]: &1" + txtMessage.Text);
                    txtMessage.InHintState = true;
                }
                else {
                    Player.UniversalChat("&a[&fConsole&a]:&f " + txtMessage.Text);
                    Logger.Log("&0[&2Console&0]: " + txtMessage.Text);
                    txtMessage.InHintState = true;
                }
            }
            else if ( e.KeyCode == Keys.Down ) {
                cmbChatType.SelectedIndex = (cmbChatType.SelectedIndex == cmbChatType.Items.Count - 1 ? 0 : cmbChatType.SelectedIndex + ( cmbChatType.Items.Count == 1 ? 0 : cmbChatType.SelectedIndex + 1 ));
            }
            else if ( e.KeyCode == Keys.Up ) {
                cmbChatType.SelectedIndex = ( cmbChatType.SelectedIndex == 0 || cmbChatType.SelectedIndex == -1 ? (cmbChatType.Items.Count == 0 ? 0 : cmbChatType.Items.Count - 1) : cmbChatType.SelectedIndex - 1 );
            }

        }

        private void FormMainScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            LevelLoadEvent.getEventList().unregister(this);
            LevelUnloadEvent.getEventList().unregister(this);
            PlayerDisconnectEvent.getEventList().unregister(this);
            PlayerConnectEvent.getEventList().unregister(this);
            ServerLogEvent.getEventList().unregister(this);
            Program.running = false;
        }

        #endregion

        #region MCForge Lib Event Handlers

        //Invoke checks are required for each event handler

        //TODO Add these events!

        [EventHandler()]
        void OnLevelLoad(LevelLoadEvent eventargs) {
            if (InvokeRequired) {
                BeginInvoke((MethodInvoker)delegate { OnLevelLoad(eventargs); });
                return;
            }
            if (!lstLevels.Items.Contains(eventargs.getLevel().getName()))
                lstLevels.Items.Add(eventargs.getLevel().getName());
        }

        [EventHandler()]
        void OnLevelUnload(LevelUnloadEvent eventargs)
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate { OnLevelUnload(eventargs); });
                return;
            }
            if (lstLevels.Items.Contains(eventargs.getLevel().getName()))
                lstLevels.Items.Remove(eventargs.getLevel().getName());
        }

        [EventHandler()]
        void PlayerDisconnect(PlayerDisconnectEvent eventargs)
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate { PlayerDisconnect(eventargs); });
                return;
            }
            lstPlayers.RemoveIfExists(eventargs.getPlayer().getName());
            if (eventargs.getPlayer() == CurrentPlayer)
                CurrentPlayer = null;
        }

        [EventHandler()]
        void OnPlayerConnect(PlayerConnectEvent eventargs)
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate { OnPlayerConnect(eventargs); });
                return;
            }
            char color = eventargs.getPlayer().getDisplayColor().getColor();

            lstPlayers.AddIfNotExist(color, eventargs.getPlayer().getName());
        }

        [EventHandler()]
        void LoggedEvent(ServerLogEvent eventarg)
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate { LoggedEvent(eventarg); });
                return;
            }
            txtLog.AppendLog(eventarg.getRawMessage() + Environment.NewLine);
        }

        #endregion

        #region IFormSharer Members

        public Form FormToShare {
            get { return this; }
        }

        #endregion

        #region Colored Reader Context Menu

        private void nightModeToolStripMenuItem_Click(object sender, EventArgs e) {
            if ( MessageBox.Show("Changing to and from night mode will clear your logs. Do you still want to change?", "You sure?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No )
                return;

            txtLog.NightMode = nightModeToolStripMenuItem.Checked;
            nightModeToolStripMenuItem.Checked = !nightModeToolStripMenuItem.Checked;
        }

        private void colorsToolStripMenuItem_Click(object sender, EventArgs e) {
            txtLog.Colorize = !colorsToolStripMenuItem.Checked;
            colorsToolStripMenuItem.Checked = !colorsToolStripMenuItem.Checked;

        }

        private void dateAndTimeToolStripMenuItem_Click(object sender, EventArgs e) {
            txtLog.DateStamp = !dateAndTimeToolStripMenuItem.Checked;
            dateAndTimeToolStripMenuItem.Checked = !dateAndTimeToolStripMenuItem.Checked;
        }

        private void copyLogsToolStripMenuItem_Click(object sender, EventArgs e) {
            Clipboard.SetText(txtLog.SelectedText, TextDataFormat.Text);
        }

        private void clearLogsToolStripMenuItem_Click(object sender, EventArgs e) {
            if ( MessageBox.Show("Are you sure you want to clear logs?", "You sure?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes ) {
                txtLog.Clear();
            }
        }
        #endregion

        #region Main Menu


        private void serverListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openServers();
        }

        private void portToolsToolStripMenuItem_Click(object sender, EventArgs e) {
            using ( var pTools = new PortToolsDialog() )
                pTools.ShowDialog();
        }


        private void visitForumsToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("http://mcforge.net/forums/");
        }

        private void reportAProblemToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("http://www.mcforge.net/community/tracker/project-1-mcforge/");
        }

        private void documentationToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/MCForge/MCForge-Vanilla/wiki");
        }

        private void shutdownToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e) {
            txtLog.AppendLog("Restarting!" + Environment.NewLine);
            txtLog.AppendLog("Please wait..." + Environment.NewLine);
            _restarting = true;
            //Close();
            Program.console.restart();
        }

        private void playerManagerToolStripMenuItem_Click(object sender, EventArgs e) {
            using ( var dialog = new PlayerManagerDialog() )
                if ( dialog.ShowDialog() == System.Windows.Forms.DialogResult.Yes ) {
                    //TODO: Save
                }
        }


        private void mapManagerToolStripMenuItem_Click(object sender, EventArgs e) {
            using ( var maps = new MapManagerDialog() )
                maps.ShowDialog();
        }

        private void newsToolStripMenuItem_Click(object sender, EventArgs e) {
            using ( var news = new NewsDialog() )
                news.ShowDialog();
        }

        private void changelogToolStripMenuItem_Click(object sender, EventArgs e) {
            using ( TextOnlyDialog dialog = new TextOnlyDialog() ) {
                dialog.Text = "ChangeLog";
                dialog.ContentText = System.IO.File.ReadAllText("ChangeLog.txt");
                dialog.ShowDialog();
            }
        }

        private void makerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //using (CommandMaker dialog = new CommandMaker())
            //    dialog.ShowDialog();
        }

        #endregion

        #region Player Menu Changer
        private void lstPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPlayers.SelectedIndex == -1)
            {
                CurrentPlayer = null;
                return;
            }
            string name = lstPlayers.Items[lstPlayers.SelectedIndex].ToString();
            CurrentPlayer = Program.console.getServer().findPlayer(name);
        }

        private void updateToolbar() {
            this.glassMenu.Items.Clear();
            this.glassMenu.Items.AddRange(new ToolStripItem[] {
                this.serverToolStripMenuItem,
                this.ranks,
                this.moderate, 
                this.titles,
                this.mapsToolStripMenuItem,
                this.helpToolStripMenuItem
            });
        }

        private void resetToolbar() {
            this.glassMenu.Items.Clear();
            this.glassMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverToolStripMenuItem,
            this.pluginsToolStripMenuItem,
            this.utilitiesToolStripMenuItem,
            this.plToolStripMenuItem,
            this.mapsToolStripMenuItem,
            this.helpToolStripMenuItem});
        }

        //===Player Tooltip Items===
        GlassToolStripMenuItem ranks = new GlassToolStripMenuItem();
        ToolStripMenuItem promote = new ToolStripMenuItem();
        ToolStripMenuItem demote = new ToolStripMenuItem();
        ToolStripMenuItem setrank = new ToolStripMenuItem();

        GlassToolStripMenuItem moderate = new GlassToolStripMenuItem();
        ToolStripMenuItem mute = new ToolStripMenuItem();
        ToolStripMenuItem kick = new ToolStripMenuItem();
        ToolStripMenuItem ban = new ToolStripMenuItem();
        ToolStripMenuItem ipban = new ToolStripMenuItem();
       

        GlassToolStripMenuItem titles = new GlassToolStripMenuItem();
        ToolStripMenuItem settitle = new ToolStripMenuItem();

        private void lstPlayers_Leave(object sender, EventArgs e)
        {
            lstPlayers.SelectedIndex = -1;
        }

        private void ExternalInitializeComponent()
        {
            this.ranks.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                 this.promote,
                 this.demote,
                 this.setrank
             });
            this.ranks.GradiantColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.ranks.Name = "rank";
            this.ranks.Text = "Rank";
            this.ranks.Size = new System.Drawing.Size(58, 19);
            this.promote.Size = new System.Drawing.Size(128, 22);
            this.promote.Name = "promote";
            this.promote.Text = "Promote";
            this.promote.Click += promote_Click;
            this.demote.Size = new System.Drawing.Size(128, 22);
            this.demote.Name = "demote";
            this.demote.Text = "Demote";
            this.demote.Click += demote_Click;
            this.setrank.Size = new System.Drawing.Size(128, 22);
            this.setrank.Name = "setrank";
            this.setrank.Text = "Set Rank";
            this.setrank.Click += setrank_Click;

            this.moderate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                mute,
                kick,
                ban,
                ipban
            });
            this.moderate.GradiantColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.moderate.Name = "moderate";
            this.moderate.Text = "Moderation";
            this.moderate.Size = new System.Drawing.Size(58, 19);
            this.mute.Size = new System.Drawing.Size(128, 22);
            this.mute.Name = "mute";
            this.mute.Text = "Mute";
            this.kick.Size = new System.Drawing.Size(128, 22);
            this.kick.Name = "kick";
            this.kick.Text = "Kick";
            this.kick.Click += kick_Click;
            this.ban.Size = new System.Drawing.Size(128, 22);
            this.ban.Name = "ban";
            this.ban.Text = "Ban";
            this.ban.Click += ban_Click;
            this.ipban.Size = new System.Drawing.Size(128, 22);
            this.ipban.Name = "ipban";
            this.ipban.Text = "IP Ban";
            this.ipban.Click += ipban_Click;


            this.titles.GradiantColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.titles.Name = "title";
            this.titles.Text = "Title";
            this.titles.Size = new System.Drawing.Size(56, 19);
        }

        void ipban_Click(object sender, EventArgs e)
        {
            if (CurrentPlayer == null)
            {
                resetToolbar();
                return;
            }
            Program.console.sendMessage("Please provide a reason.");
            string reason = Program.console.next();
            CurrentPlayer.ipBan(Program.console, reason);
        }

        void ban_Click(object sender, EventArgs e)
        {
            if (CurrentPlayer == null)
            {
                resetToolbar();
                return;
            }
            Program.console.sendMessage("Please provide a reason.");
            string reason = Program.console.next();
            CurrentPlayer.ban(Program.console, reason);
        }

        void kick_Click(object sender, EventArgs e)
        {
            if (CurrentPlayer == null)
            {
                resetToolbar();
                return;
            }
            Program.console.sendMessage("Please provide a reason.");
            string reason = Program.console.next();
            CurrentPlayer.kick(reason);
        }

        void setrank_Click(object sender, EventArgs e)
        {
            if (CurrentPlayer == null)
            {
                resetToolbar();
                return;
            }
            Program.console.sendMessage("Type the name of the rank to promote the player to.");
            string name = Program.console.next();
            while (Group.find(name) == null)
            {
                Program.console.sendMessage("That rank doesnt exists..\n\rType the name of the rank to promote the player to.");
                name = Program.console.next();
            }
            Group g = Group.find(name);
            CurrentPlayer.setGroup(g);
            CurrentPlayer.sendMessage("You are now ranked " + g.name + ChatColor.White + ", type /help for your new set of commands.");
            Program.console.SendGlobalMessage(CurrentPlayer.getDisplayName() + ChatColor.White + "'s rank was set to " + g.name);
            Program.console.SendGlobalMessage("&6Congratulations!");
        }

        void demote_Click(object sender, EventArgs e)
        {
            if (CurrentPlayer == null)
            {
                resetToolbar();
                return;
            }
            Group startGroup = CurrentPlayer.getGroup();
            if (startGroup == null)
                return;
            int perms = startGroup.permissionlevel;
            Group highabove = null;
            for (int i = 0; i < Group.getGroupList().size(); i++)
            {
                Group g = (Group)Group.getGroupList().get(i);
                if (g.permissionlevel < startGroup.permissionlevel)
                {
                    if (highabove == null) { highabove = g; }
                    if (highabove.permissionlevel < g.permissionlevel) { highabove = g; }
                }
            }
            if (highabove == null) return;
            CurrentPlayer.setGroup(highabove);
            CurrentPlayer.sendMessage("You are now ranked " + highabove.name + ChatColor.White + ", type /help for your new set of commands.");
            Program.console.SendGlobalMessage(CurrentPlayer.getDisplayName() + ChatColor.White + "'s rank was set to " + highabove.name);
            Program.console.SendGlobalMessage("&6Congratulations!");
        }

        void promote_Click(object sender, EventArgs e)
        {
            if (CurrentPlayer == null)
            {
                resetToolbar();
                return;
            }
            Group startGroup = CurrentPlayer.getGroup();
            if (startGroup == null)
                return;
            int perms = startGroup.permissionlevel;
            Group lowestabove = null;
            for (int i = 0; i < Group.getGroupList().size(); i++)
            {
                Group g = (Group)Group.getGroupList().get(i);
                if (g.permissionlevel > startGroup.permissionlevel)
                {
                    if (lowestabove == null) { lowestabove = g; }
                    if (lowestabove.permissionlevel > g.permissionlevel) { lowestabove = g; }
                }
            }
            if (lowestabove == null) return;
            CurrentPlayer.setGroup(lowestabove);
            CurrentPlayer.sendMessage("You are now ranked " + lowestabove.name + ChatColor.White + ", type /help for your new set of commands.");
            Program.console.SendGlobalMessage(CurrentPlayer.getDisplayName() + ChatColor.White + "'s rank was set to " + lowestabove.name);
            Program.console.SendGlobalMessage("&6Congratulations!");
        }
        #endregion

        private void unloadAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartInThread(UnloadAll);
        }

        private void kickAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object[] players = Program.console.getServer().getPlayers().toArray();
            for (int i = 0; i < players.Length; i++)
            {
                net.mcforge.iomodel.Player p = (net.mcforge.iomodel.Player)players[i];
                p.kick("Kicking all players");
            }
        }

        private void kickNonopsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object[] players = Program.console.getServer().getPlayers().toArray();
            for (int i = 0; i < players.Length; i++)
            {
                net.mcforge.iomodel.Player p = (net.mcforge.iomodel.Player)players[i];
                if (p.getGroup().isOP)
                    continue;
                p.kick("Kicking all non-ops");
            }
        }

        private void reloadAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StartInThread(ReloadAll);
        }

        private void ReloadAll()
        {
            List<net.mcforge.world.Level> toreload = new List<net.mcforge.world.Level>();
            for (int i = 0; i < Program.console.getServer().getLevelHandler().getLevelList().size(); i++)
            {
                net.mcforge.world.Level level = (net.mcforge.world.Level)Program.console.getServer().getLevelHandler().getLevelList().get(i);
                if (level.getName() != Program.console.getServer().MainLevel)
                    toreload.Add(level);
            }

            foreach (net.mcforge.world.Level l in toreload)
            {
                l.unload(Program.console.getServer(), true);
                Program.console.getServer().getLevelHandler().loadClassicLevel("levels/" + l.getName() + ".ggs");
            }
            toreload.Clear();
        }

        private void UnloadAll()
        {
            List<net.mcforge.world.Level> tounload = new List<net.mcforge.world.Level>();
            for (int i = 0; i < Program.console.getServer().getLevelHandler().getLevelList().size(); i++)
            {
                net.mcforge.world.Level level = (net.mcforge.world.Level)Program.console.getServer().getLevelHandler().getLevelList().get(i);
                if (level.getName() != Program.console.getServer().MainLevel)
                    tounload.Add(level);
            }

            foreach (net.mcforge.world.Level l in tounload)
            {
                Program.console.getServer().getLevelHandler().unloadLevel(l, true);
            }
            tounload.Clear();
        }

        delegate void NewThread();

        private void StartInThread(NewThread launch)
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(launch));
            t.Start();
        }

        private void serverToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void updateServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void updateServiceToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            using (UpdateServiceDialog u = new UpdateServiceDialog())
            {
                u.ShowDialog();
            }
        }

        private void pluginsManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PluginManagerDialog p = new PluginManagerDialog(Program.console.getServer()))
            {
                p.ShowDialog();
            }
        }

        private void rankManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (RankManagerDialog rmd = new RankManagerDialog()) 
            {
                rmd.ShowDialog();
            }
        }

        private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtUrl.Text == "") { return; }
            Clipboard.SetText(txtUrl.Text);
            new Thread((ThreadStart)delegate {
                string temp = txtUrl.Text;
                txtUrl.BeginInvoke((MethodInvoker)delegate { txtUrl.Text = "Copied!"; });
                Thread.Sleep(750);
                txtUrl.BeginInvoke((MethodInvoker)delegate { txtUrl.Text = temp; });
            }).Start();
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtUrl.Text == "") { return; }
            Process.Start(txtUrl.Text);
        }
    }
}
