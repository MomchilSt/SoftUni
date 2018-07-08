using System;
using System.Linq;

class P4DrawAFilledSquare
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        PrintTopAndBottom(n);

        for (int i = 0; i < n - 2; i++)
        {
            PrintMiddleRows(n);
        }

        PrintTopAndBottom(n);
    }

    static void PrintTopAndBottom(int n)
    {
        Console.WriteLine(new string('-', n * 2));
    }

    static void PrintMiddleRows(int n)
    {
        Console.Write('-');
        for (int i = 1; i < n; i++)
        {
            Console.Write("\\/");
        }
        Console.WriteLine('-');
    }
}
