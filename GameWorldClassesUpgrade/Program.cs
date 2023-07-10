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

GameScreen gameScreen = new GameScreen();
PlayerConfig playerConfig = new PlayerConfig();

AK47 aK47 = new AK47() { Ammo = 30, Dmg = 30, Name = "AK47" };

Map map = new Map();
//map.CustomMap = ReadMap("mapsmall.txt");
map.ReadMapJson("mapsmall.txt");
//string output = JsonConvert.SerializeObject(map.CustomMap);
//File.WriteAllText(@"E:\temp\defaultSmallMap.txt",output);
KeyboardInput inputPlayer2 = new KeyboardInput();
inputPlayer2.CharKey=Console.ReadKey();
KeyboardInput inputPlayer1 = new KeyboardInput();
inputPlayer1.CharKey=Console.ReadKey();
//gameScreen.ChangeMap( map.CustomMap);


Console.SetCursorPosition(0, 0);

Player player1 = new Player ("Chubrik");
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

        inputPlayer2.MovingEngine(charKey.Key, player2,gameScreen/*,ConsoleKey.R,ConsoleKey.F,ConsoleKey.D,ConsoleKey.G*/);
        //switch (charKey.Key)
        //{

        //    case ConsoleKey.W:
        //        if (gameScreen.Map[player2.Position.X - 1, player2.Position.Y] != '#')
               
        //            player2.Position.MoveTop(); player2.ChangePlayerModel(player2.ModelViewTop);
        //            break;
                
        //    case ConsoleKey.S:
        //        if (gameScreen.Map[player2.Position.X + 1, player2.Position.Y] != '#')
               
        //            player2.Position.MoveDown(); player2.ChangePlayerModel(player2.ModelViewBot); ;
        //            break;
                
        //    case ConsoleKey.A:
        //        if (gameScreen.Map[player2.Position.X, player2.Position.Y - 1] != '#')
                
        //            player2.Position.MoveLeft(); player2.ChangePlayerModel(player2.ModelViewLeft); ;
        //            break;
                
        //    case ConsoleKey.D:
        //        if (gameScreen.Map[player2.Position.X, player2.Position.Y + 1] != '#')
               
        //            player2.Position.MoveRight(); player2.ChangePlayerModel(player2.ModelViewRight);
        //            break;
               
        //    case ConsoleKey.Q:
        //        if (player1.Model == '^' && gameScreen.Map[player2.Position.X - 1, player2.Position.Y] != '#')
        //            gameScreen.Map[player2.Position.X - 1, player2.Position.Y] = '*';
        //        else if

        //            (player2.Model == '>' && gameScreen.Map[player2.Position.X, player2.Position.Y + 1] != '#')
        //            gameScreen.Map[player2.Position.X, player2.Position.Y + 1] = '*';

                

        //        break;


        //}
        
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
    gameScreen.PaintMap();


    Console.SetCursorPosition(player1.Position.Y, player1.Position.X);

    Console.Write($"{player1.Model}");
    Console.SetCursorPosition(player2.Position.Y, player2.Position.X);
    Console.Write($"{player2.Model}");
    Console.SetCursorPosition(0, 26);

    ConsoleKeyInfo charKey = Console.ReadKey();

    inputPlayer1.MovingEngine(charKey.Key, player1, gameScreen/*,ConsoleKey.UpArrow,ConsoleKey.DownArrow,ConsoleKey.LeftArrow,ConsoleKey.RightArrow*/);
    //switch (charKey.Key)
    //{
    //    case ConsoleKey.UpArrow:
    //        if (gameScreen.Map[player1.Position.X - 1, player1.Position.Y] != '#')
    //            player1.Position.MoveTop(); player1.ChangePlayerModel(player1.ModelViewTop);
    //        break;
    //    case ConsoleKey.DownArrow:
    //        if (gameScreen.Map[player1.Position.X + 1, player1.Position.Y] != '#')
    //            player1.Position.MoveDown(); player1.ChangePlayerModel(player1.ModelViewBot);
    //        break;
    //    case ConsoleKey.LeftArrow:
    //        if (gameScreen.Map[player1.Position.X, player1.Position.Y - 1] != '#')
    //            player1.Position.MoveLeft(); player1.ChangePlayerModel(player1.ModelViewLeft);
    //        break;
    //    case ConsoleKey.RightArrow:
    //        if (gameScreen.Map[player1.Position.X, player1.Position.Y + 1] != '#')
    //            player1.Position.MoveRight(); player1.ChangePlayerModel(player1.ModelViewRight);
    //        break;
    //    case ConsoleKey.Spacebar:
    //        if (player1.Model == '^' && gameScreen.Map[player1.Position.X - 1, player1.Position.Y] != '#')
    //            gameScreen.Map[player1.Position.X - 1, player1.Position.Y] = '*';
    //        else if

    //            (player1.Model == '>' && gameScreen.Map[player1.Position.X, player1.Position.Y + 1] != '#')
    //            gameScreen.Map[player1.Position.X, player1.Position.Y + 1] = '*';

           

    //        break;


    //}


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
