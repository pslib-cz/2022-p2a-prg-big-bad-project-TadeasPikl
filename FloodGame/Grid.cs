using System;
using System.Collections.Generic;
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

        public void FloodFill(int colorId)
        {

        }
    }
}
