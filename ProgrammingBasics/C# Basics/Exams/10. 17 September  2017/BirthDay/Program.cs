using System;

class Program
{
    static void Main()
    {
        int lenght = int.Parse(Console.ReadLine());
        int width = int.Parse(Console.ReadLine());
        int height = int.Parse(Console.ReadLine());
        double percent = double.Parse(Console.ReadLine());

        int area = lenght * width * height;
        double liters = area * 0.001;
        percent = percent * 0.01;
        Console.WriteLine($"{liters * (1 - percent):f3}");
    }
}
