using System;

class KnightGame
{
    static void Main()
    {
        int boardSize = int.Parse(Console.ReadLine());
        char[][] board = new char[boardSize][];

        for (int row = 0; row < board.Length; row++)
        {
            board[row] = Console.ReadLine().ToCharArray();
        }
        int maxRow = 0;
        int maxCol = 0;
        int maxAttacked = 0;
        int removedKnights = 0;

        do
        {
            if (maxAttacked > 0)
            {
                board[maxRow][maxCol] = '0';
                maxAttacked = 0;
                removedKnights++;
            }
            int currentAttackPositions = 0;
            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    if (board[row][col] == 'K')
                    {
                        currentAttackPositions = CalculateAttackedPositions(row, col, board);
                        if (currentAttackPositions > maxAttacked)
                        {
                            maxAttacked = currentAttackPositions;
                            maxCol = col;
                            maxRow = row;
                        }
                    }
                }
            }

        } while (maxAttacked > 0);

        Console.WriteLine(removedKnights);
    }

    static bool IsPositionAttacked(int row, int col, char[][] board)
    {
        return IsPositionWithinBoard(row, col, board[0].Length)
            && board[row][col] == 'K';
    }

    static bool IsPositionWithinBoard(int row, int col, int boardSize)
    {
        return row >= 0 && row < boardSize && col >= 0 && col < boardSize;
    }

    static int CalculateAttackedPositions(int row, int col, char[][] board)
    {
        int currentAttackedPositions = 0;
        if (IsPositionAttacked(row - 2, col - 1, board)) currentAttackedPositions++;
        if (IsPositionAttacked(row - 2, col + 1, board)) currentAttackedPositions++;
        if (IsPositionAttacked(row - 1, col - 2, board)) currentAttackedPositions++;
        if (IsPositionAttacked(row - 1, col + 2, board)) currentAttackedPositions++;
        if (IsPositionAttacked(row + 1, col - 2, board)) currentAttackedPositions++;
        if (IsPositionAttacked(row + 1, col + 2, board)) currentAttackedPositions++;
        if (IsPositionAttacked(row + 2, col - 1, board)) currentAttackedPositions++;
        if (IsPositionAttacked(row + 2, col + 1, board)) currentAttackedPositions++;
        return currentAttackedPositions;
    }
}