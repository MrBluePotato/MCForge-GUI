﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MCForge.Gui;
using net.mcforge.iomodel;
using net.mcforge.chat;

namespace MCForge
{
    public class Player
    {
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
        public string title = "";
        public string titlecolor;

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

        public Player(net.mcforge.iomodel.Player parent)
        {
            this.parent = parent;
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

        public static net.mcforge.iomodel.Player Find(string player)
        {
            return Program.console.getServer().findPlayer(player);
        }
    }
}
