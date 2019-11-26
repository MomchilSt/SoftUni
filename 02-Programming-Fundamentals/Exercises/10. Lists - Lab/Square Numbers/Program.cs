using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        List<int> result = new List<int>();

        for (int i = 0; i < numbers.Count; i++)
        {
            if (Math.Sqrt(numbers[i]) == (int)Math.Sqrt(numbers[i]))
            {
                result.Add(numbers[i]);
            }
        }
        result.Sort((a,b) => b.CompareTo(a));
        Console.WriteLine(string.Join(" ", result));
    }
}
