using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace QueensGame_WeBareBears
{
    public static class Writer
    {
        public static void PrintMessage(string text)
        {
            foreach (char symbol in text)
            {
                Console.Write(symbol);
                Thread.Sleep(15);
            }

        }

        public static void FillTheInvalidCellsInMatrix(char[,] matrix, int row, int col)
        {
            //Filling the row
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (i != col)
                {
                    matrix[row, i] = '*';
                }
            }

            //Filling the column
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i != row)
                {
                    matrix[i, col] = '*';
                }
            }

            //Filling the diagonals
            //down second
            int currRow = row;
            int currCol = col;

            while (currRow < matrix.GetLength(0) - 1 && currCol > 0)
            {
                currRow++;
                currCol--;
                matrix[currRow, currCol] = '*';

            }
            //up second
            currRow = row;
            currCol = col;
            while (currRow > 0 && currCol < matrix.GetLength(1) - 1)
            {
                currRow--;
                currCol++;
                matrix[currRow, currCol] = '*';
            }

            //down main
            currRow = row;
            currCol = col;
            while (currRow < matrix.GetLength(0) - 1 && currCol < matrix.GetLength(1) - 1)
            {
                currRow++;
                currCol++;
                matrix[currRow, currCol] = '*';

            }

            //up main
            currRow = row;
            currCol = col;
            while (currRow > 0 && currCol > 0)
            {
                currRow--;
                currCol--;
                matrix[currRow, currCol] = '*';

            }

        }

    }
}
