using System;
using System.Collections.Generic;
using System.Text;

namespace QueensGame_WeBareBears
{
    public class Player
    {
        
        public bool isYourTurn;
        private string username;
        public Player(string username)
        {
            this.Username = username;
            isYourTurn = false;
        }

        public string Username
        {
            get 
            {
                return username; 
            }
            set 
            {
                username = value;
            }
        }
        public bool IsYourTurn
        {
            get
            {
                return isYourTurn;
            }
            set
            {
                isYourTurn = value;
            }
        }


        public virtual int[] ReturnCoordinates(char[,] matrix) 
        {
            return new int[] { 0, 1 };
        }

    }
}
