using System;

class PascalTriangle
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        long[][] matrix = new long[n][];

        for (int i = 0; i < n; i++)
        {
            long[] row = new long[i + 1];
            row[0] = 1;
            row[i] = 1;

            for (int j = 1; j < i; j++)
            {
                row[j] = matrix[i - 1][j - 1] + matrix[i - 1][j];
            }

            matrix[i] = row;
        }

        foreach (long[] row in matrix)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }
}