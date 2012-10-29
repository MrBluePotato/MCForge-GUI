using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using net.mcforge.world;

namespace MCForge
{
    public class Level
    {
        net.mcforge.world.Level parent;

        public Level(net.mcforge.world.Level parent)
        {
            this.parent = parent;
        }

        public byte GetTile(ushort x, ushort y, ushort z)
        {
            return parent.getTile(x, y, z).getVisableBlock();
        }

        public byte GetTile(int index)
        {
            return parent.getTile(index).getVisableBlock();
        }
    }
}
