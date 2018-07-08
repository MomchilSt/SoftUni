using System;

class Program
{
    static void Main()
    {
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        double result = width * height;

        Console.WriteLine("{0:f2}", result);
    }
}
