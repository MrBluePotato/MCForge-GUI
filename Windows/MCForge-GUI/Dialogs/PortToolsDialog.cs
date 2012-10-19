﻿/*
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
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace MCForge.Gui.Dialogs {
    public partial class PortToolsDialog : Form {

        private BackgroundWorker mWorkerChecker;
        private BackgroundWorker mWorkerForwarder;

        public PortToolsDialog() {
            InitializeComponent();
            mWorkerChecker = new BackgroundWorker();
            mWorkerChecker.WorkerSupportsCancellation = true;
            mWorkerChecker.DoWork += new DoWorkEventHandler( mWorker_DoWork );
            mWorkerChecker.RunWorkerCompleted += new RunWorkerCompletedEventHandler( mWorker_RunWorkerCompleted );

            mWorkerForwarder = new BackgroundWorker();
            mWorkerForwarder.WorkerSupportsCancellation = true;
            mWorkerForwarder.DoWork += new DoWorkEventHandler( mWorkerForwarder_DoWork );
            mWorkerForwarder.RunWorkerCompleted += new RunWorkerCompletedEventHandler( mWorkerForwarder_RunWorkerCompleted );
        }

        private void linkManually_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e ) {
            Process.Start( "http://www.canyouseeme.org/" );
        }

        private void linkHelp_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e ) {
            Process.Start( "http://www.mcforge.net/forums/forumdisplay.php?fid=19" );
        }

        private void btnCheck_Click( object sender, EventArgs e ) {
            int port = 25565;
            if ( String.IsNullOrWhiteSpace( txtPort.Text ) )
                txtPort.Text = "25565";

            try {
                port = int.Parse( txtPort.Text );
            }
            catch {
                txtPort.Text = "25565";
            }

            btnCheck.Enabled = false;
            txtPort.Enabled = false;
            lblStatus.Text = "Checking...";
            mWorkerChecker.RunWorkerAsync( port );
        }

        void mWorker_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e ) {
            if ( e.Cancelled )
                return;

            btnCheck.Enabled = true;
            txtPort.Enabled = true;

            int result = ( int ) e.Result;
            switch ( result ) {
                case 0:
                    lblStatus.Text = "Problems Occurred";
                    lblStatus.ForeColor = Color.Red;
                    return;
                case 1:
                    lblStatus.Text = "Open";
                    lblStatus.ForeColor = Color.Green;
                    return;
                case 2:
                    lblStatus.Text = "Closed";
                    lblStatus.ForeColor = Color.Red;
                    return;
                case 3:
                    lblStatus.Text = "Web site error";
                    lblStatus.ForeColor = Color.Yellow;
                    return;
            }
        }

        void mWorker_DoWork( object sender, DoWorkEventArgs e ) {
            try {
                using ( var webClient = new WebClient() ) {
                    string response = webClient.DownloadString( "http://www.mcforge.net/ports.php?port=" + e.Argument );
                    switch ( response.ToLower() ) {
                        case "open":
                            e.Result = 1;
                            return;
                        case "closed":
                            e.Result = 2;
                            return;
                        default:
                            e.Result = 3;
                            return;
                    }
                }
            }
            catch {
                e.Result = 0;
                return;
            }
        }

        private void PortChecker_FormClosing( object sender, FormClosingEventArgs e ) {
            mWorkerChecker.CancelAsync();
            mWorkerForwarder.CancelAsync();
        }

        private void linkHelpForward_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e ) {
            Process.Start( "https://github.com/MCForge/MCForge-Vanilla/wiki/Setup%20MCForge%205.5.0.2" );
        }

        private void btnForward_Click( object sender, EventArgs e ) {
            int port = 25565;
            if ( String.IsNullOrWhiteSpace( txtPortForward.Text ) )
                txtPortForward.Text = "25565";

            try {
                port = int.Parse( txtPortForward.Text );
            }
            catch {
                txtPortForward.Text = "25565";
            }
            btnDelete.Enabled = false;
            btnForward.Enabled = false;
            txtPortForward.Enabled = false;
            mWorkerForwarder.RunWorkerAsync( new object[] { port, true } );
        }

        private void btnDelete_Click( object sender, EventArgs e ) {
            int port = 25565;
            if ( String.IsNullOrWhiteSpace( txtPortForward.Text ) )
                txtPortForward.Text = "25565";

            try {
                port = int.Parse( txtPortForward.Text );
            }
            catch {
                txtPortForward.Text = "25565";
            }

            btnDelete.Enabled = false;
            btnForward.Enabled = false;
            txtPortForward.Enabled = false;
            mWorkerForwarder.RunWorkerAsync( new object[] { port, false } );

        }

        void mWorkerForwarder_DoWork( object sender, DoWorkEventArgs e ) {
            //TODO Add UPnP!
            
        	/*int port = ( int ) ( ( object[] ) e.Argument )[ 0 ];
            bool adding = ( bool ) ( ( object[] ) e.Argument )[ 1 ];
            try {
                if ( !UPnP.CanUseUpnp ) {
                    e.Result = 0;
                    return;
                }
                else {

                    if ( adding ) {
                        UPnP.ForwardPort( port, ProtocolType.Tcp, "MCForgeServer" );
                        e.Result = 1;
                    }
                    else {
                        UPnP.DeleteForwardingRule( port, ProtocolType.Tcp );
                        e.Result = 3;
                    }
                    return;
                }
            }
            catch {
                e.Result = 2;
                return;
            }*/
        }

        void mWorkerForwarder_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e ) {
            if ( e.Cancelled )
                return;

            btnDelete.Enabled = true;
            btnForward.Enabled = true;
            txtPortForward.Enabled = true;

            int result = ( int ) e.Result;

            switch ( result ) {
                case 0:
                    lblForward.Text = "Your router does not support UPnP";
                    lblForward.ForeColor = Color.Red;
                    return;
                case 1:
                    lblForward.Text = "Port forwarded automatically using UPnP";
                    lblForward.ForeColor = Color.Green;
                    return;
                case 2:
                    lblForward.Text = "Something Weird just happened, try again.";
                    lblForward.ForeColor = Color.Black;
                    return;
                case 3:
                    lblForward.Text = "Deleted Port Forward Rule.";
                    lblForward.ForeColor = Color.Green;
                    return;
            }
        }

        private void PortToolsDialog_Load( object sender, EventArgs e ) {

        }
    }
}
