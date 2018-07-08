using System;

class P6CalculateTrianglerArea
{
    static void Main()
    {
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());
        double area = GetTriangleArea(width, height);
        Console.WriteLine(area);
    }

    static double GetTriangleArea(double width, double height)
    {
        return width * height / 2;
    }
}
