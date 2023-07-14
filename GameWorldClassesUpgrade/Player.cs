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
        
        private Guid _id;
        private string _nickname;
        private Weapon _weapon;
        private int _ammo;
        private int _frags;
        private int _deaths;
        private int _hP;
        private int _maxHP;
        private Armor _armor;
        private PlayerPosition _position;
        private char _basicModel = '@';
        private char _model='@';
        private char _modelViewTop = '^';
        private char _modelViewBot = 'V';
        private char _modelViewRight = '>';
        private char _modelViewLeft = '<';
        public string configPath = @"E:\temp\defaultConfig.txt";
        public PlayerConfig Config;

        public Player()
        {
            _id = Guid.NewGuid();
            _nickname = "unknown";
            //_weapon = new Weapon();


            _frags = 0;
            _deaths = 0;

            _armor = new Armor();
            _position = new PlayerPosition(0, 0);
            Config = new PlayerConfig();

            SetDefaultValues();

        }
        public Player(string nickname)
        {
            _id = Guid.NewGuid();
            _nickname = nickname;
            _weapon = new Weapon();


            _frags = 0;
            _deaths = 0;

            _armor = new Armor();
            _position = new PlayerPosition(0, 0);


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
        
        public char Model { get { return _model; }  }    

        public char ModelViewTop { get { return _modelViewTop; }  }
        public char ModelViewBot { get { return _modelViewBot; } }
        public char ModelViewLeft { get { return _modelViewLeft; } }
        public char ModelViewRight { get { return _modelViewRight; } }  
        public PlayerPosition Position { get { return _position; } }
            
        public void PickUpArmor()
        {
            _armor.ArmorValue += 50;                                   //set otkritii v armore (
        }
        public void ChangePlayerModel(char model)
        {
            _model = model;
        }
        public void TakeDamage(Weapon weapon)
        {
            if(_armor.ArmorValue <= 0)
            _hP=_hP-weapon.Dmg;
            else
            {
                _hP=_hP-weapon.Dmg/2;
                _armor.ArmorValue -= weapon.Dmg/2;
                if(_armor.ArmorValue < 0)
                { _armor.ArmorValue = 0; }
            }
        }

        public void TakeMega()
        {if(_hP<MaxHP)
            _hP += 10;
        else if (_hP>MaxHP)
                { _hP -= MaxHP; }
        }
        public void TakeWeapon(Weapon weapon)
        {
            _weapon = weapon;
        }
        public void ChangeNickName(string name)
        {
            _nickname=name;
        }


        public void SetConfigPath(string path)
        {
           configPath=path;
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
        }
       
    }
}

      



