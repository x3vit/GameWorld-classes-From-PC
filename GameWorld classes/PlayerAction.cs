using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWorld_classes
{
    internal class PlayerAction
    {
       public Player player;
       public ActionType action; 


    }
   public enum ActionType
    {
        MoveForward,
        MoveBack,
        TurnLeft,
        TurnRight,
        Shoot
            
    }
    


}
