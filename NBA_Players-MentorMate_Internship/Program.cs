
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NBA_Players_MentorMate_Internship
{
    class Program
    {
        public static List<NBAPlayer> LoadJsonFile()
        {
            Console.WriteLine("Please insert a path to the Json file: ");
            var filePath = Console.ReadLine();

            if (filePath.EndsWith(".json"))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string json = reader.ReadToEnd();

                        List<NBAPlayer> players = JsonConvert.DeserializeObject<List<NBAPlayer>>(json);
                        return players;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("That's not a valid path");
                    return LoadJsonFile();
                }
            }
            else
            {
                Console.WriteLine("That isn't a Json File");
                return LoadJsonFile();
            }
        }

        private static int InputIntValidator(string input)
        {
            int value = -1;
            if (int.TryParse(input, out value))
            {
                if (value < 0)
                {
                    Console.WriteLine("Please input a valid Positive Integer");
                    return InputIntValidator(Console.ReadLine());
                }

                return value;
            }
            else
            {
                Console.WriteLine("That is not a valid Integer!!!");
                return InputIntValidator(Console.ReadLine());
            }
        }

        private static void GiveReport(List<NBAPlayer> players, int maxParticipationYears, int minimumRating)
        {
            Console.WriteLine("Please insert a path where to leave the report: ");
            string filePath = Console.ReadLine();

            if (filePath.EndsWith('\\'))
            {
                filePath += "Report.csv";

                using (var stream = File.CreateText(filePath))
                {
                    stream.WriteLine("Name,Rating");

                    foreach (var player in players.Where(x => x.Rating >= minimumRating).Where(x => x.YearsPlaying < maxParticipationYears))
                    {
                        stream.WriteLine($"{player.Name.ToString()},{player.Rating.ToString()}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Please give a valid Directory");
                GiveReport(players, maxParticipationYears, minimumRating);
            }

        }
        static void Main(string[] args)
        {
            var players = LoadJsonFile();
            Console.WriteLine("Please insert the maximum number of years a player can participate: ");
            var maxParticipationYears = InputIntValidator(Console.ReadLine());
            Console.WriteLine("Please insert the minimum rating required: ");
            var minimumRating = InputIntValidator(Console.ReadLine());
            GiveReport(players, maxParticipationYears, minimumRating);
        }

    }
}
