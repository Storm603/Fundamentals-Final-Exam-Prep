using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace T02._Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {

            Regex template = new Regex(@"(::|\*\*)(?<emoji>[A-Z][a-z]{2,})\1");
            Regex numberFinder = new Regex(@"\d");

            string input = Console.ReadLine();

            MatchCollection emojiCollection = template.Matches(input);

            MatchCollection validatedNumbers = numberFinder.Matches(input);

            long coolThreshhold = 1;

            foreach (Match symbol in validatedNumbers)
            {
                coolThreshhold *= int.Parse(symbol.ToString());
            }

            Console.WriteLine($"Cool threshold: {coolThreshhold}");
            Console.WriteLine($"{emojiCollection.Count} emojis found in the text. The cool ones are:");

            foreach (Match emoji in emojiCollection)
            {
                string emojiVal = emoji.Groups["emoji"].Value;
                long asciiSum = 0;

                foreach (char letter in emojiVal)
                {
                    asciiSum += letter;
                }

                if (asciiSum >= coolThreshhold)
                {
                    Console.WriteLine(emoji);
                }
            }
        }
    }
}