using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // dict in dict
        Dictionary<string, List<decimal>> Database = new Dictionary<string, List<decimal>>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "stocked")
            {
                break;
            }
            string[] tokens = input.Split();
            string product = tokens[0];
            decimal price = decimal.Parse(tokens[1]);
            int quantity = int.Parse(tokens[2]);

            if (Database.ContainsKey(product) == false)
            {
                Database.Add(product, new List<decimal>());
                Database[product].Add(price);
                Database[product].Add(quantity);
                continue;
            }
            else
            {
                Database[product][1] += quantity;
                Database[product][0] = price;
            }
        }

        decimal grandTotal = 0;

        foreach (var product in Database)
        {
            decimal currentSum = product.Value[0] * product.Value[1];
            grandTotal += currentSum;

            decimal currentPrice = product.Value[0] * 1.0m;
            decimal currentQuantity = product.Value[1] * 1;

            Console.WriteLine($"{product.Key}: ${currentPrice:f2} * {currentQuantity} = ${currentSum:f2}");
        }
        Console.WriteLine("------------------------------");
        Console.WriteLine($"Grand Total: ${grandTotal:f2}");
    }
}