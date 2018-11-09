using System;
using System.Linq;

class Miner
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var directions = Console.ReadLine().Split();

        bool gameOver = false;
        bool wins = false;

        var board = new char[n][];
        int coals = 0;

        int minerRow = 0;
        int minerCol = 0;

        for (int row = 0; row < board.Length; row++)
        {
            board[row] = Console.ReadLine().Split().Select(char.Parse).ToArray();

            if (board[row].Contains('s'))
            {
                minerRow = row;
                minerCol = Array.IndexOf(board[row], 's');
            }
        }

        for (int i = 0; i < directions.Length; i++)
        {
            bool isAvailable = CheckIfInRange(board, minerRow, minerCol, directions[i]);

            switch (directions[i])
            {
                case "left":
                    if (isAvailable == false)
                    {
                        continue;
                    }

                    if (board[minerRow][minerCol - 1] == 'e')
                    {
                        minerCol--;
                        gameOver = true;
                        break;
                    }

                    MoveMiner(board, ref minerRow, ref minerCol, directions[i]);
                    coals = CoalChecker(board);

                    if (coals == 0)
                    {
                        wins = true;
                        break;
                    }

                    break;

                case "right":
                    if (isAvailable == false)
                    {
                        continue;
                    }

                    if (board[minerRow][minerCol + 1] == 'e')
                    {
                        minerCol++;
                        gameOver = true;
                        break;
                    }

                    MoveMiner(board, ref minerRow, ref minerCol, directions[i]);
                    coals = CoalChecker(board);

                    if (coals == 0)
                    {
                        wins = true;
                        break;
                    }

                    break;

                case "up":
                    if (isAvailable == false)
                    {
                        continue;
                    }

                    if (board[minerRow - 1][minerCol] == 'e')
                    {
                        minerRow--;
                        gameOver = true;
                        break;
                    }

                    MoveMiner(board, ref minerRow, ref minerCol, directions[i]);
                    coals = CoalChecker(board);
                    if (coals == 0)
                    {
                        wins = true;
                        break;
                    }

                    break;

                case "down":
                    if (isAvailable == false)
                    {
                        continue;
                    }

                    if (board[minerRow + 1][minerCol] == 'e')
                    {
                        minerRow++;
                        gameOver = true;
                        break;
                    }

                    MoveMiner(board, ref minerRow, ref minerCol, directions[i]);
                    coals = CoalChecker(board);
                    if (coals == 0)
                    {
                        wins = true;
                        break;
                    }

                    break;

                default:
                    break;
            }
        }

        if (gameOver == true)
        {
            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
        }
        else if (wins == true)
        {
            Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
        }
        else
        {
            Console.WriteLine($"{coals} coals left. ({minerRow}, {minerCol})");
        }
    }

    private static int CoalChecker(char[][] board)
    {
        int coals = 0;

        for (int row = 0; row < board.Length; row++)
        {
            if (board[row].Contains('c') == true)
            {
                for (int col = 0; col < board[row].Length; col++)
                {
                    if (board[row][col] == 'c')
                    {
                        coals++;
                    }
                }
            }
        }

        return coals;
    }

    private static void MoveMiner(char[][] board, ref int minerRow, ref int minerCol, string move)
    {
        switch (move)
        {
            case "left":
                board[minerRow][minerCol] = '*';
                minerCol--;
                board[minerRow][minerCol] = 's';
                break;

            case "right":
                board[minerRow][minerCol] = '*';
                minerCol++;
                board[minerRow][minerCol] = 's';
                break;

            case "up":
                board[minerRow][minerCol] = '*';
                minerRow--;
                board[minerRow][minerCol] = 's';
                break;

            case "down":
                board[minerRow][minerCol] = '*';
                minerRow++;
                board[minerRow][minerCol] = 's';
                break;
        }
    }

    private static bool CheckIfInRange(char[][] board, int minerRow, int minerCol, string move)
    {
        if (move == "left" && minerCol - 1 >= 0)
        {
            return true;
        }
        else if (move == "right" && minerCol + 1 <= board[minerRow].Length - 1)
        {
            return true;
        }
        else if (move == "up" && minerRow - 1 >= 0)
        {
            return true;
        }
        else if (move == "down" && minerRow + 1 <= board.Length - 1)
        {
            return true;
        }
        return false;
    }
}