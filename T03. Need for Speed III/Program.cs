using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsBought = int.Parse(Console.ReadLine());

            Dictionary<string, List<int>> garage = new Dictionary<string, List<int>>();

            for (int i = 0; i < carsBought; i++)
            {
                string[] currentCar = Console.ReadLine().Split("|");

                string car = currentCar[0];
                int mileage = int.Parse(currentCar[1]);
                int fuel = int.Parse(currentCar[2]);

                garage.Add(car, new List<int>());
                garage[car].Add(mileage);
                garage[car].Add(fuel);
            }

            string[] actionWithCars = Console.ReadLine().Split(" : ");

            while (actionWithCars[0] != "Stop")
            {
                string mainCommand = actionWithCars[0];
                string currCar = actionWithCars[1];

                if (mainCommand == "Drive")
                {
                    int distance = int.Parse(actionWithCars[2]);
                    int fuel = int.Parse(actionWithCars[3]);

                    if (fuel > garage[currCar][1])
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else if (fuel <= garage[currCar][1])
                    {
                        garage[currCar][0] += distance;
                        garage[currCar][1] -= fuel;

                        Console.WriteLine($"{currCar} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }

                    if (garage[currCar][0] >= 100000)
                    {
                        garage.Remove(currCar);
                        Console.WriteLine($"Time to sell the {currCar}!");
                    }
                }
                else if (mainCommand == "Refuel")
                {
                    int fuel = int.Parse(actionWithCars[2]);

                    int currFuel = garage[currCar][1];

                    garage[currCar][1] += fuel;
                    if (garage[currCar][1] >= 75)
                    {
                        garage[currCar][1] = 75;

                        Console.WriteLine($"{currCar} refueled with {75 - currFuel} liters");
                    }
                    else
                    {
                        Console.WriteLine($"{currCar} refueled with {fuel} liters");
                    }
                }
                else if (mainCommand == "Revert")
                {
                    int mileage = int.Parse(actionWithCars[2]);

                    garage[currCar][0] -= mileage;
                    if (garage[currCar][0] < 10000)
                    {
                        garage[currCar][0] = 10000;
                    }
                    else
                    {
                        Console.WriteLine($"{currCar} mileage decreased by {mileage} kilometers");
                    }
                }

                actionWithCars = Console.ReadLine().Split(" : ");
            }

            garage = garage.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var car in garage)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value[0]} kms, Fuel in the tank: {car.Value[1]} lt.");
            }
        }
    }
}
