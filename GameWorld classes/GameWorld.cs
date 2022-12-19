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
            
            if (position.Angle == 0)
            {
                for (int y = position.Y+1; (y <= Height); y++)

                    foreach (var player in Players)
                    {
                        if (player.Position.Y == y && player.Position.Y != position.Y && player.Position.X ==position.X)
                            RegistrationDmg(weapon, player);

                    }
            }
            if (position.Angle == 90)
            {
                for (int x = position.X + 1; (x <= Lenght); x++)

                    foreach (var player in Players)
                    {
                        if (player.Position.X == x && player.Position.X != position.X && player.Position.Y == position.Y)
                            RegistrationDmg(weapon, player);

                    }
            }

            if (position.Angle == 180)
            {
                for (int y = position.Y - 1; (y >= 0); y--)

                    foreach (var player in Players)
                    {
                        if (player.Position.Y == y && player.Position.Y != position.Y && player.Position.X == position.X)
                            RegistrationDmg(weapon, player);

                    }
            }
            if (position.Angle == 270)
            {
                for (int x = position.X - 1; ( x >= 0); x--)

                    foreach (var player in Players)
                    {
                        if (player.Position.X == x && player.Position.X != position.X && player.Position.Y == position.Y)
                            RegistrationDmg(weapon, player);

                    }
            }

        }
        public void RegistrationDmg(Weapon weapon, Player player)
        {

            if (player.Armor.ArmorValue > 0 && player.HP >0)
            {
                player.HP = player.HP - (weapon.Dmg / player.Armor.DmgReductionMultiplier);
                player.Armor.ArmorValue = player.Armor.ArmorValue - (weapon.Dmg / player.Armor.DmgReductionMultiplier);
                Console.WriteLine($"{player.Nickname} получил урон от игрока  nado bi vivesti igroka");
                if (player.HP <= 0)
                {
                    Console.WriteLine($"игрок {player.Nickname} убит");
                }
            }
            else if (player.Armor.ArmorValue <= 0 && player.HP > 0)
            {
                player.HP = player.HP - weapon.Dmg;
                Console.WriteLine($"{player.Nickname} получил урон от игрока  nado bi vivesti igroka");
                if (player.HP <= 0)
                {
                    Console.WriteLine($"игрок {player.Nickname} убит i +1 frag");
                }
            }
           
           

        }
    }
}
    

