using System;

class KnightGameV2
{
    static void Main()
    {
        int boardSize = int.Parse(Console.ReadLine());
        char[][] board = new char[boardSize][];

        for (int row = 0; row < boardSize; row++)
        {
            board[row] = Console.ReadLine().ToCharArray();
        }

        int maxRow = 0;
        int maxCol = 0;
        int maxAttackedKnights = 0;
        int removeKnights = 0;

        while (true)
        {
            if (maxAttackedKnights > 0)
            {
                board[maxRow][maxCol] = '0';
                maxAttackedKnights = 0;
                removeKnights++;

            }

            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    if (board[row][col] == 'K')
                    {
                        int currentAttackedPositions = CurrentAttackedPositons(board, row, col);
                        if (currentAttackedPositions > maxAttackedKnights)
                        {
                            maxAttackedKnights = currentAttackedPositions;
                            maxCol = col;
                            maxRow = row;
                        }
                    }
                }
            }
           
            if (maxAttackedKnights == 0)
            {
                break;
            }
        }
        Console.WriteLine(removeKnights);
    }

    private static int CurrentAttackedPositons(char[][] board, int row, int col)
    {
        int currentAttackedPositions = 0;

        if (IsAvailable(row - 2, col - 1, board)) currentAttackedPositions++;
        if (IsAvailable(row - 2, col + 1, board)) currentAttackedPositions++;

        if (IsAvailable(row - 1, col + 2, board)) currentAttackedPositions++;
        if (IsAvailable(row - 1, col - 2, board)) currentAttackedPositions++;

        if (IsAvailable(row + 2, col - 1, board)) currentAttackedPositions++;
        if (IsAvailable(row + 2, col + 1, board)) currentAttackedPositions++;

        if (IsAvailable(row + 1, col + 2, board)) currentAttackedPositions++;
        if (IsAvailable(row + 1, col - 2, board)) currentAttackedPositions++;
        return currentAttackedPositions;
    }

    private static bool IsAvailable(int row, int col, char[][] board)
    {
        return IsWithInBoard(row, col, board[0].Length) && board[row][col] == 'K';
    }

    private static bool IsWithInBoard(int row, int col, int boardSize)
    {
        return row >= 0 && row < boardSize && col >= 0 && col < boardSize;
    }
}
