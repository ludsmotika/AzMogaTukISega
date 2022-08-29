using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace QueensGame_WeBareBears
{
    public class Board
    {
        private int rows;

        private int columns;

        public Player playerOne;

        public Player playerTwo;

        public char[,] matrix;

        public Board(int rows, int columns, Player playerOne, Player playerTwo)
        {
            Rows = rows;
            this.playerOne = playerOne;
            playerOne.isYourTurn = true;
            this.playerTwo = playerTwo;
            Columns = columns;
            matrix = new char[rows, columns];
        }

        public int Rows
        {
            get
            {
                return rows;
            }
            set
            {
                rows = value;
            }
        }

        public int Columns
        {
            get
            {
                return columns;
            }
            set
            {
                columns = value;
            }
        }

        public void PrintMatrix()
        {
            Console.Clear();


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.Write("+");
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    Console.Write("-+");
                }
                Console.WriteLine();
                Console.Write("|");
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == '1')
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else if (matrix[row, col] == '2')
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    Console.Write(matrix[row, col]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("|");
                }
                Console.WriteLine();
            }
            Console.Write("+");
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                Console.Write("-+");
            }
            Console.WriteLine();

        }
        public bool IsTheGameOver()
        {
            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void InitializeMatrix()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    this.matrix[i, j] = ' ';
                }
            }
        }

    }
}
