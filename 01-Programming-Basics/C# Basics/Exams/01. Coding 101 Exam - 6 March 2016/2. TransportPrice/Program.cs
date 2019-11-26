using System;

namespace _2.TransportPrice
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string time = Console.ReadLine();

            double result = 0;

            if (n < 20 && time == "day")
            {
                result = 0.70 + n * 0.79;
            }
            else if (n < 20 && time == "night")
            {
                result = 0.70 + n * 0.90;
            }
            else if (n >= 20 && n < 100)
            {
                result = n * 0.09;
            }
            else if (n >= 100)
            {
                result = n * 0.06;
            }

            Console.WriteLine(result);
        }
    }
}
