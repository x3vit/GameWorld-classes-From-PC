// See https://aka.ms/new-console-template for more information
using GameWorld_classes;
//4th branch
Weapon AWP=new Weapon() { Name="AWP",Ammo=5,Dmg=100,Price=5000};
CTWeapon M16 = new CTWeapon() { Name="M16" ,Ammo=30,Dmg=25,Price=3000};

TWeapon AK47 = new TWeapon() { Name="AK47",Ammo=30,Dmg=30,Price=3500};

Player player1 = new Player();
Player player2 = new Player();
Player player3 = new Player();
player1.Nickname = "Chubrik1";
player2.Nickname = "Chubrick2";
player3.Nickname = "Chubrick3";
player1.Weapon = AWP;
//Player player4 = new Player();
//Player player5 = new Player();
player1.Position.X = 0;
player1.Position.Y = 0;
player2.Position.X = 0;
player2.Position.Y = 3;
player3.Position.X = 6;
player3.Position.Y = 0;
//player4.Position.X = 3;
//player4.Position.Y = 3;
//player5.Position.X = 4;
//player5.Position.Y = 4;
GameWorld server = new GameWorld();
server.Actions.Add(new PlayerAction {player=player1,action=ActionType.MoveForward });

//server.Players.Add(player4);
//server.Players.Add(player5);
Console.WriteLine(player1.id);
Console.WriteLine(player1.HP);
Console.WriteLine(player1.Action);
Armor player1Armor = new Armor();
Console.WriteLine(player1Armor.ArmorValue);
Console.WriteLine($"игровое поле {((int)WorldHorizontalFieldX.coordinateX9)} по горизонтали на {((int)WorldVerticalFieldY.coordinateY9)} по вертикали ");
Weapon players1Weapon = new Weapon();
//PlayerPosition playerPosition = new PlayerPosition(1,1,270);



Console.WriteLine($"число игроков на сервере {server.Players.Count}");
GameScreen mapView = new GameScreen() { GameWorld = server };
server.Players.Add(player1);
server.Players.Add(player2);
server.Players.Add(player3);
player1.GameWorld = server;
player2.GameWorld = server;
player3.GameWorld = server;
mapView.PaintMap();

player1.TurnRight();
player1.Shoot(player1);
player1.TurnLeft();
player1.TurnLeft();
player2.TurnLeft();

player2.Shoot(player2);


//player2.TurnLeft();
//player2.MoveForward();
//player2.TurnRight();
//player1.TurnLeft();
//player2.TurnLeft();
//player2.TurnLeft();    

//server.Shoot(player1);server.Shoot(player1);server.Shoot(player1);server.Shoot(player1);server.Shoot(player1);server.Shoot(player1);server.Shoot(player1);server.Shoot(player1);server.Shoot(player1);





mapView.PaintMap();
//server.Shoot(player2.Position, player2.Weapon); server.Shoot(player2.Position, player2.Weapon); server.Shoot(player2.Position, player2.Weapon); server.Shoot(player2.Position, player2.Weapon); server.Shoot(player2.Position, player2.Weapon); server.Shoot(player2.Position, player2.Weapon); server.Shoot(player2.Position, player2.Weapon); server.Shoot(player2.Position, player2.Weapon); server.Shoot(player2.Position, player2.Weapon); server.Shoot(player2.Position, player2.Weapon); server.Shoot(player2.Position, player2.Weapon); server.Shoot(player2.Position, player2.Weapon); server.Shoot(player2.Position, player2.Weapon); server.Shoot(player2.Position, player2.Weapon); server.Shoot(player2.Position, player2.Weapon); server.Shoot(player2.Position, player2.Weapon); server.Shoot(player2.Position, player2.Weapon);


//mapView.PaintStats(player1);
