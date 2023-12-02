using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWorldClassesUpgrade
{
    internal class GameObjectPosition2D
    {

        protected int _x;
        protected int _y;
        public int X { get { return _x; } set { _x = value; } }
        public int Y { get { return _y; } set { _y = value; } }

       

        

        public GameObjectPosition2D()
        {

        }
        public GameObjectPosition2D(int x,int y)
        {
            _x = x;
            _y = y;
        }
    }
}
