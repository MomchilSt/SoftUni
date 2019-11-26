using System;

class P9MultiplyEvenByOdds
{
    static void Main()
    {
        int n = Math.Abs(int.Parse(Console.ReadLine()));
        Console.WriteLine(GetMultipleOfEvensAndOdds(n));
    }

    static int GetSumOfOddDigits(int n)
    {
        int sum = 0;
        while (n > 0)
        {
            int lastDigit = n % 10;
            if (lastDigit % 2 != 0)
            {
                sum += lastDigit;
            }
            n /= 10;
        }
        return sum;
    }

    static int GetSumOfEvenDigits(int n)
    {
        int sum = 0;
        while (n > 0)
        {
            int lastDigit = n % 10;
            if (lastDigit % 2 == 0)
            {
                sum += lastDigit;
            }
            n /= 10;
        }
        return sum;
    }

    static int GetMultipleOfEvensAndOdds(int n)
    {
        int sumEvens = GetSumOfEvenDigits(n);
        int sumOdds = GetSumOfOddDigits(n);
        return sumEvens * sumOdds;
    }
}
