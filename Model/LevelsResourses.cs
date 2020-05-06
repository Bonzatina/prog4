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
        public Dictionary<string, Screen> screens = new Dictionary<string, Screen>();
        public LevelsResourses()
        {  
            // first screen
            Point[] oneSlice1 = new Point[]{
                new Point(0, 0),
                new Point(150, 0),
                new Point(200, 100),
                new Point(650, -80),
                new Point(850, -80),
            };

            Point[] secondSlice1 = new Point[]
            {
                new Point(200, -100),
                new Point(250, -100),
            };
            Point[][] grounds1 = new Point[][] { oneSlice1, secondSlice1 };

            
            List<SpecialItem> specialItems1 = new List<SpecialItem>();
            //specialItems.Add(new SpecialItem(0, GameModel.ZeroAxios, Brushes.Green, new Pen(Brushes.Black, 2), new RectangleGeometry(new Rect(220, -100, 20, 30))));
            specialItems1.Add(new IncreaseHealthItem(1, 220, GameModel.ZeroAxios, Brushes.BlueViolet, new Pen(Brushes.Black, 2), GameShapes.gameShapes["plusOneLiveShape"]));
            specialItems1.Add(new DecreaseHealthItem(1, 700, GameModel.ZeroAxios, Brushes.Red, new Pen(Brushes.Black, 2), GameShapes.gameShapes["spikesShape"]
                ));

            List<Enemy> enemies1 = new List<Enemy>();
            enemies1.Add(new MediumEnemy(500, GameModel.ZeroAxios, GameShapes.gameShapes["mediumEnemy"]));

            screens.Add("screen_1", new Screen(new GroundLine(0, GameModel.ZeroAxios, grounds1), specialItems1, enemies1));


            // second screen
            Point[] oneSlice2 = new Point[]{
                new Point(0, 0),
                new Point(150, 0),
       
            };
            Point[][] grounds2 = new Point[][] { oneSlice2 };

            screens.Add("screen_2", new Screen(new GroundLine(0, GameModel.ZeroAxios, grounds2)));


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
            gameShapes.Add("spikesShape", spikesShape.GetWidenedPathGeometry(new Pen(Brushes.Black, 2)));

            Geometry plusOneLiveShape = new EllipseGeometry(new Rect(0, -100, 20, 30));
            gameShapes.Add("plusOneLiveShape", plusOneLiveShape);

            GeometryGroup mediumEnemyShape = new GeometryGroup();
            mediumEnemyShape.Children.Add(new EllipseGeometry(new Rect(0, 0, 10, 50)));
            gameShapes.Add("mediumEnemy", mediumEnemyShape);
            //new RectangleGeometry(new Rect(0, 0, 10, 50))

        }
    }
}
