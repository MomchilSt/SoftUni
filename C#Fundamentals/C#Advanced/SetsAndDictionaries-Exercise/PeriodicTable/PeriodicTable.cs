using System;
using System.Collections.Generic;

class PeriodicTable
{
    static void Main()
    {
        SortedSet<string> periodicTable = new SortedSet<string>();

        int n = int.Parse(Console.ReadLine());

        for (int m1 = 0; m1 < n; m1++)
        {
            string[] input = Console.ReadLine().Split();

            for (int m2 = 0; m2 < input.Length; m2++)
            {
                periodicTable.Add(input[m2]);
            }
        }

        Console.WriteLine(string.Join(" ", periodicTable));
    }
}