using System;

class CelsiusToFahrenheit
{
    static void Main()
    {
        var cel = double.Parse(Console.ReadLine());
        var toFar = (cel * 1.8) + 32;
        Console.WriteLine(Math.Round(toFar, 2));
    }
}
