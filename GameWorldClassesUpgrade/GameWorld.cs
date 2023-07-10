using GameWorld_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameWorldClassesUpgrade
{
    internal class GameWorld
    {
     private Player _player;
        private List<Player> _players=new List<Player>();
       private GameScreen _gameScreen=new GameScreen();
        //private string _mapName;
        private int _timer;
        private int _maxRoundTime=60;
        private char _mega = 'M';
        private char _armor = 'A';
        private char _emptyField = 'o';

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
        public GameScreen GameScreen { get { return _gameScreen; } }
        
        public void RestartRound()
        {
            
           foreach(var player in Players)
            {
                player.Respawn();
                
            }
           //GameScreen.RestartMap();
           
          
        }
       public async void ShowTimer(int cursorPositionX, int cursorPositionY, int maxRoundTime = 60)
        {
            
            for (int i = maxRoundTime; i >= 0; i--)
            {
                Console.SetCursorPosition(cursorPositionY,cursorPositionX);
                Console.Write($"раунд:{i} сек.)");
                await Task.Delay(1000);
               
            }
            Console.Clear();
            Console.Write("новый раунд");
            RestartRound();
        }
        // состояигие катки часы,спавны
    }
    
}
