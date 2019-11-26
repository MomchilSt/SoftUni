using System;
using System.Linq;
//za 3 = 12 full za 5 = 14
class Program                                                     
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int width = 3 * n + 6;
        string wave = (string.Join("", Enumerable.Repeat(" ~", 3)));

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("{0}{1}", new string(' ', n - 1), wave);
        }

        Console.WriteLine(new string('=', 3 * n + 6));

        if (n % 2 == 0)
        {
            for (int i = 0; i < n / 2 - 1; i++)
            {
                Console.WriteLine("|{0}|{1}|", new string('~', n * 2 + 4), new string(' ', n - 1));
            }
            Console.WriteLine("|{0}JAVA{0}|{1}|", new string('~', n), new string(' ', n - 1));
            for (int i = 0; i < n / 2 - 2; i++)
            {
                Console.WriteLine("|{0}|{1}|", new string('~', n * 2 + 4), new string(' ', n - 1));
            }

        }
        else
        {
            for (int i = 0; i < (n - 3) / 2; i++)
            {
                Console.WriteLine("|{0}|{1}|", new string('~', n * 2 + 4), new string(' ', n - 1));
            }
            Console.WriteLine("|{0}JAVA{0}|{1}|", new string('~', n), new string(' ', n - 1));
            for (int i = 0; i < (n - 3) / 2; i++)
            {
                Console.WriteLine("|{0}|{1}|", new string('~', n * 2 + 4), new string(' ', n - 1));

            }

            Console.WriteLine(new string('=', 3 * n + 6));

            var monkey = ((3 * n) + 6) - (n + 2);
            var spaces = 0;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(@"{0}\{1}/", new string(' ', spaces), new string('@', monkey));
                spaces++;
                monkey -= 2;
            }

            Console.WriteLine($"{new string('=', width - n)}");
        }
    }
}
