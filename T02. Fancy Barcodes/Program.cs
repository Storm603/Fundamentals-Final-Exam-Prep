using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace T02._Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {

            Regex template = new Regex(@"^@[#]+(?<word>[A-Z][A-Za-z0-9]{4,}[A-Z])@[#]+$");

            int numberOfBarcodes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfBarcodes; i++)
            {
                string currBarcode = Console.ReadLine();
                Match validate = template.Match(currBarcode);

                if (validate.Success)
                {
                    string productGroup = String.Empty;

                    foreach (char character in currBarcode)
                    {
                        if (character >= 48 && character <= 57)
                        {
                            productGroup += int.Parse(character.ToString());
                        }
                    }

                    if (productGroup == String.Empty)
                    {
                        Console.WriteLine("Product group: 00");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: {productGroup}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
