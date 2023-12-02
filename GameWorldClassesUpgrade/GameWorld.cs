using GameWorld_classes;
using GameWorld_classes.weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameWorldClassesUpgrade
{
    internal class GameWorld
    {
        private Player _player;
        private Shot _shot;
        public KeyboardInput KeyboardInput;
        private List<Player> _players = new List<Player>();
        public GameScreen _gameScreen = new GameScreen();
        private Weapon _weapon = new Weapon();
        private List<Weapon> _bulletDmgList = new List<Weapon>();
        //private string _mapName;
        private int _timer;
        private int _maxRoundTime = 60;
        private char _mega = 'M';
        private char _armor = 'A';
        private char _emptyField = 'o';
        private Map _gameWorldMap = new Map();
        private GameScreen _gameScreenWorld = new GameScreen();
        public int Timer
        {
            get { return _timer; }
        }
        public Player Player
        {
            get { return _player; }
        }

        public List<Player> Players
        {
            get { return _players; }
        }
        public Shot Shot
        {
            get { return _shot; }
        }
        public Weapon Weapon { get { return _weapon; } }
        //public GameScreen GameScreen { get { return _gameScreen; } }
        // public List<Weapon> BulletList { get { return _bulletList; } }
        public Map Map { get { return _gameWorldMap; } }
        public void RestartRound()
        {

            foreach (var player in Players)
            {
                player.Respawn();

            }
            //GameScreen.RestartMap();
            _gameWorldMap.DownloadMap(_gameWorldMap.MapPath);

        }
        //public void CheckDmg(Player player)                          //dodymat v programm
        //{

        //    if (player.Model == '>')
        //    {
        //        foreach (var playerCheck in Players)
        //        {
        //            if (player.Position.Y + player.Weapon.Range < playerCheck.Position.Y)
        //            {
        //                playerCheck.TakeDamage(player.Weapon);

        //            }
        //        }
        //    }
        //}
        public async void ShowTimer(int cursorPositionX, int cursorPositionY, int maxRoundTime = 60)
        {

            for (int i = maxRoundTime; i >= 0; i--)
            {
                Console.SetCursorPosition(cursorPositionY, cursorPositionX);
                Console.Write($"раунд:{i} сек.)");
                await Task.Delay(1000);

            }
            Console.Clear();
            Console.Write("новый раунд");
            RestartRound();
        }

        //public void ConvertModelToDmg()
        //{
        //    foreach (var weapon in Weapon.BulletWeaponModels)
        //    {
        //        if (weapon == '*')
        //            Weapon.Dmg = 20;
        //        if (weapon != '.')
        //            Weapon.Dmg = 10;
        //    }

        //}
        public void CreateShot(Player player)                                         //sozdat shot
        {
            if (player != null)
            {

                if (player.Position.Direction == 90)
                {
                    _shot.X = player.Position.X;
                    _shot.Y = player.Position.Y + 1;
                    _shot.Angle = player.Position.Direction;
                    _shot.WeaponDmg = player.Weapon.Dmg;
                    _shot.WeaponRange = player.Weapon.Range;
                    Shot playerShot = new Shot(_shot.X, _shot.Y, _shot.Angle, _shot.WeaponDmg, _shot.WeaponRange, _player.Id);
                    playerShot.ShotToArray(playerShot.ShotPosition, _shot.WeaponRange, _shot.WeaponDmg, _player.Id);
                    _shot.ShotVectorArray = playerShot.ShotVectorArray;
                }

                else if (player.Position.Direction == 270)
                {
                    _shot.X = player.Position.X;
                    _shot.Y = player.Position.Y - 1;
                    _shot.Angle = player.Position.Direction;
                    _shot.WeaponDmg = player.Weapon.Dmg;
                    _shot.WeaponRange = player.Weapon.Range;
                    Shot playerShot = new Shot(_shot.X, _shot.Y, _shot.Angle, _shot.WeaponDmg, _shot.WeaponRange, _player.Id);
                    playerShot.ShotToArray(playerShot.ShotPosition, _shot.WeaponRange, _shot.WeaponDmg, _player.Id);
                    _shot.ShotVectorArray = playerShot.ShotVectorArray;
                }

                else if (player.Position.Direction == 0)
                {
                    Shot playerShot = new Shot(player.Position.X, player.Position.Y, player.Position.Direction, player.Weapon.Dmg, player.Weapon.Range, player.Id);

                    playerShot.ShotToArray(playerShot.ShotPosition, player.Weapon.Range, player.Weapon.Dmg, player.Id);
                    // _shot.ShotVectorArray = playerShot.ShotVectorArray;
                }
                else if (player.Position.Direction == 180)
                {
                    _shot.X = player.Position.X + 1;
                    _shot.Y = player.Position.Y;
                    _shot.Angle = player.Position.Direction;
                    _shot.WeaponDmg = player.Weapon.Dmg;
                    _shot.WeaponRange = player.Weapon.Range;
                    Shot playerShot = new Shot(_shot.X, _shot.Y, _shot.Angle, _shot.WeaponDmg, _shot.WeaponRange, _player.Id);
                    playerShot.ShotToArray(playerShot.ShotPosition, _shot.WeaponRange, _shot.WeaponDmg, _player.Id);
                    _shot.ShotVectorArray = playerShot.ShotVectorArray;
                }
            }

            //player.Position.Y
            //player.Weapon
            //player.Position.

        }
        public void CreateShot(Player player, GameWorld gameWorld)
        {
            Shot playerShot = new Shot(player.Position.X, player.Position.Y, player.Position.Direction, player.Weapon.Dmg, player.Weapon.Range, player.Id);

            playerShot.ShotVectorArray = playerShot.ShotToArray(playerShot.ShotPosition, player.Weapon.Range, player.Weapon.Dmg, player.Id);
            for (int i = 0; i < playerShot.ShotVectorArray.Length; i++)
            {
                GameObjectPosition2D ShotVectorArrayUp = (GameObjectPosition2D)playerShot.ShotVectorArray[i];




            }
            CheckShot(playerShot, player.Id);
        }

        
        public void CheckShot(Shot shot, Guid ID)
        {

            //ShotVectorPlayerPositionComparer shotVectorPlayerPositionComparer = new ShotVectorPlayerPositionComparer();

            
            foreach (var player in Players)
            {

                if (player.Id != ID)
                {
                    GameObjectPosition2D playerPositionUp = (GameObjectPosition2D)player.Position;
                   
                    
                    playerPositionUp.X = player.Position.X;
                    playerPositionUp.Y = player.Position.Y;
                    for (int i = 0; i < shot.ShotVectorArray.Length; i++)
                    {

                        
                        if (shot.ShotVectorArray[i].X == playerPositionUp.X && shot.ShotVectorArray[i].Y==playerPositionUp.Y)
                        {

                            player.TakeDamage(shot.WeaponDmg);
                        }
                    }

                }

            }

            // состояигие катки часы,спавны
        }

    }
}
