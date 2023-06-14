using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FloodGame
{
    internal class Game
    {
        private Grid grid;
        private Renderer renderer;
        private InputListener input;
        private ScoreManager scoreManager;

        private int[] cursorLocation;

        private int[] gridParams;

        private int moves;

        public Game()
        {
            renderer = new Renderer();
            input = new InputListener();
            scoreManager = new ScoreManager(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/FloodGameTG");
            cursorLocation = new int[2] {0, 0};
            moves = 0;
        }

        public void NewGrid(int width, int height, int colors)
        {
            this.grid = new Grid(width, height, colors);
        }

        public void PrintGrid(bool showMoves = true)
        {
            renderer.PrintGrid(grid, cursorLocation);
            if (showMoves) { Console.WriteLine($"Moves: {moves}"); }
        }

        private void MoveCursor(int dimension, int value)
        {
            if (cursorLocation[dimension] + value >= 0 && cursorLocation[dimension] + value < gridParams[dimension]) { cursorLocation[dimension] += value; }
        }

        private void FloodFill()
        {
            if (grid.Tiles[cursorLocation[0], cursorLocation[1]].colorId != grid.Tiles[0, 0].colorId)
            {
                grid.FloodFill(grid.Tiles[cursorLocation[0], cursorLocation[1]].colorId);
                moves++;
            }
        }

        public void StartGame()
        {
            gridParams = input.GridSetup();
            while (true)
            {
                NewGrid(gridParams[0], gridParams[1], gridParams[2]);
                cursorLocation = new int[] { 0, 0 };

                while (!grid.IsFinished())
                {
                    PrintGrid();

                    ConsoleKeyInfo key = Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.DownArrow: MoveCursor(0, 1); break;
                        case ConsoleKey.UpArrow: MoveCursor(0, -1); break;
                        case ConsoleKey.RightArrow: MoveCursor(1, 1); break;
                        case ConsoleKey.LeftArrow: MoveCursor(1, -1); break;
                        case ConsoleKey.Spacebar:
                        case ConsoleKey.Enter: FloodFill(); break;
                        case ConsoleKey.Escape: Environment.Exit(0); break;
                        default: break;
                    }
                }

                PrintGrid(false);
                Console.WriteLine($"Board finished with {moves} moves!");
                
                string name = InputListener.AskSingle("Enter name:");
                scoreManager.AddScore(name, moves, gridParams[0], gridParams[1], gridParams[2]);

                scoreManager.PrintRelevantScores(gridParams[0], gridParams[1], gridParams[2]);


                Console.ReadKey();
            }
        }


    }
}
