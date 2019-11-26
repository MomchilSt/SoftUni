using System;
using System.Linq;

class TriangleOfDollarsV2
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string dollar = "$";
            var space_dollar = string.Join("", Enumerable.Repeat(" $", i));
            Console.Write(dollar);
            Console.Write(space_dollar);
            Console.WriteLine();
        }
    }
}
