using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using net.mcforge.system.updater;
using net.mcforge.server;

namespace MCForge.Gui.Dialogs
{
    public partial class UpdateServiceDialog : Form, Tick
    {
        private List<Updatable> objects = new List<Updatable>();
        private static UpdateService service = Program.console.getServer().getUpdateService();
        bool updated = true;
        public UpdateServiceDialog()
        {
            InitializeComponent();
        }

        private void UpdateService_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < service.getUpdateManager().getUpdateObjects().size(); i++)
            {
                Updatable u = (Updatable)Program.console.getServer().getUpdateService().getUpdateManager().getUpdateObjects().get(i);
                objects.Add(u);
            }
            Program.console.getServer().Add(this);
        }

        public void tick()
        {
            if (updated)
            {
                this.imageListBox1.Items.Clear();
                foreach (Updatable u in objects)
                {
                    if (service.hasUpdate(u))
                    {

                    }
                }
            }
        }

        private void UpdateService_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.console.getServer().Remove(this);
        }
    }
}
