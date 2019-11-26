using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int width = 3 * n;
        int spaces = 0;

        //top part

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(@"{0}/{1}\{0}", new string('.', ((width - 2) - spaces) / 2), 
                new string(' ', spaces));
            spaces += 2;
        }

        //first solo row

        Console.WriteLine("{0}{1}{0}", new string('.', n /2), new string('*', width - n));

        //mid part
                                        // string dash = (string.Join("", Enumerable.Repeat("\ ", 1)));

        for (int i = 0; i < n * 2; i++)
        {
            Console.WriteLine("{0}|{1}|{0}", new string('.', n /2), new string('\\', width - (n+2)));
        }

        //last part

        int dots = n / 2;
        int midSection = (width - 2) - (dots * 2);

        for (int i = 0; i < n / 2; i++)
        {
            Console.WriteLine(@"{0}/{1}\{0}", new string('.', dots), new string('*', midSection));
            midSection += 2;
            dots--;
        }
    }
}
