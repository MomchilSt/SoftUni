using System;

namespace _05.Diamond
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());


            // Print the first row
            string topDots = new string('.', n);
            string topStars = new string('*', n * 3);
            Console.WriteLine("{0}{1}{0}", topDots, topStars);

            // Print top middle rows
            for (int i = 1; i <= n - 1; i++)
            {
                string endTopMiddleDots = new string('.', n - i);
                string midTopMiddleDots = new string('.', n * 5 - 2 * (n - i) - 2);
                Console.WriteLine("{0}*{1}*{0}", endTopMiddleDots, midTopMiddleDots);
            }

            // Print middle row
            string middleStars = new string('*', n * 5);
            Console.WriteLine(middleStars);

            // Print low middle rows
            for (int i = 1; i <= n * 2; i++)
            {
                string endLowMiddleDots = new string('.', i);
                string midLowMiddleDots = new string('.', n * 5 - 2 * i - 2);
                Console.WriteLine("{0}*{1}*{0}", endLowMiddleDots, midLowMiddleDots);
            }

            // Print the low row
            string lowDots = new string('.', n * 2 + 1);
            string lowStars = new string('*', n * 5 - (n * 2 + 1) * 2);
            Console.WriteLine("{0}{1}{0}", lowDots, lowStars);

        }
    }
}
