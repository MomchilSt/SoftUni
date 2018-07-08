using System;

class P8CenterPoint
{
    static void Main(string[] args)
    {
        double x1 = double.Parse(Console.ReadLine());
        double y1 = double.Parse(Console.ReadLine());
        double x2 = double.Parse(Console.ReadLine());
        double y2 = double.Parse(Console.ReadLine());

        ClosestPoint(x1, x2, y1, y2);
    }

    static void ClosestPoint(double x1, double x2, double y1, double y2)
    {
        double first = Math.Sqrt((x1 * x1) + (y1 * y1));
        double second = Math.Sqrt((y2 * y2) + (x2 * x2));

        if (first <= second)
        {
            Console.WriteLine($"({x1}, {y1})");
        }
        else
        {
            Console.WriteLine($"({x2}, {y2})");
        }
    }
}