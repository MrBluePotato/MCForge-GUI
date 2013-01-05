#region License
/*
Permission is hereby granted, free of
charge, to any person obtaining a copy of
this software and associated documentation
 files (the "Software"), to deal in the
Software without restriction, including
without limitation the rights to use, copy,
 modify, merge, publish, distribute,
sublicense, and/or sell copies of the
Software, and to permit persons to whom the
 Software is furnished to do so, subject to
the following conditions:


The above copyright notice and this
permission notice shall be included in all
 copies or substantial portions of the
Software.


THE SOFTWARE IS PROVIDED "AS IS", WITHOUT
WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 OF MERCHANTABILITY, FITNESS FOR A
PARTICULAR PURPOSE AND NONINFRINGEMENT. IN
NO EVENT SHALL THE AUTHORS OR COPYRIGHT
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
 OTHER LIABILITY, WHETHER IN AN ACTION OF
CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR
 THE USE OR OTHER DEALINGS IN THE SOFTWARE.

 * User: Eddie
 * Date: 10/7/2012
 * Time: 2:26 PM
 * 
 */
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing.Drawing2D;
using System.Windows.Forms.VisualStyles;
using System.Diagnostics;
using System.Threading;
using MCForge.Gui.Components;
using MCForge.Gui.Properties;
using net.mcforge.API.plugin;
using net.mcforge.API.io;
using net.mcforge.server;
using net.mcforge.API;
using net.mcforge.API.server;
using net.mcforge.groups;
using MCForge.Gui.Dialogs;
using MCForge.Gui.WindowsAPI;
using MCForge.Gui.WindowsAPI.Utils;
using System.Net;


namespace MCForge.Gui
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class SplashScreen : AeroForm, Listener
	{
		private string LogMessage;
		private string[] devlist = new string[] { "Dmitchell", "501st_commander", "Lavoaster", "Alem_Zupa", "bemacized", "Shade2010", "edh649", "hypereddie10", "Gamemakergm", "Serado", "Wouto1997", "cazzar", "givo" };
		private string devs;
		private readonly static Font DrawingFont;
		private readonly static Bitmap HammerBitmap;
		private readonly static Bitmap MCForgeBitmap;
		static SplashScreen() {
			DrawingFont = new Font("Arial", Constants.DEV_TEXT_SIZE, FontStyle.Regular);
            HammerBitmap = Resource.hirez_mcforge;
            MCForgeBitmap = Resource.mcforge_text;
		}
		
		public SplashScreen() {
			InitializeComponent();
			GlassArea = ClientRectangle;
			LogMessage = "Loading MCForge v6.0.0";			
			Paint += new PaintEventHandler(PaintEvent);
			devs = GenerateDevList();
		}
		
		#region Form Events
		void PaintEvent(object sender, PaintEventArgs e)
		{
			if (AeroAPI.CanUseAero) {
				AeroAPI.FillBlackRegion(e.Graphics, ClientRectangle);
				e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

				var gDevPath = new GraphicsPath();
				var gLogPath = new GraphicsPath();
				var brush = new SolidBrush(Color.FromArgb(0x99, Color.Black));

				gDevPath.AddString(devs, DrawingFont.FontFamily, (int)FontStyle.Regular, Constants.DEV_TEXT_SIZE,
				                   new Point(Constants.LOGO_WIDTH + Constants.PADDING, Constants.TEXT_HEIGHT + Constants.PADDING), StringFormat.GenericDefault);

				gLogPath.AddString(LogMessage, DrawingFont.FontFamily, (int)FontStyle.Bold, Constants.LOG_TEXT_SIZE, new Point(Constants.PADDING, Height - 65 - Constants.PADDING), StringFormat.GenericDefault);

				e.Graphics.DrawImage(HammerBitmap, Constants.PADDING, Constants.PADDING, Constants.LOGO_WIDTH, Constants.LOGO_HEIGHT);
				e.Graphics.DrawImage(MCForgeBitmap, Constants.LOGO_WIDTH + Constants.PADDING, Constants.PADDING, Constants.TEXT_WIDTH, Constants.TEXT_HEIGHT);
				e.Graphics.FillPath(brush, gDevPath);
				e.Graphics.FillPath(brush, gLogPath);


				gDevPath.Dispose();
				gLogPath.Dispose();
				brush.Dispose();
			}
		}
		void SplashScreen_Load(object sender, EventArgs e) {
			if (!AeroAPI.CanUseAero)
				NoAreoStart();
		}
		
		private void SplashScreen_Shown(object sender, EventArgs e) {

			if (!AeroAPI.CanUseAero)
				return; //Just incase
            DrawText("Getting Changelog...");
            using (WebClient c = new WebClient())
            {
                c.DownloadFile(Program.ChangeLogDownload, "ChangeLog.txt");
            }
			StartServer();
		}
		
		void SplashScreen_FormClosing(object sender, FormClosingEventArgs e) {
			UnregisterEvents();
        }
		#endregion
		
		
		#region MCForge Events
		[EventHandler()]
		void ServerDone(ServerStartedEvent eventargs) {
			if (InvokeRequired) {
				BeginInvoke((MethodInvoker)delegate { ServerDone(eventargs); });
				return;
			}
            DrawText("Loading BC Commands...");
            MCForge.CommandLoader.Autoload();
            DrawText("Loading BC Permissions...");
            MCForge.Command.LoadPermissions();
			DialogResult = DialogResult.OK;
			this.Close();
		}
		
		[EventHandler()]
		void OnLog(ServerLogEvent eventargs) {
			DrawText(eventargs.getMessage());
		}
		
		[EventHandler()]
		void OnPluginLoad_All(PluginLoadEvent eventarg) {
			DrawText("Loaded: " + eventarg.getPlugin().getName());
		}

		[EventHandler()]
		void OnCommandLoad_All(CommandLoadEvent eventarg) {
			DrawText("Loaded: " + eventarg.getCommand().getName());
		}
		#endregion
		
		
		#region Helpers
		
		/*
		 These methods are here to prevent the runtime
         from loading the required DLL files until the Updater has done its job  
		*/
		
		[MethodImpl(MethodImplOptions.NoInlining)]
		private void NoAreoStart() {
			new Thread(Program.console.Start).Start();
			DialogResult = DialogResult.OK;
			this.Close();
		}
		
		[MethodImpl(MethodImplOptions.NoInlining)]
		private void StartServer() {
			DrawText("Setting up the server..");
			new Thread(new ThreadStart(Program.console.Start)).Start();
			while (Program.console.getServer() == null || Program.console.getServer().getEventSystem() == null) { Thread.Sleep(1); } //Wait till event system is up
			Program.console.getServer().getEventSystem().registerEvents(this);
		}
		
		[MethodImpl(MethodImplOptions.NoInlining)]
		private void UnregisterEvents() {
			ServerLogEvent.getEventList().unregister(this);
        	PluginLoadEvent.getEventList().unregister(this);
        	CommandLoadEvent.getEventList().unregister(this); 
        	ServerStartedEvent.getEventList().unregister(this);
		}
		
		public void DrawText(string text) {
			if ( !Natives.CanUseAero )
				return;

			if ( InvokeRequired ) {
				BeginInvoke((MethodInvoker)delegate { DrawText(text); });
				return;
			}

			LogMessage = text;

			Refresh();
		}
		private string GenerateDevList() {
            var devList = devlist;
            var compiledString = "";

            float curr = Constants.LOGO_WIDTH + Constants.PADDING;

            using ( var g = CreateGraphics() )
                for ( int i = 0; i < devList.Length; i++ ) {

                    float len = g.MeasureString(devList[i], DrawingFont).Width;

                    if ( curr + len + 30 >= Width - Constants.PADDING ) {
                        compiledString += devList[i] + ",\n";
                        curr = ( Constants.LOGO_WIDTH + Constants.PADDING );
                    }
                    else {
                        compiledString += devList[i] + ", ";
                        curr += len;
                    }
                }
		    compiledString = compiledString.Replace("bemacized", "BeMacized");
            return compiledString;
        }
		#endregion
		
	}
}
