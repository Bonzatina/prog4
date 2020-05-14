using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Model
{
    public class GameModel
    {
        public double GameWidth { get; private set; }
        public double GameHeight { get; private set; }
        public static int ZeroAxios { get; private set; }
        public Player player;
        public LevelsResourses levelsResourses;
        public Screen screen;
        public int RespawnCX { get; set; }
        public int RespawnCY { get; set; }

        public GameModel(double w, double h)
        {
            GameWidth = w;
            GameHeight = h;
            ZeroAxios = (int)h / 2;
            RespawnCX = 10;
            RespawnCY = 50;
            player = new Player(RespawnCX, RespawnCY)
            {
                Lives = 3
            };
            levelsResourses = new LevelsResourses();
            screen = levelsResourses.screens["screen_1"];
        }
    }
}
