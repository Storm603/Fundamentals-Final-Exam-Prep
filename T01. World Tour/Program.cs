using System;
using System.Text;

namespace T01._World_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder desinations = new StringBuilder(Console.ReadLine());

            string[] command = Console.ReadLine().Split(":");

            while (command[0] != "Travel")
            {
                string action = command[0];

                if (action == "Add Stop")
                {
                    int index = int.Parse(command[1]);
                    string substring = command[2];

                    if (desinations.Length > index && index >= 0)
                    {
                        desinations.Insert(index, substring);
                    }
                    Console.WriteLine(desinations);
                }
                else if (action == "Remove Stop")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);

                    int length = (endIndex+1) - startIndex;

                    if (startIndex >= 0 && startIndex < desinations.Length)
                    {
                        if (endIndex >= 0 && endIndex < desinations.Length)
                        {
                            desinations.Remove(startIndex, length);
                        }
                    }
                    Console.WriteLine(desinations);
                }
                else if (action == "Switch")
                {
                    string oldSubstring = command[1];
                    string newSubstring = command[2];

                    string container = desinations.ToString();

                    if (container.Contains(oldSubstring))
                    {
                        desinations.Replace(oldSubstring, newSubstring);
                    }
                    Console.WriteLine(desinations);
                }
                command = Console.ReadLine().Split(":");
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {desinations}");

        }
    }
}
