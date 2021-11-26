using System;
using System.Collections.Generic;
using System.Linq;

namespace Т03._Plant_Discovery
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());

            Dictionary<string, double> plants = new Dictionary<string, double>();  // name - rarity 
            Dictionary<string, List<double>> averageRating = new Dictionary<string, List<double>>(); // name - rating

            for (int i = 0; i < number; i++)
            {
                string[] info = Console.ReadLine().Split("<->");

                string plantName = info[0];
                double plantRarity = double.Parse(info[1]);

                int plantRating = 0;

                if (!plants.ContainsKey(plantName))
                {
                    plants.Add(plantName, plantRarity);

                    averageRating.Add(plantName, new List<double>());
                    averageRating[plantName].Add(plantRating);
                }
                else if(plants.ContainsKey(info[0]))
                {
                    plants[plantName] = plantRarity;
                }
                
            }

            string[] command = Console.ReadLine().Split(" - ").ToArray();
            string[] splitCmd1 = command[0].Split(": ").ToArray();

            while (splitCmd1[0] != "Exhibition")
            {
                string action = splitCmd1[0];
                string plant = splitCmd1[1];

                if (!plants.ContainsKey(plant)) // removed  || !averageRating.ContainsKey(plant)
                {
                    Console.WriteLine("error");
                }
                else if (action == "Rate")
                {
                    double rating = double.Parse(command[1]);
                    averageRating[plant].Add(rating);
                }
                else if (action == "Update")
                {
                    double plantRarity = double.Parse(command[1]);
                    plants[plant] = plantRarity;
                }
                else if (action == "Reset")
                {
                    averageRating[plant].Clear();
                    averageRating[plant].Add(0);
                }

                command = Console.ReadLine().Split(" - ").ToArray(); 
                splitCmd1 = command[0].Split(": ").ToArray();
            }

            Dictionary<string, List<double>> final = new Dictionary<string, List<double>>(); // name - rarity - rating

            foreach (var rate in averageRating)
            {
                string plantName = rate.Key;
                double rarity = plants[plantName];

                if (rate.Value.Count == 1 && rate.Value.Contains(0))
                {
                    final.Add(plantName, new List<double>());
                    final[plantName].Add(rarity);
                    final[plantName].Add(0);
                }
                else
                {
                    rate.Value.Remove(0);
                    //double average = rate.Value.Average();
                    final.Add(plantName, new List<double>());
                    final[plantName].Add(rarity);
                    final[plantName].Add(rate.Value.Average());
                }
            }

            final = final.OrderByDescending(x => x.Value[0]).ThenByDescending(x => x.Value[1]).ToDictionary(x => x.Key, x=> x.Value);

            Console.WriteLine("Plants for the exhibition:");

            foreach (var plant in final)
            {
                Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value[0]}; Rating: {plant.Value[1]:f2}");
            }
        }
    }
}
