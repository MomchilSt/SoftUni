using System;

class Program
{
    static void Main()
    {
        string drink = Console.ReadLine();
        int ml = int.Parse(Console.ReadLine());
        int kcal = int.Parse(Console.ReadLine());
        int sugar = int.Parse(Console.ReadLine());

        double energy = (ml * kcal) / 100.0;
        double sugarContent = (ml * sugar) / 100.0;

        Console.WriteLine("{0}ml {1}:", ml, drink);
        Console.WriteLine("{0}kcal, {1}g sugars", energy, sugarContent);
    }
}
