using System;
using System.Collections.Generic;
using System.Text;

namespace QueensGame_WeBareBears
{
    public static class Moves
    {
        public static bool CanIMakeMyMove(char[,] matrix, int row, int col)
        {
            return Moves.CanYouGoUpInMainDiagonal(matrix, row, col) && Moves.CanYouGoDownInMainDiagonal(matrix, row, col)
                && Moves.CanYouGoUpInSecondDiagonal(matrix, row, col) && Moves.CanYouGoDownInSecondDiagonal(matrix, row, col)
                && Moves.CanYouGoThroughTheRow(matrix, row) && Moves.CanYouGoThroughTheColumn(matrix, col);
        } 

        private static bool CanYouGoUpInSecondDiagonal(char[,] matrix, int row, int col)
        {
            row--;
            col++;

            while (row >= 0 && col < matrix.GetLength(1))
            {
                if (matrix[row, col] != ' ' && matrix[row, col] != '*')
                {
                    return false;
                }
                row--;
                col++;
            }
            return true;
        }

        private static bool CanYouGoDownInSecondDiagonal(char[,] matrix, int row, int col)
        {
            row++;
            col--;

            while (row < matrix.GetLength(0) && col >= 0)
            {
                if (matrix[row, col] != ' ' && matrix[row, col] != '*')
                {
                    return false;
                }
                row++;
                col--;
            }
            return true;
        }

        private static bool CanYouGoUpInMainDiagonal(char[,] matrix, int row, int col)
        {
            row--;
            col--;

            while (row >= 0 && col >= 0)
            {
                if (matrix[row, col] != ' ' && matrix[row, col] != '*')
                {
                    return false;
                }
                row--;
                col--;
            }
            return true;
        }

        private static bool CanYouGoDownInMainDiagonal(char[,] matrix, int row, int col)
        {
            row++;
            col++;

            while (row < matrix.GetLength(0) && col < matrix.GetLength(1))
            {
                if (matrix[row, col] != ' ' && matrix[row, col] != '*')
                {
                    return false;
                }
                row++;
                col++;
            }
            return true;
        }

        private static bool CanYouGoThroughTheRow(char[,] matrix, int row)
        {
            int count = 1;
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] != ' ' && matrix[row, col] != '*')
                {
                    count++;
                }
            }

            if (count != 1)
            {
                return false;
            }
            return true;
        }

        private static bool CanYouGoThroughTheColumn(char[,] matrix, int col)
        {
            int count = 1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (matrix[row, col] != ' ' && matrix[row, col] != '*')
                {
                    count++;
                }
            }

            if (count != 1)
            {
                return false;
            }
            return true;
        }
    }
}
