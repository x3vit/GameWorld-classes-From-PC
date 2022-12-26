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
        public  CTWeapon(): base()
        {
            Dmg = Dmg * DmgMultiplier;
            Ammo = Ammo / 2+(Ammo%2);
        }
        public CTWeapon(int DmgMultiplier) : base()
        {
            Dmg = Dmg * DmgMultiplier;
            Ammo = Ammo / 2 + (Ammo % 2);
        }
    }
}
