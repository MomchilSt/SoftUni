using System;
using System.Collections.Generic;
using System.Linq;

class SortEvenNumbers
{
    static void Main()
    {
        List<int> list = Console.ReadLine()
            .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .Where(n => n % 2 == 0)
            .OrderBy(n => n)
            .ToList();

        Console.WriteLine(string.Join(", ", list));
    }
}