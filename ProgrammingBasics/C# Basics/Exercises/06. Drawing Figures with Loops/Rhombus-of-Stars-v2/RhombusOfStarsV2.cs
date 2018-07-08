using System;
using System.Linq;

class RhombusOfStarsV2
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string spaces = "";
        string stars = "";

        for (int i = 1; i <= n - 1; i++)
        {
            spaces = new string(' ', n - i);
            stars = string.Join("", Enumerable.Repeat("* ", i - 1));
            Console.WriteLine("{0}{1}*{0}", spaces, stars);
        }

        stars = string.Join("", Enumerable.Repeat("* ", n - 1));
        Console.WriteLine($"{stars}*");

        for (int k = 1; k <= n - 1; k++)
        {
            spaces = new string(' ', k);
            stars = string.Join("", Enumerable.Repeat("* ", n - k - 1));
            Console.WriteLine("{0}{1}*{0}", spaces, stars);
        }
    }
}
