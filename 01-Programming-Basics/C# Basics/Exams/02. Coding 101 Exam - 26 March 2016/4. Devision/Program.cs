using System;

namespace Devision
{
    class Program
    {
        static void Main()
        {
            double n = int.Parse(Console.ReadLine());

            double p1 = 0;
            double p2 = 0;
            double p3 = 0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num % 2 == 0) p1++;
                if (num % 3 == 0) p2++;
                if (num % 4 == 0) p3++;
            }

            double p1p = p1 / n * 100;
            double p2p = p2 / n * 100;
            double p3p = p3 / n * 100;

            Console.WriteLine("{0:f2}%", p1p);
            Console.WriteLine("{0:f2}%", p2p);
            Console.WriteLine("{0:f2}%", p3p);
        }
    }
}
