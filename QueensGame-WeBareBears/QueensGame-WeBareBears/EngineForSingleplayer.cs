using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueensGame_WeBareBears
{
    public static class EngineForSingleplayer
    {
        public static void Run(Board board) 
        {
            Player playerOne = board.playerOne;
            Player playerTwo = board.playerTwo;

            Writer.PrintMessage("Enter coordinates where you want to place your queen in the format: 6,9");
            Console.WriteLine();
            while (true)
            {
                string coordinates;
                if (playerOne.IsYourTurn)
                {
                    Writer.PrintMessage($"{playerOne.Username}: ");
                    coordinates = Console.ReadLine();
                   
                }
                else
                {
                    coordinates = String.Join(",", playerTwo.ReturnCoordinates(board.matrix));
                    Writer.PrintMessage($"{playerTwo.Username}: {coordinates}");
                    
                }

                if (!PlaceQueen(board, coordinates))
                {
                    continue;
                }
                // changing turns

                if (playerOne.IsYourTurn)
                {
                    playerOne.isYourTurn = false;
                    playerTwo.isYourTurn = true;
                }
                else
                {
                    playerOne.isYourTurn = true;
                    playerTwo.isYourTurn = false;
                }

                if (board.IsTheGameOver())
                {
                    break;
                }
                board.PrintMatrix();
            }

            board.PrintMatrix();
            if (playerOne.isYourTurn == false)
            {
                Writer.PrintMessage($"The winner is {playerOne.Username}!");
            }
            else
            {
                Writer.PrintMessage($"The winner is {playerTwo.Username}!");
            }
        }



        public static bool PlaceQueen(Board board, string stringCoordinates)
        {
            //check for * and 1 or 2

            try
            {
                int[] coordinates = stringCoordinates.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                if (coordinates.Length != 2)
                {
                    throw new Exception();
                }

                if (coordinates[0] < 0 || coordinates[0] >= board.matrix.GetLength(0) || coordinates[1] < 0 || coordinates[1] >= board.matrix.GetLength(1))
                {
                    Console.WriteLine("Coordinates are out of the matrix!");
                    throw new Exception();
                }
                else
                {
                    if (Moves.CanIMakeMyMove(board.matrix, coordinates[0], coordinates[1]))
                    {
                        if (board.playerOne.IsYourTurn == true)
                        {
                            board.matrix[coordinates[0], coordinates[1]] = '1';
                        }
                        else

                        {
                            board.matrix[coordinates[0], coordinates[1]] = '2';
                        }
                        Writer.FillTheInvalidCellsInMatrix(board.matrix, coordinates[0], coordinates[1]);
                    }
                    else
                    {
                        Console.WriteLine("You can't place your queen there.\nYou will be captured by another queen with this move.");
                        throw new Exception();
                    }

                }


            }
            catch (Exception)
            {
                Writer.PrintMessage("Try again! Enter valid coordinates!");
                Console.WriteLine();
                return false;
            }
            return true;
        }
    }
}

