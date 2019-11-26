using System;

namespace _2.Pets
{
    class Program
    {
        static void Main()
        {
            int days = int.Parse(Console.ReadLine());
            int foodKg = int.Parse(Console.ReadLine());
            double dogFoodPerDay = double.Parse(Console.ReadLine());
            double catFoodPerDay = double.Parse(Console.ReadLine());
            double turtleFoodPerDay = double.Parse(Console.ReadLine());

            turtleFoodPerDay /= 1000;

            double foodNeeded = (dogFoodPerDay + catFoodPerDay + turtleFoodPerDay) * days;

            double diff = Math.Abs(foodNeeded - foodKg);

            if (foodKg >= foodNeeded)
                Console.WriteLine($"{Math.Floor(diff)} kilos of food left.");
            else
                Console.WriteLine($"{Math.Ceiling(diff)} more kilos of food are needed.");

        }
    }
}
