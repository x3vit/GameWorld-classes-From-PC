using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWorld_classes
{
    internal class GameScreen
    {
        private int Lenght = 10;
        private int Height = 10;
        private int ModelAngle;
        private string Model;
       
        public void PaintMap(PlayerPosition position)
        {
            ModelAngle=position.Angle;
            if (ModelAngle==0)
            {
                Model = "V   ";

            }
            else if (ModelAngle==90)
            {
                Model = ">   ";
            }
            else if ( ModelAngle==180)
            {
                Model = "^   ";
            }
            else if (ModelAngle==270)
            {
                Model = "<   ";
            }
            Console.WriteLine("Карта с игроками");
            for (int y = 0; y <= Height; y++)
            {

                for (int x = 0; x <= Lenght; x++)
                {
                    
                    if(x == position.X && y==position.Y)
                    {
                        Console.Write($"{Model}");
                    }
                    else Console.Write("+   ");
                }
                Console.WriteLine("\n");

            }
            
            
               
                
            
        }
        public void PaintStats(Player player)
        {
            Console.WriteLine($"Ник игрока {player.Nickname} \n Здоровье {player.HP} \n Броня {player.Armor.ArmorValue} \n Фраги {player.Frags} \n Оружие {player.Weapon.Name} \n Смерти {player.Deaths} ");
        }
    }
   
}
