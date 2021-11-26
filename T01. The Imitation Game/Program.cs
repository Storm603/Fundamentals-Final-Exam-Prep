using System;
using System.Linq;
using System.Text;

namespace T01._The_Imitation_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder decrypting = new StringBuilder(Console.ReadLine());

            string[] messageEncrypted = Console.ReadLine().Split("|").ToArray();

            while (messageEncrypted[0] != "Decode")
            {
                string command = messageEncrypted[0];

                if (command == "Move")
                {
                    int numberOfLetters = int.Parse(messageEncrypted[1]); // 3 letters to move
                    string sub = decrypting.ToString(0, numberOfLetters);
                    decrypting.Append(sub);
                    decrypting.Remove(0, numberOfLetters);
                }
                else if (command == "Insert")
                {
                    int index = int.Parse(messageEncrypted[1]);
                    string value = messageEncrypted[2];
                    decrypting.Insert(index, value);
                }
                else if (command == "ChangeAll")
                {
                    string substring = messageEncrypted[1];
                    string replacement = messageEncrypted[2];
                    decrypting.Replace(substring, replacement);
                }
                messageEncrypted = Console.ReadLine().Split("|").ToArray();
            }
            Console.WriteLine($"The decrypted message is: {decrypting}");
        }
    }
}
