using System;

namespace _02.Simple_Conditional_Statements
{
    class Task2
    {
        static void Main()
        {
            double budget = double.Parse(Console.ReadLine());
            double house = double.Parse(Console.ReadLine());
            double windows = double.Parse(Console.ReadLine());
            double stiroporInBox = double.Parse(Console.ReadLine());
            double stiroporBoxPrice = double.Parse(Console.ReadLine());

            double houseArea = (house - (windows * 2.4)) * 1.1;
            double striroporPriceTotal = Math.Ceiling(houseArea / stiroporInBox) * stiroporBoxPrice;

            double diff = Math.Abs(striroporPriceTotal - budget);

            if (striroporPriceTotal <= budget)
            {
                Console.WriteLine($"Spent: {striroporPriceTotal:f2}");
                Console.WriteLine($"Left: {diff:f2}");
            }
            else
            {
                Console.WriteLine($"Need more: {diff:f2}");
            }
        }
    }
}
