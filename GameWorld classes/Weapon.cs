using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWorld_classes
{
    internal class Weapon
    {
       
            public string Name { get; set; }
            public int Dmg { get  ; set; }
            public int Ammo { get; set; }
            public string Shoot;

        public Weapon()
        {
            Name = "P250";
        }
            public Weapon(string name,int dmg,int ammo)
            {
            Name = name;
            Dmg = dmg;
            Ammo = ammo;
            
                
            }
        
    }
}
