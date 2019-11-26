using System;

class RadiansToDegrees
{
    static void Main()
    {
        var rad = double.Parse(Console.ReadLine());
        var deg = (180 / Math.PI) * rad;
        Console.WriteLine(Math.Round(deg, 0));
    }
}
