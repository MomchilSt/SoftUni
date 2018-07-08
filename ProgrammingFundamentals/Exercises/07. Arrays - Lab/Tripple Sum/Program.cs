using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        bool isFound = false;

        for (int m1 = 0; m1 < numbers.Length; m1++)
        {

            for (int m2 = m1 + 1; m2 < numbers.Length; m2++)
            {

                for (int m3 = 0; m3 < numbers.Length; m3++)
                {
                    if (numbers[m1] + numbers[m2] == numbers[m3])
                    {
                        Console.WriteLine($"{numbers[m1]} + {numbers[m2]} == {numbers[m3]}");
                        isFound = true;
                        break;
                    }
                }
            }
        }
        if (!isFound)
        {
            Console.WriteLine("No");
        }
    }
}
