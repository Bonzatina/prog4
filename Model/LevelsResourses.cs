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
    public static class LevelsResourses
    {
        public static Dictionary<string, Screen> screens = new Dictionary<string, Screen>();
        static LevelsResourses()
        {  
            // first screen

            // arrays of points for grounds
            Point[] oneSlice1 = new Point[]{
                new Point(0, 0),
                new Point(150, 0),
                new Point(200, 100),
                new Point(650, -80),
                new Point(1280, -80),
            };

            Point[] secondSlice1 = new Point[]
            {
                new Point(200, -100),
                new Point(250, -100),
            };
            Point[][] grounds1 = new Point[][] { oneSlice1, secondSlice1 };


            // fill specialItems List
            List<SpecialItem> specialItems1 = new List<SpecialItem>();
            // get from Shapes dictionary needed shape
            Geometry plusOneLiveShape1 = GameShapes.gameShapes["plusOneLiveShape"];
            // create tranformation for it which will define it's position relative to x = 0, y = GameModel.ZeroAxios
            TransformGroup plusOneLiveShape1Transform = new TransformGroup();
            plusOneLiveShape1Transform.Children.Add(new TranslateTransform(220, -100)); // offsets from  x = 0, y = GameModel.ZeroAxios
            plusOneLiveShape1.Transform = plusOneLiveShape1Transform;
            // get final shape now we can add it to List
            plusOneLiveShape1 = plusOneLiveShape1.GetFlattenedPathGeometry();

            // go to next shape ...
            Geometry spikesShape1 = GameShapes.gameShapes["spikesShape"];
            TransformGroup spikesShape1Tranform = new TransformGroup();
            spikesShape1Tranform.Children.Add(new TranslateTransform(700, 0));
            spikesShape1.Transform = spikesShape1Tranform;
            spikesShape1 = spikesShape1.GetFlattenedPathGeometry();

            specialItems1.Add(new IncreaseHealthItem(1, Brushes.BlueViolet, new Pen(Brushes.Black, 2), plusOneLiveShape1));
            specialItems1.Add(new DecreaseHealthItem(1, Brushes.Red, new Pen(Brushes.Black, 2), spikesShape1));


            // fill enemies ...
            List<Enemy> enemies1 = new List<Enemy>();
            Geometry mediumEnemyShape1 = GameShapes.gameShapes["mediumEnemyShape"];
            TransformGroup mediumEnemyShape1Transform = new TransformGroup();
            mediumEnemyShape1Transform.Children.Add(new TranslateTransform(500, 0));
            mediumEnemyShape1.Transform = mediumEnemyShape1Transform;
            mediumEnemyShape1 = mediumEnemyShape1.GetFlattenedPathGeometry();

            enemies1.Add(new MediumEnemy(mediumEnemyShape1));

          
            // exit to next game screen
            Geometry doorNextScreenShape1 = new LineGeometry(new Point(0, 0), new Point(0, -160))
                .GetWidenedPathGeometry(new Pen(Brushes.Black, 2));
            TransformGroup doorNextScreenShape1Transform = new TransformGroup();
            doorNextScreenShape1Transform.Children.Add(new TranslateTransform(1263, 0));
            doorNextScreenShape1.Transform = doorNextScreenShape1Transform;
            doorNextScreenShape1 = doorNextScreenShape1.GetFlattenedPathGeometry();
            DoorNextScreen doorNextScreen1 = new DoorNextScreen(Brushes.Black, new Pen(Brushes.Black, 5), doorNextScreenShape1);

            screens.Add("screen_1", new Screen(new GroundLine(grounds1), specialItems1, enemies1, doorNextScreen1));


            // second screen
            Point[] oneSlice2 = new Point[]{
                new Point(0, 0),
                new Point(150, 0),
       
            };
            Point[][] grounds2 = new Point[][] { oneSlice2 };

            screens.Add("screen_2", new Screen(new GroundLine(grounds2)));


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

            Geometry plusOneLiveShape = new EllipseGeometry(new Rect(0, 0, 20, 30));
            gameShapes.Add("plusOneLiveShape", plusOneLiveShape);

            GeometryGroup mediumEnemyShape = new GeometryGroup();
            mediumEnemyShape.Children.Add(new EllipseGeometry(new Rect(0, 0, 10, 50)));
            gameShapes.Add("mediumEnemyShape", mediumEnemyShape);
            //new RectangleGeometry(new Rect(0, 0, 10, 50))

        }
    }
}
