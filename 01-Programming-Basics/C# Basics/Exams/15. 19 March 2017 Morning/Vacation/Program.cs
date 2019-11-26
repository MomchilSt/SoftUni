using System;

class Program
{
    static void Main()
    {
        double budget = double.Parse(Console.ReadLine());
        string season = Console.ReadLine().ToLower();

        double summerCost = 0;
        double winterCost = 0;

        if (budget <= 1000)
        {
            if (season == "summer")
            {
                summerCost = budget * 0.65;
                Console.WriteLine($"Alaska - Camp - {summerCost:f2}");
            }
            else if (season == "winter")
            {
                winterCost = budget * 0.45;
                Console.WriteLine($"Morocco - Camp - {winterCost:f2}");
            }
        }

        else if (budget >= 1000 && budget <= 3000)
        {
            if (season == "summer")
            {
                summerCost = budget * 0.80;
                Console.WriteLine($"Alaska - Hut - {summerCost:f2}");
            }
            else if (season == "winter")
            {
                winterCost = budget * 0.60;
                Console.WriteLine($"Morocco - Hut - {winterCost:f2}");
            }
        }

        else if (budget > 3000)
        {
            if (season == "summer")
            {
                summerCost = budget * 0.90;
                Console.WriteLine($"Alaska - Hotel - {summerCost:f2}");
            }
            else if (season == "winter")
            {
                winterCost = budget * 0.90;
                Console.WriteLine($"Morocco - Hotel - {winterCost:f2}");
            }
        }
    }
}
