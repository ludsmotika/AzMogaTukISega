using System;
using System.Collections.Generic;
using System.Text;

namespace QueensGame_WeBareBears
{
    public class SmartAiPlayer : Player
    {
        public SmartAiPlayer(string username) : base(username)
        {
        }
        public override int[] ReturnCoordinates(char[,] matrix)
        {
            char[,] bestMatrix = new char[matrix.GetLength(0), matrix.GetLength(1)];
            CopyMatrix(matrix, bestMatrix);
            int mostStars = 0;
            int bestRow = -1;
            int bestCol = -1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    if (matrix[i,k]==' ')
                    {
                        Writer.FillTheInvalidCellsInMatrix(bestMatrix, i, k);
                        int num = NumberOfStars(bestMatrix);
                        if (num>mostStars)
                        {
                            mostStars = num;
                            bestRow = i;
                            bestCol = k;
                        }
                        CopyMatrix(matrix, bestMatrix);
                    }
                }
            }
            return new int[] { bestRow, bestCol }; 
        }
        private int NumberOfStars(char[,] matrix) 
        {
            int stars = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(0); k++)
                {
                    if (matrix[i,k]=='*')
                    {
                        stars++;
                    }
                }
            }
            return stars;
        }

        private void CopyMatrix(char[,] matrix,char[,] newMatrix) 
        {
            for (int k = 0; k < matrix.GetLength(0); k++)
            {
                for (int l = 0; l < matrix.GetLength(1); l++)
                {
                    newMatrix[k, l] = matrix[k, l];
                }
            }
        }
    }
}
