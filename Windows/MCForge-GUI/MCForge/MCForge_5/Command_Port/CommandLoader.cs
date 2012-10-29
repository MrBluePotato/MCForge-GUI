using System;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Reflection.Emit;
using System.IO;
using System.Text;

namespace MCForge
{
    public static class CommandLoader
    {
        public static net.mcforge.server.Server Server = MCForge.Gui.Program.console.getServer();
        public static void Autoload()
        {
            if (!Directory.Exists("extra"))
                Directory.CreateDirectory("extra");
            if (!Directory.Exists("extra/commands"))
                Directory.CreateDirectory("extra/commands");
            if (!Directory.Exists("extra/commands/dll/"))
                Directory.CreateDirectory("extra/commands/dll/");
            if (!Directory.Exists("text"))
                Directory.CreateDirectory("text");

            if (!File.Exists("text/cmdautoload.txt"))
            {
                File.Create("text/cmdautoload.txt");
                return;
            }
            string[] autocmds = File.ReadAllLines("text/cmdautoload.txt");
            foreach (string cmd in autocmds)
            {
                if (cmd == "")
                {
                    continue;
                }
                string error = Load("Cmd" + cmd.ToLower());
                if (error != null)
                {
                    Server.Log(error);
                    error = null;
                    continue;
                }
                Server.Log("AUTOLOAD: Loaded " + cmd.ToLower() + ".dll");

            }
            //ScriptingVB.Autoload();
        }
        /// <summary>
        /// Loads a command for use on the server.
        /// </summary>
        /// <param name="command">Name of the command to be loaded (make sure it's prefixed by Cmd before bringing it in here or you'll have problems).</param>
        /// <returns>Error string on failure, null on success.</returns>
        public static string Load(string command)
        {
            if (command.Length < 3 || command.Substring(0, 3).ToLower() != "cmd")
            {
                return "Invalid command name specified.";
            }
            try
            {
                //Allows unloading and deleting dlls without server restart
                object instance = null;
                Assembly lib = null;
                using (FileStream fs = File.Open("extra/commands/dll/" + command + ".dll", FileMode.Open))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        byte[] buffer = new byte[1024];
                        int read = 0;
                        while ((read = fs.Read(buffer, 0, 1024)) > 0)
                            ms.Write(buffer, 0, read);
                        lib = Assembly.Load(ms.ToArray());
                        ms.Close();
                        ms.Dispose();
                    }
                    fs.Close();
                    fs.Dispose();
                }
                try
                {
                    foreach (Type t in lib.GetTypes())
                    {
                        if (t.BaseType == typeof(Command))
                        {
                            instance = Activator.CreateInstance(t);
                            Command.all.Add((Command)instance);
                        }
                    }
                }
                catch (ReflectionTypeLoadException e) {
                    Server.Log(e.ToString());
                    foreach (Exception ee in e.LoaderExceptions)
                    {
                        Server.Log(ee.ToString());
                    }
                }
                if (instance == null)
                {
                    Server.Log("The command " + command + " couldnt be loaded!");
                    throw new BadImageFormatException();
                }
            }
            catch (FileNotFoundException e)
            {
                Server.Log(e.ToString());
                return command + ".dll does not exist in the DLL folder, or is missing a dependency.  Details in the error log.";
            }
            catch (BadImageFormatException e)
            {
                Server.Log(e.ToString());
                return command + ".dll is not a valid assembly, or has an invalid dependency.  Details in the error log.";
            }
            catch (PathTooLongException)
            {
                return "Class name is too long.";
            }
            catch (FileLoadException e)
            {
                Server.Log(e.ToString());
                return command + ".dll or one of its dependencies could not be loaded.  Details in the error log.";
            }
            catch (Exception e)
            {
                Server.Log(e.ToString());
                return "An unknown error occured and has been logged.";
            }
            return null;
        }

        /// <summary>
        /// Creates a class name from the given string.
        /// </summary>
        /// <param name="name">String to convert to an MCForge class name.</param>
        /// <returns>Successfully generated class name.</returns>
        private static string ClassName(string name)
        {
            char[] conv = name.ToCharArray();
            conv[0] = char.ToUpper(conv[0]);
            return "Cmd" + new string(conv);
        }
    }
}
