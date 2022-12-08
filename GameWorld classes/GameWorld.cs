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

        public GameWorld()
        { }
        
            public GameWorld(string endround)
            {
            Players.Add(new Player() { Nickname="Chubrik2" }) ;
           
                if (endround == "конец раунда")
                {
                    Console.WriteLine("начало следующего раунда.параметры игрока установлены на дефолтные");
                }
            }
        }
    
}
