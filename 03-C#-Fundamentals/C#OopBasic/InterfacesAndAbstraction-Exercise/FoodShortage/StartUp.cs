using FoodShortage.Interfaces;
using FoodShortage.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main()
        {
            List<IBuyer> collection = new List<IBuyer>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var tokens = input.Split();

                if (tokens.Length == 3)
                {
                    collection.Add(new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]));
                }
                else if (tokens.Length == 4)
                {
                    collection.Add(new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]));
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                var currBuyer = collection.FirstOrDefault(x => x.Name == input);

                if (currBuyer != null)
                {
                    currBuyer.BuyFood();
                }
            }

            int result = 0;
            result += collection.Select(x => x.Food).Sum();

            Console.WriteLine(result);
        }
    }
}
