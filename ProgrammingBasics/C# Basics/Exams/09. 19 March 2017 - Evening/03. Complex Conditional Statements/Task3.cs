using System;

namespace _03.Complex_Conditional_Statements
{
    class Task3
    {
        static void Main()
        {
            string season = Console.ReadLine().ToLower();
            double kmPerMonth = double.Parse(Console.ReadLine());

            double income = 0;

            switch (season)
            {
                case "spring":
                case "autumn":
                    if (kmPerMonth <= 5000)
                    {
                        income = kmPerMonth * 0.75;
                    }
                    else if (kmPerMonth > 5000 && kmPerMonth <= 10000)
                    {
                        income = kmPerMonth * 0.95;
                    }
                    break;
                case "summer":
                    if (kmPerMonth <= 5000)
                    {
                        income = kmPerMonth * 0.9;
                    }
                    else if (kmPerMonth > 5000 && kmPerMonth <= 10000)
                    {
                        income = kmPerMonth * 1.1;
                    }
                    break;

                case "winter":
                    if (kmPerMonth <= 5000)
                    {
                        income = kmPerMonth * 1.05;
                    }
                    else if (kmPerMonth > 5000 && kmPerMonth <= 10000)
                    {
                        income = kmPerMonth * 1.25;
                    }
                    break;
            }

            if (kmPerMonth > 10000 && kmPerMonth <= 20000)
            {
                income = kmPerMonth * 1.45;
            }

            income *= 4;
            income *= 0.9;

            Console.WriteLine($"{income:f2}");

        }
    }
}
