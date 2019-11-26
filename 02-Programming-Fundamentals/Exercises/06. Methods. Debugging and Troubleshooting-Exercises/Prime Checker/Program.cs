using System;

class P6PrimeChecker
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        Console.WriteLine(IsPrime(n));
    }
    static bool IsPrime(long n)
    {
        bool isNumberAPrime = n > 1;
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
            {
                isNumberAPrime = false;
                return false;
            }
        }
        return isNumberAPrime;
    }
}
