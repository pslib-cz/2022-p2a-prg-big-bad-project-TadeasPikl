using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FloodGame
{
    internal class Grid
    {
        public GridTile[,] Tiles;
        private Random rand = new Random();

        public Grid(int width, int height, int colors)
        {
            Tiles = GenerateGrid(width, height, colors);
        }


        private GridTile[,] GenerateGrid(int width, int height, int colors)
        {
            GridTile[,] tiles = new GridTile[width, height];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    tiles[i,j] = new GridTile(i,j,rand.Next(colors));
                }
            }

            return tiles;
        }

        public bool IsFinished()
        {
            int color = Tiles[0, 0].colorId;
            foreach (GridTile tile in Tiles)
            {
                if (tile.colorId != color) return false;
            }
            return true;
        }

        public void FloodFill(int color)
        {
            int changingColor = Tiles[0, 0].colorId;
            Queue<GridTile> queue = new Queue<GridTile>();
            queue.Enqueue(Tiles[0,0]);

            while (queue.Count > 0)
            {
                GridTile n = queue.Dequeue();

                if (n.colorId == changingColor)
                {
                    n.colorId = color;
                    if (n.x+1 < Tiles.GetLength(0))  { queue.Enqueue(Tiles[n.x+1, n.y]); }
                    if (n.x-1 >= 0)                    { queue.Enqueue(Tiles[n.x-1, n.y]); }
                    if (n.y+1 < Tiles.GetLength(1))  { queue.Enqueue(Tiles[n.x, n.y+1]); }
                    if (n.y-1 >= 0)                    { queue.Enqueue(Tiles[n.x, n.y-1]); }
                }
            }
        }
    }
}
