using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GameWorld_classes
{
    internal class GameScreen
    {
        //private int Lenght = 10;
        //private int Height = 10;
        //private int ModelAngle;
        
        public GameWorld GameWorld;
       
        public void PaintMap()
        {
           
            Console.WriteLine("Карта с игроками");
            for (int y = 0; y <= GameWorld.Height; y++)
            {

                for (int x = 0; x <= GameWorld.Lenght; x++ )
                {

                    foreach (var player in GameWorld.Players)

                     if (x == player.Position.X && y == player.Position.Y)
                        {
                            PaintPlayer(player);
                            x++;

                            
                        }
                    
                    
                    if(x <=10)
                    Console.Write("+  ");













                }
                if (y < GameWorld.Players.Count)
                {
                    PaintStats(GameWorld.Players[y]);
                    //Console.Write("\n");
                }
                else Console.Write("\n");


            }
            
            
               
                
            
        }
        public void PaintStats(Player player)
        {
            Console.WriteLine($"\tНик игрока{player.Nickname}\tЗдоровье{player.HP} Броня{player.Armor.ArmorValue} Фраги {player.Frags} Оружие{player.Weapon.Name} Смерти{player.Deaths} ");
        }
        private void PaintPlayer(Player player)
        {
            string Model="";
            if (player.Position.Angle == 0)
            {
                Model = "V  ";

            }
            else if (player.Position.Angle == 90)
            {
                Model = ">  ";
            }
            else if (player.Position.Angle == 180)
            {
                Model = "^  ";
            }
            else if (player.Position.Angle == 270)
            {
                Model = "<  ";
            }
            
            Console.Write($"{Model}");
        }
    }
   
}
