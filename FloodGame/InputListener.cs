using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodGame
{
    internal class InputListener
    {
        public int[] GridSetup()
        {
            int[] gridValues = new int[3];
            List<string> answers;

            do
            {
                answers = Ask("Enter width and height(separated by ,): ");
                if (answers.Count < 2) { answers.Add(answers[0]); }
            } while (!int.TryParse(answers[0], out gridValues[0]) & !int.TryParse(answers[1], out gridValues[1]));
            do
            {
                answers = Ask("Enter number of colors(max 6): ");
            } while (!int.TryParse(answers[0], out gridValues[2]) && int.Parse(answers[0]) > 6 && int.Parse(answers[0]) < 2);

            return gridValues;
        }

        public static List<string> Ask(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine().Split(",").ToList();
        }

        public static string AskSingle(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
    }
}
