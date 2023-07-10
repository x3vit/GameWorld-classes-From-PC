using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameWorldClassesUpgrade
{
    internal class Map
    {

        public char[,] CustomMap = null;
        public char[,] ReadMapJson(string path)
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
    };

}
