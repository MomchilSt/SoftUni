using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        for (int m1 = 0; m1 < numbers.Length; m1++)
        {
            int leftSum = 0;
            int rightSum = 0;

            for (int m2 = 0; m2 < m1; m2++)
            {
                leftSum += numbers[m2];
            }

            for (int m2 = m1 +1; m2 < numbers.Length; m2++)
            {
                rightSum += numbers[m2];
            }

            if (leftSum == rightSum)
            {
                Console.WriteLine(m1);
                return;
            }
        }
        Console.WriteLine("no");
    }
}
