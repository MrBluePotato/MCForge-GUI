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
 * Time: 5:42 PM
 * 
 */
#endregion
using System;
using System.Collections.Generic;
using System.Drawing;
using MCForgeGUI.Console;
using System.Windows.Forms;

namespace MCForgeGUI
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		MCForgeConsole console = new MCForgeConsole();
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			console.Start();
			MessageBox.Show("Started!", "Started!");
		}
	}
}
