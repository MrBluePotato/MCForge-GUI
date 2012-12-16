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
using MCForge.Gui.Components;
using System.Threading;

namespace MCForge.Gui.Dialogs
{
    public partial class UpdateServiceDialog : Form
    {
        private List<Updatable> objects = new List<Updatable>();
        private static UpdateService service = Program.console.getServer().getUpdateService();
        private System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        private ImageList il;
        bool updated = true;
        public UpdateServiceDialog()
        {
            InitializeComponent();
            il = new ImageList();
            il.Images.Add(Properties.Resource.updateicon);
        }

        private void UpdateService_Load(object sender, EventArgs e)
        {
            this.imageListBox1.ImageList = il;
            t.Interval = 120000;
            t.Tick += delegate
            {
                tick();
            };
            t.Enabled = true;
            t.Start();
            for (int i = 0; i < service.getUpdateManager().getUpdateObjects().size(); i++)
            {
                Updatable u = (Updatable)Program.console.getServer().getUpdateService().getUpdateManager().getUpdateObjects().get(i);
                objects.Add(u);
            }
            tick();
        }

        public void tick()
        {
            if (this.InvokeRequired)
            {
                Invoke((MethodInvoker)delegate { tick(); });
                return;
            }
            if (updated)
            {
                toolStripStatusLabel1.Text = "Checking for updates..";
                this.imageListBox1.Items.Clear();
                foreach (Updatable u in objects)
                {
                    if (u.getName() == "MCForge") //Ignore MCForge
                        continue; 
                    ImageListBoxItem i;
                    if (service.hasUpdate(u))
                        i = new ImageListBoxItem(u.getName(), 0);
                    else
                        i = new ImageListBoxItem(u.getName());
                    this.imageListBox1.Items.Add(i);
                }
                if (this.imageListBox1.SelectedIndex != -1)
                {
                    button1.Enabled = true;
                    bool enabled = service.hasUpdate(objects[this.imageListBox1.SelectedIndex]);
                    button2.Enabled = enabled;
                    button3.Enabled = enabled && !service.isInRestartQueue(objects[this.imageListBox1.SelectedIndex]);
                    button4.Enabled = enabled && service.isInRestartQueue(objects[this.imageListBox1.SelectedIndex]);
                }
                updated = false;
                toolStripStatusLabel1.Text = "Checking for updates..(Done!)";
            }
        }

        private void UpdateService_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Enabled = false;
            t.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.imageListBox1.SelectedIndex == -1)
                return;
            Updatable u = objects[this.imageListBox1.SelectedIndex];
            if (!service.hasUpdate(u))
            {
                MessageBox.Show("No updates found.", "MCF Update Service", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }
            else
            {
                MessageBox.Show("Updates have been found for " + u.getName(), "MCF Update Service", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button2.Enabled = true;
                button3.Enabled = !service.isInRestartQueue(u);
                button4.Enabled = service.isInRestartQueue(u);
            }
            updated = true;
        }

        private void imageListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.imageListBox1.SelectedIndex == -1)
                return;
            Updatable u = objects[this.imageListBox1.SelectedIndex];
            if (!service.hasUpdate(u))
            {
                MessageBox.Show("No updates found.", "MCF Update Service", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                return;
            }
            Thread t = new Thread(new ThreadStart(delegate
                {
                    this.toolStripStatusLabel1.Text = "Updating " + u.getName() + "..";
                    disableAll();
                    service.forceUpdate(u);
                    this.toolStripStatusLabel1.Text = "Updating " + u.getName() + "..(Done!)";
                    MessageBox.Show(u.getName() + " updated!", "MCF Update Service", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tick();
                }));
            t.Start();
        }

        private void disableAll()
        {
            if (this.InvokeRequired)
            {
                Invoke((MethodInvoker)delegate { disableAll(); });
                return;
            }
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            imageListBox1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.imageListBox1.SelectedIndex == -1)
                return;
            Updatable u = objects[this.imageListBox1.SelectedIndex];
            if (!service.hasUpdate(u))
            {
                MessageBox.Show("No updates found.", "MCF Update Service", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }
            if (service.isInRestartQueue(u))
                button3.Enabled = false;
            else
            {
                service.addToRestartQueue(u);
                MessageBox.Show(u.getName() + " will be updated after a server restart!", "MCF Update Service", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button3.Enabled = false;
            }
            updated = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Updatable u = objects[this.imageListBox1.SelectedIndex];
            if (!service.hasUpdate(u))
            {
                MessageBox.Show("No updates found.", "MCF Update Service", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }
            if (!service.isInRestartQueue(u))
                button4.Enabled = false;
            else
            {
                service.removeFromRestartQueue(u);
                MessageBox.Show(u.getName() + " has been removed from restart queue.", "MCF Update Service", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button4.Enabled = false;
            }
            updated = true;
        }

        private void imageListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (this.imageListBox1.SelectedIndex == -1)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                bool enabled = service.hasUpdate(objects[this.imageListBox1.SelectedIndex]);
                button2.Enabled = enabled;
                button3.Enabled = enabled && !service.isInRestartQueue(objects[this.imageListBox1.SelectedIndex]);
                button4.Enabled = enabled && service.isInRestartQueue(objects[this.imageListBox1.SelectedIndex]);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tick();
            MessageBox.Show("Update check complete!", "MCF Update Service", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
