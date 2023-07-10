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
        private int _armorValue; //{ get; set; }                             // возможно лучше через uint
        public int DmgReductionMultiplier; //{ get; set; }

        public Armor()
        {
            Name = "white armor";
            _armorValue = 50;
            DmgReductionMultiplier = 2;
        }

        public int ArmorValue
        {
            get { return _armorValue; }
            set { _armorValue = value; }
        }
    }
}
