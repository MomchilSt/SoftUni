using System;

namespace p02
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbersOfSteps = double.Parse(Console.ReadLine());
            var dancers = double.Parse(Console.ReadLine());
            var countDays = double.Parse(Console.ReadLine());

            var stepsPerDay = numbersOfSteps / countDays;
            var secondStep = stepsPerDay / numbersOfSteps;
            var percent = Math.Ceiling(secondStep * 100); 
            var totalPercent = percent / dancers; 

            if (percent <= 13) 
            {
                Console.WriteLine($"Yes, they will succeed in that goal! {totalPercent:F2}%.");
            }
            else
            {
                Console.WriteLine($"No, They will not succeed in that goal! Required {totalPercent:F2}% steps to be learned per day.");
            }

        }
    }
}
