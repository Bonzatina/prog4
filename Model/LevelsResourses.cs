using Model.Enemies;
using Model.GameItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Model
{
    public  class LevelsResourses
    {
        public Dictionary<string, Screen> screens = new Dictionary<string, Screen>();
        public LevelsResourses()
        {  
            // first screen

            // arrays of points for grounds
            Point[] oneSlice1 = new Point[]{
                new Point(0, 0),
                new Point(230, 0),
                new Point(280, 100),
                new Point(730, -80),
                new Point(1280, -80),
            };

            Point[] secondSlice1 = new Point[]
            {
                new Point(280, -100),
                new Point(320, -100),
            };

            Point[] thirdSlice1 = new Point[]
      {
                new Point(700, 120),
                new Point(860, 120),
                new Point(970, 20),
      };
            Point[][] grounds1 = new Point[][] { oneSlice1, secondSlice1, thirdSlice1 };


            // fill specialItems List
            List<SpecialItem> specialItems1 = new List<SpecialItem>();
            // get from Shapes dictionary needed shape
            Geometry plusOneLiveShape1 = GameShapes.gameShapes["plusOneLiveShape"];
            // create tranformation for it which will define it's position relative to x = 0, y = GameModel.ZeroAxios
            TransformGroup plusOneLiveShape1Transform = new TransformGroup();
            plusOneLiveShape1Transform.Children.Add(new TranslateTransform(300, -100)); // offsets from  x = 0, y = GameModel.ZeroAxios
            plusOneLiveShape1.Transform = plusOneLiveShape1Transform;
            // get final shape now we can add it to List
            plusOneLiveShape1 = plusOneLiveShape1.GetFlattenedPathGeometry();

            // go to next shape ...
            Geometry spikesShape1 = GameShapes.gameShapes["spikesShape"];
            TransformGroup spikesShape1Tranform = new TransformGroup();
            spikesShape1Tranform.Children.Add(new TranslateTransform(180, 0));
            spikesShape1Tranform.Children.Add(new MatrixTransform(new Matrix(1, 0, 0, -1, 0, 0)));
            spikesShape1.Transform = spikesShape1Tranform;
            spikesShape1 = spikesShape1.GetFlattenedPathGeometry();

            Geometry spikesShape_1_2 = GameShapes.gameShapes["spikesShape"];
            TransformGroup spikesShape_1_2_Tranform = new TransformGroup();
            spikesShape_1_2_Tranform.Children.Add(new TranslateTransform(730, -80));     
            spikesShape_1_2.Transform = spikesShape_1_2_Tranform;
            spikesShape_1_2 = spikesShape_1_2.GetFlattenedPathGeometry(); ;

            Geometry plusScoresShape1 = GameShapes.gameShapes["plusScoresShape"];
            TransformGroup plusScoresShape1Transform = new TransformGroup();
            plusScoresShape1Transform.Children.Add(new TranslateTransform(480, 40));
            plusScoresShape1.Transform = plusScoresShape1Transform;
            plusScoresShape1 = plusScoresShape1.GetFlattenedPathGeometry();

            Geometry plusScoresShape2 = GameShapes.gameShapes["plusScoresShape"];
            TransformGroup plusScoresShape2Transform = new TransformGroup();
            plusScoresShape2Transform.Children.Add(new TranslateTransform(750, 140));
            plusScoresShape2.Transform = plusScoresShape2Transform;
            plusScoresShape2 = plusScoresShape2.GetFlattenedPathGeometry();


            Geometry wallShape1 = GameShapes.gameShapes["wallShape"];
            TransformGroup wallShape1Tranform = new TransformGroup();
            wallShape1Tranform.Children.Add(new TranslateTransform(575, -103));
            wallShape1.Transform = wallShape1Tranform;
            wallShape1 = wallShape1.GetFlattenedPathGeometry();

            specialItems1.Add(new IncreaseHealthItem(1, Brushes.BlueViolet, new Pen(Brushes.Black, 2), plusOneLiveShape1));
            specialItems1.Add(new DecreaseHealthItem(1, Brushes.Red, new Pen(Brushes.Black, 2), spikesShape1));
            specialItems1.Add(new DecreaseHealthItem(1, Brushes.Red, new Pen(Brushes.Black, 2), spikesShape_1_2));
            specialItems1.Add(new WallItem(Brushes.DarkKhaki, new Pen(Brushes.DarkGray, 2), wallShape1));
            specialItems1.Add(new IncreasePlayerScoreItem(Brushes.Gold, new Pen(Brushes.Red, 2), plusScoresShape1));
            specialItems1.Add(new IncreasePlayerScoreItem(Brushes.Gold, new Pen(Brushes.Red, 2), plusScoresShape2));

            // fill enemies ...
            List<Enemy> enemies1 = new List<Enemy>();
            Geometry mediumEnemyShape1 = GameShapes.gameShapes["mediumEnemyShape"];
            TransformGroup mediumEnemyShape1Transform = new TransformGroup();
            mediumEnemyShape1Transform.Children.Add(new TranslateTransform(450, 40));
            mediumEnemyShape1.Transform = mediumEnemyShape1Transform;
            mediumEnemyShape1 = mediumEnemyShape1.GetFlattenedPathGeometry();

            //Geometry mediumEnemyShape2 = GameShapes.gameShapes["mediumEnemyShape"];
            //TransformGroup mediumEnemyShape2Transform = new TransformGroup();
            //mediumEnemyShape2Transform.Children.Add(new TranslateTransform(650, 135));
            //mediumEnemyShape2.Transform = mediumEnemyShape2Transform;
            //mediumEnemyShape2 = mediumEnemyShape2.GetFlattenedPathGeometry();

            enemies1.Add(new MediumEnemy(mediumEnemyShape1));
            //enemies1.Add(new MediumEnemy(mediumEnemyShape2));

          
            // exit to next game screen
            Geometry doorNextScreenShape1 = new LineGeometry(new Point(0, 0), new Point(0, -160))
                .GetWidenedPathGeometry(new Pen(Brushes.Black, 2));
            TransformGroup doorNextScreenShape1Transform = new TransformGroup();
            doorNextScreenShape1Transform.Children.Add(new TranslateTransform(1263, 0));
            doorNextScreenShape1.Transform = doorNextScreenShape1Transform;
            doorNextScreenShape1 = doorNextScreenShape1.GetFlattenedPathGeometry();
            DoorNextScreen doorNextScreen1 = new DoorNextScreen("screen_2", Brushes.Black, new Pen(Brushes.Black, 5), doorNextScreenShape1);

            screens.Add("screen_1", new Screen(new GroundLine(grounds1), doorNextScreen1, specialItems1, enemies1));


            // second screen
            Point[] oneSlice2 = new Point[]{
                new Point(0, 0),
                new Point(150, 0),
                new Point(330, -230),
                new Point(930, -230),
                new Point(1200, 70),
                new Point(1280, 70),

            };
            Point[] secondSlice2 = new Point[]{ 
                new Point(330, 100),
                new Point(500, 200),
            };
            Point[] firstSlice2 = new Point[]{
                new Point(480, 0),
                new Point(650, 100),
            };

            Point[][] grounds2 = new Point[][] { oneSlice2, secondSlice2, firstSlice2 };

            Geometry doorNextScreenShape2 = new LineGeometry(new Point(0, 0), new Point(0, -160))
                .GetWidenedPathGeometry(new Pen(Brushes.Black, 2));
            TransformGroup doorNextScreenShape2Transform = new TransformGroup();
            doorNextScreenShape2Transform.Children.Add(new TranslateTransform(1263,  140));
            doorNextScreenShape2.Transform = doorNextScreenShape2Transform;
            doorNextScreenShape2 = doorNextScreenShape2.GetFlattenedPathGeometry();
            DoorNextScreen doorNextScreen2 = new DoorNextScreen("screen_3", Brushes.Black, new Pen(Brushes.Black, 5), doorNextScreenShape2);

            screens.Add("screen_2", new Screen(new GroundLine(grounds2), doorNextScreen2));


            // third screen
            Point[] oneSlice3 = new Point[]{
                new Point(0, 0),
                new Point(150, 0),

            };
            Point[][] grounds3 = new Point[][] { oneSlice3 };

            screens.Add("screen_3", new Screen(new GroundLine(grounds3)));


        }
    }

    public static  class GameShapes
    {
        public static  Dictionary<string, Geometry> gameShapes = new Dictionary<string, Geometry>();
        static GameShapes()
        {
            GeometryGroup spikesShape = new GeometryGroup();
            spikesShape.Children.Add(new LineGeometry(new Point(0, 0), new Point(5, 20)));
            spikesShape.Children.Add(new LineGeometry(new Point(5, 20), new Point(10, 0)));
            spikesShape.Children.Add(new LineGeometry(new Point(10, 0), new Point(15, 20)));
            spikesShape.Children.Add(new LineGeometry(new Point(15, 20), new Point(20, 0)));
            spikesShape.Children.Add(new LineGeometry(new Point(20, 0), new Point(25, 20)));
            spikesShape.Children.Add(new LineGeometry(new Point(25, 20), new Point(30, 0)));
            gameShapes.Add("spikesShape", spikesShape.GetWidenedPathGeometry(new Pen(Brushes.Black, 2)));

            Geometry plusOneLiveShape = new EllipseGeometry(new Rect(0, 0, 20, 30));
            gameShapes.Add("plusOneLiveShape", plusOneLiveShape);

            //Geometry wallShape = new LineGeometry(new Point(0, 0), new Point(0, 80))
            Geometry wallShape = new RectangleGeometry(new Rect(0, 0, 5, 80));
            //.GetWidenedPathGeometry(new Pen(Brushes.Black, 2));
            gameShapes.Add("wallShape", wallShape);

            GeometryGroup mediumEnemyShape = new GeometryGroup();
            mediumEnemyShape.Children.Add(new EllipseGeometry(new Rect(0, 0, 10, 50)));
            gameShapes.Add("mediumEnemyShape", mediumEnemyShape);

            Geometry plusScoresShape = new RectangleGeometry(new Rect(0, 0, 10, 10));
            TransformGroup tg = new TransformGroup();
            tg.Children.Add(new RotateTransform(45));
            plusScoresShape.Transform = tg;
            plusScoresShape = plusScoresShape.GetFlattenedPathGeometry();
            gameShapes.Add("plusScoresShape", plusScoresShape);
            //new RectangleGeometry(new Rect(0, 0, 10, 50))

        }
    }
}
