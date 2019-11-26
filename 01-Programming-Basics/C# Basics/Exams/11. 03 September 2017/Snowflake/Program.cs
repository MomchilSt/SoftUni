using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int width = 2 * n + 3;
        int dots = n;

        //first section
        for (int i = 0; i < n - 1 ; i++)
        {
            Console.WriteLine("{0}*{1}*{1}*{0}",
                new string('.', i),
                new string('.', dots));
            dots--;
        }

        //static rows
        Console.WriteLine("{0}*****{0}", new string('.', (width - 5) / 2));
        Console.WriteLine(new string('*', width));
        Console.WriteLine("{0}*****{0}", new string('.', (width - 5) / 2));

        //last section
        dots = n - 2;
        for (int i = 0; i < n - 1; i++)
        {
            Console.WriteLine("{0}*{1}*{1}*{0}",
                new string('.', dots),
                new string('.', 2 + i));
            dots--;

        }

        //Console.WriteLine("*{0}*{0}*", new string('.', (width - 3) / 2));
    }
}
