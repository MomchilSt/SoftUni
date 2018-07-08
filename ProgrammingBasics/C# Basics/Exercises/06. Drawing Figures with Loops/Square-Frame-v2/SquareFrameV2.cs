using System;
using System.Linq;

class SquareFrameV2
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string plus1 = "+";
        string plus2 = " +";
        var tire = string.Join("", Enumerable.Repeat(" -", n - 2));
        string line1 = "|";
        string line2 = " |";

        Console.WriteLine("{0}{1}{2}", plus1, tire, plus2);

        for (int i = 0; i < n - 2; i++)
        {
            Console.WriteLine("{0}{1}{2}", line1, tire, line2);
        }

        Console.WriteLine("{0}{1}{2}", plus1, tire, plus2);
    }
}
