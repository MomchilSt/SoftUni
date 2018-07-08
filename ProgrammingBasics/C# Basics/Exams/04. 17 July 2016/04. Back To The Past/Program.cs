using System;

namespace _04.Back_To_The_Past
{
    class Program
    {
        static void Main()
        {
            double x = double.Parse(Console.ReadLine());
            int lastYearLive = int.Parse(Console.ReadLine());

            double moneySpend = 0;

            for (int i = 1800; i <= lastYearLive; i++)
            {
                if (i % 2 == 0) { moneySpend += 12000; }
                else { moneySpend += 12000 + 50 * (18 + i - 1800); }
            }

            double diff = Math.Abs(moneySpend - x);

            if (x >= moneySpend)
            {
                Console.WriteLine
                    ($"Yes! He will live a carefree life and will have {diff:f2} dollars left.");
            }
            else
            {
                Console.WriteLine($"He will need {diff:f2} dollars to survive.");
            }
        }
    }
}
