using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        var width = 2 * n + 3;

        Console.WriteLine("*{0}*{0}*", new string('.', (width - 3) / 2));

        var leftAndRightDots = 1;
        var midDots = ((width - 3) - leftAndRightDots) / 2;            //(n - 1) / 2;

        for (int i = 0; i < n - 2; i++)
        {
            Console.WriteLine("{0}*{1}*{1}*{0}", new string('.', leftAndRightDots), new string('.', midDots));
            leftAndRightDots++;
            midDots--;
        }

        Console.WriteLine("{0}{1}{0}", new string('.', (width - 5) /2), new string('*', 5));
        Console.WriteLine(new string('*', width));
        Console.WriteLine("{0}{1}{0}", new string('.', (width - 5) / 2), new string('*', 5));

        

        for (int i = 0; i < n - 2; i++)
        {
            Console.WriteLine("{0}*{1}*{1}*{0}", new string('.', leftAndRightDots), new string('.', midDots));
            leftAndRightDots--;
            midDots++;
        }

        Console.WriteLine("*{0}*{0}*", new string('.', (width - 3) / 2));
    }
}
