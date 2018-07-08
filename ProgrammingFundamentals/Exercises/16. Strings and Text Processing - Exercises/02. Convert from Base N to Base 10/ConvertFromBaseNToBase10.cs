using System;
using System.Numerics;

class ConvertFromBaseNToBase10
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');

        int baseN = int.Parse(input[0]);
        BigInteger baseNNum = BigInteger.Parse(input[1]);

        BigInteger base10Num = 0;
        for (int i = 0; baseNNum > 0; i++)
        {
            BigInteger digit = baseNNum % 10;
            base10Num += digit * BigInteger.Pow(baseN, i);
            baseNNum /= 10;
        }

        Console.WriteLine(base10Num);
    }
}
