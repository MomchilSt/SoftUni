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

        long[] quantity = Console.ReadLine()
        .Split()
        .Select(long.Parse)
        .ToArray();

        decimal[] prices = Console.ReadLine()
            .Split()
            .Select(decimal.Parse)
            .ToArray();

        while (true)
        {
            string checkIn = Console.ReadLine();
            if (checkIn == "done")
            {
                break;
            }

            int position = Array.IndexOf(products, checkIn);

            Console.Write($"{products[position]} costs: {prices[position]}; ");
            Console.WriteLine($"Available quantity: {quantity[position]}");
        }
    }
}