using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int rotations = int.Parse(Console.ReadLine());

        int[] sumOfRotations = new int[numbers.Length];

        for (int i = 0; i < rotations; i++)
        {
            int[] rotated = new int[numbers.Length];
            rotated[0] = numbers[numbers.Length - 1];

            for (int j = 1; j < rotated.Length; j++)
            {
                rotated[j] = numbers[j - 1];
            }

            for (int k = 0; k < sumOfRotations.Length; k++) 
            {
                sumOfRotations[k] += rotated[k];
            }

            numbers = rotated;
        }
        Console.WriteLine(string.Join(" ", sumOfRotations));
    }
}