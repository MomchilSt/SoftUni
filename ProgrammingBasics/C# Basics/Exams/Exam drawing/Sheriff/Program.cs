using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int width = 3 * n;

        Console.WriteLine($"{new string('.', (width - 1) / 2)}x{new string('.', (width - 1) / 2)}");
        Console.WriteLine($@"{new string('.', (width - 3) / 2)}/x\{new string('.', (width - 3) / 2)}");
        Console.WriteLine($@"{new string('.', (width - 3) / 2)}x|x{new string('.', (width - 3) / 2)}");

        var dots = (width - (n * 2) - 1) / 2;

        if (n % 2 == 0)
        {
            for (int i = 0; i < n / 2; i++)
            {

                Console.WriteLine("{0}{1}|{1}{0}", new string('.', dots - i), new string('x', n + i));

            }
        }
        else
        {
            for (int i = 0; i < n / 2 + 1; i++)
            {

                Console.WriteLine("{0}{1}|{1}{0}", new string('.', dots - i), new string('x', n + i));

            }
        }

        var xCounter = (width - 3) / 2;

        for (int i = 0; i < (n / 2) ; i++)
        {
            Console.WriteLine("{0}{1}|{1}{0}", new string('.', i + 1), new string('x', xCounter - i));
        }

        Console.WriteLine(@"{0}/x\{0}", new string('.', (width - 3) / 2));
        Console.WriteLine(@"{0}\x/{0}", new string('.', (width - 3) / 2));

        if (n % 2 == 0)
        {
            for (int i = 0; i < n / 2; i++)
            {

                Console.WriteLine("{0}{1}|{1}{0}", new string('.', dots - i), new string('x', n + i));

            }
        }
        else
        {
            for (int i = 0; i < n / 2 + 1; i++)
            {

                Console.WriteLine("{0}{1}|{1}{0}", new string('.', dots - i), new string('x', n + i));

            }
        }

        for (int i = 0; i < (n / 2); i++)
        {
            Console.WriteLine("{0}{1}|{1}{0}", new string('.', i + 1), new string('x', xCounter - i));
        }

        Console.WriteLine("{0}x|x{0}", new string('.', (width - 3) / 2));
        Console.WriteLine(@"{0}\x/{0}", new string('.', (width - 3) / 2));
        Console.WriteLine("{0}x{0}", new string('.', (width - 1) / 2));
    }
}
