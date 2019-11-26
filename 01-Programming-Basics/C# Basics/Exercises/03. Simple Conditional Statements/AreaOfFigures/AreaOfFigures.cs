using System;

class AreaOfFigures
{
    static void Main()
    {
        string formType = Console.ReadLine();

        if (formType == "square")
        {
            double squareA = double.Parse(Console.ReadLine());
            double squareArea = squareA * squareA;
            Console.WriteLine(Math.Round(squareArea, 2));
        }
        else if (formType == "rectangle")
        {
            double rectangleA = double.Parse(Console.ReadLine());
            double rectangleB = double.Parse(Console.ReadLine());
            double rectangleArea = rectangleA * rectangleB;
            Console.WriteLine(Math.Round(rectangleArea, 2));
        }
        else if (formType == "circle")
        {
            double radius = double.Parse(Console.ReadLine());
            double circleArea = Math.PI * radius * radius;
            Console.WriteLine(Math.Round(circleArea, 2));
        }
        else if (formType == "triangle")
        {
            double triangleA = double.Parse(Console.ReadLine());
            double triangleH = double.Parse(Console.ReadLine());
            double triangleArea = (triangleA * triangleH) / 2;
            Console.WriteLine(Math.Round(triangleArea, 2));
        }
    }
}
