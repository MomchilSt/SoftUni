using System;

namespace _5.Stop
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            // Print top row
            string topDots = new string('.', n + 1);
            string topUnderscores = new string('_', n * 2 + 1);
            Console.WriteLine("{0}{1}{0}", topDots, topUnderscores);

            // Print top middle rows
            for (int i = 0; i < n; i++)
            {
                string middleTopDots = new string('.', n - i);
                string middleTopUndercores = new string('_', n * 2 - 1 + i * 2);
                Console.WriteLine(@"{0}//{1}\\{0}", middleTopDots, middleTopUndercores);
            }

            // Print middle row
            string middleUndercores = new string('_', n * 2 - 3);
            Console.WriteLine(@"//{0}STOP!{0}\\", middleUndercores);

            // Print low rows
            for (int i = 0; i < n; i++)
            {
                string lowDots = new string('.', i);
                string lowUndercores = new string('_', n * 4 - 1 - 2 * i);
                Console.WriteLine(@"{0}\\{1}//{0}", lowDots, lowUndercores);
            }
        }
    }
}
