/*******************************************************************************
 * Copyright (c) 2012 MCForge.
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the GNU Public License v3.0
 * which accompanies this distribution, and is available at
 * http://www.gnu.org/licenses/gpl.html
 ******************************************************************************/
using MCForge.Gui.Dialogs.Panels;
using System.Windows.Forms;

namespace MCForge.Gui.Dialogs
{
    public partial class PluginManagerDialog : Form
    {
        public PluginManagerDialog(net.mcforge.server.Server serv)
        {
            InitializeComponent();
            this.Controls.Add(new PluginManager(this, serv));
        }
    }
}
