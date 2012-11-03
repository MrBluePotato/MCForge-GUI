using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using net.mcforge.groups;

namespace MCForge
{
    public class BC_Group
    {
        private Group parent;
        public LevelPermission Permissions
        {
            get
            {
                return (LevelPermission)parent.permissionlevel;
            }
            set
            {
                parent.permissionlevel = (int)value;
            }
        }

        public string name
        {
            get
            {
                return parent.name;
            }
            set
            {
                parent.name = value;
            }
        }

        public BC_Group(net.mcforge.groups.Group parent) 
        {
            this.parent = parent;
        }

        public bool CanExecute(Command c)
        {
            if (Command.permission.ContainsKey(parent))
                return Command.permission[parent].commands.Contains(c);
            return false;
        }
    }
}
