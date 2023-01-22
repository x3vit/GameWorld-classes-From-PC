// See https://aka.ms/new-console-template for more information
using GameWorld_classes;
using GameWorld_classes.weapons;
using System;
using System.Security.AccessControl;
using static System.Collections.Specialized.BitVector32;
{

}
//4th branch
//Weapon AWP = new Weapon() { Name = "AWP", Ammo = 5, Dmg = 100, Price = 5000 };

//CTWeapon M16 = new CTWeapon() { Name = "M16", Ammo = 30, Dmg = 25, Price = 3000 };
//TWeapon AK47 = new TWeapon() { Name = "AK47", Ammo = 30, Dmg = 30, Price = 3500 };
AK47 aK47 = new AK47() { Ammo = 30, Dmg = 30, Name = "AK47", Price = 2500 };
M16A1 m16A1 = new M16A1() { Ammo = 30, Dmg = 25, Name = "M16", Price = 3100 };
Scout scout = new Scout() { Ammo = 10, Dmg = 51, Name = "scout", Price = 2100 };
Shotgun shotgun = new Shotgun() { Ammo = 6, Dmg = 30, Name = "shotgun", Price = 2000 };
USP usp = new USP() { Ammo = 12, Dmg = 12, Name = "usp", Price = 0 };
Glock glock = new Glock() { Ammo = 20, Dmg = 10, Name = "glock", Price = 0 };
AWP awp = new AWP() { Ammo = 5, Dmg = 100, Name = "AWP", Price = 5100 };
Player player1 = new Player();
Player player2 = new Player();
Player player3 = new Player();
Player player4 = new Player();

player1.Nickname = "Chubrik1";
player2.Nickname = "Chubrick2";
player3.Nickname = "Chubrick3";
player4.Nickname = "Chubrik4";

player1.Weapon = aK47;
player2.Weapon = m16A1;
player3.Weapon = shotgun;
player4.Weapon = usp;
//player2.Weapon = M16;
//player3.Weapon = AK47;

player1.Position.X = 1;
player1.Position.Y = 1;
player2.Position.X = 1;
player2.Position.Y = 4;
player3.Position.X = 4;
player3.Position.Y = 1;
player4.Position.X = 4;
player4.Position.Y = 4;

GameWorld server = new GameWorld();

server.Actions.Add(new PlayerAction { player = player1, type = ActionType.MoveForward });
server.Actions.Add(new PlayerAction { player = player1, type = ActionType.TurnLeft });
server.Actions.Add(new PlayerAction { player = player1, type = ActionType.TurnLeft });
server.Actions.Add(new PlayerAction { player = player1, type = ActionType.TurnLeft });

//server.Actions.Add(new PlayerAction { player = player1, type = ActionType.TurnLeft });

server.Actions.Add(new PlayerAction { player = player2, type = ActionType.TurnLeft });
server.Actions.Add(new PlayerAction { player = player2, type = ActionType.MoveForward });
server.Actions.Add(new PlayerAction { player = player2, type = ActionType.TurnLeft });
server.Actions.Add(new PlayerAction { player = player2, type = ActionType.TurnLeft });


Armor player1Armor = new Armor();
Console.WriteLine(player1Armor.ArmorValue);
Console.WriteLine($"игровое поле {((int)WorldHorizontalFieldX.coordinateX9)} по горизонтали на {((int)WorldVerticalFieldY.coordinateY9)} по вертикали ");
Weapon players1Weapon = new Weapon();




Console.WriteLine($"число игроков на сервере {server.Players.Count}");
GameScreen mapView = new GameScreen() { GameWorld = server };
server.Players.Add(player1);
server.Players.Add(player2);
server.Players.Add(player3);
server.Players.Add(player4);
player1.GameWorld = server;
player2.GameWorld = server;
player3.GameWorld = server;
player4.GameWorld = server;
mapView.PaintMap();
for (int j = 0; j < server.RoundMaxAction; j++)
{
    
// for (int i = 0; i <1; i++)
//{
int actionIndex=0;
foreach (var action in server.Actions.ToList())
{

    if (action.player.ActionCounter < 1)
    {
        if (action.type == ActionType.MoveForward && server.Actions.Count >0)
        {
            action.player.MoveForward();
            action.player.ActionCounter++;
            mapView.PaintMap();
            server.Actions.RemoveAt(actionIndex);
            actionIndex = 0;

        }
        else if (action.type == ActionType.TurnLeft && server.Actions.Count > 0)
        {
            action.player.TurnLeft();
            action.player.ActionCounter++;
            mapView.PaintMap();
            server.Actions.RemoveAt(actionIndex);
            actionIndex = 0;
        }
        else if (action.type == ActionType.TurnRight && server.Actions.Count > 0)
        {
            action.player.TurnRight();
            action.player.ActionCounter++;
            mapView.PaintMap();
            server.Actions.RemoveAt(actionIndex);
            actionIndex = 0;
        }
        else if (action.type == ActionType.MoveBack && server.Actions.Count > 0)
        {
            action.player.MoveBack();
            action.player.ActionCounter++;
            mapView.PaintMap();
            server.Actions.RemoveAt(actionIndex);
            actionIndex = 0;
        }
        else if (action.type == ActionType.Shoot && server.Actions.Count != 0)
        {
            action.player.Shoot();
            action.player.ActionCounter++;
            mapView.PaintMap();
            server.Actions.RemoveAt(actionIndex);
            actionIndex = 0;
        }
        
        

    }




      }
foreach(var Players in server.Players)
    {
        Players.EndStep();
    }


}
//foreach (var action in server.Actions)
//{
//    action.player.ActionCounter = 0;
//}
//}


















//player1.TurnLeft();

//player2.TurnLeft();

//player2.TurnLeft();
//player4.TurnRight();
//player1.Shoot();
//player2.Shoot();
//player3.Shoot();
//player4.Shoot();




