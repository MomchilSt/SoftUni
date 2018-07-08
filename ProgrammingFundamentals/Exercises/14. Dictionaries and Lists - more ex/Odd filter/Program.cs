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

        numbers.RemoveAll(x => x % 2 != 0);
        int average = (int)numbers.Average();

        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] > average)
            {
                numbers[i]++;
            }
            if (numbers[i] <= average)
            {
                numbers[i]--;
            }
        }

        Console.WriteLine(string.Join(" ", numbers));
    }
}
