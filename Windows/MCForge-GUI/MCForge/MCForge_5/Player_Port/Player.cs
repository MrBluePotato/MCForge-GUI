using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MCForge.Gui;
using net.mcforge.iomodel;
using net.mcforge.chat;
using net.mcforge.API;
using net.mcforge.API.player;

namespace MCForge
{
    public class Player : Listener
    {
        public delegate void BlockchangeEventHandler(Player p, ushort x, ushort y, ushort z, byte type);
        private event BlockchangeEventHandler blockchange = null;
        public event BlockchangeEventHandler Blockchange
        {
            add
            {
                lock (this)
                {
                    blockchange += value;
                }
                Program.console.getServer().getEventSystem().registerEvents(this);

            }
            remove
            {
                lock (this)
                {
                    blockchange -= value;
                }
                PlayerBlockChangeEvent.getEventList().unregister(this);
            }
        }

        protected net.mcforge.iomodel.Player parent;

        private string Prefix;

        public string color
        {
            get
            {
                return parent.getDisplayColor().toString();
            }
            set
            {
                parent.setDisplayColor(ChatColor.parse(value));
            }
        }

        public string prefix
        {
            get
            {
                return Prefix;
            }
            set
            {
                this.Prefix = value;
                this.parent.setPrefix(Prefix);
            }
        }
        public int ponycount;
        public int rdcount;
        public BC_Group group;
        public System.Threading.Thread commThread;
        public string title = "";
        public string titlecolor;

        public Level level
        {
            get
            {
                return new Level(parent.getLevel());
            }
            set
            {
                net.mcforge.world.Level temp = parent.getServer().getLevelHandler().findLevel(value.name);
                parent.changeLevel(temp);
            }
        }

        public string name
        {
            get
            {
                return parent.getName();
            }
            set
            {
                parent.username = value;
            }
        }

        public int[] pos
        {
            get
            {
                int[] pos = new int[3];
                pos[0] = parent.getX();
                pos[1] = parent.getY();
                pos[2] = parent.getZ();
                return pos;
            }
            set
            {
                parent.setX((short)value[0]);
                parent.setY((short)value[1]);
                parent.setZ((short)value[2]);
            }
        }

        public void ClearBlockchange() 
        {
            blockchange = null;
            PlayerBlockChangeEvent.getEventList().unregister(this);
        }

        public Player(net.mcforge.iomodel.Player parent)
        {
            this.parent = parent;
            this.group = new BC_Group(parent.getGroup());
        }

        ~Player()
        {
            PlayerBlockChangeEvent.getEventList().unregister(this);
        }

        [EventHandler()]
        public void blockChangeEvent(PlayerBlockChangeEvent eventargs)
        {
            if (blockchange != null)
            {
                blockchange(this, (ushort)eventargs.getX(), (ushort)(eventargs.getY()), (ushort)(eventargs.getZ()), eventargs.getBlock().getVisibleBlock());
                eventargs.setCancel(true);
                return;
            }
        }

        public void Kick(string message)
        {
            parent.kick(message);
        }

        public void HandleDeath(byte b, string s, bool bool1)
        {
            throw new NotImplementedException();
        }

        public void SetPrefix()
        {
            prefix = (title == "") ? "" : (titlecolor == "") ? "[" + title + "] " : "[" + titlecolor + title + color + "] ";
        }

        public void SendPos(byte id, ushort x, ushort y, ushort z, byte rotx, byte roty)
        {
            parent.setPos((short)x, (short)y, (short)z, rotx, roty);
        }

        public net.mcforge.iomodel.Player getParent()
        {
            return parent;
        }

        public static void SendMessage(Player p, string message)
        {
            p.parent.sendMessage(message);
        }

        public static void UniversalChatOps(string message)
        {
            Program.console.SendOpMessage(message);
        }

        public static void UniversalChatAdmins(string message)
        {
            Program.console.SendOpMessage(message);
        }

        public static void UniversalChat(string message)
        {
            Program.console.SendGlobalMessage(message);
        }

        public static void GlobalMessage(string message)
        {
            UniversalChat(message);
        }

        public static net.mcforge.iomodel.Player FindPlayer(string player)
        {
            return Program.console.getServer().findPlayer(player);
        }

        public static Player Find(string name)
        {
            net.mcforge.iomodel.Player parent = MCForge.Gui.Program.console.getServer().findPlayer(name);
            Player p = new Player(parent);
            return p;
        }
    }
}
