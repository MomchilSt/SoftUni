using System;
using System.Collections.Generic;

class MetricConverterV2
{
    static void Main()
    {
        double num = double.Parse(Console.ReadLine());
        string firstUnit = Console.ReadLine();
        string secondUnit = Console.ReadLine();

        var dictonary = new Dictionary<string, double>()
            {
                {"m", 1},
                {"mm", 1000},
                {"cm", 100},
                {"mi", 0.000621371192},
                {"in", 39.3700787},
                {"km", 0.001},
                {"ft", 3.2808399},
                {"yd", 1.0936133}
            };

        var result = (num / dictonary[firstUnit]) * dictonary[secondUnit];
        Console.WriteLine("{0} {1}", result, secondUnit);
    }
}
