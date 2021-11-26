using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace T02._Destination_Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex template = new Regex(@"([\=\/])(?<name>[A-Z][A-Za-z]{2,})\1");

            string locations = Console.ReadLine();

            MatchCollection validatedLocations = template.Matches(locations);
            Console.Write("Destinations: ");

            int travelPoints = 0;
            int count = 0;

            foreach (Match location in validatedLocations)
            {
                string local = location.Groups["name"].Value;
                count++;

                travelPoints += local.Length;

                if (count == validatedLocations.Count)
                {
                    Console.Write($"{local}");
                }
                else
                {
                    Console.Write($"{local}, ");
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
