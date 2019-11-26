using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        int diff = int.Parse(Console.ReadLine());
        int counter = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = numbers.Length - 1; j >= i; j--)
            {
                if (numbers[i] - numbers[j] == diff || numbers[j] - numbers[i] == diff)
                {
                    counter++;
                }
            }
        }
        Console.WriteLine(counter);
    }
}