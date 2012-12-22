/*******************************************************************************
 * Copyright (c) 2012 MCForge.
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the GNU Public License v3.0
 * which accompanies this distribution, and is available at
 * http://www.gnu.org/licenses/gpl.html
 ******************************************************************************/
using net.mcforge.groups;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MCForge.Gui.Dialogs.Panels
{
    public partial class PlayerDisplay : UserControl
    {
        private Group editGroup;

        private RankManagerDialog baseDialog;
        private UserControl baseControl;

        private PlayerRanker ranker;
        private readonly Point RANKER_LOCATION = new Point(209, 193);

        public PlayerDisplay(RankManagerDialog baseDialog, UserControl baseControl, Group editGroup)
        {
            InitializeComponent();
            this.editGroup = editGroup;
            this.baseDialog = baseDialog;
            this.baseControl = baseControl;
            ranker = new PlayerRanker(this, editGroup) { Location = RANKER_LOCATION };
            initializeGroup();
        }
        private void safeDemote(string username)
        {
            net.mcforge.iomodel.Player p = Program.console.getServer().findPlayer(username);

            Group playerGroup = editGroup;
            Group found = editGroup;
            java.util.List groups = Group.getGroupList();
            for (int i = 0; i < groups.size(); i++)
            {
                Group g = (Group)groups.get(i);
                if (g.permissionlevel < playerGroup.permissionlevel)
                    found = g;
            }
            if (found == editGroup) return;

            if (p == null)
            {
                if (File.Exists("ranks\\" + editGroup.name))
                {
                    var clines = File.ReadAllLines("ranks\\" + editGroup.name);
                    File.WriteAllLines("ranks\\" + editGroup.name, from player in clines where player != username select player);
                }
                File.AppendAllText("ranks\\" + found.name, username + "\n");
            }
            else
            {
                p.setGroup(found);
                p.sendMessage("Your rank was changed to " + found.color + found.name);
            }
        }

        private void safePromote(string username)
        {
            net.mcforge.iomodel.Player p = Program.console.getServer().findPlayer(username);

            Group playerGroup = editGroup;
            Group found = editGroup;
            java.util.List groups = Group.getGroupList();
            for (int i = 0; i < groups.size(); i++)
            {
                Group g = (Group)groups.get(i);
                if (g.permissionlevel > playerGroup.permissionlevel)
                    found = g;
            }
            if (found == editGroup) return;

            if (p == null)
            {
                if (File.Exists("ranks\\" + editGroup.name))
                {
                    var clines = File.ReadAllLines("ranks\\" + editGroup.name);
                    File.WriteAllLines("ranks\\" + editGroup.name, from player in clines where player != username select player);
                }
                File.AppendAllText("ranks\\" + found.name, username + "\n");
            }
            else
            {
                p.setGroup(found);
                p.sendMessage("Your rank was changed to " + found.color + found.name);
            }
        }

        private void safeDefault(string username)
        {
            net.mcforge.iomodel.Player p = Program.console.getServer().findPlayer(username);
            Group g = Group.getDefault();
            if (p == null)
            {
                if (File.Exists("ranks\\" + editGroup.name))
                {
                    var clines = File.ReadAllLines("ranks\\" + editGroup.name);
                    File.WriteAllLines("ranks\\" + editGroup.name, from player in clines where player != username select player);
                }
                File.AppendAllText("ranks\\" + g.name, username + "\n");
            }
            else
            {
                p.setGroup(g);
                p.sendMessage("Your rank was changed to " + g.color + g.name);
            }
        }

        public void initializeGroup()
        {
            lstPlayers.Clear();
            string filePath = "ranks\\" + editGroup.name;
            lblManaging.Text = "Managing players for " + editGroup.name + " rank";
            gboxPlayers.Text = "Players with the " + editGroup.name + " rank";
            if (!File.Exists(filePath)) return;
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                lstPlayers.Items.Add(lines[i]);
            }
        }

        private void promotePlayer(object sender, EventArgs e)
        {
            if (lstPlayers.SelectedItems[0] == null)
            {
                MessageBox.Show("Please select a player first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            safePromote(lstPlayers.SelectedItems[0].Text);
            initializeGroup();
        }
        private void demotePlayer(object sender, EventArgs e)
        {
            if (lstPlayers.SelectedItems[0] == null)
            {
                MessageBox.Show("Please select a player first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            safeDemote(lstPlayers.SelectedItems[0].Text);
            initializeGroup();
        }

        private void goBach(object sender, EventArgs e)
        {
            baseDialog.Controls.Add(baseControl);
            baseDialog.Controls.Remove(this);
        }

        private void derankPlayer(object sender, EventArgs e)
        {
            if (lstPlayers.SelectedItems[0] == null)
            {
                MessageBox.Show("Please select a player first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Group g = Group.getDefault();
            safeDefault(lstPlayers.SelectedItems[0].Text);
            initializeGroup();
        }

        private void rankPlayer(object sender, EventArgs e)
        {
            if (!Controls.Contains(ranker))
                Controls.Add(ranker);
        }
    }
}
