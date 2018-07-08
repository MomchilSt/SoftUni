using System;

class Program
{
    static void Main()
    {
        int spaceLenght = int.Parse(Console.ReadLine());
        int spaceWidth = int.Parse(Console.ReadLine());
        double wireHeight = double.Parse(Console.ReadLine());
        double wirePrice = double.Parse(Console.ReadLine());
        double wireKg = double.Parse(Console.ReadLine());

        int wireLenght = (2 * spaceLenght) + (2 * spaceWidth);
        double price = wireLenght * wirePrice;
        double wireArea = wireLenght * wireHeight;
        double kgWire = wireArea * wireKg;

        Console.WriteLine(wireLenght);
        Console.WriteLine($"{price:f2}");
        Console.WriteLine($"{kgWire:f3}");
    }
}
