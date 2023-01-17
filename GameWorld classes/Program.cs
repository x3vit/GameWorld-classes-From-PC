﻿// See https://aka.ms/new-console-template for more information
using GameWorld_classes;
using System.Security.AccessControl;
{

}
//4th branch
Weapon AWP = new Weapon() { Name = "AWP", Ammo = 5, Dmg = 100, Price = 5000 };

CTWeapon M16 = new CTWeapon() { Name = "M16", Ammo = 30, Dmg = 25, Price = 3000 };
TWeapon AK47 = new TWeapon() { Name = "AK47", Ammo = 30, Dmg = 30, Price = 3500 };

Player player1 = new Player();
Player player2 = new Player();
Player player3 = new Player();
Player player4 = new Player();

player1.Nickname = "Chubrik1";
player2.Nickname = "Chubrick2";
player3.Nickname = "Chubrick3";
player4.Nickname = "Chubrik4";

player1.Weapon = AWP;
player2.Weapon = M16;
player3.Weapon = AK47;

player1.Position.X = 1;
player1.Position.Y = 1;
player2.Position.X = 1;
player2.Position.Y = 4;
player3.Position.X = 4;
player3.Position.Y = 1;
player4.Position.X = 4;
player4.Position.Y = 4;

GameWorld server = new GameWorld();
server.Actions.Add(new PlayerAction { player = player1, action = ActionType.MoveForward });
server.Actions.Add(new PlayerAction { player=player2,action= ActionType.TurnLeft });


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
foreach(var action in server.Actions)
{
    if (action=ActionType.MoveForward )
    {

    }
    
}
mapView.PaintMap();
player1.TurnLeft();
player2.TurnLeft();
player2.TurnLeft();
player4.TurnRight();
player1.Shoot(player1);
player2.Shoot(player2);
player3.Shoot(player3);
player4.Shoot(player4);


mapView.PaintMap();

