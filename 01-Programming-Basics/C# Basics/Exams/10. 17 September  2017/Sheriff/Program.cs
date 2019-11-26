using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int width = 3 * n;

        //three static rows
        Console.WriteLine("{0}x{0}", new string('.', (width - 1) / 2));
        Console.WriteLine(@"{0}/x\{0}", new string('.', (width - 3) / 2));
        Console.WriteLine(@"{0}x|x{0}", new string('.', (width - 3) / 2));

        //first section
        int leftAndRight = ((width - 1) - (2 * n)) / 2;
        if (n % 2 == 0)
        {
            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine("{0}{1}|{1}{0}",
                    new string('.', leftAndRight - i),
                    new string('x', n + i));
            }
        }
       else
        {
            for (int i = 0; i < n / 2 + 1; i++)
            {
                Console.WriteLine("{0}{1}|{1}{0}",
                    new string('.', leftAndRight - i),
                    new string('x', n + i));
            }
        }

        //second section
        int xCounter = n;
        int dots = ((width - 1) - (n * 2)) / 2;
        for (int i = 0; i < n / 2; i++)
        {
            Console.WriteLine("{0}{1}|{1}{0}",
                new string('.', i + 1),
                new string('x', ((width - 1) - (2*(i + 1))) / 2));
        }

        //two static
        Console.WriteLine(@"{0}/x\{0}", new string('.', (width - 3) / 2));
        Console.WriteLine(@"{0}\x/{0}", new string('.', (width - 3) / 2));

        //mirror section
        if (n % 2 == 0)
        {
            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine("{0}{1}|{1}{0}",
                    new string('.', leftAndRight - i),
                    new string('x', n + i));
            }
        }
        else
        {
            for (int i = 0; i < n / 2 + 1; i++)
            {
                Console.WriteLine("{0}{1}|{1}{0}",
                    new string('.', leftAndRight - i),
                    new string('x', n + i));
            }
        }

        for (int i = 0; i < n / 2; i++)
        {
            Console.WriteLine("{0}{1}|{1}{0}",
                new string('.', i + 1),
                new string('x', ((width - 1) - (2 * (i + 1))) / 2));
        }

        //three static rows
        Console.WriteLine("{0}x|x{0}", new string('.', (width - 3) / 2));
        Console.WriteLine(@"{0}\x/{0}", new string('.', (width - 3) / 2));
        Console.WriteLine(@"{0}x{0}", new string('.', (width - 1) / 2));

    }
}
