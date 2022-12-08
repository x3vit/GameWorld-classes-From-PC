using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWorld_classes
{
    internal class Armor
    {
        public string Name { get; set; }
        public int ArmorValue = 100;                            // возможно лучше через uint
        public int DmgReductionMultiplier = 2;

        public Armor()
        {
            this.Name = "p250";
        }

    }
}
