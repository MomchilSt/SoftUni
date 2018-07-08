using System;

class P11GeometryCalculator
{
    static void Main(string[] args)
    {
        string figure = Console.ReadLine();

        if (figure == "triangle")
        {
            double side = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            PrintTriangleArea(side, height);
        }
        else if (figure == "square")
        {
            double side = double.Parse(Console.ReadLine());
            PrintSquareArea(side);
        }
        else if (figure == "rectangle")
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            PrintRectangleArea(width, height);
        }
        else
        {
            double radius = double.Parse(Console.ReadLine());
            PrintCircleArea(radius);
        }
    }

    static void PrintTriangleArea(double side, double height)
    {
        double result = 0.5 * side * height;
        Console.WriteLine("{0:f2}", result);
    }

    static void PrintSquareArea(double side)
    {
        double result = side * side;
        Console.WriteLine("{0:f2}", result);
    }

    static void PrintRectangleArea(double width, double height)
    {
        double result = width * height;
        Console.WriteLine("{0:f2}", result);
    }

    static void PrintCircleArea(double radius)
    {
        double result = Math.PI * (radius * radius);
        Console.WriteLine("{0:f2}", result);
    }
}
