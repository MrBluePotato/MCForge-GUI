﻿using MCForge.Gui.WindowsAPI.Utils;
namespace MCForge.Gui.Forms {
    partial class FormMainScreen {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainScreen));
            this.glassMenu = new MCForge.Gui.Components.GlassMenuStrip();
            this.serverToolStripMenuItem = new MCForge.Gui.Components.GlassToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.shutdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginsToolStripMenuItem = new MCForge.Gui.Components.GlassToolStripMenuItem();
            this.pluginsManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.updateServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilitiesToolStripMenuItem = new MCForge.Gui.Components.GlassToolStripMenuItem();
            this.portToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plToolStripMenuItem = new MCForge.Gui.Components.GlassToolStripMenuItem();
            this.kickAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kickNonopsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.playerManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rankManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapsToolStripMenuItem = new MCForge.Gui.Components.GlassToolStripMenuItem();
            this.unloadAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.reloadAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadEmptyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mapManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new MCForge.Gui.Components.GlassToolStripMenuItem();
            this.visitForumsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportAProblemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changelogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxLogStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nightModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateAndTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.copyLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtLog = new MCForge.Gui.Components.ColoredTextBox();
            this.cmbChatType = new System.Windows.Forms.ComboBox();
            this.txtMessage = new MCForge.Gui.Components.HintedTextbox();
            this.lstPlayers = new MCForge.Gui.Components.ColoredListBox();
            this.lstLevels = new System.Windows.Forms.ListBox();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.ctxLinkStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.glassMenu.SuspendLayout();
            this.ctxLogStrip.SuspendLayout();
            this.ctxLinkStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // glassMenu
            // 
            this.glassMenu.ColorBottom = System.Drawing.SystemColors.Control;
            this.glassMenu.ColorOutlineInner = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.glassMenu.ColorOutlineOuter = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.glassMenu.ColorTop = System.Drawing.SystemColors.ControlLightLight;
            this.glassMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverToolStripMenuItem,
            this.pluginsToolStripMenuItem,
            this.utilitiesToolStripMenuItem,
            this.plToolStripMenuItem,
            this.mapsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.glassMenu.Location = new System.Drawing.Point(0, 0);
            this.glassMenu.Name = "glassMenu";
            this.glassMenu.Padding = new System.Windows.Forms.Padding(6, 7, 0, 2);
            this.glassMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.glassMenu.Size = new System.Drawing.Size(772, 28);
            this.glassMenu.TabIndex = 1;
            this.glassMenu.Text = "glassMenuStrip1";
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.toolStripSeparator1,
            this.shutdownToolStripMenuItem,
            this.restartToolStripMenuItem});
            this.serverToolStripMenuItem.GradiantColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(51, 19);
            this.serverToolStripMenuItem.Text = "Server";
            this.serverToolStripMenuItem.Click += new System.EventHandler(this.serverToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(125, 6);
            // 
            // shutdownToolStripMenuItem
            // 
            this.shutdownToolStripMenuItem.Name = "shutdownToolStripMenuItem";
            this.shutdownToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.shutdownToolStripMenuItem.Text = "Shutdown";
            this.shutdownToolStripMenuItem.Click += new System.EventHandler(this.shutdownToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // pluginsToolStripMenuItem
            // 
            this.pluginsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pluginsManagerToolStripMenuItem,
            this.toolStripSeparator5,
            this.updateServiceToolStripMenuItem});
            this.pluginsToolStripMenuItem.GradiantColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.pluginsToolStripMenuItem.Name = "pluginsToolStripMenuItem";
            this.pluginsToolStripMenuItem.Size = new System.Drawing.Size(58, 19);
            this.pluginsToolStripMenuItem.Text = "Plugins";
            // 
            // pluginsManagerToolStripMenuItem
            // 
            this.pluginsManagerToolStripMenuItem.Name = "pluginsManagerToolStripMenuItem";
            this.pluginsManagerToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.pluginsManagerToolStripMenuItem.Text = "Plugins Manager";
            this.pluginsManagerToolStripMenuItem.Click += new System.EventHandler(this.pluginsManagerToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(160, 6);
            // 
            // updateServiceToolStripMenuItem
            // 
            this.updateServiceToolStripMenuItem.Name = "updateServiceToolStripMenuItem";
            this.updateServiceToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.updateServiceToolStripMenuItem.Text = "Update Service";
            this.updateServiceToolStripMenuItem.Click += new System.EventHandler(this.updateServiceToolStripMenuItem_Click_1);
            // 
            // utilitiesToolStripMenuItem
            // 
            this.utilitiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portToolsToolStripMenuItem,
            this.makerToolStripMenuItem,
            this.serverListToolStripMenuItem});
            this.utilitiesToolStripMenuItem.GradiantColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.utilitiesToolStripMenuItem.Name = "utilitiesToolStripMenuItem";
            this.utilitiesToolStripMenuItem.Size = new System.Drawing.Size(58, 19);
            this.utilitiesToolStripMenuItem.Text = "Utilities";
            // 
            // portToolsToolStripMenuItem
            // 
            this.portToolsToolStripMenuItem.Name = "portToolsToolStripMenuItem";
            this.portToolsToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.portToolsToolStripMenuItem.Text = "Port Tools";
            this.portToolsToolStripMenuItem.Click += new System.EventHandler(this.portToolsToolStripMenuItem_Click);
            // 
            // makerToolStripMenuItem
            // 
            this.makerToolStripMenuItem.Name = "makerToolStripMenuItem";
            this.makerToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.makerToolStripMenuItem.Text = "Maker";
            this.makerToolStripMenuItem.Click += new System.EventHandler(this.makerToolStripMenuItem_Click);
            // 
            // serverListToolStripMenuItem
            // 
            this.serverListToolStripMenuItem.Name = "serverListToolStripMenuItem";
            this.serverListToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.serverListToolStripMenuItem.Text = "Server List";
            this.serverListToolStripMenuItem.Click += new System.EventHandler(this.serverListToolStripMenuItem_Click);
            // 
            // plToolStripMenuItem
            // 
            this.plToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kickAllToolStripMenuItem,
            this.kickNonopsToolStripMenuItem,
            this.toolStripSeparator3,
            this.playerManagerToolStripMenuItem,
            this.rankManagerToolStripMenuItem});
            this.plToolStripMenuItem.GradiantColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.plToolStripMenuItem.Name = "plToolStripMenuItem";
            this.plToolStripMenuItem.Size = new System.Drawing.Size(56, 19);
            this.plToolStripMenuItem.Text = "Players";
            // 
            // kickAllToolStripMenuItem
            // 
            this.kickAllToolStripMenuItem.Name = "kickAllToolStripMenuItem";
            this.kickAllToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.kickAllToolStripMenuItem.Text = "Kick all";
            this.kickAllToolStripMenuItem.Click += new System.EventHandler(this.kickAllToolStripMenuItem_Click);
            // 
            // kickNonopsToolStripMenuItem
            // 
            this.kickNonopsToolStripMenuItem.Name = "kickNonopsToolStripMenuItem";
            this.kickNonopsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.kickNonopsToolStripMenuItem.Text = "Kick non-ops";
            this.kickNonopsToolStripMenuItem.Click += new System.EventHandler(this.kickNonopsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(153, 6);
            // 
            // playerManagerToolStripMenuItem
            // 
            this.playerManagerToolStripMenuItem.Name = "playerManagerToolStripMenuItem";
            this.playerManagerToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.playerManagerToolStripMenuItem.Text = "Player Manager";
            this.playerManagerToolStripMenuItem.Click += new System.EventHandler(this.playerManagerToolStripMenuItem_Click);
            // 
            // rankManagerToolStripMenuItem
            // 
            this.rankManagerToolStripMenuItem.Name = "rankManagerToolStripMenuItem";
            this.rankManagerToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.rankManagerToolStripMenuItem.Text = "Rank Manager";
            this.rankManagerToolStripMenuItem.Click += new System.EventHandler(this.rankManagerToolStripMenuItem_Click);
            // 
            // mapsToolStripMenuItem
            // 
            this.mapsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unloadAllToolStripMenuItem,
            this.reloadAllToolStripMenuItem,
            this.toolStripSeparator2,
            this.reloadAllToolStripMenuItem1,
            this.reloadEmptyToolStripMenuItem,
            this.toolStripSeparator4,
            this.mapManagerToolStripMenuItem});
            this.mapsToolStripMenuItem.GradiantColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.mapsToolStripMenuItem.Name = "mapsToolStripMenuItem";
            this.mapsToolStripMenuItem.Size = new System.Drawing.Size(48, 19);
            this.mapsToolStripMenuItem.Text = "Maps";
            // 
            // unloadAllToolStripMenuItem
            // 
            this.unloadAllToolStripMenuItem.Name = "unloadAllToolStripMenuItem";
            this.unloadAllToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.unloadAllToolStripMenuItem.Text = "Unload All";
            this.unloadAllToolStripMenuItem.Click += new System.EventHandler(this.unloadAllToolStripMenuItem_Click);
            // 
            // reloadAllToolStripMenuItem
            // 
            this.reloadAllToolStripMenuItem.Name = "reloadAllToolStripMenuItem";
            this.reloadAllToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.reloadAllToolStripMenuItem.Text = "Unload Empty";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(146, 6);
            // 
            // reloadAllToolStripMenuItem1
            // 
            this.reloadAllToolStripMenuItem1.Name = "reloadAllToolStripMenuItem1";
            this.reloadAllToolStripMenuItem1.Size = new System.Drawing.Size(149, 22);
            this.reloadAllToolStripMenuItem1.Text = "Reload All";
            this.reloadAllToolStripMenuItem1.Click += new System.EventHandler(this.reloadAllToolStripMenuItem1_Click);
            // 
            // reloadEmptyToolStripMenuItem
            // 
            this.reloadEmptyToolStripMenuItem.Name = "reloadEmptyToolStripMenuItem";
            this.reloadEmptyToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.reloadEmptyToolStripMenuItem.Text = "Reload Empty";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(146, 6);
            // 
            // mapManagerToolStripMenuItem
            // 
            this.mapManagerToolStripMenuItem.Name = "mapManagerToolStripMenuItem";
            this.mapManagerToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.mapManagerToolStripMenuItem.Text = "Map Manager";
            this.mapManagerToolStripMenuItem.Click += new System.EventHandler(this.mapManagerToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visitForumsToolStripMenuItem,
            this.reportAProblemToolStripMenuItem,
            this.documentationToolStripMenuItem,
            this.newsToolStripMenuItem,
            this.changelogToolStripMenuItem});
            this.helpToolStripMenuItem.GradiantColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 19);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // visitForumsToolStripMenuItem
            // 
            this.visitForumsToolStripMenuItem.Name = "visitForumsToolStripMenuItem";
            this.visitForumsToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.visitForumsToolStripMenuItem.Text = "Visit Forums";
            this.visitForumsToolStripMenuItem.Click += new System.EventHandler(this.visitForumsToolStripMenuItem_Click);
            // 
            // reportAProblemToolStripMenuItem
            // 
            this.reportAProblemToolStripMenuItem.Name = "reportAProblemToolStripMenuItem";
            this.reportAProblemToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.reportAProblemToolStripMenuItem.Text = "Report a problem";
            this.reportAProblemToolStripMenuItem.Click += new System.EventHandler(this.reportAProblemToolStripMenuItem_Click);
            // 
            // documentationToolStripMenuItem
            // 
            this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            this.documentationToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.documentationToolStripMenuItem.Text = "Wiki";
            this.documentationToolStripMenuItem.Click += new System.EventHandler(this.documentationToolStripMenuItem_Click);
            // 
            // newsToolStripMenuItem
            // 
            this.newsToolStripMenuItem.Name = "newsToolStripMenuItem";
            this.newsToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.newsToolStripMenuItem.Text = "News";
            this.newsToolStripMenuItem.Click += new System.EventHandler(this.newsToolStripMenuItem_Click);
            // 
            // changelogToolStripMenuItem
            // 
            this.changelogToolStripMenuItem.Name = "changelogToolStripMenuItem";
            this.changelogToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.changelogToolStripMenuItem.Text = "Changelog";
            this.changelogToolStripMenuItem.Click += new System.EventHandler(this.changelogToolStripMenuItem_Click);
            // 
            // ctxLogStrip
            // 
            this.ctxLogStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nightModeToolStripMenuItem,
            this.colorsToolStripMenuItem,
            this.dateAndTimeToolStripMenuItem,
            this.toolStripSeparator6,
            this.copyLogsToolStripMenuItem,
            this.clearLogsToolStripMenuItem});
            this.ctxLogStrip.Name = "contextMenuStrip1";
            this.ctxLogStrip.Size = new System.Drawing.Size(152, 120);
            // 
            // nightModeToolStripMenuItem
            // 
            this.nightModeToolStripMenuItem.Name = "nightModeToolStripMenuItem";
            this.nightModeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.nightModeToolStripMenuItem.Text = "Night Mode";
            this.nightModeToolStripMenuItem.Click += new System.EventHandler(this.nightModeToolStripMenuItem_Click);
            // 
            // colorsToolStripMenuItem
            // 
            this.colorsToolStripMenuItem.Checked = true;
            this.colorsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.colorsToolStripMenuItem.Name = "colorsToolStripMenuItem";
            this.colorsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.colorsToolStripMenuItem.Text = "Colors";
            this.colorsToolStripMenuItem.Click += new System.EventHandler(this.colorsToolStripMenuItem_Click);
            // 
            // dateAndTimeToolStripMenuItem
            // 
            this.dateAndTimeToolStripMenuItem.Checked = true;
            this.dateAndTimeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dateAndTimeToolStripMenuItem.Name = "dateAndTimeToolStripMenuItem";
            this.dateAndTimeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.dateAndTimeToolStripMenuItem.Text = "Date and Time";
            this.dateAndTimeToolStripMenuItem.Click += new System.EventHandler(this.dateAndTimeToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(148, 6);
            // 
            // copyLogsToolStripMenuItem
            // 
            this.copyLogsToolStripMenuItem.Name = "copyLogsToolStripMenuItem";
            this.copyLogsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.copyLogsToolStripMenuItem.Text = "Copy Logs";
            this.copyLogsToolStripMenuItem.Click += new System.EventHandler(this.copyLogsToolStripMenuItem_Click);
            // 
            // clearLogsToolStripMenuItem
            // 
            this.clearLogsToolStripMenuItem.Name = "clearLogsToolStripMenuItem";
            this.clearLogsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.clearLogsToolStripMenuItem.Text = "Clear Logs";
            this.clearLogsToolStripMenuItem.Click += new System.EventHandler(this.clearLogsToolStripMenuItem_Click);
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.White;
            this.txtLog.ContextMenuStrip = this.ctxLogStrip;
            this.txtLog.ForeColor = System.Drawing.Color.Black;
            this.txtLog.Location = new System.Drawing.Point(6, 19);
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(488, 416);
            this.txtLog.TabIndex = 5;
            this.txtLog.Text = "";
            // 
            // cmbChatType
            // 
            this.cmbChatType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChatType.Items.AddRange(new object[] {
            "Player",
            "Global",
            "Op",
            "Admin"});
            this.cmbChatType.Location = new System.Drawing.Point(392, 543);
            this.cmbChatType.Name = "cmbChatType";
            this.cmbChatType.Size = new System.Drawing.Size(109, 21);
            this.cmbChatType.TabIndex = 8;
            // 
            // txtMessage
            // 
            this.txtMessage.ForeColor = System.Drawing.Color.Gray;
            this.txtMessage.Hint = "Enter a command or message.";
            this.txtMessage.HintColor = System.Drawing.Color.Gray;
            this.txtMessage.Location = new System.Drawing.Point(13, 543);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(373, 20);
            this.txtMessage.TabIndex = 10;
            this.txtMessage.Text = "Enter a command or message...";
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            // 
            // lstPlayers
            // 
            this.lstPlayers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPlayers.FormattingEnabled = true;
            this.lstPlayers.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lstPlayers.ItemHeight = 18;
            this.lstPlayers.Location = new System.Drawing.Point(6, 19);
            this.lstPlayers.Name = "lstPlayers";
            this.lstPlayers.SelectedItem = "";
            this.lstPlayers.Size = new System.Drawing.Size(239, 202);
            this.lstPlayers.TabIndex = 9;
            this.lstPlayers.SelectedIndexChanged += new System.EventHandler(this.lstPlayers_SelectedIndexChanged);
            this.lstPlayers.Leave += new System.EventHandler(this.lstPlayers_Leave);
            // 
            // lstLevels
            // 
            this.lstLevels.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLevels.FormattingEnabled = true;
            this.lstLevels.ItemHeight = 16;
            this.lstLevels.Location = new System.Drawing.Point(6, 19);
            this.lstLevels.Name = "lstLevels";
            this.lstLevels.Size = new System.Drawing.Size(238, 244);
            this.lstLevels.TabIndex = 11;
            // 
            // txtUrl
            // 
            this.txtUrl.ContextMenuStrip = this.ctxLinkStrip;
            this.txtUrl.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUrl.Location = new System.Drawing.Point(13, 44);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.ReadOnly = true;
            this.txtUrl.Size = new System.Drawing.Size(488, 21);
            this.txtUrl.TabIndex = 12;
            // 
            // ctxLinkStrip
            // 
            this.ctxLinkStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToClipboardToolStripMenuItem,
            this.playToolStripMenuItem});
            this.ctxLinkStrip.Name = "ctxLinkStrip";
            this.ctxLinkStrip.Size = new System.Drawing.Size(170, 70);
            // 
            // copyToClipboardToolStripMenuItem
            // 
            this.copyToClipboardToolStripMenuItem.Name = "copyToClipboardToolStripMenuItem";
            this.copyToClipboardToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.copyToClipboardToolStripMenuItem.Text = "Copy to clipboard";
            this.copyToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyToClipboardToolStripMenuItem_Click);
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.playToolStripMenuItem.Text = "Join server";
            this.playToolStripMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLog);
            this.groupBox1.Location = new System.Drawing.Point(10, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 441);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Console";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(10, 518);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(500, 50);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Messaging and commands";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstLevels);
            this.groupBox3.Location = new System.Drawing.Point(516, 44);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(251, 276);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Levels";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lstPlayers);
            this.groupBox4.Location = new System.Drawing.Point(516, 326);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(251, 237);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Players";
            // 
            // FormMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 572);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.cmbChatType);
            this.Controls.Add(this.glassMenu);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MCForge 6";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMainScreen_FormClosed);
            this.Load += new System.EventHandler(this.FormMainScreen_Load);
            this.Shown += new System.EventHandler(this.FormMainScreen_Shown);
            this.glassMenu.ResumeLayout(false);
            this.glassMenu.PerformLayout();
            this.ctxLogStrip.ResumeLayout(false);
            this.ctxLinkStrip.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MCForge.Gui.Components.GlassMenuStrip glassMenu;
        private MCForge.Gui.Components.GlassToolStripMenuItem serverToolStripMenuItem;
        private MCForge.Gui.Components.GlassToolStripMenuItem pluginsToolStripMenuItem;
        private MCForge.Gui.Components.GlassToolStripMenuItem helpToolStripMenuItem;
        private MCForge.Gui.Components.GlassToolStripMenuItem utilitiesToolStripMenuItem;
        private MCForge.Gui.Components.GlassToolStripMenuItem plToolStripMenuItem;
        private MCForge.Gui.Components.GlassToolStripMenuItem mapsToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem shutdownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portToolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visitForumsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportAProblemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pluginsManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem kickAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kickNonopsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem rankManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unloadAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem reloadAllToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reloadEmptyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mapManagerToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ctxLogStrip;
        private System.Windows.Forms.ToolStripMenuItem colorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dateAndTimeToolStripMenuItem;
        private Components.ColoredTextBox txtLog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem copyLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nightModeToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbChatType;
        private Components.HintedTextbox txtMessage;
        private System.Windows.Forms.ToolStripMenuItem playerManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changelogToolStripMenuItem;
        private Components.ColoredListBox lstPlayers;
        private System.Windows.Forms.ListBox lstLevels;
        private System.Windows.Forms.ToolStripMenuItem makerToolStripMenuItem;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ToolStripMenuItem serverListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateServiceToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ctxLinkStrip;
        private System.Windows.Forms.ToolStripMenuItem copyToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;


    }
}