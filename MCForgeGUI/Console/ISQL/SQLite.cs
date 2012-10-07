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
 * Time: 5:46 PM
 * 
 */
#endregion
using System;
using net.mcforge.sql;
using java.sql;

namespace MCForgeGUI.Console.SQL
{
	public class SQLite : ISQL
	{
		//TODO Port SQLite
		public void ExecuteQuery(string s) {
			
		}
		
		public void ExecuteQuery(string[] s) {
			
		}
		
		public void Connect(net.mcforge.server.Server s) {
			
		}
		
		public void setPrefix(string s) {
			
		}
		
		public Connection getConnection() {
			return null;
		}
		
		public ResultSet fillData(string s) {
			return null;
		}
		
		public string getPrefix() {
			return "";
		}
	}
}
