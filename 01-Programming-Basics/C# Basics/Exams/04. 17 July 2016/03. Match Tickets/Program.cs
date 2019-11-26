using System;

namespace _03.Match_Tickets
{
    class Program
    {
        static void Main()
        {
            double budget = double.Parse(Console.ReadLine());
            string ticketType = Console.ReadLine().ToLower();
            int people = int.Parse(Console.ReadLine());

            double priceTickets = 0;
            double moneyCost = 0;

            switch (ticketType)
            {
                case "vip":
                    priceTickets = people * 499.99;
                    break;
                case "normal":
                    priceTickets = people * 249.99;
                    break;
            }

            if (people >= 50)
                moneyCost = priceTickets + budget * 0.25;
            else if (people >= 25)
                moneyCost = priceTickets + budget * 0.4;
            else if (people >= 10)
                moneyCost = priceTickets + budget * 0.5;
            else if (people >= 5)
                moneyCost = priceTickets + budget * 0.6;
            else
                moneyCost = priceTickets + budget * 0.75;

            double diff = Math.Abs(moneyCost - budget);

            if (budget >= moneyCost)
                Console.WriteLine($"Yes! You have {diff:f2} leva left.");
            else
                Console.WriteLine($"Not enough money! You need {diff:f2} leva.");
        }
    }
}
