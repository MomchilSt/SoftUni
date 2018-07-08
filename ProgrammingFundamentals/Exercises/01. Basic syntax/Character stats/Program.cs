using System;

class Program
{
    static void Main()
    {
        string name = Console.ReadLine();
        int currentHp = int.Parse(Console.ReadLine());
        int fullHp = int.Parse(Console.ReadLine());
        int currentEng = int.Parse(Console.ReadLine());
        int fullEnergy = int.Parse(Console.ReadLine());

        Console.WriteLine("Name: {0}", name);
        Console.Write("Health: ");
        Console.WriteLine($"|{new string('|', currentHp)}{new string('.', fullHp - currentHp)}|");
        Console.Write("Energy: ");
        Console.WriteLine($"|{new string('|', currentEng)}{new string('.', fullEnergy - currentEng)}|");
    }
}
