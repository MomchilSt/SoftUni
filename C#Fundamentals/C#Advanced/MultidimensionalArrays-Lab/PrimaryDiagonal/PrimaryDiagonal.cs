﻿using System;
using System.Linq;

class PrimaryDiagonal
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];

        for (int row = 0; row < n; row++)
        {
            int[] colElements = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int col = 0; col < n; col++)
            {
                matrix[row, col] = colElements[col];
            }
        }

        int sum = 0;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
              sum += matrix[row, row];       
        }

        Console.WriteLine(sum);
    }
}
