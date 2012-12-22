/*******************************************************************************
 * Copyright (c) 2012 MCForge.
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the GNU Public License v3.0
 * which accompanies this distribution, and is available at
 * http://www.gnu.org/licenses/gpl.html
 ******************************************************************************/
using net.mcforge.groups;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MCForge.Gui.Dialogs.Panels
{
    public partial class PlayerRanker : UserControl
    {
        private PlayerDisplay display;

        private Group editGroup;

        public PlayerRanker(PlayerDisplay display, Group editGroup)
        {
            InitializeComponent();
            this.display = display;
            this.editGroup = editGroup;
        }

        private Group getPlayerRank(string player)
        {
            string[] fi = Directory.GetFiles("ranks");
            for (int i = 0; i < fi.Length; i++)
            {
                if (fi[i].Contains("IRCControllers")) continue;
                if (File.ReadAllLines(fi[i]).Contains(player))
                    return Group.find(new FileInfo(fi[i]).Name);
            }
            return null;
        }

        private void rankPlayers(object sender, EventArgs e)
        {
            string[] players = txtPlayers.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < players.Length; i++)
            {
                rankPlayer(players[i]);
            }
        }
        private void rankPlayer(string player)
        {
            net.mcforge.iomodel.Player p = Program.console.getServer().findPlayer(player);
            if (p == null)
            {
                Group g = getPlayerRank(player);
                if (g == editGroup) return;
                if (g == null)
                {
                    editGroup.addMember(player);
                }
                else if (File.Exists("ranks\\" + g.name))
                {
                    var clines = File.ReadAllLines("ranks\\" + g.name);
                    File.WriteAllLines("ranks\\" + g.name, from user in clines where user != player select player);
                    editGroup.addMember(player);
                }
                else
                    editGroup.addMember(player);
            }
            else
            {
                p.setGroup(editGroup);
                p.sendMessage("Your rank was changed to " + editGroup.color + editGroup.name);
            }
            txtPlayers.Clear();
            display.initializeGroup();
        }

        private void clearBox(object sender, EventArgs e)
        {
            txtPlayers.Clear();
        }

        private void removeControl(object sender, EventArgs e)
        {
            display.Controls.Remove(this);
        }
    }
}
