using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        long[] numbers = Console.ReadLine()
            .Split()
            .Select(long.Parse)
            .ToArray();

        long n = long.Parse(Console.ReadLine());

        long sum = 0;
        int counter = 0;
        bool isMatch = numbers.Contains(n);


        if (isMatch == false)
        {
            Console.WriteLine("No occurrences were found!");
            return;
        }

        for (int i = numbers.Length - 1; i >= 0; i--)
        {
                counter++;

            if (numbers[i] == n)
            {
                break;    
            }
        }
        for (int i = 0; i < numbers.Length - counter; i++)
        {
            sum += numbers[i];
        }
        Console.WriteLine(sum);
    }
}