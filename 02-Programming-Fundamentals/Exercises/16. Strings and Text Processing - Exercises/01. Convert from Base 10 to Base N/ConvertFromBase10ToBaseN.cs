using System;
using System.Linq;
using System.Numerics;

class ConvertFromBase10ToBaseN
{
    static void Main()
    {
        BigInteger[] input = Console.ReadLine()
            .Split(' ')
            .Select(x => BigInteger.Parse(x))
            .ToArray();
        BigInteger baseN = input.First();
        BigInteger base10Num = input.Last();

        string baseNNum = string.Empty;
        while (base10Num > 0)
        {
            baseNNum = $"{base10Num % baseN}{baseNNum}";
            base10Num /= baseN;
        }

        Console.WriteLine(baseNNum);
    }
}
