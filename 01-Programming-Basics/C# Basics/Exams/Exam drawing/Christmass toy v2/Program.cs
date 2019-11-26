using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        int n = int.Parse(Console.ReadLine());

        int width = 5 * n;

        // First line
        Console.WriteLine("{0}{1}{0}", new string('-', (width - n) / 2), new string('*', n));

        int and = n + 2;
        int stars = 1;
        int dashes = (width - (stars * 2 + and)) / 2;

        List<string> lines = new List<string>();

        // Top lines 
        for (int i = 0; i < n / 2; i++)
        {
            string dashesPrint = new string('-', dashes);
            string starsPrint = new string('*', stars + i);
            string andPrint = new string('&', and);

            string line = string.Format("{0}{1}{2}{1}{0}", dashesPrint, starsPrint, andPrint);
            Console.WriteLine(line);
            lines.Add(line);

            and += 2;
            dashes -= 2;
        }

        dashes = n - 1;
        stars = 2;
        int waves = (width - (2 * stars)) - (2 * dashes);

        for (int i = 0; i < n / 2; i++)
        {
            string dashesPrint = new string('-', dashes);
            string starsPrint = new string('*', stars);
            string wavesPrint = new string('~', waves);

            string line = string.Format("{0}{1}{2}{1}{0}", dashesPrint, starsPrint, wavesPrint);
            Console.WriteLine(line);
            lines.Add(line);

            waves += 2;
            dashes--;

        }

        // Middle line
        Console.WriteLine("{0}*{1}*{0}", new string('-', n / 2), new string('|', width - (n + 2)));

        lines.Reverse();

        Console.WriteLine(string.Join("\n", lines));

        // Last Line
        Console.WriteLine("{0}{1}{0}", new string('-', (width - n) / 2), new string('*', n));
    }
}

