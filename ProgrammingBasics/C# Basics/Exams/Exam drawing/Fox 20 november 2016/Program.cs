using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int width = 2 * n + 3;
        int stars = 1;
        int midSection = (width - 2) - (stars * 2);

            //top section

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(@"{0}\{1}/{0}", new string('*', stars), new string('-', midSection));
            midSection -= 2;
            stars++;
        }

        //mid section

        stars = stars / 2 - 1;
        midSection = n;

        for (int i = 0; i < n/3; i++)
        {
            
            Console.WriteLine(@"|{0}\{1}/{0}|", new string('*', stars), new string('*', midSection));
            midSection -= 2;
            stars++;
        }

        //bottom section

        int dashes = 1;
        midSection = (width - 2) - (dashes * 2);
        
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(@"{0}\{1}/{0}", new string('-', dashes + i), new string('*', midSection));
            midSection -= 2;
        }

    }
}
