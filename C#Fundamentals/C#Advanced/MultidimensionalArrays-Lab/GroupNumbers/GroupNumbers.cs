using System;
using System.Collections.Generic;
using System.Linq;

class GroupNumbers
{
    static void Main()
    {
        int[] nums = Console.ReadLine()
            .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int[][] matrix = new int[3][];

        for (int i = 0; i <= 2; i++)
        {
            matrix[i] = nums.Where(x => Math.Abs(x % 3) == i).ToArray();
        }

        for (int i = 0; i < matrix.Length; i++)
        {
            Console.WriteLine(string.Join(" ", matrix[i]));
        }
    }
}
