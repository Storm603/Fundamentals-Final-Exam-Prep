using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace T03._P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> cityTarget = new Dictionary<string, List<int>>();

            string[] planning = Console.ReadLine().Split("||");

            while (planning[0] != "Sail")
            {
                string cityName = planning[0];
                int population = int.Parse(planning[1]);
                int gold = int.Parse(planning[2]);

                if (!cityTarget.ContainsKey(cityName))
                {
                    cityTarget.Add(cityName, new List<int>());
                    cityTarget[cityName].Add(population);
                    cityTarget[cityName].Add(gold);
                }
                else
                {
                    cityTarget[cityName][0] += population;
                    cityTarget[cityName][1] += gold;
                }
                planning = Console.ReadLine().Split("||");
            }

            string[] movement = Console.ReadLine().Split("=>");

            while (movement[0] != "End")
            {
                string action = movement[0];
                string cityName = movement[1];

                if (action == "Plunder")
                {
                    int peopleKilled = int.Parse(movement[2]);
                    int goldPlundered = int.Parse(movement[3]);

                    Console.WriteLine($"{cityName} plundered! {goldPlundered} gold stolen, {peopleKilled} citizens killed.");
                    
                    cityTarget[cityName][0] -= peopleKilled;
                    cityTarget[cityName][1] -= goldPlundered;
                    
                    if (cityTarget[cityName][0] == 0 || cityTarget[cityName][1] == 0)
                    {
                        Console.WriteLine($"{cityName} has been wiped off the map!");
                        cityTarget.Remove(cityName);
                    }
                }
                else if (action == "Prosper")
                {
                    int goldGrowth = int.Parse(movement[2]);

                    if (goldGrowth > 0)
                    {
                        cityTarget[cityName][1] += goldGrowth;
                        Console.WriteLine($"{goldGrowth} gold added to the city treasury. {cityName} now has {cityTarget[cityName][1]} gold.");
                    }
                    else
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                }
                movement = Console.ReadLine().Split("=>");
            }

            cityTarget = cityTarget.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            if (cityTarget.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cityTarget.Count} wealthy settlements to go to:");

                foreach (KeyValuePair<string, List<int>> city in cityTarget)
                {
                    Console.WriteLine($"{city.Key} -> Population: {city.Value[0]} citizens, Gold: {city.Value[1]} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
