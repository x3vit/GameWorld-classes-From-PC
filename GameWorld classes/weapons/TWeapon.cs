using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWorld_classes.weapons
{
    internal class TWeapon : Weapon
    {
        int PriceMultiplier = 2;
        public TWeapon() : base()
        {
            Price = Price / PriceMultiplier;

        }
        public TWeapon(int priceMultiplier)
        {
            PriceMultiplier = priceMultiplier;
        }
    }
}
