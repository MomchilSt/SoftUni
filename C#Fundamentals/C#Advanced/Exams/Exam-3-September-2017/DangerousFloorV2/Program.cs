using System;
using System.Linq;

namespace DangerousFloor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] matrix = new string[8, 8];

            for (int row = 0; row < 8; row++)
            {
                string[] boardInput = Console.ReadLine().Split(',').ToArray();

                for (int col = 0; col < 8; col++)
                {
                    matrix[row, col] = boardInput[col];
                }
            }


            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                char[] figAndMoves = input.ToCharArray();

                string figure = figAndMoves[0].ToString();
                int currRow = int.Parse(figAndMoves[1].ToString());
                int currCol = int.Parse(figAndMoves[2].ToString());
                int nextRow = int.Parse(figAndMoves[4].ToString());
                int nextCol = int.Parse(figAndMoves[5].ToString());
                int diagonal = Math.Abs(currCol - nextCol);

                if (matrix[currRow, currCol] != figure)
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }

                if (nextRow >= 8 || nextRow < 0 || nextCol >= 8 || nextCol < 0)
                {
                    Console.WriteLine("Move go out of board!");
                    continue;
                }

                if (figure == "Q")
                {
                    if (currRow == nextRow && matrix[nextRow, nextCol] == "x")
                    {
                        matrix[nextRow, nextCol] = "Q";
                        matrix[currRow, currCol] = "x";
                    }
                    else if (currCol == nextCol && matrix[nextRow, nextCol] == "x")
                    {
                        matrix[nextRow, nextCol] = "Q";
                        matrix[currRow, currCol] = "x";
                    }
                    else if (IsValidDiagonal(currRow, currCol, nextRow, nextCol, diagonal) && matrix[nextRow, nextCol] == "x")
                    {
                        matrix[nextRow, nextCol] = "Q";
                        matrix[currRow, currCol] = "x";
                    }
                    else
                    {
                        Console.WriteLine("Invalid move!");
                        continue;
                    }
                }
                else if (figure == "K")
                {
                    int diff = diagonal;
                    if (currRow == nextRow && matrix[nextRow, nextCol] == "x" && IsValidKing(currRow, currCol, nextRow, nextCol))
                    {
                        matrix[nextRow, nextCol] = "K";
                        matrix[currRow, currCol] = "x";
                    }
                    else if (currCol == nextCol && matrix[nextRow, nextCol] == "x" && IsValidKing(currRow, currCol, nextRow, nextCol))
                    {
                        matrix[nextRow, nextCol] = "K";
                        matrix[currRow, currCol] = "x";
                    }
                    else if (IsValidDiagonal(currRow, currCol, nextRow, nextCol, diagonal) && matrix[nextRow, nextCol] == "x" && IsValidKing(currRow, currCol, nextRow, nextCol))
                    {
                        matrix[nextRow, nextCol] = "K";
                        matrix[currRow, currCol] = "x";
                    }
                    else
                    {
                        Console.WriteLine("Invalid move!");
                        continue;
                    }
                }
                else if (figure == "B")
                {
                    if (IsValidDiagonal(currRow, currCol, nextRow, nextCol, diagonal) && matrix[nextRow, nextCol] == "x")
                    {
                        matrix[nextRow, nextCol] = "B";
                        matrix[currRow, currCol] = "x";
                    }
                    else
                    {
                        Console.WriteLine("Invalid move!");
                        continue;
                    }
                }
                else if (figure == "R")
                {
                    if (currRow == nextRow && matrix[nextRow, nextCol] == "x" || currCol == nextCol && matrix[nextRow, nextRow] == "x")
                    {
                        matrix[nextRow, nextCol] = "R";
                        matrix[currRow, currCol] = "x";
                    }
                    else
                    {
                        Console.WriteLine("Invalid move!");
                        continue;
                    }
                }
                else if (figure == "P")
                {
                    if (currRow > nextRow && currRow - nextRow == 1 && currCol == nextCol)
                    {
                        matrix[nextRow, nextCol] = "P";
                        matrix[currRow, currCol] = "x";
                    }
                    else
                    {
                        Console.WriteLine("Invalid move!");
                        continue;
                    }
                }
            }

        }

        private static bool IsValidKing(int startRow, int startCol, int endRow, int endCol)
        {
            bool rowMove = Math.Abs(startRow - endRow) == 1
            && Math.Abs(startCol - endCol) == 0;

            bool colMove = Math.Abs(startCol - endCol) == 1
                && Math.Abs(startRow - endRow) == 0;

            bool diagonalMove = Math.Abs(startRow - endRow) == 1
                && Math.Abs(startCol - endCol) == 1;

            return rowMove || colMove || diagonalMove;
        }

        private static bool IsValidDiagonal(int currRow, int currCol, int nextRow, int nextCol, int diagonal)
        {
            return nextCol - diagonal == currCol && nextRow - diagonal == currRow
                || nextCol - diagonal == currCol && nextRow + diagonal == currRow
                || nextCol + diagonal == currCol && nextRow - diagonal == currRow
                || nextCol + diagonal == currCol && nextRow + diagonal == currRow;
        }
    }

}
