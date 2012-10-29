/*
	Copyright 2010 MCSharp team (Modified for use with MCZall/MCLawl/MCForge)

	Dual-licensed under the	Educational Community License, Version 2.0 and
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
using System.IO;
using System.Linq;
using net.mcforge.groups;
//using MCForge.Commands;

namespace MCForge
{
    public enum LevelPermission //int is default
    {
        Banned = -20,
        Guest = 0,
        Builder = 30,
        AdvBuilder = 50,
        Operator = 80,
        Admin = 100,
        Nobody = 120,
        Null = 150
    }

	public abstract class Command
	{
		public abstract string name { get; }
		public abstract string shortcut { get; }
		public abstract string type { get; }
		public abstract bool museumUsable { get; }
		public abstract LevelPermission defaultRank { get; }
		public abstract void Use(Player p, string message);
		public abstract void Help(Player p);
		public bool isIntervalized;
		public int intervalInMinutes;
		public DateTime nextExecution;
		public Player intervalUsingPlayer;

        public static Dictionary<Group, CommandList> permission = new Dictionary<Group, CommandList>();
		public static CommandList all = new CommandList();
		//public static CommandList core = new CommandList();


		/// <summary>
		/// Add a command to the server
		/// </summary>
		/// <param name="command">The command to add</param>
		public void AddCommand(Command command)
		{
			all.Add(command);
		}

        public class rankAllowance { 
            public string commandName; 
            public LevelPermission lowestRank;
            public List<LevelPermission> disallow = new List<LevelPermission>();
            public List<LevelPermission> allow = new List<LevelPermission>();
        }
        public static net.mcforge.server.Server Server = MCForge.Gui.Program.console.getServer();
        public static List<rankAllowance> allowedCommands;
        public static List<string> foundCommands = new List<string>();

        public static LevelPermission PermissionFromName(string name)
        {
            Group foundGroup = Group.find(name);
            return foundGroup != null ? (LevelPermission)foundGroup.permissionlevel : LevelPermission.Null;
        }

        public static void LoadPermissions()
        {
            foundCommands = Command.all.commandNames();
            allowedCommands = new List<rankAllowance>();

            rankAllowance allowVar;

            foreach (Command cmd in Command.all.All())
            {
                allowVar = new rankAllowance();
                allowVar.commandName = cmd.name;
                allowVar.lowestRank = cmd.defaultRank;
                allowedCommands.Add(allowVar);
            }
            if (File.Exists("properties/command.properties"))
                File.Move("properties/command.properties", "properties/bc_command.config");
            if (File.Exists("properties/bc_command.config"))
            {
                string[] lines = File.ReadAllLines("properties/bc_command.config");

                //if (lines.Length == 0) ; // this is useless?
                /*else */if (lines[0] == "#Version 2")
                {
                    string[] colon = new[] { " : " };
                    foreach (string line in lines)
                    {
                        allowVar = new rankAllowance();
                        if (line == "" || line[0] == '#') continue;
                        //Name : Lowest : Disallow : Allow
                        string[] command = line.Split(colon, StringSplitOptions.None);

                        if (!foundCommands.Contains(command[0]))
                        {
                            Server.Log("Incorrect command name: " + command[0]);
                            continue;
                        }
                        allowVar.commandName = command[0];

                        string[] disallow = new string[0];
                        if (command[2] != "")
                            disallow = command[2].Split(',');
                        string[] allow = new string[0];
                        if (command[3] != "")
                            allow = command[3].Split(',');

                        try
                        {
                            allowVar.lowestRank = (LevelPermission)int.Parse(command[1]);
                            foreach (string s in disallow) { allowVar.disallow.Add((LevelPermission)int.Parse(s)); }
                            foreach (string s in allow) { allowVar.allow.Add((LevelPermission)int.Parse(s)); }
                        }
                        catch
                        {
                            Server.Log("Hit an error on the command " + line);
                            continue;
                        }

                        int current = 0;
                        foreach (rankAllowance aV in allowedCommands)
                        {
                            if (command[0] == aV.commandName)
                            {
                                allowedCommands[current] = allowVar;
                                break;
                            }
                            current++;
                        }
                    }
                }
                else
                {
                    foreach (string line in lines.Where(line => line != "" && line[0] != '#'))
                    {
                        allowVar = new rankAllowance();
                        string key = line.Split('=')[0].Trim().ToLower();
                        string value = line.Split('=')[1].Trim().ToLower();

                        if (!foundCommands.Contains(key))
                        {
                            Server.Log("Incorrect command name: " + key);
                        }
                        else if (PermissionFromName(value) == LevelPermission.Null)
                        {
                            Server.Log("Incorrect value given for " + key + ", using default value.");
                        }
                        else
                        {
                            allowVar.commandName = key;
                            allowVar.lowestRank = PermissionFromName(value);

                            int current = 0;
                            foreach (rankAllowance aV in allowedCommands)
                            {
                                if (key == aV.commandName)
                                {
                                    allowedCommands[current] = allowVar;
                                    break;
                                }
                                current++;
                            }
                        }
                    }
                }
                Save(allowedCommands);
            }
            else Save(allowedCommands);

            for (int i = 0; i < Group.getGroupList().size(); i++)
            {
                Group g = (Group)Group.getGroupList().get(i);
                CommandList commands = new CommandList();

                foreach (rankAllowance aV in allowedCommands.Where(aV => (aV.lowestRank <= (LevelPermission)g.permissionlevel && !aV.disallow.Contains((LevelPermission)g.permissionlevel)) || aV.allow.Contains((LevelPermission)g.permissionlevel)))
                    commands.Add(Command.all.Find(aV.commandName));
                
                Command.permission.Add(g, commands);
            }
        }
        public static void Save(List<rankAllowance> givenList)
        {
            try
            {
                File.Create("properties/bc_command.config").Dispose();
                using (StreamWriter w = File.CreateText("properties/bc_command.config"))
                {
                    w.WriteLine("#Version 2");
                    w.WriteLine("#   This file contains a reference to every custom command from MCForge 5");
                    w.WriteLine("#   Use this file to specify which ranks get which custom commands");
                    w.WriteLine("#   Disallow and allow can be left empty, just make sure there's 2 spaces between the colons");
                    w.WriteLine("#   This works entirely on permission values, not names. Do not enter a rank name. Use it's permission value");
                    w.WriteLine("#   CommandName : LowestRank : Disallow : Allow");
                    w.WriteLine("#   gun : 60 : 80,67 : 40,41,55");
                    w.WriteLine("");
                    foreach (rankAllowance aV in givenList)
                    {
                        w.WriteLine(aV.commandName + " : " + (int)aV.lowestRank + " : " + getInts(aV.disallow) + " : " + getInts(aV.allow));
                    }
                }
            }
            catch
            {
                Server.Log("SAVE FAILED! properties/bc_command.config");
            }
        }
        public static string getInts(List<LevelPermission> givenList)
        {
            string returnString = ""; bool foundOne = false;
            foreach (LevelPermission Perm in givenList)
            {
                foundOne = true;
                returnString += "," + (int)Perm;
            }
            if (foundOne) returnString = returnString.Remove(0, 1);
            return returnString;
        }
	}
}