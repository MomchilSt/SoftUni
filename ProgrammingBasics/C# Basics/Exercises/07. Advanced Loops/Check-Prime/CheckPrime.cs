using System;

class CheckPrime
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int divisor = 2;

        if (n < 2)
        {
            Console.WriteLine("Not Prime");
            return;
        }

        while (divisor <= n / 2)
        {
            if (n % divisor == 0)
            {
                Console.WriteLine("Not Prime");
                return;
            }
            divisor++;
        }

        Console.WriteLine("Prime");
    }
}
