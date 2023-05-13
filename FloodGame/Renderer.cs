using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodGame
{
    internal class Renderer
    {
        private Dictionary<int, ConsoleColor> colors;
        private Dictionary<ConsoleColor, ConsoleColor> contrastColors;


        public Renderer()
        {
            colors = new Dictionary<int, ConsoleColor>()
            {
                {0, ConsoleColor.Red },
                {1, ConsoleColor.Green},
                {2, ConsoleColor.Blue},
                {3, ConsoleColor.Cyan},
                {4, ConsoleColor.Magenta},
                {5, ConsoleColor.Yellow}
            };

            contrastColors = new Dictionary<ConsoleColor, ConsoleColor>()
            {
                {ConsoleColor.Red, ConsoleColor.White},
                {ConsoleColor.Green, ConsoleColor.Black},
                {ConsoleColor.Blue, ConsoleColor.White},
                {ConsoleColor.Cyan, ConsoleColor.Black},
                {ConsoleColor.Magenta, ConsoleColor.White},
                {ConsoleColor.Yellow, ConsoleColor.Black}
            };
        }


        private void PrintTile(GridTile tile, int[] cursorLocation)
        {
            Console.BackgroundColor = colors[tile.colorId];
            if (tile.x == cursorLocation[0] && tile.y == cursorLocation[1])
            {
                Console.ForegroundColor = contrastColors[Console.BackgroundColor];
                Console.Write("[]");
            }
            else
            {
                Console.ForegroundColor = colors[tile.colorId];
                Console.Write("..");
            }
        }

        public void PrintGrid(Grid grid, int[] cursorLocation)
        {
            Console.Clear();
            for (int i = 0; i < grid.Tiles.GetLength(0); i++)
            {
                for (int j = 0; j < grid.Tiles.GetLength(1); j++)
                {
                    PrintTile(grid.Tiles[i, j], cursorLocation);
                }
                LineEnd();
                Console.WriteLine();
            }
        }

        private void LineEnd()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(".");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
