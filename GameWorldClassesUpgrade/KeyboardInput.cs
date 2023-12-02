﻿using GameWorld_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWorldClassesUpgrade
{
    internal class KeyboardInput
    {

        public ConsoleKeyInfo CharKey = Console.ReadKey();
        private ConsoleKey _up;

        private Player _player;
        private GameScreen _gameScreen;
        private GameWorld _gameWorld;
        //public Shot Shot;


        public Player Player
        {
            get { return _player; }
        }
        public GameScreen GameScreen
        {
            get { return _gameScreen; }
        }
        public GameWorld GameWorld
        {
                get { return _gameWorld; }
        }
        public bool CheckTopWall()
        {

            if (_gameScreen.Map[_player.Position.X - 1, _player.Position.Y] != '#')
            {
                return false;
            }
            return true;

        }
        public bool CheckBotWall(Player player, char[,] map)
        {
            if (_gameScreen.Map[_player.Position.X + 1, _player.Position.Y] != '#')
            {
                return false;
            }
            return true;

        }
        public bool CheckRightWall(Player player, char[,] map)
        {
            if (_gameScreen.Map[_player.Position.X, _player.Position.Y + 1] != '#')
            {
                return false;
            }
            return true;

        }
        public bool CheckLeftWall(Player player, char[,] map)
        {
            if (_gameScreen.Map[_player.Position.X, _player.Position.Y - 1] != '#')
            {
                return false;
            }
            return true;

        }

        public Player MovingEngine(ConsoleKey key, Player player, GameScreen gameScreen,GameWorld gameWorld/*,ConsoleKey up=ConsoleKey.W, ConsoleKey down = ConsoleKey.S, ConsoleKey left = ConsoleKey.A, ConsoleKey right = ConsoleKey.D*/)
        {
            switch (key)
            {

                case ConsoleKey when key == player.Config.MoveTopButton:
                    if (gameScreen.Map[player.Position.X - 1, player.Position.Y] != '#' && player.HP>0)
                    {
                        player.Position.MoveTop();
                        player.ChangeDirection(Player.DirectionTop);
                    }
                    break;

                case ConsoleKey when key == player.Config.MoveBotButton:
                    if (gameScreen.Map[player.Position.X + 1, player.Position.Y] != '#' && player.HP > 0)
                    {
                        player.Position.MoveDown();
                        player.ChangeDirection(Player.DirectionBottom); 
                    }
                    break;

                case ConsoleKey when key == player.Config.MoveLeftButton:
                    if (gameScreen.Map[player.Position.X, player.Position.Y - 1] != '#' && player.HP > 0)
                    {
                        player.Position.MoveLeft();
                        player.ChangeDirection(Player.DirectionLeft);
                    }
                    break;

                case ConsoleKey when key == player.Config.MoveRightButton:
                    if (gameScreen.Map[player.Position.X, player.Position.Y + 1] != '#' && player.HP > 0)
                    {
                        player.Position.MoveRight();
                        player.ChangeDirection(Player.DirectionRight);
                    }
                    break;

                case ConsoleKey when key == player.Config.Shot:
                    gameScreen.ShotPatterns(player);
                    gameWorld.CreateShot(player,gameWorld);

                    break;






            }
            return player;
        }
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
       
    }
}