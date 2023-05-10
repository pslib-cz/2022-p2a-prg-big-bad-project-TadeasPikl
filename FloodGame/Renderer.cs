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
        private int cursorX;
        private int cursorY;
        private Dictionary<int, ConsoleColor> colors;
        private Dictionary<ConsoleColor, ConsoleColor> contrastColors;


        public Renderer()
        {
            cursorX = 0;
            cursorY = 0;

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


        public void PrintTile(GridTile tile)
        {
            Console.BackgroundColor = colors[tile.colorId];
            if (tile.x == cursorX && tile.y == cursorY)
            {
                Console.ForegroundColor = contrastColors[Console.BackgroundColor];
                Console.Write("O");
            }
            else { Console.Write(" "); }
        }

        public void PrintGrid(Grid grid)
        {
            for (int i = 0; i < grid.Tiles.GetLength(0); i++)
            {
                for (int j = 0; j < grid.Tiles.GetLength(1); j++)
                {
                    PrintTile(grid.Tiles[i, j]);
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = default;
            Console.ForegroundColor = default;
        }
    }
}
