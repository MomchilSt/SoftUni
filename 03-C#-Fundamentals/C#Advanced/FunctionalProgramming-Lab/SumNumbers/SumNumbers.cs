using System;
using System.Collections.Generic;
using System.Linq;

class SumNumbers
{
    static void Main()
    {
        List<int> list = Console.ReadLine()
            .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        Console.WriteLine(list.Count);
        Console.WriteLine(list.Sum());
    }
}