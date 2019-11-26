using System;

class Program
{
    static void Main()
    {
        double vineyard = double.Parse(Console.ReadLine());
        double kgPerSquare = double.Parse(Console.ReadLine());
        double waste = double.Parse(Console.ReadLine());

        double kgGrapes = vineyard * kgPerSquare;
        double kgTotal = kgGrapes - waste;

        double litersVine = (kgTotal * 0.45) / 7.5;
        double grapesForSale = (kgTotal * 0.55) * 1.5;

        Console.WriteLine($"{(litersVine * 9.80):f2}");
        Console.WriteLine($"{grapesForSale:f2}");
       
    }
}
