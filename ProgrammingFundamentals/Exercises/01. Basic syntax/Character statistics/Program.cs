using System;

class Program
{
    static void Main()
    {
        string name = Console.ReadLine();
        int currentHp = int.Parse(Console.ReadLine());
        int fullHp = int.Parse(Console.ReadLine());
        int currentEnergy = int.Parse(Console.ReadLine());
        int fullEnergy = int.Parse(Console.ReadLine());

        Console.WriteLine("Name: {0}", name);
        Console.WriteLine("Health: |{0}{1}|", new string('|', currentHp), new string('.', fullHp - currentHp));
        Console.WriteLine("Energy: |{0}{1}|", new string('|', currentEnergy), new string('.', fullEnergy - currentEnergy));
    }
}
