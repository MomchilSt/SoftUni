using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int width = 2 * n + 1;

        Console.WriteLine(new string('*', width));
        Console.WriteLine($".*{new string(' ', width - 4)}*.");

        int leftAndRight = 2;
        int fill = width - ((leftAndRight * 2)) - 2;

        for (int i = 0; i < n - 2; i++)
        {
            Console.WriteLine("{0}*{1}*{0}", new string('.', leftAndRight), new string('@', fill) );
            fill -= 2;
            leftAndRight++;
        }

        Console.WriteLine("{0}*{0}", new string('.', (width - 1) / 2));

        for (int i = 0; i < n - 2; i++)
        {
            Console.WriteLine("{0}*{1}@{1}*{0}", 
                new string('.', ((width - 3) - 2*i) / 2 ),
                new string(' ', i));
        }

        Console.WriteLine($".*{new string('@', (width - 4))}*.");
        Console.WriteLine(new string('*', width));
    }
}
