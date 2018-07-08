using System;

namespace _5.Fox
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string tAndLEdgeSym = "";
            string tAndLMiddleSym = "";

            // Print top rows
            for (int i = 1; i <= n; i++)
            {
                tAndLEdgeSym = new string('*', i);
                tAndLMiddleSym = new string('-', (2 * n + 3) - 2 - i * 2);
                Console.WriteLine(@"{0}\{1}/{0}", tAndLEdgeSym, tAndLMiddleSym);
            }


            // Print middle rows
            for (int i = 0; i < n / 3; i++)
            {
                string middleEdgeStars = new string('*', n / 2 + i);
                string middleMiddleStars = new string('*', n - i * 2);
                Console.WriteLine(@"|{0}\{1}/{0}|", middleEdgeStars, middleMiddleStars);
            }

            // Print low rows
            for (int i = 1; i <= n; i++)
            {
                tAndLEdgeSym = new string('-', i);
                tAndLMiddleSym = new string('*', (2 * n + 3) - 2 - i * 2);
                Console.WriteLine(@"{0}\{1}/{0}", tAndLEdgeSym, tAndLMiddleSym);
            }
        }
    }
}
