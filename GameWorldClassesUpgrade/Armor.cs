using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWorld_classes
{
    internal class Armor
    {
        public string Name; //{ get; set; }
        public int ArmorValue; //{ get; set; }                             // возможно лучше через uint
        public int DmgReductionMultiplier; //{ get; set; }

        public Armor()
        {
            Name = "white armor";
            ArmorValue = 50;
            DmgReductionMultiplier = 2;
        }

    }
}
