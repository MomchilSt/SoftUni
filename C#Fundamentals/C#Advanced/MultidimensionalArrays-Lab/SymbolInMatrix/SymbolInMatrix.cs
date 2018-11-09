using System;

class SymbolInMatrix
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        char[][] matrix = new char [n][];

        for (int row = 0; row < matrix.Length; row++)
        {
            matrix[row] = Console.ReadLine().ToCharArray();
        }

        char checkChar = char.Parse(Console.ReadLine());

        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                if (matrix[row][col] == checkChar)
                {
                    Console.WriteLine($"({row}, {col})");
                    return;
                }
            }
        }

        Console.WriteLine($"{checkChar} does not occur in the matrix");
    }
}