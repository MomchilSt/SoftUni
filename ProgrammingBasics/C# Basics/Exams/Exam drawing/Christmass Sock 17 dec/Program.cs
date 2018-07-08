using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int width = n * 2 + 2;

        char dash = '-';
        char star = '*';
        char wave = '~';

        Console.WriteLine("|{0}|", new string(dash, width - 2));
        Console.WriteLine("|{0}|", new string(star, width - 2));
        Console.WriteLine("|{0}|", new string(dash, width - 2));

        int symbol = 2;
        int rombDashes = n - 1;
        for (int i = 0; i < n - 1; i++)
        {
            Console.WriteLine("|{0}{1}{0}|", new string(dash, rombDashes), new string(wave, symbol));
            rombDashes--;
            symbol+=2;
        }
        for (int i = 0; i < n - 2; i++)
        {
            Console.WriteLine("|{0}{1}{0}|", new string(dash, rombDashes + 2), new string(wave, symbol - 4));
            rombDashes ++;
            symbol-=2;
        }

        int dots = 2 * n + 1;
        int endDashes = 0;

        for (int i = 0; i < n / 2; i++)
        {
            Console.WriteLine(@"{0}\{1}\", new string(dash, endDashes), new string('.', dots));
            endDashes++;
        }

        
        Console.WriteLine(@"{0}\{1}MERRY{1}\", new string(dash, endDashes), new string('.', (dots - 5) / 2));
        endDashes++;
        Console.WriteLine(@"{0}\{1}\", new string(dash, endDashes), new string('.', dots));
        endDashes++;
        Console.WriteLine(@"{0}\{1}X-MAS{1}\", new string(dash, endDashes), new string('.', (dots - 5) / 2));
        endDashes++;

        for (int i = 0; i < (n - 1) / 2; i++)
        {
            Console.WriteLine(@"{0}\{1}\", new string(dash, endDashes), new string('.', dots));
            endDashes++;
        }

        Console.WriteLine(@"{0}\{1})", new string(dash, endDashes), new string('_', dots) );
    }
}
