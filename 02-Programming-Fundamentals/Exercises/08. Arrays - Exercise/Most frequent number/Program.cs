using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int number = 0;
        int count = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            int tempNum = numbers[i];
            int tempCount = 0;

            for (int k = 0; k < numbers.Length; k++)
            {
                if (numbers[k] == tempNum)
                {
                    tempCount++;
                }
                if (tempCount > count)
                {
                    number = tempNum;
                    count = tempCount;
                }
            }
        }
        Console.WriteLine(number);
    }
}
