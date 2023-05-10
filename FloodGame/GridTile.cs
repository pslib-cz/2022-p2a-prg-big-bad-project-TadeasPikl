using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodGame
{
    internal class GridTile
    {
        public int x;
        public int y;

        public int colorId;

        public GridTile(int x, int y, int colorId)
        {
            this.x = x;
            this.y = y;
            this.colorId = colorId;
        }
        
    }
}
