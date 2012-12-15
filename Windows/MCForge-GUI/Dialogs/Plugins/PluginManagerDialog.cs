using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
