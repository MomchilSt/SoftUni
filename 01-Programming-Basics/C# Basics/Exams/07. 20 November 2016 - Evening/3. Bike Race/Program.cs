using System;

namespace _3.Bike_Race
{
    class Program
    {
        static void Main()
        {
            decimal juniors = decimal.Parse(Console.ReadLine());
            decimal seniors = decimal.Parse(Console.ReadLine());
            string road = Console.ReadLine();

            decimal price = 0;

            if (road == "trail")
            {
                price = juniors * 5.5m + seniors * 7;
            }
            else if (road == "cross-country")
            {
                price = juniors * 8 + seniors * 9.5m;

                if (juniors + seniors >= 50)
                {
                    price *= 0.75m;
                }
            }
            else if (road == "downhill")
            {
                price = juniors * 12.25m + seniors * 13.75m;
            }
            else if (road == "road")
            {
                price = juniors * 20 + seniors * 21.5m;
            }

            price *= 0.95m;

            Console.WriteLine($"{price:f2}");
        }
    }
}
