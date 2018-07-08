using System;

class PokeMon
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        long m = long.Parse(Console.ReadLine());
        long y = long.Parse(Console.ReadLine());

        long initialPower = n;
        int counter = 0;

        while (!(n < m))
        {
            n -= m;
            counter++;

            if (((decimal)n / initialPower) * 100.0m == 50.0m)
            {
                if (y != 0)
                {
                    n /= y;
                }
                else
                {
                    n -= m;
                    counter++;
                }
            }
        }

        Console.WriteLine(n);
        Console.WriteLine(counter);
    }
}
