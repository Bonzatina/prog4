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
        public Screen screen;
        public int RespawnCX { get; set; } // Marcell: not sure which class should have the responsibility of storing the respawnpoint ? Should the constructor require input for setting the spawnpoint, like gamewidth & height ?
        public int RespawnCY { get; set; }

        public GameModel(double w, double h)
        {
            GameWidth = w;
            GameHeight = h;
            ZeroAxios = (int)h / 2;
            player = new Player(10, 10)
            {
                Lives = 3
            };

            screen = LevelsResourses.screens["screen_1"];
        }
    }
}
