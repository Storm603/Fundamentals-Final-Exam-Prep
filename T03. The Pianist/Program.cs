using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._The_Pianist
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> pieceCollection = new Dictionary<string, List<string>>();

            int numberOfPieces = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPieces; i++)
            {
                string[] pieceInformation = Console.ReadLine().Split("|");

                string piece = pieceInformation[0];
                string composer = pieceInformation[1];
                string key = pieceInformation[2];

                pieceCollection.Add(piece, new List<string>());
                pieceCollection[piece].Add(composer);
                pieceCollection[piece].Add(key);
            }

            string[] command = Console.ReadLine().Split("|");

            while (command[0] != "Stop")
            {

                string action = command[0];
                string piece = command[1];

                if (action == "Add")
                {
                    string composer = command[2];
                    string key = command[3];

                    if (!pieceCollection.ContainsKey(piece))
                    {
                        pieceCollection.Add(piece, new List<string>());
                        pieceCollection[piece].Add(composer);
                        pieceCollection[piece].Add(key);
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                }
                else if (action == "Remove")
                {
                    if (pieceCollection.ContainsKey(piece))
                    {
                        pieceCollection.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else if (action == "ChangeKey")
                {
                    string newKey = command[2];

                    if (pieceCollection.ContainsKey(piece))
                    {
                        pieceCollection[piece][1] = newKey;
                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }

                command = Console.ReadLine().Split("|");
            }

            pieceCollection = pieceCollection.OrderBy(x => x.Key).ThenBy(x => x.Value[0]).ToDictionary(x => x.Key, x => x.Value);

            foreach (var piece in pieceCollection)
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value[0]}, Key: {piece.Value[1]}");
            }
        }
    }
}
