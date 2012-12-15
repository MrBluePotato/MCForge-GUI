using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MCForge.Gui.Components;
using MCForge.Gui.WindowsAPI;
using System.Net;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace MCForge.Gui.Dialogs
{
    public partial class ServerList : AeroForm
    {

        List<ServerInfo> servers = new List<ServerInfo>();
        public ServerList()
        {
            InitializeComponent();
        }

        private void ServerList_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.GlassArea = new Rectangle
            {
                Location = this.dataGridView1.Location,
                Width = this.dataGridView1.Location.X + 3,
                Height = this.dataGridView1.Location.Y + 20
            };
            Paint += ServerList_Paint;
            this.dataGridView1.CellClick += dataGridView1_CellClick;
        }

        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 3:
                    Process.Start(getURL(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()));
                    break;
            }
        }

        void ServerList_Paint(object sender, PaintEventArgs e)
        {
            if (AeroAPI.CanUseAero)
            {
                AeroAPI.FillBlackRegion(e.Graphics, ClientRectangle);
            }
            new System.Threading.Thread(Parse).Start();
        }

        private void addServer(ServerInfo server)
        {
            if (servers.Contains(server))
                return;
            if (InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate { addServer(server); });
                return;
            }
            servers.Add(server);
            this.dataGridView1.Rows.Add(GetRowDataFromServer(server));
        }

        private ServerInfo findServer(string name)
        {
            foreach (ServerInfo si in servers)
            {
                if (si.Name == name)
                    return si;
            }
            return null;
        }

        private string getURL(string name)
        {
            return findServer(name).URL ?? "http://minecraft.net";
        }

        private void Parse()
        {
            using (WebClient wc = new WebClient())
            {
                string servers = wc.DownloadString("http://www.mcforge.net/community/index.php?app=serverlist&raw");
                string[] serverdata = Regex.Split(servers, "\n");
                foreach (string s in serverdata)
                {
                    try
                    {
                        string final = s;
                        if (final.EndsWith("\n"))
                            final = final.Replace("\n", "");
                        if (final == "")
                            continue;
                        ServerInfo si = new ServerInfo();
                        si.Name = Regex.Split(final, "/##")[0];
                        si.motd = Regex.Split(final, "/##")[1];
                        si.URL = Regex.Split(final, "/##")[2];
                        si.players = int.Parse(Regex.Split(final, "/##")[3]);
                        si.max = int.Parse(Regex.Split(final, "/##")[4]);
                        addServer(si);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
        }

        string[] GetRowDataFromServer(ServerInfo server)
        {
            return new[] { server.Name, server.players.ToString(), server.max.ToString() };
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    class ServerInfo
    {
        public string Name;
        public string motd;
        public string URL;
        public int players;
        public int max;
    }
}
