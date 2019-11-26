using System;
using System.Numerics;

class P14FactorialTrailingZeroes
{
    static void Main(string[] args)
    {
        BigInteger n = BigInteger.Parse(Console.ReadLine());
        BigInteger result = n;

        for (int i = 1; i < n; i++)
        {
            result = result * i;
        }


        CountZeroes(result);
    }

    static void CountZeroes(BigInteger result)
    {
        string temp = result.ToString();    
        int counter = 0;

        foreach (var character in temp)
        {
            if (character == '0')
            {
                counter++;
            }
        }
        Console.WriteLine($"{result} -> {counter} trailing zeroes");
    }

    /*static void CountZeroes(BigInteger result)
    {
        int count = 0;
        string resultAsString = result.ToString();
        foreach (char character in resultAsString)
        {
            if (character == '0')
            {
                count++;
            }
        }
        Console.WriteLine($"{result} -> {count} trailing zeroes");
    } */
}

