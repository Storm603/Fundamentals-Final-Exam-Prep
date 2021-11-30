using System;
using System.Text;

namespace T01._Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {

            StringBuilder rawActivationKey = new StringBuilder(Console.ReadLine());

            string[] operation = Console.ReadLine().Split(">>>");

            while (operation[0] != "Generate")
            {
                string command = operation[0];

                if (command == "Contains")
                {
                    string substring = operation[1];

                    if (rawActivationKey.ToString().Contains(substring))
                    {
                        Console.WriteLine($"{rawActivationKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine($"Substring not found!");
                    }
                }
                else if (command == "Flip")
                {
                    string caseOption = operation[1];
                    int startIndex = int.Parse(operation[2]);
                    int endIndex = int.Parse(operation[3]);

                    if (caseOption == "Upper")
                    {
                        string upperReplacement = String.Empty;
                        for (int i = startIndex; i < endIndex; i++)
                        {
                            upperReplacement += rawActivationKey[i];
                        }

                        rawActivationKey.Replace(upperReplacement, upperReplacement.ToUpper());
                    }
                    else if (caseOption == "Lower")
                    {
                        string lowerReplacement = String.Empty;
                        for (int i = startIndex; i < endIndex; i++)
                        {
                            lowerReplacement += rawActivationKey[i];
                        }

                        rawActivationKey.Replace(lowerReplacement, lowerReplacement.ToLower());
                    }

                    Console.WriteLine(rawActivationKey);
                }
                else if (command == "Slice")
                {
                    int startIndex = int.Parse(operation[1]);
                    int endIndex = int.Parse(operation[2]);

                    int length = endIndex - startIndex;

                    rawActivationKey.Remove(startIndex, length);
                    Console.WriteLine(rawActivationKey);
                }
                operation = Console.ReadLine().Split(">>>");
            }

            Console.WriteLine($"Your activation key is: {rawActivationKey}");

        }
    }
}
