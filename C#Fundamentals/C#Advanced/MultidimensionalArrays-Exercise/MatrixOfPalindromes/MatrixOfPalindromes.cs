using System;
using System.Linq;

class MatrixOfPalindromes
{
    static void Main()
    {
        int[] sizes = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        int rows = sizes[0];
        int cols = sizes[1];

        string[][] matrix = new string[rows][];

        char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        for (int row = 0; row < matrix.Length; row++)
        {
            matrix[row] = new string[cols];

            for (int col = 0; col < matrix[row].Length; col++)
            {
                char firstLetter = alphabet[row];
                char middleLetter = alphabet[row + col];

                matrix[row][col] = $"{firstLetter}{middleLetter}{firstLetter} ";

                Console.Write($"{matrix[row][col]}");
            }
            Console.WriteLine();
        }
    }
}