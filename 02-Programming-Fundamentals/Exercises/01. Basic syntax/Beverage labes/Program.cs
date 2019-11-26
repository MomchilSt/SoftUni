using System;

class Program
{
    static void Main()
    {
        string type = Console.ReadLine();
        int ml = int.Parse(Console.ReadLine());
        int kcl = int.Parse(Console.ReadLine());
        int sugar = int.Parse(Console.ReadLine());

        double energy = (ml * kcl) / 100.0;
        double sugars = (sugar * ml) / 100.0;

        Console.WriteLine($"{ml}ml {type}:");
        Console.WriteLine($"{energy}kcal, {sugars}g sugars");
    }
}
