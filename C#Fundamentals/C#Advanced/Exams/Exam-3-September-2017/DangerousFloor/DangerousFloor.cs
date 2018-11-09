using System;
using System.Linq;

class DangerousFloor
{
    static char[][] matrix;

    static void Main()
    {
        matrix = new char[8][];

        for (int row = 0; row < matrix.Length; row++)
        {
            matrix[row] = Console.ReadLine().Split(',').Select(char.Parse).ToArray();
        }

        while (true)
        {
            string moves = Console.ReadLine();
            if (moves == "END")
            {
                break;
            }

            char piece = moves[0];
            int startRow = int.Parse(moves[1].ToString());
            int startCol = int.Parse(moves[2].ToString());
            int endRow = int.Parse(moves[4].ToString());
            int endCol = int.Parse(moves[5].ToString());


            if (matrix[startRow][startCol] != piece)
            {
                Console.WriteLine("There is no such a piece!");
                continue;
            }

            if (!IsMoveValid(piece, startRow, startCol, endRow, endCol))
            {
                Console.WriteLine("Invalid move!");
                continue;
            }

            if (!OutOfBoard(endRow, endCol)) 
            {
                Console.WriteLine("Move go out of board!");
                continue;
            }

             matrix[endRow][endCol] = piece;
             matrix[startRow][startCol] = 'x';
        }
    }

    private static bool OutOfBoard(int row, int col)
    {
        bool validRow = row >= 0 && row <= 7;
        bool validCol = col >= 0 && col <= 7;

        return validRow && validCol;
    }

    private static bool IsMoveValid(char piece, int startRow, int startCol, int endRow, int endCol)
    {
        switch (piece)
        {
            case 'P':
                return ValidPawnMove(startRow, startCol, endRow, endCol);

            case 'R':
                return ValidStreightMove(startRow, startCol, endRow, endCol);

            case 'B':
                return ValidDiagonalMove(startRow, startCol, endRow, endCol);

            case 'Q':
                return ValidStreightMove(startRow, startCol, endRow, endCol) ||
                    ValidDiagonalMove(startRow, startCol, endRow, endCol);

            case 'K':
                return ValidKingMove(startRow, startCol, endRow, endCol);

            default:
                throw new Exception();
        }
    }

    private static bool ValidKingMove(int startRow, int startCol, int endRow, int endCol)
    {
        bool rowMove = Math.Abs(startRow - endRow) == 1 
            && Math.Abs(startCol - endCol) == 0;

        bool colMove = Math.Abs(startCol - endCol) == 1
            && Math.Abs(startRow - endRow) == 0;

        bool diagonalMove = Math.Abs(startRow - endRow) == 1
            && Math.Abs(startCol - endCol) == 1;

        return rowMove || colMove || diagonalMove;
    }

    private static bool ValidDiagonalMove(int startRow, int startCol, int endRow, int endCol)
    {
        return Math.Abs(startRow - endRow) == Math.Abs(startCol - endCol);
    }

    private static bool ValidStreightMove(int startRow, int startCol, int endRow, int endCol)
    {
        bool sameRow = startRow == endRow;
        bool sameCol = startCol == endCol;

        return sameRow || sameCol;
    }

    private static bool ValidPawnMove(int startRow, int startCol, int endRow, int endCol)
    {
        bool validColumn = startCol == endCol;
        bool validRow = startRow - 1 == endRow;

        return validColumn && validRow;
    }
}
