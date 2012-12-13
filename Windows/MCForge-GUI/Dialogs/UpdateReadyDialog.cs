using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using net.mcforge.system.updater;

namespace MCForge.Gui.Dialogs
{
    public partial class UpdateReadyDialog : Form
    {
        private Updatable u;
        private UpdateService us;
        public UpdateReadyDialog(Updatable u, UpdateService us)
        {
            InitializeComponent();
            this.u = u;
            this.us = us;
            this.label2.Text = "An update for " + u.getName() + " is ready!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
