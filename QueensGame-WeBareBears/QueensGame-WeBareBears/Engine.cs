using System;
using System.Collections.Generic;
using System.Text;

namespace QueensGame_WeBareBears
{
    public static class Engine
    {
        public static void Run(int mode) 
        {

            Writer.PrintMessage("Now the game starts!");
            Console.WriteLine();
            Console.WriteLine("Enter valid dimensions for the Board.\nNumbers between [4,100].");
            

            int numberOfRows = Reader.ReadRows();
            int numberOfColumns = Reader.ReadCols();

            Console.Clear();

            Board board=null;
            if (mode == 1)
            {
                // start

                int n = 0;
                while (true)
                {
                    Writer.PrintMessage("Enter '1' for easy or '2' for hard mode");
                    Console.WriteLine();
                    try
                    {
                        n = int.Parse(Console.ReadLine());
                        if (n == 1 || n == 2)
                        {
                            break;
                        }
                        else
                        {
                            throw new Exception("Enter valid input!");

                        }
                    }
                    catch (Exception ex)
                    {
                        Writer.PrintMessage(ex.Message);
                        Console.WriteLine();
                    }
                }

                Player playerTwo=null;

                if (n == 1)
                {
                    playerTwo = new Players.DumpAiPlayer("Robot");
                }
                else
                {
                    playerTwo = new SmartAiPlayer("Robot");
                }


                // end
                string name = Reader.ReadPlayerName();
                board = new Board(numberOfRows, numberOfColumns, new Player(name), playerTwo);
            }
            else if (mode == 2)
            {
                string[] names = Reader.ReadPlayersNames();
                Player playerOne = new Player(names[0]);
                Player playerTwo = new Player(names[1]);
                board = new Board(numberOfRows, numberOfColumns, playerOne, playerTwo);
            }            

            board.InitializeMatrix();



            if (mode==1)
            {
                EngineForSingleplayer.Run(board);
            }
            else
            { 
                EngineForMultiplayer.Run(board);
            }
           
        }
        
    }
}
