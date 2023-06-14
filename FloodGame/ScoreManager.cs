using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodGame
{
    internal class ScoreManager
    {
        private List<SavedScore> Scores;
        private string SaveLocation;
        private string SaveDirectory;

        public ScoreManager(string saveDirectory)
        {
            Scores = new();
            SaveDirectory = saveDirectory;
            SaveLocation = saveDirectory + "/scores.🗿";

            if (!Directory.Exists(SaveDirectory))
            {
                Directory.CreateDirectory(SaveDirectory);
            }

            if (File.Exists(SaveLocation))
            {
                LoadScores();
            }
            else
            {
                File.Create(SaveLocation).Close();
            }
        }

        public void AddScore(string name, int moves, int width, int height, int colors)
        {
            Scores.Add(new SavedScore(name, moves, width, height, colors));
            SaveScores();
        }

        public void SaveScores()
        {
            File.Delete(SaveLocation);
            StreamWriter writer = new StreamWriter(SaveLocation);

            foreach (SavedScore score in Scores)
            {
                writer.WriteLine($"{score.Name};{score.Moves};{score.Width};{score.Height};{score.Colors}");
            }
            
            writer.Close();
        }

        public void LoadScores()
        {
            using (StreamReader sr = new StreamReader(SaveLocation))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] score = line.Split(";");
                    Scores.Add(new SavedScore(score[0], int.Parse(score[1]), int.Parse(score[2]), int.Parse(score[3]), int.Parse(score[4])));
                }
                sr.Close();
            }
        }

        public void PrintRelevantScores(int width, int height, int colors)
        {
            int i = 1;
            foreach (SavedScore score in Scores.Where(score => (score.Width == width && score.Height == height && score.Colors == colors)).OrderBy(score => score.Moves) )
            {
                Console.WriteLine($"{i}. {score}");
                i++;
            }
        }
    }
}
