using GameWorld_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWorldClassesUpgrade
{
    internal class ZombiePlayer : Player
    {
        public Guid Id;
        private string _nickname;
        private Weapon _weapon;
        private int _ammo;
        private int _frags;
        private int _deaths;
        private int _hP;
        private int _maxHP;
        private Armor _armor;
        private GameObjectPosition _position;
        private char _basicModel = 'Z';
        private char _model = 'Z';
        private const char _modelViewTop = 'Z';
        private const char _modelViewBottom = 'Z';
        private const char _modelViewRight = 'Z';
        private const char _modelViewLeft = 'Z';
        private int _viewAngle = 0;
        public const int DirectionRight = 90;
        public const int DirectionLeft = 270;
        public const int DirectionTop = 0;
        public const int DirectionBottom = 180;
        public string configPath = @"E:\temp\defaultConfig.txt";
        //public PlayerConfig Config;
        public ZombiePlayer(Player player)
        {
           Id=player.Id;
            _nickname=player.Nickname;
            _weapon=player.Weapon;
            _armor=player.Armor;
         
            _frags=player.Frags;
            _deaths=player.Deaths;
            _hP=1;
            _position=player.Position;
            _model = 'Z';
            

        }
        public new void PickUpArmor()
        {
            _armor.ArmorValue +=1;                                   //set otkritii v armore (
        }
        private void ChangePlayerModel(int angle)
        {
            if (angle == DirectionTop)
            {
                _model = _modelViewTop;
            }

            else if (angle == DirectionBottom)
            {
                _model = _modelViewBottom;
            }
            else if (angle == DirectionLeft)
            {
                _model = _modelViewLeft;

            }
            else if (angle == DirectionRight)
            {
                _model = _modelViewRight;
            }
        }
        public new int ChangeDirection(int angle)
        {
            _viewAngle = angle;
            _position.Direction = angle;
            ChangePlayerModel(_viewAngle);
            return _viewAngle;
        }

        public  void BecomeZombie()
        {
            _model = 'Z';
        }
        public new void TakeDamage(int dmg)
        {


            if (_armor.ArmorValue <= 0)
                _hP = _hP - dmg;
            else
            {
                _hP = _hP - dmg / 2;
                _armor.ArmorValue -= dmg / 2;
                if (_armor.ArmorValue < 0)
                { _armor.ArmorValue = 0; }
            }
            if (_hP < 0)
            {
                _model = '!';
                _deaths++;
            }
        }
        public new void TakeMega()
        {
            if (_hP < MaxHP)
                _hP += 1;
            else if (_hP > MaxHP)
            { _hP -= MaxHP; }
        }
        public new void TakeWeapon(Weapon weapon)
        {
            _weapon = weapon;
        }
        public new void ChangeNickName(string name)
        {
            _nickname = name;
        }
        public new void SetConfigPath(string path)
        {
            configPath = path;
        }
        public new void Respawn()
        {

            _hP = 10;
            _armor.ArmorValue = 50;
            _position.RespawnPosition();
            ChangePlayerModel(_basicModel);
        }
        private new void SetDefaultValues()
        {
            _hP = 10;
            _maxHP = 10;
            _position.RespawnPosition();
            _weapon = new Weapon();
            _model = 'Z';

        }
    }
}
