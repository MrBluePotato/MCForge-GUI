﻿/*******************************************************************************
 * Copyright (c) 2012 MCForge.
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the GNU Public License v3.0
 * which accompanies this distribution, and is available at
 * http://www.gnu.org/licenses/gpl.html
 ******************************************************************************/
using net.mcforge.API;
using net.mcforge.API.plugin;
using net.mcforge.system.updater;
using System;
using System.Windows.Forms;

namespace MCForge.Gui.Dialogs.Plugins
{
    public partial class PluginManager : UserControl, Listener
    {
        private PluginManagerDialog baseDialog;
        private UpdateService service = Program.console.getServer().getUpdateService();
        private net.mcforge.server.Server server;

        public PluginManager(PluginManagerDialog baseDialog, net.mcforge.server.Server serv)
        {
            InitializeComponent();
            server = serv;
            this.baseDialog = baseDialog;
            initializeList();
            server.getEventSystem().registerEvents(this);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.ParentForm.FormClosing += ParentForm_FormClosing;
        }

        void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            PluginLoadEvent.getEventList().unregister(this);
        }

        [EventHandler()]
        private void onPluginLoad(PluginLoadEvent eventargs)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate { onPluginLoad(eventargs); });
                return;
            }
            if (!lstPlugins.Items.Contains(eventargs.getPlugin().getName()))
                lstPlugins.Items.Add(eventargs.getPlugin().getName());
        }

        private void initializeList()
        {
            lstPlugins.Items.Clear();
            java.util.List plugins = server.getPluginHandler().getLoadedPlugins();
            for (int i = 0; i < plugins.size(); i++)
            {
                lstPlugins.Items.Add(((Plugin)plugins.get(i)).getName());
            }
        }

        private void showInfo(object sender, EventArgs e)
        {
            Plugin p = getSelectedPlugin();
            if (p == null)
            {
                return;
            }
            txtName.Text = p.getName();
            try
            {
                txtDev.Text = p.getAuthor();
            }
            catch
            {
                txtDev.Text = "Not specified";
            }
            try
            {
                txtVersion.Text = p.getVersion();
            }
            catch
            {
                txtVersion.Text = "Not specified";
            }
        }

        private Plugin getSelectedPlugin()
        {
            if (lstPlugins.SelectedItem == null)
                return null;
            return getPluginByName((string)lstPlugins.SelectedItem);
        }

        private Plugin getPluginByName(string name)
        {
            java.util.List plugins = server.getPluginHandler().getLoadedPlugins();
            for (int i = 0; i < plugins.size(); i++)
            {
                Plugin p = (Plugin)plugins.get(i);
                if (p.getName().StartsWith(name))
                    return p;
            }
            return null;
        }

        private void unloadPlugin(object sender, EventArgs e)
        {
            Plugin p = getSelectedPlugin();
            if (p == null)
            {
                MessageBox.Show("Please select a plugin first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            server.getPluginHandler().unload(p);
            txtName.Clear();
            txtDev.Clear();
            txtVersion.Clear();
            initializeList();
        }

        private void reloadPlugin(object sender, EventArgs e)
        {
            Plugin p = getSelectedPlugin();

            if (p == null)
            {
                MessageBox.Show("Please select a plugin first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                server.getPluginHandler().unload(p);
                txtName.Clear();
                txtDev.Clear();
                txtVersion.Clear();
                lstPlugins.ClearSelected();
                server.getPluginHandler().loadPlugin(p);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void checkForUpdates(object sender, EventArgs e)
        {
            Plugin p = getSelectedPlugin();
            if (p == null)
            {
                MessageBox.Show("Please select a plugin first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!(p is Updatable))
            {
                MessageBox.Show("The plugin doesn't support automatic updates!");
                return;
            }
            Updatable u = (Updatable)p;

            if (service.hasUpdate(u))
            {
                new UpdateReadyDialog(u, service).ShowDialog();
            }
            else
            {
                MessageBox.Show("Your plugin is already up to date!", "Plugin up to date", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void forceUpdate(object sender, EventArgs e)
        {
            Plugin p = getSelectedPlugin();
            if (p == null)
            {
                MessageBox.Show("Please select a plugin first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!(p is Updatable))
            {
                MessageBox.Show("The plugin doesn't support automatic updates!");
                return;
            }
            Updatable u = (Updatable)p;

            service.forceUpdate(u, true);
        }

        private void showDetailedInfo(object sender, EventArgs e)
        {
            Plugin p = getSelectedPlugin();
            if (p == null)
            {
                MessageBox.Show("Please select a plugin first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            baseDialog.Controls.Remove(this);
            baseDialog.Controls.Add(new PluginInfo(baseDialog, this, p));
        }
    }
}
