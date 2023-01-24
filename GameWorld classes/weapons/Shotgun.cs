using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWorld_classes.weapons
{
    internal class Shotgun : Weapon
    {
       PlayerPosition playerPosition;
        public void KnockBack(Player player)
        {
            player.MoveBack();

        }
    }
}
