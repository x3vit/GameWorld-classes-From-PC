using GameWorld_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWorldClassesUpgrade
{
    internal class Shot
    {
        public GameObjectPosition ShotPosition;
        public int X;
        public int Y;
        public int WeaponRange;
        public int WeaponDmg;
        public int Angle;
        public Guid PlayerID;
        public List<GameObjectPosition2D> ShotList;
        public GameObjectPosition2D [] ShotVectorArray;
        // public Weapon Weapon;
        public Shot()
        {

        }
        

        public Shot(Shot shot)
        {
            this.X = shot.X;
            this.Y = shot.Y;
            this.WeaponRange = shot.WeaponRange;
            this.WeaponDmg = shot.WeaponDmg;
            this.Angle = shot.Angle;
            this.PlayerID = shot.PlayerID;
        }
        public GameObjectPosition[] ShotToArray(GameObjectPosition shotPosition, int weaponRange, int weaponDmg, Guid playerID)
        {
            
           GameObjectPosition ShotPositionFromPlayer=new GameObjectPosition(shotPosition.X,shotPosition.Y,shotPosition.Direction);
            
            this.Angle = shotPosition.Direction;
            this.WeaponRange = weaponRange;
            this.WeaponDmg = weaponDmg;
            PlayerID = playerID;
            GameObjectPosition[] shotVectorArray = new GameObjectPosition[weaponRange];
           
                for (int i = 0; i < shotVectorArray.Length; i++)
                {
                    ShotPositionFromPlayer.Move(shotPosition.Direction);
                    GameObjectPosition shotObjectToArray=new GameObjectPosition(ShotPositionFromPlayer.X,ShotPositionFromPlayer.Y,ShotPositionFromPlayer.Direction);
                    
                    shotVectorArray[i] = shotObjectToArray;
                    
                }
           
            
            return shotVectorArray;
        }
        public Shot(int x, int y, int direction, int weaponDmg, int weaponRange, Guid playerID)
        {
            GameObjectPosition position=new GameObjectPosition(x,y,direction);
            ShotPosition = position;
            X = x;
            Y = y;
            WeaponRange = weaponRange;
            WeaponDmg = weaponDmg;
            Angle = direction;
            PlayerID = playerID;
        }
    }

}
