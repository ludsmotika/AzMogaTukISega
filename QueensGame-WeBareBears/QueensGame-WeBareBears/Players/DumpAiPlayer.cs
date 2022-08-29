using System;
using System.Collections.Generic;
using System.Text;

namespace QueensGame_WeBareBears.Players
{
    public class DumpAiPlayer : Player
    {
        public DumpAiPlayer(string username) : base(username)
        {
        }
        public override int[] ReturnCoordinates(char[,] matrix)
        {
            int row = -1;
            int col = -1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    if (matrix[i,k]==' ')
                    {
                        row = i;
                        col = k;
                    }
                }
            }
            return new int[] {row,col};
        }
    }
}
