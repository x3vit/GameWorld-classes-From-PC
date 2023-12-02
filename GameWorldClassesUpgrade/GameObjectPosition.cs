using GameWorldClassesUpgrade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GameWorld_classes
{
    internal class GameObjectPosition: GameObjectPosition2D
    {

        public const int DirectionRight = 90;
        public const int DirectionLeft = 270;
        public const int DirectionTop = 0;
        public const int DirectionBottom = 180;
        Random random = new Random();




        public int X { get; private set; }
        public int Y { get; private set; }
        public int Direction { get; set; }
        public GameObjectPosition()
        {

        }
        
        public GameObjectPosition(int x, int y)
        {
            X = x;
            Y = y;
        }
        public GameObjectPosition(int x, int y, int viewAngle) : base(x, y)
        {
            X = x;
            Y = y;
            Direction = viewAngle;
        }

        public void RespawnPosition()
        {
            X = random.Next(2, 4);
            Y = random.Next(2, 4);
        }
        public void MoveTop()
        {
            X--;
        }
        public void Move(int angle)
        {
            if (angle == 0)
                X--;
            
            else if (angle == 180)
                X++;
            
            else if (angle == 90)
                Y++;
            
            else if (angle == 270)
                Y--;
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


