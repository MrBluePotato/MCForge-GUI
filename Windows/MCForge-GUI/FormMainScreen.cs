using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using MCForge.Gui.Utils;
//using MCForge.Gui.Components;
//using MCForge.Gui.Components.Interfaces;
//using MCForge.Entity;
//using MCForge.Interface.Command;
//using MCForge.Interfaces;
//using MCForge.Utils;
//using MCForge.Gui.Dialogs;
using System.Diagnostics;
//using MCForge.Core;
//using MCForge.World;
using System.Reflection;
using MCForge.Gui.Components;
using MCForge.Gui.Components.Interfaces;
using MCForge.Gui.Forms;
using MCForge.Gui.Dialogs;
using MCForge.Gui.WindowsAPI;
using net.mcforge.API;
using net.mcforge.API.server;
using net.mcforge.API.player;
using net.mcforge.API.level;
using net.mcforge.API.io;
using net.mcforge.world;
using net.mcforge.iomodel;
using net.mcforge.server;
using net.mcforge.API.plugin;

namespace MCForge.Gui.Forms {
    public partial class FormMainScreen : AeroForm, IFormSharer, Listener {

        private static Server Server
        {
            get
            {
                return Program.console.getServer();
            }
        }
        private bool _restarting;

        public FormMainScreen() {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e) {
            if (AeroAPI.CanUseAero) {
                base.OnPaint(e);
                return;
            }
        }

        #region Gui Event Handlers


        private void FormMainScreen_Load(object sender, EventArgs e) {
            this.GlassArea = new Rectangle {
                X = 0,
                Y = glassMenu.Height,
                Width = 0,
                Height = 0
            };

            Invalidate();
            for (int i = 0; i < Program.console.getServer().getLevelHandler().getLevelList().size(); i++)
            {
                Level level = (Level)Program.console.getServer().getLevelHandler().getLevelList().get(i);
                lstLevels.Items.Add(level.name);
            }

            for (int i = 0; i < Program.console.getServer().players.size(); i++)
            {
                net.mcforge.iomodel.Player player = (net.mcforge.iomodel.Player)Program.console.getServer().players.get(i);
                lstLevels.Items.Add(player.getDisplayColor() + player.getName());
            }


            Logger.Log("&0MCForge Version: &7" + Server.VERSION + "  &0Start Time: &7" + DateTime.Now.ToString("T"));

#if DEBUG
            Logger.Log("&6Warning: Running MCForge in Debug mode. Results may vary.");
#endif

            //if ( !String.IsNullOrWhiteSpace(Server.) )
            //    Logger.Log(Server.URL);

        }

        private void FormMainScreen_Shown(object sender, EventArgs e) {
            //if ( GuiSettings.GetSettingBoolean(GuiSettings.SHOW_NEWS_KEY) )
            using ( var news = new NewsDialog() )
               news.ShowDialog();
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e) {

            if ( e.KeyCode == Keys.Enter ) {

                if (txtMessage.Text.StartsWith("/"))
                {
                    Command cmd = null;

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
                cmbChatType.SelectedIndex = cmbChatType.SelectedIndex + ( cmbChatType.Items.Count == 1 ? 0 : cmbChatType.SelectedIndex + 1 );
            }
            else if ( e.KeyCode == Keys.Up ) {
                cmbChatType.SelectedIndex = ( cmbChatType.SelectedIndex == 0 ? cmbChatType.Items.Count - 1 : cmbChatType.SelectedIndex - 1 );
            }

        }

        #endregion

        #region MCForge Lib Event Handlers

        //Invoke checks are required for each event handler

        //TODO Add these events!

        /*void OnAllLevelsUnload_Normal(Level sender, API.Events.LevelLoadEventArgs args) {
            if ( InvokeRequired ) {
                BeginInvoke((MethodInvoker)delegate { OnAllLevelsUnload_Normal(sender, args); });
                return;
            }

            if ( lstLevels.Items.Contains(sender.Name) )
                lstLevels.Items.Remove(sender.Name);

        }

        void OnAllLevelsLoad_Normal(Level sender, API.Events.LevelLoadEventArgs args) {
            if ( InvokeRequired ) {
                BeginInvoke((MethodInvoker)delegate { OnAllLevelsLoad_Normal(sender, args); });
                return;
            }

            if ( !lstLevels.Items.Contains(sender.Name) )
                lstLevels.Items.Add(sender.Name);

        }*/

        void PlayerDisconnect(PlayerDisconnectEvent eventargs)
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate { PlayerDisconnect(eventargs); });
                return;
            }
            lstPlayers.RemoveIfExists(eventargs.getPlayer().getName());
        }


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

        /*void Logger_OnRecieveErrorLog(object sender, ErrorLogEventArgs e) {
            if ( InvokeRequired ) {
                BeginInvoke((MethodInvoker)delegate { Logger_OnRecieveErrorLog(sender, e); });
                return;
            }

            txtLog.AppendLog("&4\t------[Error]-----" + Environment.NewLine);
            txtLog.AppendLog("&4\t" + e.Message + Environment.NewLine);
            txtLog.AppendLog(Environment.NewLine);
        }*/

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

        private void portToolsToolStripMenuItem_Click(object sender, EventArgs e) {
            //using ( var pTools = new PortToolsDialog() )
            //    pTools.ShowDialog();
        }


        private void visitForumsToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("http://mcforge.net/forums/");
        }

        private void reportAProblemToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("http://www.mcforge.net/forums/forumdisplay.php?fid=5");
        }

        private void documentationToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/MCForge/MCForge-Vanilla/wiki");
        }

        private void shutdownToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e) {
            _restarting = true;
            Close();
            Program.console.restart();
        }

        private void playerManagerToolStripMenuItem_Click(object sender, EventArgs e) {
            /*using ( var dialog = new PlayerManagerDialog() )
                if ( dialog.ShowDialog() == System.Windows.Forms.DialogResult.Yes ) {
                    //TODO: Save
                }*/
        }


        private void mapManagerToolStripMenuItem_Click(object sender, EventArgs e) {
            //using ( var maps = new MapManagerDialog() )
            //    maps.ShowDialog();
        }

        private void newsToolStripMenuItem_Click(object sender, EventArgs e) {
            //using ( var news = new NewsDialog() )
            //    news.ShowDialog();
        }

        private void changelogToolStripMenuItem_Click(object sender, EventArgs e) {
            //using ( TextOnlyDialog dialog = new TextOnlyDialog() ) {
            //    dialog.Text = "ChangeLog";
            //    dialog.ContentText = "Logs of change\nLogs of changyyy\nOMGESUS";
            //    dialog.ShowDialog();
            //}
        }

        private void makerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //using (CommandMaker dialog = new CommandMaker())
            //    dialog.ShowDialog();
        }

        #endregion
    }
}
