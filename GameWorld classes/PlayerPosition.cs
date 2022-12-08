using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWorld_classes
{
    internal class PlayerPosition
    {
        public int X = 0;
        public int Y = 0;
        public int Angle=0;

        public PlayerPosition()
        {
            X = 0;
            Y = 0;
            Angle= 0;
        }
        public PlayerPosition(int playerPositionX, int playerPositionY, int playerViewAngle)
        {
            X = playerPositionX;
            Y = playerPositionY;
            Angle = playerViewAngle;
            }


        }
    }


