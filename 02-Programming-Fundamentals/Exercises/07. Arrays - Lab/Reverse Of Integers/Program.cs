using System;

class Program
{
    static void Main(string[] args)
    {
        int nums = int.Parse(Console.ReadLine());
        int[] numsInput = new int [nums];

        for (int i = 0; i < nums; i++)
        {
            int n = int.Parse(Console.ReadLine());
            numsInput[i] = n;
        }

        for (int i = numsInput.Length - 1; i >= 0; i--)
        {
            Console.Write(numsInput[i] + " ");
        }
        Console.WriteLine();
    }
}