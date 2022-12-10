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
            

        public Weapon()
        {
            Name = "P250";
            Dmg = 10;
            Ammo = 10;
        }
            public Weapon(string name,int dmg,int ammo)
            {
            Name = name;
            Dmg = dmg;
            Ammo = ammo;
            
                
            }
        public void Shoot()
        {
            if (Ammo<=0)
            {
                Reload();
            }
            Ammo--;
            Console.WriteLine($"{Name} с уроном {Dmg}, осталось патронов в обойме {Ammo}");

           
        }
        private void Reload()
        {
            Console.WriteLine("перезарядка");
            Ammo = Ammo;
            Console.WriteLine("перезарядка завершена");
        }
        
    }
}
