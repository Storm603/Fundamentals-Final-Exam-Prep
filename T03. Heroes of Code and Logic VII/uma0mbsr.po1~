using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace T03._Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> heroParty = new Dictionary<string, List<int>>();

            int heroAddCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < heroAddCount; i++)
            {
                string[] hero = Console.ReadLine().Split();

                string heroName = hero[0];
                int health = int.Parse(hero[1]);
                int mana = int.Parse(hero[2]);

                heroParty.Add(heroName, new List<int>());
                heroParty[heroName].Add(health);
                heroParty[heroName].Add(mana);
            }

            string[] command = Console.ReadLine().Split(" - ");

            while (command[0] != "End")
            {
                string action = command[0];
                string heroName = command[1];

                if (action == "CastSpell")
                {
                    int spellCost = int.Parse(command[2]);
                    string spellName = command[3];

                    if (heroParty[heroName][1] >= spellCost)
                    {
                        heroParty[heroName][1] -= spellCost;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroParty[heroName][1]} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (action == "TakeDamage")  // name - hp - mp
                {
                    int damage = int.Parse(command[2]);
                    string attackerName = command[3];

                    heroParty[heroName][0] -= damage;

                    if (heroParty[heroName][0] <= 0)
                    {
                        Console.WriteLine($"{heroName} has been killed by {attackerName}!");
                        heroParty.Remove(heroName);
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attackerName} and now has {heroParty[heroName][0]} HP left!");
                    }
                }
                else if (action == "Recharge")
                {
                    int rechargeAmount = int.Parse(command[2]);

                    int rchrgAbove200 = 200 - heroParty[heroName][1];

                    heroParty[heroName][1] += rechargeAmount;

                    if (heroParty[heroName][1] > 200)
                    {
                        heroParty[heroName][1] = 200;
                        Console.WriteLine($"{heroName} recharged for {rchrgAbove200} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} recharged for {rechargeAmount} MP!");
                    }
                }
                else if (action == "Heal")
                {
                    int healAmount = int.Parse(command[2]);

                    int healAbove100 = 100 - heroParty[heroName][0];

                    heroParty[heroName][0] += healAmount;

                    if (heroParty[heroName][0] > 100)
                    {
                        heroParty[heroName][0] = 100;
                        Console.WriteLine($"{heroName} healed for {healAbove100} HP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} healed for {healAmount} HP!");
                    }
                }
                command = Console.ReadLine().Split(" - ");
            }

            heroParty = heroParty.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (KeyValuePair<string, List<int>> hero in heroParty)
            {
                Console.WriteLine(hero.Key);
                Console.WriteLine($"  HP: {hero.Value[0]}");
                Console.WriteLine($"  MP: {hero.Value[1]}");
            }
        }
    }
}
