/*******************************************************************************
 * Copyright (c) 2012 MCForge.
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the GNU Public License v3.0
 * which accompanies this distribution, and is available at
 * http://www.gnu.org/licenses/gpl.html
 ******************************************************************************/
using net.mcforge.groups;
using net.mcforge.util;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace MCForge.Gui.Dialogs.Panels
{
    public partial class RankManager : UserControl
    {
        public RankManagerDialog baseDialog;
        public RankManager(RankManagerDialog baseDialog)
        {
            InitializeComponent();
            initializeRanks();
            this.baseDialog = baseDialog;
        }

        public void initializeRanks()
        {
            ranksView.Rows.Clear();
            XmlDocument ranksXml = new XmlDocument();
            ranksXml.Load(FileUtils.PROPS_DIR + "groups.xml");

            XmlNodeList ranks = ranksXml.GetElementsByTagName("Group");
            for (int i = 0; i < ranks.Count; i++)
            {
                XmlNode rank = ranks[i];
                using (var r = new DataGridViewRow())
                {
                    r.CreateCells(ranksView);
                    r.Cells[0].Value = rank["name"].InnerText;
                    r.Cells[1].Value = rank["permission"].InnerText;
                    r.Cells[2].Value = rank["isop"].InnerText;
                    r.Cells[3].Value = getColor(rank["color"].InnerText);
                    r.Cells[3].Style = getStyle(rank["color"].InnerText);
                    ranksView.Rows.Add(r);
                }
            }
        }

        public DataGridViewCellStyle getStyle(string color)
        {
            DataGridViewCellStyle cs = new DataGridViewCellStyle();
            string pcolor = color.Length == 1 ? color : color.Substring(1);
            switch (pcolor)
            {
                case "0":
                    cs.BackColor = Color.Black;
                    cs.ForeColor = Color.White;
                    break;
                case "1":
                    cs.BackColor = Color.FromArgb(0, 0, 191);
                    cs.ForeColor = Color.White;
                    break;
                case "2":
                    cs.BackColor = Color.FromArgb(0, 191, 0);
                    cs.ForeColor = Color.White;
                    break;
                case "3":
                    cs.BackColor = Color.FromArgb(0, 191, 191);
                    cs.ForeColor = Color.White;
                    break;
                case "4":
                    cs.BackColor = Color.FromArgb(191, 0, 0);
                    cs.ForeColor = Color.White;
                    break;
                case "5":
                    cs.BackColor = Color.FromArgb(191, 0, 191);
                    cs.ForeColor = Color.Black;
                    break;
                case "6":
                    cs.BackColor = Color.FromArgb(191, 191, 0);
                    cs.ForeColor = Color.Black;
                    break;
                case "7":
                    cs.BackColor = Color.FromArgb(191, 191, 191);
                    cs.ForeColor = Color.White;
                    break;
                case "8":
                    cs.BackColor = Color.FromArgb(64, 64, 64);
                    cs.ForeColor = Color.White;
                    break;
                case "9":
                    cs.BackColor = Color.FromArgb(64, 64, 255);
                    cs.ForeColor = Color.White;
                    break;
                case "a":
                    cs.BackColor = Color.FromArgb(64, 255, 64);
                    cs.ForeColor = Color.White;
                    break;
                case "b":
                    cs.BackColor = Color.FromArgb(64, 255, 255);
                    cs.ForeColor = Color.White;
                    break;
                case "c":
                    cs.BackColor = Color.FromArgb(255, 64, 64);
                    cs.ForeColor = Color.White;
                    break;
                case "d":
                    cs.BackColor = Color.FromArgb(255, 64, 255);
                    cs.ForeColor = Color.White;
                    break;
                case "e":
                    cs.BackColor = Color.FromArgb(255, 255, 64);
                    cs.ForeColor = Color.Black;
                    break;
                case "f":
                    cs.BackColor = Color.White;
                    cs.ForeColor = Color.Black;
                    break;
            }
            cs.Alignment = DataGridViewContentAlignment.MiddleCenter;
            return cs;
        }

        public string getColor(string code)
        {
            switch (code)
            {
                default:
                case "0":
                    return "Black";
                case "1":
                    return "Navy";
                case "2":
                    return "Green";
                case "3":
                    return "Teal";
                case "4":
                    return "Maroon";
                case "5":
                    return "Purple";
                case "6":
                    return "Gold";
                case "7":
                    return "Silver";
                case "8":
                    return "Gray";
                case "9":
                    return "Blue";
                case "a":
                    return "Lime";
                case "b":
                    return "Aqua";
                case "c":
                    return "Red";
                case "d":
                    return "Pink";
                case "e":
                    return "Yellow";
                case "f":
                    return "White";
            }
        }

        private void editProperties(object sender, System.EventArgs e)
        {
            string groupname = (string)ranksView.SelectedRows[0].Cells[0].Value;
            Group g = Group.find(groupname);
            baseDialog.Controls.Add(new RankEditor(baseDialog, this, g));
            baseDialog.Controls.Remove(this);
        }

        private void addRank(object sender, System.EventArgs e)
        {
            baseDialog.Controls.Add(new RankAdder(baseDialog, this));
            baseDialog.Controls.Remove(this);
        }

        private void removeRank(object sender, System.EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete the rank?\nAll rank data will be lost!",
                                  "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (dr == DialogResult.Yes)
            {
                string groupname = (string)ranksView.SelectedRows[0].Cells[0].Value;
                Group.find(groupname).delete();
                initializeRanks();
            }
        }

        private void viewRankedPlayers(object sender, System.EventArgs e)
        {
            string groupname = (string)ranksView.SelectedRows[0].Cells[0].Value;
            Group g = Group.find(groupname);
            baseDialog.Controls.Add(new PlayerDisplay(baseDialog, this, g));
            baseDialog.Controls.Remove(this);
        }

        private void exit(object sender, System.EventArgs e)
        {
            baseDialog.Close();
        }
    }
}
