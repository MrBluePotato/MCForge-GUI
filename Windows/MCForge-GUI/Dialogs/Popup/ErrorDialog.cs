/*
Copyright 2012 MCForge
Dual-licensed under the Educational Community License, Version 2.0 and
the GNU General Public License, Version 3 (the "Licenses"); you may
not use this file except in compliance with the Licenses. You may
obtain a copy of the Licenses at
http://www.opensource.org/licenses/ecl2.php
http://www.gnu.org/licenses/gpl-3.0.html
Unless required by applicable law or agreed to in writing,
software distributed under the Licenses are distributed on an "AS IS"
BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
or implied. See the Licenses for the specific language governing
permissions and limitations under the Licenses.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;

namespace MCForge.Gui.Dialogs {
    /// <summary>
    /// A popup that contains an error. Report returns a DialogResult.Retry. Ignore returns DialogResult.Ignore. Quit return a DialogResult.Cancel
    /// </summary>
    public partial class ErrorDialog : Form {
        private string ex;
        private bool choose;
        private Exception e;
        private bool report;
        private string[] titles = new string[] {
            "opps..:s",
            "WHOA WHOA HOLD UP FAGGOTS",
            "..what just happened?",
            "y u du dis mcforge",
            "Exception in sector C",
            "Error",
            "4th wall breaking error",
            "Alem broke it I swear",
            "Don't hit me master",
            "It wasnt my fault D:",
            "#yolo",
            "#swag",
            "what I tell ya'll about GOING IN MY SHED?!"
        };
        public ErrorDialog(Exception e, bool report)
        {
            ex = e.Message + "\n\r" + e.StackTrace;
            this.e = e;
            this.report = report;
            InitializeComponent();
        }
        public ErrorDialog(Exception e) : this(e, false) { }

        public ErrorDialog(string e) : this(new Exception(e)) { }

        private void PopupError_Load(object sender, EventArgs e) {
            
            txtError.Text = ex;
            label2.Visible = false;
            progressBar1.Visible = false;
            Random rand = new Random();
            int max = rand.Next(30);
            for (int i = 0; i < max; i++)
                this.Text = titles[rand.Next(titles.Length)];
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ReportCrash();
        }

        private void ReportCrash()
        {
            label1.Visible = false;
            this.txtError.Visible = false;
            btnIgnore.Visible = false;
            btnQuit.Visible = false;
            btnReport.Visible = false;
            this.pictureBox1.Visible = false;

            label2.Visible = true;
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            string tosend = "Server Version: " + net.mcforge.server.Server.CORE_VERSION + "\n" +
                            "GUI Version: " + Assembly.GetEntryAssembly().GetName().Version + "\n" +
                            "Exception Message: " + this.e.Message + "\n" +
                            "Exception Stacktrace: " + this.e.StackTrace + "\n" +
                            "Exception Source: " + this.e.Source + "\n" +
                            "Exception: " + this.e.ToString() + "\n" +
                            "Error Title: " + this.Text + "\n" +
                            "Is Princess Luna ruler of the free world?: No";
            Thread t = new Thread(new ThreadStart(delegate
            {
                //report data
                Thread.Sleep(new Random().Next(6549));
                DialogResult = System.Windows.Forms.DialogResult.OK;
                choose = true;
                Close();
            }));
            t.Start();
        }

        private void btnQuit_Click(object sender, EventArgs e) {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            choose = true;
            Close();
        }

        private void btnIgnore_Click(object sender, EventArgs e) {
            DialogResult = System.Windows.Forms.DialogResult.Ignore;
            choose = true;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Retry;
            choose = true;
            Close();
        }

        private void ErrorDialog_Shown(object sender, EventArgs e)
        {
            if (report)
                ReportCrash();
        }

        private void ErrorDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!choose)
                this.DialogResult = System.Windows.Forms.DialogResult.Ignore;
        }

    }
}
