/*******************************************************************************
 * Copyright (c) 2012 MCForge.
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the GNU Public License v3.0
 * which accompanies this distribution, and is available at
 * http://www.gnu.org/licenses/gpl.html
 ******************************************************************************/
using net.mcforge.API.plugin;
using net.mcforge.system.updater;
using System.Net;
using System.Windows.Forms;

namespace MCForge.Gui.Dialogs
{
    public partial class PluginInfo : UserControl
    {
        private PluginManagerDialog baseDialog;
        private PluginManager baseManager;
        public PluginInfo(PluginManagerDialog baseDialog, PluginManager baseManager, Plugin p)
        {
            InitializeComponent();
            this.baseDialog = baseDialog;
            this.baseManager = baseManager;
            lblTitle.Text = p.getName() + " - Information";
            lblName.Text += p.getName();
            try {
                lblDev.Text += p.getAuthor();
            }
            catch {
                lblDev.Text += "Not specified";
            }
            try {
                lblVersion.Text += p.getVersion();
            }
            catch {
                lblVersion.Text += "Not specified";
            }

            if (p is Updatable) {
                lblSupportsUpdates.Text = "Plugin supports automatic updates";
                Updatable u = (Updatable)p;
                lblCur.Text += u.getCurrentVersion();
                using (var wc = new WebClient()) {
                    lblLatest.Text += wc.DownloadString(u.getCheckURL());
                }
                UpdateType t = u.getUpdateType();
                if (t == UpdateType.Ask) {
                    lblType.Text += "Plugin asks before updating";
                    lblNotes.Text += "Not supported";
                    lblRestart.Text += "Not supported";
                }
                else if (t == UpdateType.Auto_Notify) {
                    lblType.Text += "Plugin updates automatically";
                    lblNotes.Text += "Yes";
                    lblRestart.Text += "No";
                }
                else if (t == UpdateType.Auto_Notify_Restart) {
                    lblType.Text += "Plugin updates automatically";
                    lblNotes.Text += "Yes";
                    lblRestart.Text += "Yes";
                }
                else if (t == UpdateType.Auto_Silent) {
                    lblType.Text += "Plugin updates automatically";
                    lblNotes.Text += "No";
                    lblRestart.Text += "No";
                }
                else if (t == UpdateType.Auto_Silent_Restart) {
                    lblType.Text += "Plugin updates automatically";
                    lblNotes.Text += "No";
                    lblRestart.Text += "Yes";
                }
            }
            else {
                lblCur.Text += "Not supported";
                lblLatest.Text += "Not supported";
                lblType.Text += "Not supported";
                lblNotes.Text += "Not supported";
                lblRestart.Text += "Not supported";
            }
        }

        private void goBach(object sender, System.EventArgs e)
        {
            baseDialog.Controls.Remove(this);
            baseDialog.Controls.Add(baseManager);
        }
    }
}
