using GameWorld_classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GameWorldClassesUpgrade
{
    internal class PlayerConfig
    {
        public Dictionary<Player, PlayerConfig> playersConfigDictionary = new Dictionary<Player, PlayerConfig>();
        public ConsoleKey MoveTopButton=ConsoleKey.W;
        public ConsoleKey MoveLeftButton=ConsoleKey.A;
        public ConsoleKey MoveRightButton=ConsoleKey.D;
        public ConsoleKey MoveBotButton=ConsoleKey.S;
        public ConsoleColor PlayerColor=ConsoleColor.Red;
        
        [Newtonsoft.Json.JsonIgnore]
        public char PlayerBasicModel;           //не убирает при сериализации

        public void AddPlayerConfig(Player player,Dictionary<Player,PlayerConfig> playersConfig)
        {
            
        }
        public  PlayerConfig ReadConfig(string path,Player player)
        {
           
            string playerConfig = File.ReadAllText(@path);
            player.Config = JsonConvert.DeserializeObject<PlayerConfig>(playerConfig);
            return player.Config;
        }
        public PlayerConfig ReadConfig(Player player)
        {
            string playerConfig = File.ReadAllText(player.configPath);
            player.Config = JsonConvert.DeserializeObject<PlayerConfig>(playerConfig);
            return player.Config;
        }
        public void  WriteConfig(string path,Player player)
        {
            string playerSetup = Newtonsoft.Json.JsonConvert.SerializeObject(player.Config);
            File.WriteAllText(path, playerSetup);
           
        }
        
    }
}
