using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int width = 5 * n;
        int fill = 3 * n;
        int leftAndRight = (width - fill) / 2;

        //first section
        for (int i = 0; i < n /2; i++)
        {
            Console.WriteLine("{0}{1}{0}",
                new string('.', leftAndRight),
                new string('#', fill));
            fill -= 2;
            leftAndRight++;
        }

        //second section
        for (int i = 0; i < n / 2 + 1; i++)
        {
            fill-=2;
            Console.WriteLine("{0}#{1}#{0}",
                new string('.', leftAndRight),
                new string('.', fill));
            leftAndRight++;
        }

        //static mid row
        Console.WriteLine("{0}{1}{0}", new string('.', (width - n) /2) , new string('#', n));

        //third section
        for (int i = 0; i < n / 2; i++)
        {
            Console.WriteLine("{0}{1}{0}", new string('.', (width - (n + 4)) / 2), new string('#', n + 4)   );
        }

        //dance row
        Console.WriteLine("{0}D^A^N^C^E^{0}", new string('.', (width - 10) / 2)   );

        //last section
        for (int i = 0; i < n / 2 + 1; i++)
        {
            Console.WriteLine("{0}{1}{0}", new string('.', (width - (n + 4)) / 2), new string('#', n + 4));
        }
    }
}
