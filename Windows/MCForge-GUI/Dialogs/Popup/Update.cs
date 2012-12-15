using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace MCForge.Gui.Dialogs
{
    public partial class Update : Form
    {
        private Updater update;
        public Update(Updater u)
        {
            this.update = u;
            InitializeComponent();
        }

        public void DrawText(string s)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate { DrawText(s); });
                return;
            }
            label3.Text = s;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.No;
            if (checkBox1.Checked)
                DialogResult = System.Windows.Forms.DialogResult.None;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button3.Visible = false;
            checkBox1.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            pictureBox1.Visible = false;
            Size s = new System.Drawing.Size(497, 175);
            this.Size = s;

            label3.Visible = true;
            progressBar1.Visible = true;

            Thread t = new Thread(new ThreadStart(delegate
                {
                    update.downloadUpdates(this);
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    end();
                }));
            progressBar1.Style = ProgressBarStyle.Marquee;
            t.Start();
        }

        private void end()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate { end(); });
                return;
            }
            DrawText("Preparing to install .exe..");
            System.Threading.Thread.Sleep(1337);
            if (!System.IO.File.Exists("exedownload.exe"))
            {
                MessageBox.Show("Could not locate exedownload.exe!\nTry downloading it from www.mcforge.net and try again!", "Error locating file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(3);
                return;
            }
            System.Diagnostics.Process.Start("exedownload.exe", "9ea582c00b878d5589a253d0863b1734");
            Environment.Exit(4);
        }

        private void Update_Load(object sender, EventArgs e)
        {
            label3.Visible = false;
            progressBar1.Visible = false;
            this.MaximizeBox = false;
        }
    }
}
