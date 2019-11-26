using System;

class SquareOfStars
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write("*");
            for (int c = 1; c < n; c++)
            {
                Console.Write(" *");
            }
            Console.WriteLine();
        }
    }
}
