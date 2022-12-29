using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWorld_classes
{
    internal class CTWeapon: Weapon
    {
        int DmgMultiplier = 2;
        int AmmoReduceMultiplier = 2;
        public  CTWeapon(): base()
        {
            Dmg = Dmg * DmgMultiplier;
            Ammo = Ammo / AmmoReduceMultiplier+(Ammo%AmmoReduceMultiplier);
        }
        public CTWeapon(int DmgMultiplier) : base()
        {
            Dmg = Dmg * DmgMultiplier;
            Ammo = Ammo / AmmoReduceMultiplier + (Ammo % AmmoReduceMultiplier);
        }
    }
}
