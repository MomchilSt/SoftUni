using System;
using System.Collections.Generic;
using System.Linq;

class SquareWithMaximumSum
{
    static void Main()
    {
        int[] sizes = Console.ReadLine()
            .Split(", ")
            .Select(int.Parse)
            .ToArray();

        int rowSize = sizes[0];
        int colSize = sizes[1];

        int[][] matrix = new int[rowSize][];

        for (int row = 0; row < rowSize; row++)
        {
            matrix[row] = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
        }

        long biggestSum = long.MinValue;
        List<int> results = new List<int>();

        for (int row = 0; row < rowSize - 1; row++)
        {
            for (int col = 0; col < matrix[row].Length - 1; col++)
            {
                int currSum = matrix[row][col] + matrix[row][col + 1]
                    + matrix[row + 1][col] + matrix[row + 1][col + 1];

                if (currSum > biggestSum)
                {
                    biggestSum = currSum;
                    if (results.Count != 0)
                    {
                        results.Clear();
                        results.Add(matrix[row][col]);
                        results.Add(matrix[row][col + 1]);
                        results.Add(matrix[row + 1][col]);
                        results.Add(matrix[row + 1][col + 1]);
                    }
                    else
                    {
                        results.Add(matrix[row][col]);
                        results.Add(matrix[row][col + 1]);
                        results.Add(matrix[row + 1][col]);
                        results.Add(matrix[row + 1][col + 1]);
                    }
                }
            }
        }

        Console.WriteLine($"{results[0]} {results[1]}");
        Console.WriteLine($"{results[2]} {results[3]}");
        Console.WriteLine(biggestSum);
    }
}