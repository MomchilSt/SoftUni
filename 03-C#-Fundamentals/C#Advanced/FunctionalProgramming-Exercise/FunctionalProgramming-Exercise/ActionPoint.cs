using System;
using System.Collections.Generic;
using System.Linq;

class ActionPoint
{
    static void Main()
    {
        Action<string> print = x => Console.WriteLine(x);

        Console.ReadLine()
            .Split()
            .ToList()
            .ForEach(print);
    }
}
