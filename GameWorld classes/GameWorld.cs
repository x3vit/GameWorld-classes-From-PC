using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace GameWorld_classes
{

    internal class GameWorld
    {

        public List<Player> Players = new List<Player>();
        public List<PlayerAction> Actions = new List<PlayerAction>();              // сделать в листе список действий, каждый ход игрока одно действие. например в листе с 1 игроком 15 действий а у другого 10 . оба выполнят 10 т.к. 10 раундов. 
        
        
        public int Lenght = 10;
        public int Height = 10;
        public int ModelAngle;
        public int RoundMaxAction=10;

        public GameWorld()
        { }

        
        public GameWorld(string endround)
        {



        }
        
       
        public void Shoot(Player player)
        {
            if (player.Weapon.Ammo > 0)
            {
                player.Weapon.Ammo--;
            }
            else
            {
                player.Weapon.Reload();
                //player.ActionCounter++;                     ////Vajno protestit
            }
            
            if (player.Position.Angle == 0)
            {
                for (int y = player.Position.Y + 1; (y <= Height); y++)

                    foreach (var playerDmgCheck in Players)
                    {
                        if (playerDmgCheck.Position.Y == y && playerDmgCheck.Position.Y != player.Position.Y && playerDmgCheck.Position.X == player.Position.X && playerDmgCheck.HP>0)
                            RegistrationDmg(player, playerDmgCheck);

                    }
            }
            if (player.Position.Angle == 270)
            {
                for (int x = player.Position.X - 1; (x >= 0); x--)

                    foreach (var playerDmgCheck in Players)
                    {
                        if (playerDmgCheck.Position.X == x && playerDmgCheck.Position.X != player.Position.X && playerDmgCheck.Position.Y == player.Position.Y && playerDmgCheck.HP > 0)
                            RegistrationDmg(player, playerDmgCheck);

                    }
            }

            if (player.Position.Angle == 180)
            {
                for (int y = player.Position.Y - 1; (y >= 0); y--)

                    foreach (var playerDmgCheck in Players)
                    {
                        if (playerDmgCheck.Position.Y == y && playerDmgCheck.Position.Y != player.Position.Y && playerDmgCheck.Position.X == player.Position.X && playerDmgCheck.HP > 0)
                            RegistrationDmg(player, playerDmgCheck);

                    }
            }
            if (player.Position.Angle == 90)
            {
                
                for (int x = player.Position.X + 1; (x <= Lenght); x++)

                    foreach (var playerDmgCheck in Players)
                    {
                        if (playerDmgCheck.Position.X == x && playerDmgCheck.Position.X != player.Position.X && playerDmgCheck.Position.Y == player.Position.Y && playerDmgCheck.HP > 0)
                            RegistrationDmg(player, playerDmgCheck);

                    }
            }

        }
        
        public void RegistrationDmg(Player player, Player playerDmgCheck)
        {

            if (playerDmgCheck.Armor.ArmorValue > 0 && player.HP > 0)
            {
                playerDmgCheck.HP = playerDmgCheck.HP - (player.Weapon.Dmg / playerDmgCheck.Armor.DmgReductionMultiplier);
                playerDmgCheck.Armor.ArmorValue = playerDmgCheck.Armor.ArmorValue - (player.Weapon.Dmg / playerDmgCheck.Armor.DmgReductionMultiplier);
                Console.WriteLine($"{playerDmgCheck.Nickname} получил урон от игрока  {player.Nickname}");
                if (playerDmgCheck.HP <= 0)
                {
                    playerDmgCheck.HP = 0;
                    playerDmgCheck.Deaths++;
                    player.Frags++;
                    Console.WriteLine($"игрок {playerDmgCheck.Nickname}  убит игроком{player.Nickname}");
                }
            }
            else if (playerDmgCheck.Armor.ArmorValue <= 0 && player.HP > 0)
            {
                playerDmgCheck.HP = playerDmgCheck.HP - player.Weapon.Dmg;
                Console.WriteLine($"{playerDmgCheck.Nickname} получил урон от игрока  {player.Nickname}");
                if (playerDmgCheck.HP <= 0)
                {
                    playerDmgCheck.HP = 0;
                    playerDmgCheck.Deaths++;
                    player.Frags++;
                    Console.WriteLine($"игрок {playerDmgCheck.Nickname}  убит игроком{player.Nickname}");
                }
            }



        }





        
       



        }
    }

    

