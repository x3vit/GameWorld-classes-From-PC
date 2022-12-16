using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWorld_classes
{

    internal class GameWorld
    {

        public List<Player> Players = new List<Player>();

        public int CurrentRoundCounter = 1; //+ Action.Respawn;
        public int PlayersGameActionCounter = 0;
        public int Lenght = 10;
        public int Height = 10;
        public int ModelAngle;
        
        public GameWorld()
        { }
        
            public GameWorld(string endround)
            {
           
           
                
            }
        }
    
}
