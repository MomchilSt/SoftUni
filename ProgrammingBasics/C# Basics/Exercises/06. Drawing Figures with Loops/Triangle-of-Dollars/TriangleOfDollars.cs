using System;

class TriangleOfDollars
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Console.Write("$");
            for (int c = 1; c < i; c++)
            {
                Console.Write(" $");
            }
            Console.WriteLine();
        }
    }
}
