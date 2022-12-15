// See https://aka.ms/new-console-template for more information
using GameWorld_classes;
//second branch
Player player1 = new Player();
GameWorld server = new GameWorld();
Console.WriteLine(player1.id);
Console.WriteLine(player1.HP);
Console.WriteLine(player1.Action);
Armor player1Armor = new Armor();
Console.WriteLine(player1Armor.ArmorValue);
Console.WriteLine($"игровое поле {((int)WorldHorizontalFieldX.coordinateX9)} по горизонтали на {((int)WorldVerticalFieldY.coordinateY9)} по вертикали ");
Weapon players1Weapon = new Weapon();
PlayerPosition playerPosition = new PlayerPosition(1,1,270);
player1.Shoot();

Console.WriteLine($"число игроков на сервере {server.Players.Count}");
GameScreen mapView = new GameScreen();
mapView.PaintMap(playerPosition);
mapView.PaintStats(player1);
