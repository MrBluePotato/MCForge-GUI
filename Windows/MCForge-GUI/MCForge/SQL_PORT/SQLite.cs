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
 * Date: 10/11/2012
 * Time: 5:32 PM
 * 
 */
#endregion
using System;
using java.sql;
using java.io;
using net.mcforge.sql;
using net.mcforge.server;
using System.Windows.Forms;

namespace MCForge.Gui.SQL_PORT
{
	/// <summary>
	/// SQLite port
	/// </summary>
	public class SQLite : net.mcforge.sql.SQLite
	{
		private Server server;
		private const string PATH = "jdbc:sqlite:MCForge.db";
		public override void Connect(Server server) {
			this.server = server;
			try {
				if (!new File("MCForge.db").exists())
					new File("MCForge.db").createNewFile();
				DriverManager.registerDriver(new org.sqlite.JDBC());
				connection = DriverManager.getConnection(PATH);
			} catch { }
		}
	}
}
