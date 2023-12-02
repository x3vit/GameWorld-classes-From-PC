using GameWorld_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWorldClassesUpgrade
{
    internal class ShotVectorPlayerPositionComparer:IEqualityComparer<GameObjectPosition>

    {
        IEqualityComparer<GameObjectPosition> m_Comparer;

        public bool Equals(GameObjectPosition xyFirstObject,GameObjectPosition xySecondObject)
        {
            bool xyCompare=xyFirstObject.X==xySecondObject.X&&xyFirstObject.Y==xySecondObject.Y;
            return xyCompare;
        }
        public int GetHashCode(GameObjectPosition obj)
        {
            return obj.GetHashCode();
        }
    }
}
