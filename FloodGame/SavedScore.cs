using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodGame
{
    internal class SavedScore
    {
        public string Name;
        public int Moves;
        public int Height;
        public int Width;
        public int Colors;

        public SavedScore(string name, int moves, int width, int height, int colors)
        {
            Name = name;
            Moves = moves;
            Width = width;
            Height = height;
            Colors = colors;
        }

        public override string ToString()
        {
            return $"Moves: {Moves}, Name: {Name}";
        }
    }
}
