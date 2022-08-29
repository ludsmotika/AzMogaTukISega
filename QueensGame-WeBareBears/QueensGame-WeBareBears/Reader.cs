using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace QueensGame_WeBareBears
{
    public static class Reader
    {
        public static string ReadPlayerName()
        {
            Console.WriteLine();
            string playerName = "";
            while (playerName == "")
            {
                Writer.PrintMessage("Enter your name: ");
                string testName = Console.ReadLine();
                try
                {
                    if (testName.Length < 3)
                    {
                        throw new Exception("The name must be at least 3 symbols long!");
                    }
                    if (testName=="Robot")
                    {
                        throw new Exception("Enter new name! There is already a player called Robot!");
                    }
                    playerName = testName;
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Writer.PrintMessage(ex.Message);
                    Console.WriteLine();
                }
            }
            return playerName;
        }

        public static string[] ReadPlayersNames()
        {
            Writer.PrintMessage("Now you have to enter the names of the players!");
            Console.WriteLine();
            string playerOneName = "";
            while (playerOneName == "")
            {
                Writer.PrintMessage("Enter playerOne name: ");
                string testName = Console.ReadLine();
                try
                {
                    if (testName.Length < 3)
                    {
                        throw new Exception();
                    }
                    playerOneName = testName;
                }
                catch (Exception)
                {
                    Console.Clear();
                    Writer.PrintMessage("The name must be at least 3 symbols long!");
                    Console.WriteLine();
                }
            }


            string playerTwoName = "";
            while (playerTwoName == "")
            {
                Writer.PrintMessage("Enter playerTwo name: ");
                string testName = Console.ReadLine();
                try
                {
                    if (testName.Length < 3)
                    {
                        throw new Exception("The name must be at least 3 symbols long!");
                    }
                    if (playerOneName == testName)
                    {
                        throw new Exception("The players must have different names!");
                    }
                    playerTwoName = testName;
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Writer.PrintMessage(ex.Message);
                    Console.WriteLine();
                }
            }
            return new string[] { playerOneName, playerTwoName };
        }

        public static int ReadRows()
        {
            int numberOfRows = -1;
            while (numberOfRows == -1)
            {
                Writer.PrintMessage("Enter number of rows: ");
                string rows = Console.ReadLine();
                try
                {
                    numberOfRows = int.Parse(rows);
                    if (numberOfRows < 4 || numberOfRows > 100)
                    {
                        numberOfRows = -1;
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Writer.PrintMessage("Wrong input! Try again!");
                    Console.WriteLine();
                }
            }
            return numberOfRows;
        }
        public static int ReadCols()
        {
            int numberOfColumns = -1;
            while (numberOfColumns == -1)
            {
                Writer.PrintMessage("Enter number of columns: ");
                string columns = Console.ReadLine();
                try
                {
                    numberOfColumns = int.Parse(columns);
                    if (numberOfColumns < 4 || numberOfColumns > 100)
                    {
                        numberOfColumns = -1;
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Writer.PrintMessage("Wrong input! Try again!");
                    Console.WriteLine();
                }
            }
            return numberOfColumns;

        }

    }
}
