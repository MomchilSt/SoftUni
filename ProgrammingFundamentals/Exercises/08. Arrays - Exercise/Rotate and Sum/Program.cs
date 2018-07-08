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

        int[] summ = new int[numbers.Length];

        int rotations = int.Parse(Console.ReadLine());

        for (int m1 = 1; m1 <= rotations; m1++)
        {
            for (int m2  = 0; m2 < numbers.Length; m2++)
            {
                int temp = numbers[m2];
                summ[(m2 + m1) % numbers.Length] += temp;
            }
        }
        Console.WriteLine(string.Join(" ", summ));
    }
}
