using System;

namespace _4.SmartLilli
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            double laundry = double.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());

            int toys = 0;
            int money = 0;
            int brotherCut = 0;
            int yearIncrease = 0;

            for (int i = 1; i <= n; i++)
            {
                if (i % 2 == 0)
                {
                    yearIncrease += 10;
                    money += yearIncrease;
                    brotherCut++;
                }
                else
                {
                    toys++;
                }
            }

            int budget = money + toys * p - brotherCut;
            double diff = Math.Abs(budget - laundry);

            if (budget >= laundry)
            {
                Console.WriteLine($"Yes! {diff:f2}");
            }
            else
            {
                Console.WriteLine($"No! {diff:f2}");
            }
        }
    }
}
