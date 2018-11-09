using System;
using System.Linq;

class SquaresInMatrix
{
    static void Main()
    {
        int[] sizes = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int rowSize = sizes[0];

        char[][] matrix = new char[rowSize][];

        for (int i = 0; i < rowSize; i++)
        {
            matrix[i] = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();
        }

        int equalSquares = 0;

        for (int row = 0; row < rowSize - 1; row++)
        {
            for (int col = 0; col < matrix[row].Length - 1; col++)
            {
                if (matrix[row][col] == matrix[row][col + 1] &&
                    matrix[row][col] == matrix[row + 1][col] &&
                    matrix[row][col] == matrix[row + 1][col + 1])
                {
                    equalSquares++;
                }
            }
        }
        Console.WriteLine(equalSquares);
    }
}