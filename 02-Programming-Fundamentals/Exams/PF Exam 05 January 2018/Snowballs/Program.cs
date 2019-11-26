using System;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int bestSnow = 0;
        int bestTime = 0;
        int bestQuality = 0;
        BigInteger bestSum = 0;

        for (int i = 0; i < n; i++)
        {
            int snowballSnow = int.Parse(Console.ReadLine());
            int snowballTime = int.Parse(Console.ReadLine());
            int snowballQuality = int.Parse(Console.ReadLine());
            BigInteger sum = 0;

            sum = (snowballSnow / snowballTime);
            sum = BigInteger.Pow(sum, snowballQuality);

            if (sum > bestSum)
            {
                bestSum = sum;
                bestSnow = snowballSnow;
                bestTime = snowballTime;
                bestQuality = snowballQuality;
            }
        }


        Console.WriteLine($"{bestSnow} : {bestTime} = {bestSum} ({bestQuality})");
    }
}
