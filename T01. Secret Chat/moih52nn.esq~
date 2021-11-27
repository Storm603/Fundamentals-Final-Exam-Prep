using System;
using System.Linq;
using System.Text;

namespace T01._Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string concealedMessage = Console.ReadLine();

            string[] action = Console.ReadLine().Split(":|:");

            StringBuilder message = new StringBuilder(concealedMessage);

            while (action[0] != "Reveal")
            {
                string operation = action[0];

                if (operation == "InsertSpace")
                {
                    int index = int.Parse(action[1]);
                    message.Insert(index, " ");
                    Console.WriteLine(message);
                }
                else if (operation == "Reverse")
                {
                    string substring = action[1];
                    if (concealedMessage.Contains(substring))
                    {
                        int index = concealedMessage.IndexOf(substring);
                        message.Remove(index, substring.Length);
                        char[] reversed = substring.Reverse().ToArray();
                        string reversedWord = String.Join("", reversed);
                        message.Append(reversedWord);

                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }

                }
                else if (operation == "ChangeAll")
                {
                    string letterOne = action[1];
                    string letterTwo = action[2];

                    message.Replace(letterOne, letterTwo);
                    
                    Console.WriteLine(message);
                }

                concealedMessage = message.ToString();
                action = Console.ReadLine().Split(":|:");
            }
            Console.WriteLine($"You have a new text message: {message}");

        }
    }
}
