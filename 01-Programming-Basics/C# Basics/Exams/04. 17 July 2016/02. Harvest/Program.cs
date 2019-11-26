using System;

namespace _02.Harvest
{
    class Program
    {
        static void Main()
        {
            int x = int.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            int z = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            double wine = (x * y) * 0.4 / 2.5;

            if (wine < z)
            {
                double neededWine = Math.Floor(z - wine);

                Console.WriteLine
                  ($"It will be a tough winter! More {neededWine} liters wine needed.");
            }
            else
            {
                Console.WriteLine
                  ($"Good harvest this year! Total wine: {Math.Floor(wine)} liters.");

                double remWine = Math.Ceiling(wine - z);
                double winePerWorker = Math.Ceiling(remWine / workers);

                Console.WriteLine
                  ($"{remWine} liters left -> {winePerWorker} liters per person.");
            }
        }
    }
}
