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
    public partial class RankEditor : UserControl
    {
        private bool changed = false;
        private Group editGroup;

        private RankManagerDialog baseDialog;
        private RankManager baseManager;

        public RankEditor(RankManagerDialog baseDialog, RankManager baseManager, Group g)
        {
            InitializeComponent();
            editGroup = g;
            this.baseDialog = baseDialog;
            this.baseManager = baseManager;
            initGroup();
            changed = false;
        }

        private void saveProperties()
        {
            editGroup.setName(txtName.Text);
            int perm;
            try
            {
                perm = int.Parse(txtPermission.Text);
            }
            catch
            {
                MessageBox.Show("Please enter a valid permission number!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            editGroup.setPermission(perm);
            editGroup.setIsOp(chkIsOp.CheckState == CheckState.Checked);
            editGroup.setColor(ChatColor.parse(btnColor.Relation.MinecraftColorCode));
            Group.saveGroups();
            changed = false;
            baseManager.initializeRanks();
        }

        private void initGroup()
        {
            lblEditing.Text = "Currently editing the " + editGroup.name + " rank";
            txtName.Text = editGroup.name;
            txtPermission.Text = editGroup.permissionlevel.ToString();
            chkIsOp.CheckState = editGroup.isOP ? CheckState.Checked : CheckState.Unchecked;
            chkIsOp.Text = editGroup.isOP ? "TRUE" : "FALSE";
            ColorRelation clr = ColorRelation.FindColorRelationByMinecraftCode(editGroup.color.toString());
            btnColor.Relation = clr;
        }

        private void changedItem(object sender, EventArgs e)
        {
            changed = true;
        }

        private void saveAndReturn(object sender, EventArgs e)
        {
            saveProperties();
            baseDialog.Controls.Add(baseManager);
            baseDialog.Controls.Remove(this);
        }

        private void saveProps(object sender, EventArgs e)
        {
            saveProperties();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (changed)
            {
                DialogResult dr = MessageBox.Show("You have unsaved changes!\nAre you sure you want to go back?",
                                                  "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    baseDialog.Controls.Add(baseManager);
                    baseDialog.Controls.Remove(this);
                }
                return;
            }
            baseDialog.Controls.Add(baseManager);
            baseDialog.Controls.Remove(this);
        }
        private void deleteGroup(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete the rank?\nAll rank data will be lost!",
                                              "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (dr == DialogResult.Yes)
            {
                editGroup.delete();
                baseManager.initializeRanks();
                baseDialog.Controls.Add(baseManager);
                baseDialog.Controls.Remove(this);
            }
        }

        private void btnPlayers_Click(object sender, EventArgs e)
        {
            baseDialog.Controls.Add(new PlayerDisplay(baseDialog, this, editGroup));
            baseDialog.Controls.Remove(this);
        }

        private void changeCheckState(object sender, EventArgs e)
        {
            changed = true;
            if (chkIsOp.CheckState == CheckState.Checked)
                chkIsOp.Text = "TRUE";
            else
                chkIsOp.Text = "FALSE";
        }
    }
}
