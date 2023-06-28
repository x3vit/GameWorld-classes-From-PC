// See https://aka.ms/new-console-template for more information
using GameWorld_classes;
using GameWorld_classes.weapons;
using GameWorldClassesUpgrade;
using System.IO;
using System.Threading;


Console.CursorVisible = false;
GameWorld gameWorld = new GameWorld();
GameScreen gameScreen = new GameScreen();
Map map = new Map();
AK47 aK47 = new AK47() { Ammo = 30, Dmg = 30, Name = "AK47" };
map.CustomMap = ReadMap("mapsmall.txt");
gameScreen.ChangeMap(ref gameScreen.MapDefault, map.CustomMap);


Console.SetCursorPosition(0, 0);

Player player1 = new Player { };
player1.Nickname = "Chubrik";


PlayerPosition player1position = new PlayerPosition(3, 3, 0);

Player player2 = new Player { };
player2.Nickname = "Chubrik2";
PlayerPosition player2position = new PlayerPosition(3, 4, 0);

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
        Console.SetCursorPosition(player2position.Y, player2position.X);


        switch (charKey.Key)
        {

            case ConsoleKey.W:
                if (gameScreen.MapDefault[player2position.X - 1, player2position.Y] != '#')
                    player2position.X--; player2.Model = player2.ModelViewTop;
                break;
            case ConsoleKey.S:
                if (gameScreen.MapDefault[player2position.X + 1, player2position.Y] != '#')
                    player2position.X++; player2.Model = player2.ModelViewBot;
                break;
            case ConsoleKey.A:
                if (gameScreen.MapDefault[player2position.X, player2position.Y - 1] != '#')
                    player2position.Y--; player2.Model = player2.ModelViewLeft;
                break;
            case ConsoleKey.D:
                if (gameScreen.MapDefault[player2position.X, player2position.Y + 1] != '#')
                    player2position.Y++; player2.Model = player2.ModelViewRight;
                break;
            case ConsoleKey.Q:
                if (player1.Model == '^' && gameScreen.MapDefault[player2position.X - 1, player2position.Y] != '#')
                    gameScreen.MapDefault[player2position.X - 1, player2position.Y] = '*';
                else if

                    (player2.Model == '>' && gameScreen.MapDefault[player2position.X, player2position.Y + 1] != '#')
                    gameScreen.MapDefault[player2position.X, player2position.Y + 1] = '*';

                

                break;


        }

        if (gameScreen.MapDefault[player2position.X, player2position.Y] == 'A')
        {
            gameScreen.MapDefault[player2position.X, player2position.Y] = 'o';
            player2.Armor.ArmorValue += 50;

        }
        if (gameScreen.MapDefault[player2position.X, player2position.Y] == 'M')
        {
            gameScreen.MapDefault[player2position.X, player2position.Y] = 'o';
            player2.HP += 10;

        }
        if (gameScreen.MapDefault[player2position.X, player2position.Y] == 'W')
        {
            gameScreen.MapDefault[player2position.X, player2position.Y] = 'o';
            player2.Weapon = aK47;

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


    Console.SetCursorPosition(player1position.Y, player1position.X);

    Console.Write($"{player1.Model}");
    Console.SetCursorPosition(player2position.Y, player2position.X);
    Console.Write($"{player2.Model}");
    Console.SetCursorPosition(0, 26);

    ConsoleKeyInfo charKey = Console.ReadKey();

    switch (charKey.Key)
    {
        case ConsoleKey.UpArrow:
            if (gameScreen.MapDefault[player1position.X - 1, player1position.Y] != '#')
                player1position.X--; player1.Model = player1.ModelViewTop;
            break;
        case ConsoleKey.DownArrow:
            if (gameScreen.MapDefault[player1position.X + 1, player1position.Y] != '#')
                player1position.X++; player1.Model = player1.ModelViewBot;
            break;
        case ConsoleKey.LeftArrow:
            if (gameScreen.MapDefault[player1position.X, player1position.Y - 1] != '#')
                player1position.Y--; player1.Model = player1.ModelViewLeft;
            break;
        case ConsoleKey.RightArrow:
            if (gameScreen.MapDefault[player1position.X, player1position.Y + 1] != '#')
                player1position.Y++; player1.Model = player1.ModelViewRight;
            break;
        case ConsoleKey.Spacebar:
            if (player1.Model == '^' && gameScreen.MapDefault[player1position.X - 1, player1position.Y] != '#')
                gameScreen.MapDefault[player1position.X - 1, player1position.Y] = '*';
            else if

                (player1.Model == '>' && gameScreen.MapDefault[player1position.X, player1position.Y + 1] != '#')
                gameScreen.MapDefault[player1position.X, player1position.Y + 1] = '*';

           

            break;


    }


    if (gameScreen.MapDefault[player1position.X, player1position.Y] == 'A')
    {
        gameScreen.MapDefault[player1position.X, player1position.Y] = 'o';
        player1.Armor.ArmorValue += 50;

    }
    if (gameScreen.MapDefault[player1position.X, player1position.Y] == 'M')
    {
        gameScreen.MapDefault[player1position.X, player1position.Y] = 'o';
        player1.HP += 10;

    }
    if (gameScreen.MapDefault[player1position.X, player1position.Y] == 'W')
    {
        gameScreen.MapDefault[player1position.X, player1position.Y] = 'o';
        player1.Weapon = aK47;

    }

    Console.Clear();
}
static char[,] ReadMap(string path)
{
    string[] file = File.ReadAllLines(path);
    char[,] map = new char[file.Length, GetMaxLenghtofLine(file)];
    for (int x = 0; x < map.GetLength(0); x++)
    {
        for (int y = 0; y < map.GetLength(1); y++)
        {
            map[x, y] = file[x][y];
        }

    }
    return map;
}
static int GetMaxLenghtofLine(string[] lines)
{
    int maxLenghtofLine = lines[0].Length;
    foreach (var line in lines)
    {
        if (line.Length > maxLenghtofLine)
        {
            maxLenghtofLine = line.Length;
        }

    }
    return maxLenghtofLine;
}
