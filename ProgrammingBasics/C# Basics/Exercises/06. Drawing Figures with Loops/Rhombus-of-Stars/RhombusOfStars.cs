using System;

class RhombusOfStars
{
    static void Main()
    {
        Console.WriteLine("Input number from 2 to 40:");
        int n = int.Parse(Console.ReadLine());

        for (int i = 2; i <= n; i++)
        {
            Console.Write(new string(' ', n - i + 1));
            Console.Write("*");
            for (int c = 2; c < i; c++)
            {
                Console.Write(" *");
            }
            Console.WriteLine();
        }

        for (int k = n; k >= 1; k--)
        {
            Console.Write(new string(' ', n - k));
            Console.Write("*");
            for (int l = 1; l < k; l++)
            {
                Console.Write(" *");
            }
            Console.WriteLine();
        }
        Console.ReadLine();
    }
}
