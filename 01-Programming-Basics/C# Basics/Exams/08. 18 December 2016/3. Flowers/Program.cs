using System;

namespace _3.Flowers
{
    class Program
    {
        static void Main()
        {
            int flower1 = int.Parse(Console.ReadLine());
            int flower2 = int.Parse(Console.ReadLine());
            int flower3 = int.Parse(Console.ReadLine());
            string season = Console.ReadLine().ToLower();
            string isHoliday = Console.ReadLine().ToLower();

            double price = 0;

            if (season == "spring" || season == "summer")
            {
                price = flower1 * 2.0 + flower2 * 4.10 + flower3 * 2.50;

                if (isHoliday == "y")
                    price *= 1.15;

                if (flower3 > 7 && season == "spring")
                    price *= .95;
            }
            else if (season == "autumn" || season == "winter")
            {
                price = flower1 * 3.75 + flower2 * 4.50 + flower3 * 4.15;

                if (isHoliday == "y")
                    price *= 1.15;

                if (flower2 >= 10 && season == "winter")
                    price *= .90;
            }

            if (flower1 + flower2 + flower3 > 20)
                price *= .80;

            price += 2;

            Console.WriteLine($"{price:f2}");
        }
    }
}
