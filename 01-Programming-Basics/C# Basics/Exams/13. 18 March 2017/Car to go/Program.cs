using System;

class Program
{
    static void Main()
    {
        double budget = double.Parse(Console.ReadLine());
        string season = Console.ReadLine().ToLower();



        if (budget <= 100)
        {
            if (season == "summer")
            {
                budget *= 0.35;
                Console.WriteLine("Economy class");
                Console.WriteLine($"Cabrio - {budget:f2}");
            }
            else if (season == "winter")
            {
                budget *= 0.65;
                Console.WriteLine("Economy class");
                Console.WriteLine($"Jeep - {budget:f2}");
            }
        }

        // --------------------------

        if (budget > 100 && budget <= 500)
        {
            if (season == "summer")
            {
                budget *= 0.45;
                Console.WriteLine("Compact class");
                Console.WriteLine($"Cabrio - {budget:f2}");
            }
            else if (season == "winter")
            {
                budget *= 0.80;
                Console.WriteLine("Compact class");
                Console.WriteLine($"Jeep - {budget:f2}");
            }
        }

        //-------------

        if (budget > 500)
        {
            if (season == "summer")
            {
                budget *= 0.90;
                Console.WriteLine("Luxury class");
                Console.WriteLine($"Jeep - {budget:f2}");
            }
            else if (season == "winter")
            {
                budget *= 0.90;
                Console.WriteLine("Luxury class");
                Console.WriteLine($"Jeep - {budget:f2}");
            }
        }
    }
}
