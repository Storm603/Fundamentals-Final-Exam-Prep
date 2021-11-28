using System;
using System.Linq;
using System.Text;

namespace T01._Password_Reset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string[] command = Console.ReadLine().Split();

            StringBuilder modifiedPassword = new StringBuilder(password);

            while (command[0] != "Done")
            {
                string action = command[0];

                if (action == "TakeOdd")
                {
                    string newPass = String.Empty;

                    for (int i = 0; i < modifiedPassword.Length; i++)
                    {
                        if (i % 2 == 1)
                        {
                            newPass += modifiedPassword[i];
                        }
                    }

                    modifiedPassword = new StringBuilder(newPass);
                    Console.WriteLine(modifiedPassword);
                }
                else if (action == "Cut")
                {
                    int index = int.Parse(command[1]);
                    int length = int.Parse(command[2]);

                    modifiedPassword.Remove(index, length);

                    Console.WriteLine(modifiedPassword);

                }
                else if (action == "Substitute")
                {
                    string substring = command[1];
                    string substitute = command[2];

                    if (modifiedPassword.ToString().Contains(substring))
                    {
                        modifiedPassword.Replace(substring, substitute);
                        Console.WriteLine(modifiedPassword);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine($"Your password is: {modifiedPassword}");
        }
    }
}
