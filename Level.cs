using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSokoban
{
    enum LevelType
    {
        XsbLevel,
        HsbLevel
    }

    class Level
    {
        private char[,] levelData;

        public Level(int width, int height)
        {
            levelData = new char[width, height];
        }

        public string Author { get; set; }
        public string Title { get; set; }
        public LevelType Type { get; set; }
    }
}
