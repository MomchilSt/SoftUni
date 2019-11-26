using System;
using System.Linq;

class DiagonalDifference
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[][] matrix = new int[n][];

        for (int i = 0; i < n; i++)
        {
            matrix[i] = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        int primary = 0;
        int secondary = 0;

        for (int i = 0; i < n; i++)
        {
            primary += matrix[i][i];
            secondary += matrix[i][n - i - 1];
        }

        int diagDiffSum = Math.Abs(primary - secondary);

        Console.WriteLine(diagDiffSum);
    }
}