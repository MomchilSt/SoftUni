using System;
using System.Collections.Generic;
using System.Linq;

class AddVAT
{
    static void Main()
    {
        List<double> list = Console.ReadLine()
            .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)
            .ToList();

        Console.WriteLine(string.Join(Environment.NewLine,
            list.Select(n => $"{n * 1.20:f2}")));
    }
}