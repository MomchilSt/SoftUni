using System;

namespace _5.Butterfly
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string stars = new string('*', n - 2);
            string dashes = new string('-', n - 2);
            string spaces = new string(' ', n - 1);

            for (int i = 0; i < n / 2 - 1; i++)
            {
                Console.WriteLine(@"{0}\ /{0}", stars);
                Console.WriteLine(@"{0}\ /{0}", dashes);
            }
            Console.WriteLine(@"{0}\ /{0}", stars);

            Console.WriteLine("{0}@{0}", spaces);

            for (int i = 0; i < n / 2 - 1; i++)
            {
                Console.WriteLine(@"{0}/ \{0}", stars);
                Console.WriteLine(@"{0}/ \{0}", dashes);
            }
            Console.WriteLine(@"{0}/ \{0}", stars);
        }
    }
}
