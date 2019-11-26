using System;
using System.Linq;

class Sneaking
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char[][] matrix = new char[n][];

        int samsRow = 0;
        int samsCol = 0;

        for (int m1 = 0; m1 < n; m1++)
        {
            matrix[m1] = Console.ReadLine().ToCharArray();

            if (matrix[m1].Contains('S'))
            {
                samsRow = m1;
                samsCol = Array.IndexOf(matrix[m1], 'S');
            }
        }

        char[] directions = Console.ReadLine().ToCharArray();

        for (int i = 0; i < directions.Length; i++)
        {
            MoveEnemies(matrix);

            if (matrix[samsRow].Contains('d') && Array.IndexOf(matrix[samsRow], 'd') > samsCol)
            {
                matrix[samsRow][samsCol] = 'X';
                Console.WriteLine($"Sam died at {samsRow}, {samsCol}");
                break;
            }
            else if (matrix[samsRow].Contains('b') && Array.IndexOf(matrix[samsRow], 'b') < samsCol)
            {
                matrix[samsRow][samsCol] = 'X';
                Console.WriteLine($"Sam died at {samsRow}, {samsCol}");
                break;
            }

            MoveSam(matrix, ref samsRow, ref samsCol, directions[i]);

            if (matrix[samsRow].Contains('N'))
            {
                int colOfN = Array.IndexOf(matrix[samsRow], 'N');
                matrix[samsRow][colOfN] = 'X';
                Console.WriteLine("Nikoladze killed!");
                break;
            }
        }

        foreach (var row in matrix)
        {
            Console.WriteLine(string.Join("", row));
        }
    }

    private static void MoveSam(char[][] matrix, ref int samsRow, ref int samsCol, char direction)
    {
        matrix[samsRow][samsCol] = '.';
        switch (direction)
        {
            case 'U': samsRow--; break;
            case 'D': samsRow++; break;
            case 'L': samsCol--; break;
            case 'R': samsCol++; break;
            default:
                break;
        }
        matrix[samsRow][samsCol] = 'S';
    }

    private static void MoveEnemies(char[][] matrix)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            int indexD = Array.IndexOf(matrix[i], 'd');
            int indexB = Array.IndexOf(matrix[i], 'b');

            if (indexD != -1)
            {
                if (indexD == 0)
                {
                    matrix[i][indexD] = 'b';
                }
                else
                {
                    matrix[i][indexD] = '.';
                    indexD--;
                    matrix[i][indexD] = 'd';
                }
            }
            else if (indexB != -1)
            {
                if (indexB == matrix[i].Length - 1)
                {
                    matrix[i][indexB] = 'd';
                }
                else
                {
                    matrix[i][indexB] = '.';
                    indexB++;
                    matrix[i][indexB] = 'b';
                }
            }
        }
    }
}
