﻿#region License
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
using System.IO;
using net.mcforge.API;
using net.mcforge.server;
using net.mcforge.system.updater;
using net.mcforge.API.io;
using java.lang;
using java.util;
using IKVM.Attributes;
using System.Runtime.CompilerServices;
using MCForgeGUI.Console.SQL;
using net.mcforge.sql;

namespace MCForgeGUI.Console
{
	public class MCForgeConsole : net.mcforge.system.Console, Listener
	{
		private Server server;
		private ISQL sql;
		public void Start() {
			sql = new MCForgeGUI.Console.SQL.SQLite();
			server = new Server("[MCForge] Default", 25565, "Welcome!");
			server.Start(this, false);
			server.getEventSystem().registerEvents(this);
			server.startSQL(sql);
		}
		public override net.mcforge.groups.Group getGroup()
		{
			return net.mcforge.groups.Group.getDefault();
		}
		
		public override string getName()
		{
			return "Test";
		}
		
		public override void sendMessage(string s)
		{
			server.Log(s);
		}
		
		public override string next()
		{
			//TODO Get input from somewhere..
			return "";
		}
		
		[EventHandler()]
		public void testEvent(ServerLogEvent eventa) {
			//TODO Create event to call
		}
	}
}
