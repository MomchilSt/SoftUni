using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // array of products
        // array of quantity long
        // array of prices double or decimal

        string[] products = Console.ReadLine()
            .Split();

        long[] quantityInput = Console.ReadLine()
        .Split()
        .Select(long.Parse)
        .ToArray();

        decimal[] prices = Console.ReadLine()
            .Split()
            .Select(decimal.Parse)
            .ToArray();

        long[] quantity = new long[products.Length];

        for (int i = 0; i < quantityInput.Length; i++)
        {
            quantity[i] = quantityInput[i];
        }

        while (true)
        {
            string[] checkIn = Console.ReadLine()
                .Split();

            if (checkIn[0] == "done")
            {
                break;
            }

            var product = checkIn[0];
            var quantityOrder = long.Parse(checkIn[1]);

            int position = Array.IndexOf(products, product);

                if (quantity[position] >= quantityOrder)
                {
                    Console.WriteLine($"{product} x {quantityOrder} costs {(quantityOrder * prices[position]):f2}");

                quantity[position] = quantity[position] - quantityOrder;
                }
            else
            {
                Console.WriteLine($"We do not have enough {product}");
            }

        }
    }
}