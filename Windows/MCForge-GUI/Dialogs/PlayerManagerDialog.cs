using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MCForge.Gui.WindowsAPI.Utils;
using net.mcforge.iomodel;
using net.mcforge.API;
using net.mcforge.chat;

using net.mcforge.API.player;

namespace MCForge.Gui.Dialogs {
    public partial class PlayerManagerDialog : Form, Listener {

        private net.mcforge.iomodel.Player selectedPlayer;
        private bool changed = false;

        public PlayerManagerDialog() {
            InitializeComponent();
        }
        private ChatColor relationToColor(ColorRelation r) {
            ChatColor c;
            switch (r.Text) {
                case "Black":
                    c = ChatColor.Black;
                    break;
                case "Navy":
                    c = ChatColor.Dark_Blue;
                    break;
                case "Green":
                    c = ChatColor.Dark_Green;
                    break;
                case "Teal":
                    c = ChatColor.Dark_Aqua;
                    break;
                case "Maroon":
                    c = ChatColor.Dark_Red;
                    break;
                case "Purple":
                    c = ChatColor.Purple;
                    break;
                case "Gold":
                    c = ChatColor.Orange;
                    break;
                case "Silver":
                    c = ChatColor.Grey;
                    break;
                case "Gray":
                    c = ChatColor.Dark_Grey;
                    break;
                case "Blue":
                    c = ChatColor.Indigo;
                    break;
                case "Lime":
                    c = ChatColor.Bright_Green;
                    break;
                case "Aqua":
                    c = ChatColor.Aqua;
                    break;
                case "Red":
                    c = ChatColor.Red;
                    break;
                case "Pink":
                    c = ChatColor.Pink;
                    break;
                case "Yellow":
                    c = ChatColor.Yellow;
                    break;
                case "White":
                    c = ChatColor.White;
                    break;
                default:
                    c = null;
                    break;
            }
            return c;
        }
        private void lstPlayers_SelectedIndexChanged( object sender, EventArgs e ) {

            if (lstPlayers.SelectedIndex == -1)
            {
                this.grpInfo.Enabled = false;
                this.btnColor.Enabled = false;
                this.btnTitleColor.Enabled = false;
                this.txtTitle.Enabled = false;
                this.txtTitle.BackColor = Color.FromKnownColor(KnownColor.Window);
                this.btnEditMap.Enabled = false;
                this.btnEditRank.Enabled = false;
                this.btnBan.Enabled = false;
                this.btnKick.Enabled = false;
                this.btnUndo.Enabled = false;
                this.txtChat.Enabled = false;
                this.txtUndo.Enabled = false;
                this.txtStatus.Enabled = false;
                this.txtName.Text = "";
                this.txtIp.Text = "";
                this.txtMap.Text = "";
                this.txtRank.Text = "";
                this.txtTitle.Text = "";
                this.txtUndo.Text = "Undo Amount";
                this.txtChat.Text = "Send message or command";
                btnColor.Relation = ColorRelation.Purple;
                btnTitleColor.Relation = ColorRelation.Purple;
                txtStatus.Text = "Offline";
                return;
            }

            selectedPlayer = Player.FindPlayer( lstPlayers.SelectedItem.ToString().Substring( 1 ) );

            bool enabled = true;
            char color = (selectedPlayer.getPrefix() == null || selectedPlayer.getPrefix() == "" || !selectedPlayer.getPrefix().StartsWith("&") ? ChatColor.White.getColor() : selectedPlayer.getPrefix()[1]);

#if !DEBUG
            if ( selectedPlayer == null ) {
                enabled = false;
            }
#endif


            this.grpInfo.Enabled = enabled;
            this.btnColor.Enabled = enabled;
            this.btnTitleColor.Enabled = enabled;
            this.txtTitle.Enabled = enabled;
            this.txtTitle.BackColor = Color.FromKnownColor(KnownColor.Window);
            this.btnEditMap.Enabled = enabled;
            this.btnEditRank.Enabled = enabled;
            this.btnBan.Enabled = enabled;
            this.btnKick.Enabled = enabled;
            this.btnUndo.Enabled = enabled;
            this.txtChat.Enabled = enabled;
            this.txtUndo.Enabled = enabled;
            this.txtStatus.Enabled = enabled;

            if ( !enabled )
                return;


            btnColor.Relation = ColorRelation.FindColorRelationByMinecraftCode( selectedPlayer.getDisplayColor().toString() );
            btnTitleColor.Relation = ColorRelation.FindColorRelationByMinecraftCode("&" + color);
            setInfo(selectedPlayer);
            

        }

        public void setInfo(net.mcforge.iomodel.Player player)
        {
            this.grpInfo.Text = player.getGroup().name;
            this.txtTitle.Text = player.getPrefix();
            if (txtTitle.Text.StartsWith("&"))
                txtTitle.Text = txtTitle.Text.Substring(2);
            this.txtMap.Text = player.getLevel().name;
            this.txtIp.Text = player.getIP();
            this.txtName.Text = player.getName();
            this.txtStatus.Text = "Online"; //lolwut ?

        }

        #region MCForge Events
        [EventHandler()]
        public void PlayerConnect(PlayerConnectEvent eventargs)
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate { PlayerConnect(eventargs); });
                return;
            }
            lstPlayers.AddIfNotExist(eventargs.getPlayer().getDisplayColor().getColor(), eventargs.getPlayer().getName());
        }

        [EventHandler()]
        public void PlayerDisconnect(PlayerDisconnectEvent eventargs)
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate { PlayerDisconnect(eventargs); });
                return;
            }
            if (selectedPlayer == eventargs.getPlayer())
            {
                selectedPlayer = null;
                lstPlayers.SelectedIndex = -1;
                lstPlayers_SelectedIndexChanged(null, null);
            }
            lstPlayers.RemoveIfExists(eventargs.getPlayer().getName());
        }
        #endregion

        private void PlayerManagerDialog_Load(object sender, EventArgs e)
        {
            Program.console.getServer().getEventSystem().registerEvents(this);
            for (int i = 0; i < Program.console.getServer().players.size(); i++)
            {
                net.mcforge.iomodel.Player p = (net.mcforge.iomodel.Player)(Program.console.getServer().players.get(i));
                lstPlayers.AddIfNotExist(p.getDisplayColor().getColor(), p.getName());
            }
            this.btnColor.OnColorRelationChanged += btnColor_OnColorRelationChanged;
        }

        void btnColor_OnColorRelationChanged()
        {
            if (selectedPlayer == null)
                return;
            selectedPlayer.setDisplayColor(net.mcforge.chat.ChatColor.parse(btnColor.Relation.MinecraftColorCode));
        }

        private void PlayerManagerDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            PlayerConnectEvent.getEventList().unregister(this);
            PlayerDisconnectEvent.getEventList().unregister(this);
        }

        private void btnEditMap_Click(object sender, EventArgs e)
        {

        }

        private void btnEditRank_Click(object sender, EventArgs e)
        {

        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (selectedPlayer == null)
            {
                btnColor.Enabled = false;
            }
            else
                changed = true;
        }

        private void btnKick_Click(object sender, EventArgs e)
        {
            if (selectedPlayer == null)
                return;
            Program.console.sendMessage("Please provide a reason.");
            string reason = Program.console.next();
            selectedPlayer.kick(reason);
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            if (selectedPlayer == null)
                return;
            Program.console.sendMessage("Please provide a reason.");
            string reason = Program.console.next();
            selectedPlayer.ban(Program.console, reason);
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            if (selectedPlayer == null)
            {
                txtTitle.Enabled = false;
                txtTitle.Text = "";
            }
            else
                changed = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            savePlayerData(false);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            savePlayerData(true);
        }
        private void savePlayerData(bool apply) {
            if (selectedPlayer == null)
            {
                if (apply)
                    this.Close();
                return;
            }
            if (txtTitle.Text != "")
            {
                selectedPlayer.setShowPrefix(true);
                selectedPlayer.setPrefix(btnTitleColor.Relation.MinecraftColorCode + "[" + txtTitle.Text + "]");
            }
            else
                selectedPlayer.setShowPrefix(false);

            selectedPlayer.setDisplayColor(relationToColor(btnColor.Relation));

            lstPlayers.SelectedItem = selectedPlayer.getDisplayColor() + selectedPlayer.getDisplayName();
            if (apply)
                this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!changed)
            {
                this.Close();
                return;
            }
            DialogResult dr = MessageBox.Show("Are you sure you want to cancel?\nThis won't save any changes made!", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                this.Close();
        }


    }
}
