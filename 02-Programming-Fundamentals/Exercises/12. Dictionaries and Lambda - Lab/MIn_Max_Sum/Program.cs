using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            int addToList = int.Parse(Console.ReadLine());
            numbers.Add(addToList);
        }

        Console.WriteLine("Sum = {0}", numbers.Sum());
        Console.WriteLine("Min = {0}", numbers.Min());
        Console.WriteLine("Max = {0}", numbers.Max());
        Console.WriteLine("Average = {0}", numbers.Average());
    }
}
