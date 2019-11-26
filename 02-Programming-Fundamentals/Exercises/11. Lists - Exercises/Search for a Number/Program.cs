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

        int[]  manipulationDigits = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        List<int> result = new List<int>(manipulationDigits[0]);

        for (int i = 0; i < manipulationDigits[0]; i++)
        {
            result.Add(numbers[i]);
        }

        for (int i = 0; i < manipulationDigits[1]; i++)
        {
            result.RemoveAt(0);
        }


        if (result.Contains(manipulationDigits[2]))
        {
            Console.WriteLine("YES!");
        }
        else
        {
            Console.WriteLine("NO!");
        }
    }
}
