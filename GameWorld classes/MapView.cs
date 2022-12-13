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
       
        public void PaintMap()
        {

            for (int y = Height; y >= 0; y--)
            {

                for (int x = Lenght; x >= 0; x--)
                {
                    Console.Write("+          ");
                }
                Console.WriteLine("\n");

            }
            
            
               
                
            
        }
    }
   
}
