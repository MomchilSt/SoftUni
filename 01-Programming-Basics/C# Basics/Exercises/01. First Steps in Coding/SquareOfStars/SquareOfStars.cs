using System;

class SquareOfStars
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine(new string('*', n));

        {
            Console.WriteLine('*' + new string(' ', n - 2) + '*');
        }

        Console.WriteLine(new string('*', n));
    }
}
