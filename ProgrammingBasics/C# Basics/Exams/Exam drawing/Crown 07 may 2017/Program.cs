using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
                                                                            //+4
        int width = (2 * n) - 1;
        int height = (n / 2) + 4;

        Console.WriteLine("@{0}@{0}@",new string(' ', (width - 3) / 2));
        Console.WriteLine("**{0}*{0}**", new string(' ', (width -5) /2));

        for (int i = 0; i < height - 6; i++)            // height - 6
        {
            Console.WriteLine("*{0}*{1}*{2}*{1}*{0}*", new string('.', 1 + i), new string(' ', (width - 9-(4 * i)) / 2), new string('.', 2 * i + 1));
        }
        //Console.WriteLine("*{0}*{1}*{0}*", new string('.', ((n / 2) -1)), new string('.', (n / 2) + 2));
        //Console.WriteLine("*{0}{1}.{1}{0}*", new string('.', n / 2), new string('*', n / 2 - 2));


        Console.WriteLine("*{0}*{1}.{1}*{0}*", new string('.', (n / 2) - 1), new string('.', (n / 2) - 2));
        Console.WriteLine("*{0}{1}.{1}{0}*", new string('.', n / 2), new string('*', (width - 3 - n) / 2));

        Console.WriteLine(new string('*', width));
        Console.WriteLine(new string('*', width));
    }
}
