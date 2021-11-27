using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Т02._Mirrorr_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex template = new Regex(@"(?<symbol>[\@\#])(?<word>[A-Za-z]{3,})\1{2}(?<wordTwo>[A-Za-z]{3,})\1");

            string input = Console.ReadLine();

            Dictionary<int, List<string>> mirrorWords = new Dictionary<int, List<string>>();

            MatchCollection mirrorCheck = template.Matches(input);

            int count = 0;

            int totalPairCount = 0;

            for (int i = 0; i < mirrorCheck.Count; i++)
            {
                totalPairCount++;

                string wordOne = mirrorCheck[i].Groups["word"].Value;
                string secondWord = mirrorCheck[i].Groups["wordTwo"].Value;

                string wordTwo = String.Empty;

                for (int j = secondWord.Length - 1; j >= 0; j--)
                {
                    wordTwo += secondWord[j];
                }

                if (wordOne == wordTwo)
                {
                    mirrorWords.Add(count, new List<string>());
                    mirrorWords[count].Add(wordOne);
                    mirrorWords[count].Add(secondWord);
                    count++;
                }
            }

            Console.WriteLine($"{totalPairCount} word pairs found!");

            if (mirrorWords.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine($"The mirror words are:");
                for (int i = 0; i < mirrorWords.Count; i++)
                {
                    if (i == mirrorWords.Count - 1)
                    {
                        Console.Write($"{mirrorWords[i][0]} <=> {mirrorWords[i][1]}");
                    }
                    else
                    {
                        Console.Write($"{mirrorWords[i][0]} <=> {mirrorWords[i][1]}, ");
                    }
                }
            }
        }
    }
}
