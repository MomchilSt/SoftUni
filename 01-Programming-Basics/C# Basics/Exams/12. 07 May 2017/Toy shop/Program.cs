using System;

class Program
{
    static void Main()
    {
        double moneyRequired = double.Parse(Console.ReadLine());
        int puzzles = int.Parse(Console.ReadLine());
        int dolls = int.Parse(Console.ReadLine());
        int bears = int.Parse(Console.ReadLine());
        int minions = int.Parse(Console.ReadLine());
        int trucks = int.Parse(Console.ReadLine());

        double total = (puzzles * 2.60) + (dolls * 3) + (bears * 4.10) + (minions * 8.20) + (trucks * 2);

        int totalToys = puzzles + dolls + bears + minions + trucks;

        if (totalToys >= 50)
        {
            total = total - (total * 0.25);
        }

        double afterRent = total - (total * 0.10);

        if (afterRent >= moneyRequired)
        {
            Console.WriteLine($"Yes! {(afterRent - moneyRequired):f2} lv left.");
        }
        else
        {
            Console.WriteLine($"Not enough money! {(moneyRequired - afterRent):f2} lv needed.");
        }
    }
}
