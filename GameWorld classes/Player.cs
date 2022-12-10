using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWorld_classes
{
    internal class Player
    {
        public Guid id;
        public string Nickname;
        public Weapon Weapon;
        public int Ammo;
        public int Frags;
        public int Deaths;
        public int HP;
        public Armor Armor;
        public PlayerPosition Position;
        public string Action;

        public Player()
        {
            id = Guid.NewGuid();
            Nickname = "unknown";
            Weapon = new Weapon();
           
            Frags = 0;
            Deaths = 0;
            
            Armor = new Armor();
            Position=new PlayerPosition();
           
            
            SetDefaultValues();
           
        }
        private void SetDefaultValues()
        {
            HP = 100;
            Ammo = 100;
        }
        
        public void MoveForward()
        {
            if (Position.Angle == 180)
            {
                Position.Y = Position.Y + 1;
            }
            if (Position.Angle == 0)
            {
                Position.Y = Position.Y - 1;
            }
            if (Position.Angle == 90)
            {
                Position.X= Position.X + 1;
            }
            if (Position.Angle ==270 && Position.X >0)
            {
                Position.X = Position.X - 1;
            }
            if (Position.Y < 0) { Position.Y = 0; } 
            if (Position.X < 0) { Position.X = 0; }
                
        }
        public void MoveBack()
        {
            if (Position.Angle == 180)
            {
                Position.Y = Position.Y - 1;
            }
            if (Position.Angle == 0)
            {
                Position.Y = Position.Y + 1;
            }
            if (Position.Angle == 90)
            {
                Position.X = Position.X - 1;
            }
            if (Position.Angle == 270 && Position.X > 0)
            {
                Position.X = Position.X + 1;
            }
            if (Position.Y < 0) { Position.Y = 0; }
            if (Position.X < 0) { Position.X = 0; }
        }
        public void TurnRight()
        {
            Position.Angle=(Position.Angle+90)%360;
           // if (Position.Angle >= 360) { Position.Angle=0; }
            
        }
       public void TurnLeft()
        {
            Position.Angle = (Position.Angle - 90)%360;
            

        }
        public void Respawn(PlayerPosition position)
        {
            this.Position.X = Position.X;
            this.Position.Y = Position.Y;
            SetDefaultValues();
            

        }
        public Player(Guid id, string nickname, Weapon weapon,Armor armor,PlayerPosition position)
        {
            this.id = id;
            Nickname = nickname;
            Weapon = weapon;
            Armor = armor;
            Position = position;
        }
      
        public void Shoot()
        {
            Console.WriteLine($"{ Nickname} сделал выстрел из оружия {Weapon.Name} ");
        }
      
        }
    }



