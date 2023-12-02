// See https://aka.ms/new-console-template for more information
using GameWorld_classes;
using GameWorld_classes.weapons;
using GameWorldClassesUpgrade;
using System.IO;
using System.Threading;
using System.Linq;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

Console.CursorVisible = false;

GameWorld gameWorld = new GameWorld();
Shot shot = new Shot();
GameScreen gameScreen = new GameScreen();
PlayerConfig playerConfig = new PlayerConfig();

AK47 aK47 = new AK47() { Ammo = 30, Dmg = 8, Name = "AK47",Range = 2,BulletModel='$' };
Weapon listWeaponModel=new Weapon();

Map map = new Map();
map.MapPath = @"E:\temp\defaultSmallMap.txt";
gameWorld.Map.MapPath=map.MapPath;
gameWorld.Map.DownloadMap(gameWorld.Map.MapPath);
//               map.DownloadMap(map.MapPath);
//map.MapPath = "mapsmall.txt";
//map.CustomMap = ReadMap("mapsmall.txt");
//gameWorld.Map.DownloadMap(map.MapPath);
//gameWorld.GameScreen.SetMap(map.GameMap);

//string output = JsonConvert.SerializeObject(map.CustomMap);
//File.WriteAllText(@"E:\temp\defaultSmallMap.txt",output);
KeyboardInput inputPlayer2 = new KeyboardInput();

inputPlayer2.CharKey=Console.ReadKey();
KeyboardInput inputPlayer1 = new KeyboardInput();
inputPlayer1.CharKey=Console.ReadKey();
 




Console.SetCursorPosition(0, 0);

Player player1 = new Player ("Chubrik");
AlivePlayer alivePlayer1 = new AlivePlayer();
AlivePlayer alivePlayer2 = new AlivePlayer();
//ZombiePlayer zombiePlayer1 = new ZombiePlayer();
//ZombiePlayer zombiePlayer2 = new ZombiePlayer();


player1.Config = new PlayerConfig {};
player1.SetConfigPath(@"E:\temp\player1Config.txt");

Player player2 = new Player ("Chubrik2");
player2.Config = new PlayerConfig();
player2.SetConfigPath(@"E:\temp\player2Config.txt");



gameWorld.Players.Add(player1);
gameWorld.Players.Add(player2);

foreach (var player in gameWorld.Players)
{
    player.Config.ReadConfig(player);
}

gameWorld.ShowTimer(0, 45, 10);
playerConfig.playersConfigDictionary.Add(player1, player1.Config);
playerConfig.playersConfigDictionary.Add(player2, player2.Config);
Task.Run(() =>
{

    while (true)
    {
        
        ConsoleKeyInfo charKey = Console.ReadKey();
        ConsoleColor defaultColor = Console.ForegroundColor;

        Console.SetCursorPosition(0, 25);
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write($"Nickname: {player2.Nickname} \nHP: \nБроня:{player2.Armor.ArmorValue}\nОружие:{player2.Weapon.Name}");
        Console.SetCursorPosition(3, 26);
        gameScreen.DrawHpBar(player2.HP, player2.MaxHP, ConsoleColor.Green);

        
        Console.ForegroundColor = defaultColor;
        Console.SetCursorPosition(player2.Position.Y, player2.Position.X);
        
        inputPlayer2.MovingEngine(charKey.Key, player2,gameScreen,gameWorld/*,ConsoleKey.R,ConsoleKey.F,ConsoleKey.D,ConsoleKey.G*/);
        //gameWorld.CheckDmg(player1);                                                // dodymat v gamescreen
         
        if (gameScreen.Map[player2.Position.X, player2.Position.Y] == 'A')
        {
            gameScreen.Map[player2.Position.X, player2.Position.Y] = 'o';
            player2.PickUpArmor();

        }
        if (gameScreen.Map[player2.Position.X, player2.Position.Y] == 'M')
        {
            gameScreen.Map[player2.Position.X, player2.Position.Y] = 'o';
            player2.TakeMega();

        }
        if (gameScreen.Map[player2.Position.X, player2.Position.Y] == 'W')
        {
            gameScreen.Map[player2.Position.X, player2.Position.Y] = 'o';
            player2.TakeWeapon(aK47);

        }
        listWeaponModel.BulletWeaponModels.Add(player2.Weapon.BulletModel);
    }
});
while (true)
{
    
    

    ConsoleColor defaultColor = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Red;
    Console.SetCursorPosition(0, 20);

    Console.Write($"Nickname: {player1.Nickname} \nHP: \nБроня:{player1.Armor.ArmorValue}\nОружие:{player1.Weapon.Name}");
    Console.SetCursorPosition(3, 21);
    gameScreen.DrawHpBar(player1.HP, player1.MaxHP, ConsoleColor.Green);
    Console.SetCursorPosition(0, 25);
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write($"Nickname: {player2.Nickname} \nHP: \nБроня:{player2.Armor.ArmorValue}\nОружие:{player2.Weapon.Name}");
    Console.SetCursorPosition(3, 26);
    gameScreen.DrawHpBar(player2.HP, player2.MaxHP, ConsoleColor.Green);
    Console.ForegroundColor = defaultColor;

    Console.SetCursorPosition(0, 0);
    
    gameScreen.SetMap(gameWorld.Map.GameMap);
    //gameWorld.CheckDmg();
    gameWorld._gameScreen=gameScreen;
    gameScreen.PaintMap();
    //gameScreen.ResetShotMap();


    Console.SetCursorPosition(player1.Position.Y, player1.Position.X);

    Console.Write($"{player1.Model}");
    Console.SetCursorPosition(player2.Position.Y, player2.Position.X);
    Console.Write($"{player2.Model}");
    Console.SetCursorPosition(0, 26);

    ConsoleKeyInfo charKey = Console.ReadKey();

    inputPlayer1.MovingEngine(charKey.Key, player1, gameScreen,gameWorld);
    //gameWorld.CheckDmg(player2);


    if (gameScreen.Map[player1.Position.X, player1.Position.Y] == 'A')
    {
        gameScreen.Map[player1.Position.X, player1.Position.Y] = 'o';
        player1.PickUpArmor();

    }
    if (gameScreen.Map[player1.Position.X, player1.Position.Y] == 'M')
    {
        gameScreen.Map[player1.Position.X, player1.Position.Y] = 'o';
        player1.TakeMega();

    }
    if (gameScreen.Map[player1.Position.X, player1.Position.Y] == 'W')
    {
        gameScreen.Map[player1.Position.X, player1.Position.Y] = 'o';
        player1.TakeWeapon(aK47);

    }
    listWeaponModel.BulletWeaponModels.Add(player1.Weapon.BulletModel);
    Console.Clear();
}

//static char[,] ReadMap(string path)
//{
//    string[] file = File.ReadAllLines(path);
//    char[,] map = new char[file.Length, GetMaxLenghtofLine(file)];
//    for (int x = 0; x < map.GetLength(0); x++)
//    {
//        for (int y = 0; y < map.GetLength(1); y++)
//        {
//            map[x, y] = file[x][y];
//        }

//    }
//    return map;
//}
//static int GetMaxLenghtofLine(string[] lines)
//{
//    int maxLenghtofLine = lines[0].Length;
//    foreach (var line in lines)
//    {
//        if (line.Length > maxLenghtofLine)
//        {
//            maxLenghtofLine = line.Length;
//        }

//    }
//    return maxLenghtofLine;
//}
