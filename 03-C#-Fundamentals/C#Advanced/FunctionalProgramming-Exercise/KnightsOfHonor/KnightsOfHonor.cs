using System;
using System.Linq;

class KnightsOfHonor
{
    static void Main()
    {
        Action<string> print = x => Console.WriteLine("Sir " + x);

        Console.ReadLine()
            .Split()
            .ToList()
            .ForEach(print);
    }
}