using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<double> numbers = Console.ReadLine()
            .Split()
            .Select(double.Parse)
            .ToList();

        var counts = new SortedDictionary<double, int>();

        foreach (var num in numbers)
        {
            if (counts.ContainsKey(num))
            {
                counts[num]++;
            }
            else
            {
                counts[num] = 1;
            }
        }

        foreach (var key in counts.Keys)
        {
            Console.WriteLine($"{key} -> {counts[key]}");
        }
    }
}
