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
using net.mcforge.API.player;

namespace MCForge.Gui.Dialogs {
    public partial class PlayerManagerDialog : Form, Listener {

        private net.mcforge.iomodel.Player selectedPlayer;

        public PlayerManagerDialog() {
            InitializeComponent();
        }

        private void lstPlayers_SelectedIndexChanged( object sender, EventArgs e ) {

            if (lstPlayers.SelectedIndex == -1)
                return;

            selectedPlayer = Player.Find( lstPlayers.SelectedItem.ToString().Substring( 1 ) );

            bool enabled = true;

#if !DEBUG
            if ( selectedPlayer == null ) {
                enabled = false;
            }
#endif


            this.grpInfo.Enabled = enabled;
            this.btnColor.Enabled = enabled;
            this.btnTitleColor.Enabled = enabled;
            this.txtTitle.Enabled = enabled;
            this.btnEditMap.Enabled = enabled;
            this.btnEditRank.Enabled = enabled;
            this.btnBan.Enabled = enabled;
            this.btnKick.Enabled = enabled;
            this.btnUndo.Enabled = enabled;
            this.txtChat.Enabled = enabled;
            this.txtUndo.Enabled = enabled;
            this.txtStatus.Enabled = enabled;

            this.label1.Enabled = enabled;
            this.label2.Enabled = enabled;
            this.label3.Enabled = enabled;
            this.label4.Enabled = enabled;
            this.label5.Enabled = enabled;
            this.label6.Enabled = enabled;
            this.label7.Enabled = enabled;
            this.label8.Enabled = enabled;

            if ( !enabled )
                return;

#if DEBUG
            btnColor.Relation = ColorRelation.Red;
            btnTitleColor.Relation = ColorRelation.Green;
#else
            btnColor.Relation = ColorRelation.FindColorRelationByMinecraftCode( selectedPlayer.getDisplayColor().toString() );
            btnTitleColor.Relation = ColorRelation.FindColorRelationByMinecraftCode(selectedPlayer.getDisplayColor().toString());
#endif
            setInfo(selectedPlayer);
            

        }

        public void setInfo(net.mcforge.iomodel.Player player)
        {
            this.grpInfo.Text = player.getGroup().name;
            if (player.hasValue("title"))
            {
                this.txtTitle.Text = player.getValue("title").ToString();
            }
            this.txtMap.Text = player.getLevel().name;
            this.txtIp.Text = player.getIP();
            this.txtName.Text = player.getName();
            this.txtStatus.Text = "Online"; //lolwut ?

        }

        #region MCForge Events
        [EventHandler()]
        public void PlayerConnect(PlayerConnectEvent eventargs)
        {
            lstPlayers.AddIfNotExist(eventargs.getPlayer().getDisplayColor().getColor(), eventargs.getPlayer().getName());
        }

        [EventHandler()]
        public void PlayerDisconnect(PlayerDisconnectEvent eventargs)
        {
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
            //TODO Add ban request handler
        }

    }
}
