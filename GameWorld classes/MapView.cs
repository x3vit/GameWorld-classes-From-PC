using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWorld_classes
{
    internal class MapView
    {
       private int Lenght = 10;
       private int Height = 10;
       
        public void PaintMap(PlayerPosition position)
        {
            Console.WriteLine("Карта с игроками");
            for (int y = 0; y <= Height; y++)
            {

                for (int x = 0; x <= Lenght; x++)
                {
                    
                    if(x == position.X && y==position.Y)
                    {
                        Console.Write("H   ");
                    }
                    else Console.Write("+   ");
                }
                Console.WriteLine("\n");

            }
            
            
               
                
            
        }
    }
   
}
