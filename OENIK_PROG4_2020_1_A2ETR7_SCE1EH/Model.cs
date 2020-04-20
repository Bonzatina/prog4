using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace OENIK_PROG4_2020_1_A2ETR7_SCE1EH
{
    class Model
    {
        public double GameWidth { get; private set; }
        public double GameHeight { get; private set; }
        public int ZeroAxios { get; private set; }
        public Player player;
        public Level level;

        public Model(double w, double h)
        {
            GameWidth = w;
            GameHeight = h;
            ZeroAxios = (int)h / 2;
            player = new Player(10,10);
            List<SpecialItem> specialItems = new List<SpecialItem>();
            specialItems.Add(new SpecialItem(0, ZeroAxios, Brushes.Green, new Pen(Brushes.Black, 2), new RectangleGeometry(new Rect(220, -100, 20, 30))));
            specialItems.Add(new SpecialItem(0, ZeroAxios, Brushes.Red, new Pen(Brushes.Black, 2), new EllipseGeometry(new Rect(700, -80, 20, 30))));
            level = new Level(new RectangleGeometry(new Rect(0, 0, GameWidth, GameHeight)), new GroundLine(0, ZeroAxios), specialItems);
        }
    }
}
