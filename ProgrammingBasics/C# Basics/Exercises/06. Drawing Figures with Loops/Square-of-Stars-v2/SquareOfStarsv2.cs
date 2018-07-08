using System;
using System.Linq;

class SquareOfStarsv2
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string star = "*";
            var space_star = string.Join("", Enumerable.Repeat(" *", n - 1));
            Console.WriteLine("{0}{1}", star, space_star);
        }
    }
}
