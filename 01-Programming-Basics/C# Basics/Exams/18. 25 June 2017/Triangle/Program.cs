using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int width = (4 * n) + 1;

        //first row
        Console.WriteLine(new string('#',width));

        //first section
        int midSpaces = 1;
        int leftRightDots = 1;
        int fill = (width - midSpaces - leftRightDots) / 2;
        for (int i = 1; i <= n / 2; i++)
        {
            Console.WriteLine("{0}{1}{2}{1}{0}",
                new string('.', leftRightDots),
                new string('#', fill),
                new string(' ', midSpaces));
            midSpaces += 2;
            leftRightDots++;
            fill -= 2;
        }

        //mid row
        
        Console.WriteLine("{0}{1}{2}(@){2}{1}{0}",
            new string('.', leftRightDots),
            new string('#', fill),
            new string(' ', (midSpaces - 3) /2 ));

        //second section

        if (n % 2 == 0)
        {
            for (int i = 0; i < n/2 - 1; i++)
            {
                midSpaces += 2;
                fill -= 2;
                leftRightDots++;
                Console.WriteLine("{0}{1}{2}{1}{0}",
                    new string('.', leftRightDots),
                    new string('#', fill),
                    new string(' ', midSpaces));
            }
        }
        else
        {
            for (int i = 0; i < n / 2 ; i++)
            {
                midSpaces += 2;
                fill -= 2;
                leftRightDots++;
                Console.WriteLine("{0}{1}{2}{1}{0}",
                    new string('.', leftRightDots),
                    new string('#', fill),
                    new string(' ', midSpaces));
            }
        }

        //last section
        fill = fill + midSpaces -1;
        leftRightDots = n + 1;
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("{0}{1}{0}",
                new string('.', leftRightDots),
                new string('#', fill));
            fill -= 2;
            leftRightDots++;
        }
    }
}
