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
 * Date: 10/12/2012
 * Time: 4:20 PM
 * 
 */
#endregion
using System;
using System.Threading;
using System.Net;

namespace MCForge.Gui
{
	/// <summary>
	/// Description of Updater.
	/// </summary>
	public class Updater
	{
		private const string VERSION = "6.0.0";
		public Updater()
		{
		}
		
		public bool checkUpdates() {
			string last = "";
			using (WebClient wc = new WebClient()) {
				last = wc.DownloadString("http://update.mcforge.net/VERSION_2/GUI/current.txt");
			}
			return last != VERSION;
		}
		
		public void downloadUpdates(SplashScreen parent) {
			string[] files;
			using (WebClient wc = new WebClient()) {
				parent.DrawText("Getting file list..");
				files = wc.DownloadString("http://update.mcforge.net/VERSION_2/GUI/files.txt").Split(':');
				foreach (string s in files) {
					//FIXME This will throw a error because MCForge.dll is in use. Need to fix
					parent.DrawText("Downloading " + s.Split('/')[1] + "...");
					wc.DownloadFile("http://update.mcforge.net/VERSION_2/GUI/" + s, s.Split('/')[1]);
				}
			}
		}
	}
}
