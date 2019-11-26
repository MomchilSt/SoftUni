using System;
using System.Linq;

class MaximumSum
{
    static void Main()
    {
        int[] sizes = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int rowSize = sizes[0];

        int[][] matrix = new int[rowSize][];

        for (int i = 0; i < rowSize; i++)
        {
            matrix[i] = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

        }

        int biggestSum = int.MinValue;
        int startingRow = 0;
        int startingCol = 0;

        for (int row = 0; row < rowSize - 2; row++)
        {
            for (int col = 0; col < matrix[row].Length - 2; col++)
            {
                int firstRow = matrix[row][col] +
                    matrix[row][col + 1] +
                    matrix[row][col + 2];

                int secondRow = matrix[row + 1][col] +
                matrix[row + 1][col + 1] +
                matrix[row + 1][col + 2];

                int thirdRow = matrix[row + 2][col] +
                matrix[row + 2][col + 1] +
                matrix[row + 2][col + 2];

                if (biggestSum < firstRow + secondRow + thirdRow)
                {
                    biggestSum = firstRow + secondRow + thirdRow;
                    startingRow = row;
                    startingCol = col;
                    
                }
            }
        }

        Console.WriteLine($"Sum = {biggestSum}");
        Console.WriteLine($"{matrix[startingRow][startingCol]} {matrix[startingRow][startingCol + 1]} {matrix[startingRow][startingCol + 2]}");
        Console.WriteLine($"{matrix[startingRow + 1][startingCol]} {matrix[startingRow + 1][startingCol + 1]} {matrix[startingRow + 1][startingCol + 2]}");
        Console.WriteLine($"{matrix[startingRow + 2][startingCol]} {matrix[startingRow + 2][startingCol + 1]} {matrix[startingRow + 2][startingCol + 2]}");
    }
}