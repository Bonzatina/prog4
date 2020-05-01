﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GameModel
    {
        public double GameWidth { get; private set; }
        public double GameHeight { get; private set; }
        public static int ZeroAxios { get; private set; }
        public Player player;
        public Level level;

        public GameModel(double w, double h)
        {
            GameWidth = w;
            GameHeight = h;
            ZeroAxios = (int)h / 2;
            player = new Player(10, 10);

            LevelsResourses resourses = new LevelsResourses();
            level = resourses.levels["level_1"];
        }
    }
}