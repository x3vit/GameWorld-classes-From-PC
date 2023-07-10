using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GameWorld_classes
{
    internal class PlayerPosition
    {


        Random random = new Random();
       
       

        
        public int X { get;private set; }
        public int Y { get;private set; }  
        public PlayerPosition(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public void RespawnPosition()
        {
            X =random.Next(2,4);
            Y =random.Next(2,4);
        }
        public void MoveTop()
        {
            X--;
        }
        public void MoveDown()
        {
            X++;
        }
        public void MoveLeft()
        {
            Y--;
        }
        public void MoveRight()
        {
            Y++;
        }

    }
}


