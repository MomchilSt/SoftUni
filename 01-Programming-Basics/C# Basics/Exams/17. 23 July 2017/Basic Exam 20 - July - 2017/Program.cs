using System;

class Program
{
    static void Main()
    {
        double l = double.Parse(Console.ReadLine());
        double w = double.Parse(Console.ReadLine());
        double a = double.Parse(Console.ReadLine());

        double hallArea = (l * 100) * (w * 100);
        double woredrobe = (a * 100) * (a * 100);

        double bench = hallArea / 10;
        double freeSpace = hallArea - woredrobe - bench;

        double dancers = freeSpace / (40 + 7000);
        Console.WriteLine((int)dancers);
    }
}
