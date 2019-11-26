using System;

namespace _3.Trip
{
    class Program
    {
        static void Main()
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double money = 0;

            if (budget <= 100)
            {
                Console.WriteLine("Somewhere in Bulgaria");

                if (season == "summer")
                {
                    money = budget * 0.3;
                    Console.WriteLine("Camp - {0:f2}", money);
                }
                else if (season == "winter")
                {
                    money = budget * 0.7;
                    Console.WriteLine("Hotel - {0:f2}", money);
                }
            }
            else if (budget > 100 && budget <= 1000)
            {
                Console.WriteLine("Somewhere in Balkans");

                if (season == "summer")
                {
                    money = budget * 0.4;
                    Console.WriteLine("Camp - {0:f2}", money);
                }
                else if (season == "winter")
                {
                    money = budget * 0.8;
                    Console.WriteLine("Hotel - {0:f2}", money);
                }
            }
            else if (budget > 1000)
            {
                money = budget * 0.9;
                Console.WriteLine("Somewhere in Europe");
                Console.WriteLine("Hotel - {0:f2}", money);
            }
        }
    }
}
