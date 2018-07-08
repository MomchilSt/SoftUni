using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int width = (2 * n) + 1;
        int topLeftAndRight = (width - 3) / 2;
        int spaces = 3;

        Console.WriteLine(@"{0}/^\{0}", new string('#', (width - 3) / 2));

        for (int i = 0; i < n / 2; i++)
        {
            topLeftAndRight--;
            Console.WriteLine("{0}.{1}.{0}", new string('#', topLeftAndRight), new string(' ', spaces));
            spaces += 2;
        }

        if (n % 2 == 0)
        {
            Console.WriteLine("{0}|{1}S{1}|{0}", new string('#', n / 2 - 1), new string(' ', n / 2));
            Console.WriteLine("{0}|{1}O{1}|{0}", new string('#', n / 2 - 1), new string(' ', n / 2));
            Console.WriteLine("{0}|{1}F{1}|{0}", new string('#', n / 2 - 1), new string(' ', n / 2));
            Console.WriteLine("{0}|{1}T{1}|{0}", new string('#', n / 2 - 1), new string(' ', n / 2));
        }
        else
        {
            Console.WriteLine("{0}|{1}S{1}|{0}", new string('#', n / 2), new string(' ', n / 2));
            Console.WriteLine("{0}|{1}O{1}|{0}", new string('#', n / 2), new string(' ', n / 2));
            Console.WriteLine("{0}|{1}F{1}|{0}", new string('#', n / 2), new string(' ', n / 2));
            Console.WriteLine("{0}|{1}T{1}|{0}", new string('#', n / 2), new string(' ', n / 2));
        }

        if (n == 4)
        {
            for (int i = 0; i < n - 3; i++)     //n / 2 - 1
            {
                Console.WriteLine("{0}|{1}|{0}", new string('#', n / 2 - 1), new string(' ', n + 1));
            }
        }
        else if (!(n % 2 == 0))
        {
            for (int i = 0; i < n - 4; i++)
            {
                Console.WriteLine("{0}|{1}|{0}", new string('#', n / 2 ), new string(' ', n ));
            }
        }
        else
        {
            for (int i = 0; i < n - 4 ; i++)
            {
                Console.WriteLine("{0}|{1}|{0}", new string('#', n / 2 - 1), new string(' ', n + 1));
            }
        }

        if (n % 2 == 0)
        {
            Console.WriteLine("{0}|{1}U{1}|{0}", new string('#', n / 2 - 1), new string(' ', n / 2));
            Console.WriteLine("{0}|{1}N{1}|{0}", new string('#', n / 2 - 1), new string(' ', n / 2));
            Console.WriteLine("{0}|{1}I{1}|{0}", new string('#', n / 2 - 1), new string(' ', n / 2));
        }
        else
        {
            Console.WriteLine("{0}|{1}U{1}|{0}", new string('#', n / 2), new string(' ', n / 2));
            Console.WriteLine("{0}|{1}N{1}|{0}", new string('#', n / 2), new string(' ', n / 2));
            Console.WriteLine("{0}|{1}I{1}|{0}", new string('#', n / 2), new string(' ', n / 2));
        }

        Console.WriteLine("@{0}@", new string('=', width - 2));

        if (n % 2 == 0)
        {
            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine("{0}|{1}|{0}", new string('#', (width - (n - 1)) / 2), new string(' ', n - 3));
            }
        }
        else
        {
            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine("{0}|{1}|{0}", new string('#', (width - (n - 2)) / 2), new string(' ', n - 4));
            }
        }

        //int width = (2 * n) + 1;
        int lastDots = (width - (n - 1));
        if (n % 2 == 0)
        {
            Console.WriteLine(@"{0}\{1}/{0}", new string('#', (width - (n - 1)) / 2), new string('.', n -3 ));
        }
        else
        {
            Console.WriteLine(@"{0}\{1}/{0}", new string('#', (width - (n - 2)) / 2), new string('.', n - 4));
        }
    }
}
