using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int width = (2 * n) - 1;

        //first two rows
        Console.WriteLine("@{0}@{0}@", new string(' ', (width - 3) / 2));
        Console.WriteLine("**{0}*{0}**", new string(' ', (width - 5) / 2));

        //first section
        int leftAndRight = 1;
        int midFill = 1;
        int spaces = ((width - 8) - (leftAndRight - midFill)) / 2;
        for (int i = 1; i < n / 2 - 1; i++)
        {
            Console.WriteLine("*{0}*{1}*{2}*{1}*{0}*", 
                new string('.', leftAndRight),
                new string(' ', spaces),
                new string('.', midFill));
            leftAndRight++;
            spaces -=2;
            midFill += 2;
        }

        //four static rows
        
        Console.WriteLine("*{0}*{1}*{0}*",
            new string('.', leftAndRight),
            new string('.', midFill),
            new string('.', leftAndRight));

        Console.WriteLine("*{0}{1}.{1}{0}*",
            new string('.', n / 2),
            new string('*', (n / 2) -2));

        Console.WriteLine(new string('*', width));
        Console.WriteLine(new string('*', width));
    }
}
