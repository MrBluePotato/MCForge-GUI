using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using net.mcforge.system.updater;

namespace MCForge.Gui.Dialogs
{
    public partial class ManualUpdateReady : Form
    {
        private Updatable u;
        private UpdateService us;
        public ManualUpdateReady(Updatable u, UpdateService us)
        {
            InitializeComponent();
            this.us = us;
            this.u = u;
            this.label2.Text = "An update for " + u.getName() + " is ready!";
        }

        private void ManualUpdateReady_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start(u.getWebsite());
            DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.No;
            this.Close();
        }
    }
}
