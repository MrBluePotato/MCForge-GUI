/*******************************************************************************
 * Copyright (c) 2012 MCForge.
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the GNU Public License v3.0
 * which accompanies this distribution, and is available at
 * http://www.gnu.org/licenses/gpl.html
 ******************************************************************************/
using MCForge.Gui.WindowsAPI.Utils;
using net.mcforge.chat;
using net.mcforge.groups;
using System;
using System.Windows.Forms;

namespace MCForge.Gui.Dialogs.Ranks
{
    public partial class RankAdder : UserControl
    {
        private RankManagerDialog baseDialog;
        private RankManager baseControl;
        public RankAdder(RankManagerDialog baseDialog, RankManager baseControl)
        {
            InitializeComponent();
            btnColor.Relation = ColorRelation.White;
            this.baseDialog = baseDialog;
            this.baseControl = baseControl;
        }

        private void create(object sender, EventArgs e)
        {
            if (Group.find(txtName.Text) != null) {
                MessageBox.Show("That group already exists!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int perm;
            if (String.IsNullOrEmpty(txtName.Text) || String.IsNullOrEmpty(txtPerms.Text)) {
                MessageBox.Show("Please enter all the information!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try {
                perm = int.Parse(txtPerms.Text);
            }
            catch {
                MessageBox.Show("Please enter a valid permission number!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Group.add(new Group(txtName.Text, perm, 
                                chkIsOp.CheckState == CheckState.Checked,
                                ChatColor.parse(btnColor.Relation.MinecraftColorCode), 
                                Program.console.getServer()
                                ));
            baseControl.initializeRanks();
            baseDialog.Controls.Add(baseControl);
            baseDialog.Controls.Remove(this);
        }

        private void discard(object sender, EventArgs e)
        {
            baseDialog.Controls.Add(baseControl);
            baseDialog.Controls.Remove(this);
        }
    }
}
