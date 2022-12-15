// See https://aka.ms/new-console-template for more information
using GameWorld_classes;
//second branch
Player player1 = new Player() { Nickname = "Chubrik"};
Player player2 = new Player() { Nickname = "Chubrik3" };
GameWorld server = new GameWorld();
Console.WriteLine(player1.id);
Console.WriteLine(player1.HP);
Console.WriteLine(player1.Action);
Armor player1Armor = new Armor();
Console.WriteLine(player1Armor.ArmorValue);
Console.WriteLine($"игровое поле {((int)WorldHorizontalFieldX.coordinateX9)} по горизонтали на {((int)WorldVerticalFieldY.coordinateY9)} по вертикали ");
Weapon players1Weapon = new Weapon();
PlayerPosition playerPosition = new PlayerPosition(1,1,90);
PlayerPosition playerPostition2 = new PlayerPosition(2, 2, 180);
player1.Shoot();

Console.WriteLine($"число игроков на сервере {server.Players.Count}");
MapView mapView = new MapView(playerPosition);
//mapView.PaintMap(playerPosition);
//mapView.PaintMap(playerPostition2);

