using GameWorldClassesUpgrade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace GameWorld_classes
{
    internal class Player
    {
        Random rnd = new Random();

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
        private char _basicModel = '@';
        private char _model = '@';
        private const char _modelViewTop = '^';
        private const char _modelViewBottom = 'V';
        private const char _modelViewRight = '>';
        private const char _modelViewLeft = '<';
        private int _viewAngle = 0;
        public const int DirectionRight = 90;
        public const int DirectionLeft = 270;
        public const int DirectionTop = 0;
        public const int DirectionBottom = 180;
        public string configPath = @"E:\temp\defaultConfig.txt";
        public PlayerConfig Config;

        public Player()
        {
            Id = Guid.NewGuid();
            _nickname = "unknown";
            //_weapon = new Weapon();


            _frags = 0;
            _deaths = 0;

            _armor = new Armor();
            _position = new GameObjectPosition(0, 0);
            Config = new PlayerConfig();

            SetDefaultValues();

        }
        public Player(string nickname)
        {
            Id = Guid.NewGuid();
            _nickname = nickname;
            _weapon = new Weapon();


            _frags = 0;
            _deaths = 0;

            _armor = new Armor();
            _position = new GameObjectPosition(0, 0);


            SetDefaultValues();

        }
        public string Nickname { get { return _nickname; } }

        public Weapon Weapon { get { return _weapon; } }

        public int Ammo { get { return _ammo; } }
        public Armor Armor { get { return _armor; } }

        public int Frags { get { return _frags; } }

        public int Deaths { get { return _deaths; } }
        public int HP { get { return _hP; } }
        public int MaxHP { get { return _maxHP; } }

        public char Model { get { return _model; } }

        public int ViewAngle { get { return _viewAngle; } }
        public char ModelViewTop { get { return _modelViewTop; } }
        public char ModelViewBot { get { return _modelViewBottom; } }
        public char ModelViewLeft { get { return _modelViewLeft; } }
        public char ModelViewRight { get { return _modelViewRight; } }
        public GameObjectPosition Position { get { return _position; } set { } }
       
        public void PickUpArmor()
        {
            _armor.ArmorValue += 50;                                   //set otkritii v armore (
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
            else if (angle==DirectionLeft)
            {
                _model = _modelViewLeft;

            }
            else if (angle==DirectionRight)
            {
                _model = _modelViewRight;
            }
        }
        public int ChangeDirection(int angle)
        {
            _viewAngle = angle;
            _position.Direction = angle;
            ChangePlayerModel(_viewAngle);
            return _viewAngle;
        }
        public void TakeDamage(int dmg)
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
            if (_hP <0)
            {
           
                _model = 'X';
                _deaths++;
            }
        }

        public void TakeMega()
        {
            if (_hP < MaxHP)
                _hP += 10;
            else if (_hP > MaxHP)
            { _hP -= MaxHP; }
        }
        public void TakeWeapon(Weapon weapon)
        {
            _weapon = weapon;
        }
        public void ChangeNickName(string name)
        {
            _nickname = name;
        }


        public void SetConfigPath(string path)
        {
            configPath = path;
        }
        public void Respawn()
        {

            _hP = 10;
            _armor.ArmorValue = 50;
            _position.RespawnPosition();
            ChangePlayerModel(_basicModel);
        }
        private void SetDefaultValues()
        {
            _hP = 10;
            _maxHP = 20;
            _position.RespawnPosition();
            _weapon = new Weapon();
            _model = '@';

        }

    }
}






