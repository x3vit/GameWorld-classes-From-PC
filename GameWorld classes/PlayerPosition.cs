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
        public string Model;

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
            ModelPosition(Angle);

            }
        public void ModelPosition(int Angle)
        {

            if (Angle == 0)
            {
                Model = "V   ";

            }
            else if (Angle == 90)
            {
                Model = ">   ";
            }
            else if (Angle == 180)
            {
                Model = "^   ";
            }
            else if (Angle == 270)
            {
                Model = "<   ";
            }

        }

    }
    }


