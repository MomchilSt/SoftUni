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

        long sum = 0;
        long index = 0;
        int maxIndex = numbers.Length - 1;

        while (true)
        {
            sum += numbers[index];

            long nextIndex = index + numbers[index];

            if (nextIndex <= maxIndex)
            {
                index = nextIndex;
                continue;
            }

            nextIndex = index - numbers[index];

            if (nextIndex >= 0)
            {
                index = nextIndex;
                continue;
            }

            break;
        }
        Console.WriteLine(sum);
    }
}
