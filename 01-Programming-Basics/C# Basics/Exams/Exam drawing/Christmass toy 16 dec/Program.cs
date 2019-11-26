using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int and = n + 2;
        int width = 5 * n;
        int stars = 1;
        int dash = (width - (n + 4)) / 2;

        Console.WriteLine("{0}{1}{0}", new string('-', (width - n) / 2), new string('*', n));
        

        for (int i = 0; i < n / 2; i++)
        {
            //Console.WriteLine("{0}{1}{2}{1}{0}", new string('-', dash), new string('*', stars), new string('&', and));
            Console.Write(new string('-', dash));
            Console.Write(new string('*', stars + i));
            Console.Write(new string('&', and));
            Console.Write(new string('*', stars + i));
            Console.WriteLine(new string('-', dash));
            and += 2;
            dash -= 2;
        }

        stars = 2;
        dash = n - 1;
        

        for (int i = 0; i < n / 2; i++)         //n= 6 must add 4 to and //n=4
        {
            //Console.WriteLine("{0}{1}{2}{1}{0}", new string('-', n - 1), new string('*', stars), new string('~', and));
            Console.Write(new string('-', n - 1 - i));
            Console.Write("**");
            Console.Write(new string('~', width - 4 -2 * n + 2 + 2 * i));
            Console.Write("**");
            Console.WriteLine(new string('-', n - 1 - i));
        }
                            //pri 4 = 14 dashes   //pri 6 = 22 dashes
        Console.WriteLine("{0}*{1}*{0}", new string('-', n / 2), new string('|', width - (n + 2)));


        for (int i = 0; i < n / 2; i++)         
        {
            int wave = width - 4 - 2 * n + 2 + 2 * i;
            int dashes = (n - 1 - i * 1);

            Console.Write(new string('-', dashes - 1));
            Console.Write("**");
            Console.Write(new string('~', wave +2));
            Console.Write("**");
            Console.WriteLine(new string('-', dashes -1));
            wave -= 2;

        }

        for (int i = 0; i < n / 2; i++)
        {
            stars = n / 2;
            and -= 2;
           var dashes = n / 2;
            Console.Write(new string('-', dashes + 2));
            Console.Write(new string('*', stars - i));
            Console.Write(new string('&', and));
            Console.Write(new string('*', stars - i));
            Console.WriteLine(new string('-', dashes + 2));

        }
    }
}
