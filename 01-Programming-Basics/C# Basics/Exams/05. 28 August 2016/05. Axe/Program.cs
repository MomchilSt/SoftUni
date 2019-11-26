using System;

namespace _05.Axe
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string lowMiddleMiddleDashes = "";

            // Print top rows
            for (int i = 0; i < n; i++)
            {
                string topLeftDashes = new string('-', n * 3);
                string topMiddleDashes = new string('-', i);
                string topRightDashes = new string('-', n * 5 - n * 3 - i - 2);
                Console.WriteLine($"{topLeftDashes}*{topMiddleDashes}*{topRightDashes}");
            }

            // Print middle rows
            for (int i = 0; i < n / 2; i++)
            {
                string middleStars = new string('*', n * 3 + 1);
                string middleDashes = new string('-', n - 1);
                Console.WriteLine("{0}{1}*{1}", middleStars, middleDashes);
            }

            // Print low middle rows
            for (int i = 0; i < n / 2; i++)
            {
                if (i == n / 2 - 1)
                {
                    lowMiddleMiddleDashes = new string('*', n - 1 + i * 2);
                }
                else
                {
                    lowMiddleMiddleDashes = new string('-', n - 1 + i * 2);
                }

                string lowMiddleLeftDashes = new string('-', n * 3 - i);
                string lowMiddleRightDashes = new string('-', n - 1 - i);
                Console.WriteLine($"{lowMiddleLeftDashes}*{lowMiddleMiddleDashes}*{lowMiddleRightDashes}");
            }
        }
    }
}
