using Model.Enemies;
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
            //specialItems.Add(new SpecialItem(0, GameModel.ZeroAxios, Brushes.Green, new Pen(Brushes.Black, 2), new RectangleGeometry(new Rect(220, -100, 20, 30))));
            specialItems.Add(new IncreaseHealthItem(1, 220, GameModel.ZeroAxios, Brushes.Red, new Pen(Brushes.Black, 2), GameShapes.gameShapes["plusOneLiveShape"]));
            specialItems.Add(new DecreaseHealthItem(1, 700, GameModel.ZeroAxios, Brushes.Red, new Pen(Brushes.Black, 2), GameShapes.gameShapes["spikesShape"]
                .GetWidenedPathGeometry(new Pen(Brushes.Black, 2))));

            List<Enemy> enemies = new List<Enemy>();
            enemies.Add(new MediumEnemy(500,120));


            levels.Add("level_1", new Level(new GroundLine(0, GameModel.ZeroAxios, grounds), specialItems, enemies));
        }
    }

    public static  class GameShapes
    {
        public static  Dictionary<string, Geometry> gameShapes = new Dictionary<string, Geometry>();
        static GameShapes()
        {
            GeometryGroup spikesShape = new GeometryGroup();
            spikesShape.Children.Add(new LineGeometry(new Point(0, -80), new Point(5, -60)));
            spikesShape.Children.Add(new LineGeometry(new Point(5, -60), new Point(10, -80)));
            spikesShape.Children.Add(new LineGeometry(new Point(10, -80), new Point(15, -60)));
            spikesShape.Children.Add(new LineGeometry(new Point(15, -60), new Point(20, -80)));
            spikesShape.Children.Add(new LineGeometry(new Point(20, -80), new Point(25, -60)));
            spikesShape.Children.Add(new LineGeometry(new Point(25, -60), new Point(30, -80)));
            gameShapes.Add("spikesShape", spikesShape);

            Geometry plusOneLiveShape = new EllipseGeometry(new Rect(0, -100, 20, 30));
            gameShapes.Add("plusOneLiveShape", plusOneLiveShape);
        }
    }
}
