using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using MCForge.Gui.WindowsAPI.Utils;

namespace MCForge.Gui.Dialogs {
    public partial class NewsDialog : Form {

        public const string URL = "http://server.mcforge.net/news/index.html";
        private BackgroundWorker mNewsFetcher;

        public NewsDialog() {
            InitializeComponent();

            mNewsFetcher = new BackgroundWorker() {
                WorkerSupportsCancellation = true
            };
            mNewsFetcher.DoWork += new DoWorkEventHandler(mNewsFetcher_DoWork);
            mNewsFetcher.RunWorkerCompleted += new RunWorkerCompletedEventHandler(mNewsFetcher_RunWorkerCompleted);
        }

        void mNewsFetcher_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if ( e.Cancelled || mNewsFetcher.CancellationPending )
                return;

            if (!browser.IsDisposed)
                browser.Navigate(URL);
        }

        void mNewsFetcher_DoWork(object sender, DoWorkEventArgs e) {
            if ( !PageExists() ) {
                e.Result = "Cannot find news :(";
                return;
            }
        }



        private void NewsDialog_Load(object sender, EventArgs e) {
            mNewsFetcher.RunWorkerAsync();

            checkBox1.Checked = !Program.guisettings.showNews;
        }

        bool PageExists() {
            try {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Method = WebRequestMethods.Http.Head;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                return response.StatusCode == HttpStatusCode.OK;
            }
            catch {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Program.guisettings.showNews = !checkBox1.Checked;
        }

        private void browser_Click(object sender, EventArgs e)
        {

        }
    }
}
