using System;

namespace _05.Drawing_Figures_with_Loops
{
    class Task5
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            // Print top row
            string tildas = new string('~', (3 * n + 1) - 3 - 2 * n);
            string topDots = new string('.', 2 * n + 1);
            Console.WriteLine($"+{tildas}+{topDots}");

            // Print top middle rows
            for (int i = 0; i <= n * 2; i++)
            {
                string topMiddleDots1 = new string('.', 2 * n - i);
                string topMiddleDots2 = new string('.', i - 1 + 1);

                Console.WriteLine($@"|{topMiddleDots2}\{tildas}\{topMiddleDots1}");
            }
            // Print low middle rows
            for (int i = 0; i <= n * 2; i++)
            {
                string lowMiddleDots1 = new string('.', i);
                string lowMiddleDots2 = new string('.', n * 2 - i);

                Console.WriteLine($@"{lowMiddleDots1}\{lowMiddleDots2}|{tildas}|");
            }

            // Print low row
            Console.WriteLine($"{topDots}+{tildas}+");

            // var space_star = string.Join("", Enumerable.Repeat(" *", n));
        }
    }
}
