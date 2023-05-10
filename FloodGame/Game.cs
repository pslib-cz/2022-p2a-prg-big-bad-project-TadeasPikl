using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodGame
{
    internal class Game
    {
        public Grid grid;
        public Renderer renderer;

        public Game()
        {
            this.renderer = new Renderer();
        }

        public void NewGrid(int width, int height, int colors)
        {
            this.grid = new Grid(width, height, colors);
        }
        public void NewGrid(int width, int colors)
        {
            this.grid = new Grid(width, width, colors);
        }


        public void PrintGrid()
        {
            renderer.PrintGrid(grid);
        }
    }
}
