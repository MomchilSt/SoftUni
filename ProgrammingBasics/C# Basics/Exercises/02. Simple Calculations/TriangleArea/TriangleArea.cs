using System;

class TriangleArea
{
    static void Main()
    {
        var a = double.Parse(Console.ReadLine());
        var h = double.Parse(Console.ReadLine());
        Console.WriteLine(Math.Round((a * h) / 2, 2));
    }
}
