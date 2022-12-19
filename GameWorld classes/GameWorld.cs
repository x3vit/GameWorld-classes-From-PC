using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWorld_classes
{

    internal class GameWorld
    {

        public List<Player> Players = new List<Player>();

        public int CurrentRoundCounter = 1; //+ Action.Respawn;
        public int PlayersGameActionCounter = 0;
        public int Lenght = 10;
        public int Height = 10;
        public int ModelAngle;

        public GameWorld()
        { }

        public GameWorld(string endround)
        {



        }
        public void Shoot(PlayerPosition position, Weapon weapon)
        {
            //Console.WriteLine($"{ Nickname} сделал выстрел из оружия {Weapon.Shoot} ");  //одинаково называются методы в разных классах
            if (position.Angle == 0)
            {
                for (int y = position.Y; (y <= Height); y++)

                    foreach (var player in Players)
                    {
                        if (player.Position.Y == y && player.Position.Y != position.Y)
                            RegistrationDmg(weapon, player);

                    }
            }


            // if (Position.Angle == 90)
            //  if (Position.Angle == 180)
            // if (Position.Angle == 270)

        }
        public void RegistrationDmg(Weapon weapon, Player player)
        {

            if (player.Armor.ArmorValue > 0)
            {
                player.HP = player.HP - (weapon.Dmg / player.Armor.DmgReductionMultiplier);
                player.Armor.ArmorValue = player.Armor.ArmorValue - (weapon.Dmg / player.Armor.DmgReductionMultiplier);
            }
            else if (player.Armor.ArmorValue <= 0)
            {
                player.HP = player.HP - weapon.Dmg;
            }
            else if (player.HP <= 0)
            {
                Console.WriteLine($"игрок {player.Nickname} убит");
            }
            Console.WriteLine($"{player.Nickname} получил урон от игрока nado vivesti igroka");

        }
    }
}
    

