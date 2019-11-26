using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<string> times = Console.ReadLine()
            .Split()
            .OrderBy(x => x)
            .ToList();

        Console.WriteLine(string.Join(", ", times));
    }
}

