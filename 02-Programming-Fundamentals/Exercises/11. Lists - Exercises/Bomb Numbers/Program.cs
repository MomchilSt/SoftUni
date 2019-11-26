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

        int[] manipulations = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        while (numbers.Contains(manipulations[0]))
        {       // manipulations[0] = the bomb
            int bombPlace = numbers.IndexOf(manipulations[0]); // index off the bomb
            // manipulations[1] = count of neighbors that will explode
            for (int i = 0; i < manipulations[1]; i++)
            {
                if (bombPlace + 1 < numbers.Count)
                {
                    numbers.RemoveAt(bombPlace + 1);
                }
                if (bombPlace - 1 >= 0)
                {
                    numbers.RemoveAt(bombPlace - 1);
                    bombPlace--;
                }       
            }
            numbers.RemoveAt(bombPlace);
        }
        Console.WriteLine(numbers.Sum());
    }
}
