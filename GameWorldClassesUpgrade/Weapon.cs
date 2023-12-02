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
        public int Dmg { get; set; }
        public int Ammo { get; set; }
        public int Price { get; set; }

        public int Range { get; set; }
        public char BulletModel = '*';
        public List<char> BulletWeaponModels = new List<char> ();
        public void Reload()
        {
            Console.WriteLine("перезарядка");
            Ammo = Ammo;
            Console.WriteLine("перезарядка завершена");
        }


        public Weapon()
        {
            Name = "P250";
            Dmg = 20;
            Ammo = 10;
            Range = 1;
            BulletModel = '.';
        }
        public Weapon(string name, int dmg, int ammo,int price)
        {
            Name = name;
            Dmg = dmg;
            Ammo = ammo;
            Price = price;

        }
        public void ConvertModelToDmg()
        {
            if (BulletModel == '*')
                Dmg = 20;
            if (BulletModel != '.')
                Dmg= 10;
        }

    }

}
