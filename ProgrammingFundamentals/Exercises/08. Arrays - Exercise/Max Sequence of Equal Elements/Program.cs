using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int len = 1;
        int bestStart = 0;
        int bestLenght = 1;

        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] == numbers[i - 1])
            {
                len++;
                if (len > bestLenght)
                {
                    bestLenght = len;
                    bestStart = numbers[i];
                }
            }
            else
            {
                len = 1;
            }
        }
        for (int i = 0; i < bestLenght; i++)
        {
            Console.Write(bestStart + " ");
        }
        Console.WriteLine();
    }
}