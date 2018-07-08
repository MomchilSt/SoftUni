using System;

class CircleAreaAndPerimeter
{
    static void Main()
    {
        var r = double.Parse(Console.ReadLine());
        var area = Math.PI * r * r;
        var perimeter = 2 * Math.PI * r;
        Console.WriteLine("Area = {0}, \nPerimeter = {1}", area, perimeter);
    }
}
