using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] prices = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int jewelsPrice = prices[0];
        int goldPrice = prices[1];

        int jewelsCounter = 0;
        int goldCounter = 0;
        int expenses = 0;

        while (true)
        {
            string[] loot = Console.ReadLine().Split();
            if (loot[0] == "Jail" && loot[1] == "Time")
            {
                break;
            }

            expenses += int.Parse(loot[1]);

            char[] lootAsChar = loot[0].ToCharArray();

            foreach (var goodie in lootAsChar)
            {
                if (goodie == '%')
                {
                    jewelsCounter++;
                }
                if (goodie == '$')
                {
                    goldCounter++;
                }
            }
        }

        int sum = (goldCounter * goldPrice + jewelsCounter * jewelsPrice) - expenses;

        if (sum >= 0)
        {
            Console.WriteLine($"Heists will continue. Total earnings: {sum}.");
        }
        else
        {
            Console.WriteLine($"Have to find another job. Lost: {Math.Abs(sum)}.");
        }
    }
}