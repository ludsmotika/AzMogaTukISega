using System;
using System.Linq;
using System.Threading;
using System.Media;

namespace QueensGame_WeBareBears
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Console.Title = "Queens♛";


            string welcome = "Welcome to our new game called Queens!!!\nWe are happy to have you here!";

            Writer.PrintMessage(welcome);
            Console.WriteLine();

            Writer.PrintMessage("Choose game mode!");
            Console.WriteLine();
            Writer.PrintMessage("Write 1 for Singleplayer!");
            Console.WriteLine();
            Writer.PrintMessage("Write 2 for Multiplayer!");
            Console.WriteLine();

          

            int mode = 0;
            while (mode != 1 && mode!=2)
            {
                try
                {
                    mode = int.Parse(Console.ReadLine());
                    if (!(mode == 1 || mode == 2))
                    {
                        throw new Exception("Enter valid mode number!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Engine.Run(mode);


        }

    }
}
