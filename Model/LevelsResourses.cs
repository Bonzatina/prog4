using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Model
{
    class LevelsResourses
    {
        public Dictionary<string, Level> levels = new Dictionary<string, Level>();
        public LevelsResourses()
        {  
            Point[] oneSlice = new Point[]{
                new Point(0, 0),
                new Point(150, 0),
                new Point(200, 100),
                new Point(650, -80),
                new Point(850, -80),
            };

            Point[] secondSlice = new Point[]
            {
                new Point(200, -100),
                new Point(250, -100),
            };
            Point[][] grounds = new Point[][] { oneSlice, secondSlice };

            List<SpecialItem> specialItems = new List<SpecialItem>();
            specialItems.Add(new SpecialItem(0, GameModel.ZeroAxios, Brushes.Green, new Pen(Brushes.Black, 2), new RectangleGeometry(new Rect(220, -100, 20, 30))));
            specialItems.Add(new SpecialItem(0, GameModel.ZeroAxios, Brushes.Red, new Pen(Brushes.Black, 2), new EllipseGeometry(new Rect(700, -80, 20, 30))));

            levels.Add("level_1", new Level(new GroundLine(0, GameModel.ZeroAxios, grounds), specialItems));
        }
    }
}
