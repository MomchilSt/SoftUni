using System;
using System.Collections.Generic;
using System.Linq;

class SetsOfElements
{
    static void Main()
    {
        int[] sizes = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        int firstSize = sizes[0];
        int secondSize = sizes[1];

        HashSet<int> firstSet = new HashSet<int>();

        for (int i = 0; i < firstSize; i++)
        {
            int input = int.Parse(Console.ReadLine());

            firstSet.Add(input);
        }

        HashSet<int> secondSet = new HashSet<int>();

        for (int i = 0; i < secondSize; i++)
        {
            int input = int.Parse(Console.ReadLine());

            secondSet.Add(input);
        }

        HashSet<int> result = new HashSet<int>();

        foreach (var num in firstSet)
        {
            if (secondSet.Contains(num))
            {
                result.Add(num);
            }
        }

        Console.WriteLine(string.Join(" ", result));
    }
}