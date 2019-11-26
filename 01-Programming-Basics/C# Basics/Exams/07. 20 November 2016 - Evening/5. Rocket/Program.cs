using System;

namespace _5.Rocket
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            // Print top rows
            for (int i = 0; i < n; i++)
            {
                string topDots = new string('.', (3 * n - i * 2) / 2 - 1);
                string spaces = new string(' ', i * 2);

                Console.WriteLine(@"{0}/{1}\{0}", topDots, spaces);
            }

            // Print top middle rows
            string topMiddleDots = new string('.', n / 2);
            string topMiddleStars = new string('*', n * 2);
            Console.WriteLine("{0}{1}{0}", topMiddleDots, topMiddleStars);

            // Print middle rows
            for (int i = 0; i < n * 2; i++)
            {
                string middleDots = new string('.', n / 2);
                string middleSlashes = new string('\\', n * 2 - 2);
                Console.WriteLine(@"{0}|{1}|{0}", middleDots, middleSlashes);
            }

            // Print low rows
            for (int i = 0; i < n / 2; i++)
            {
                string lowDots = new string('.', n / 2 - i);
                string lowStars = new string('*', n * 2 + i * 2 - 2);
                Console.WriteLine(@"{0}/{1}\{0}", lowDots, lowStars);
            }

        }
    }
}
