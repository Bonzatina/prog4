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
            Geometry smallEnemyShape1 = GameShapes.gameShapes["smallEnemyShape"];
            TransformGroup smallEnemyShape1Transform = new TransformGroup();
            smallEnemyShape1Transform.Children.Add(new TranslateTransform(450, 40));
            smallEnemyShape1.Transform = smallEnemyShape1Transform;
            smallEnemyShape1 = smallEnemyShape1.GetFlattenedPathGeometry();

            //Geometry mediumEnemyShape2 = GameShapes.gameShapes["mediumEnemyShape"];
            //TransformGroup mediumEnemyShape2Transform = new TransformGroup();
            //mediumEnemyShape2Transform.Children.Add(new TranslateTransform(650, 135));
            //mediumEnemyShape2.Transform = mediumEnemyShape2Transform;
            //mediumEnemyShape2 = mediumEnemyShape2.GetFlattenedPathGeometry();

            enemies1.Add(new SmallEnemy(smallEnemyShape1));
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
            Point[] thirdSlice2 = new Point[]{
                new Point(580, 0),
                new Point(750, 100),
            };

            Point[][] grounds2 = new Point[][] { oneSlice2, secondSlice2, thirdSlice2 };

            List<SpecialItem> specialItems2 = new List<SpecialItem>();
            Geometry spikesShape_2_1 = GameShapes.gameShapes["spikesShape"];
            TransformGroup spikesShape_2_1_Tranform = new TransformGroup();
            spikesShape_2_1_Tranform.Children.Add(new TranslateTransform(600, 230));
            spikesShape_2_1_Tranform.Children.Add(new MatrixTransform(new Matrix(1, 0, 0, -1, 0, 0)));
            spikesShape_2_1.Transform = spikesShape_2_1_Tranform;
            spikesShape_2_1 = spikesShape_2_1.GetFlattenedPathGeometry(); ;

            Geometry plusScoresShape2_1 = GameShapes.gameShapes["plusScoresShape"];
            TransformGroup plusScoresShape2_1Transform = new TransformGroup();
            plusScoresShape2_1Transform.Children.Add(new TranslateTransform(530, -175));
            plusScoresShape2_1.Transform = plusScoresShape2_1Transform;
            plusScoresShape2_1 = plusScoresShape2_1.GetFlattenedPathGeometry();

            Geometry plusScoresShape2_2 = GameShapes.gameShapes["plusScoresShape"];
            TransformGroup plusScoresShape2_2Transform = new TransformGroup();
            plusScoresShape2_2Transform.Children.Add(new TranslateTransform(670, -90));
            plusScoresShape2_2.Transform = plusScoresShape2_2Transform;
            plusScoresShape2_2 = plusScoresShape2_2.GetFlattenedPathGeometry();

            Geometry plusOneLiveShape_2_1 = GameShapes.gameShapes["plusOneLiveShape"];
            TransformGroup plusOneLiveShape_2_1Transform = new TransformGroup();
            plusOneLiveShape_2_1Transform.Children.Add(new TranslateTransform(635, 232));
            plusOneLiveShape_2_1Transform.Children.Add(new MatrixTransform(new Matrix(1, 0, 0, -1, 0, 0)));
            plusOneLiveShape_2_1.Transform = plusOneLiveShape_2_1Transform;
            plusOneLiveShape_2_1 = plusOneLiveShape_2_1.GetFlattenedPathGeometry();

            specialItems2.Add(new DecreaseHealthItem(1, Brushes.Red, new Pen(Brushes.Black, 2), spikesShape_2_1));
            specialItems2.Add(new IncreasePlayerScoreItem(Brushes.Gold, new Pen(Brushes.Red, 2), plusScoresShape2_1));
            specialItems2.Add(new IncreasePlayerScoreItem(Brushes.Gold, new Pen(Brushes.Red, 2), plusScoresShape2_2));
            specialItems2.Add(new IncreaseHealthItem(1, Brushes.BlueViolet, new Pen(Brushes.Black, 2), plusOneLiveShape_2_1));

            List<Enemy> enemies2 = new List<Enemy>();

            Geometry smallEnemyShape_2_1 = GameShapes.gameShapes["smallEnemyShape"];
            TransformGroup smallEnemyShape_2_1Transform = new TransformGroup();
            smallEnemyShape_2_1Transform.Children.Add(new TranslateTransform(680, 65));
            smallEnemyShape_2_1.Transform = smallEnemyShape_2_1Transform;
            smallEnemyShape_2_1 = smallEnemyShape_2_1.GetFlattenedPathGeometry();

            Geometry mediumEnemyShape2_1 = GameShapes.gameShapes["mediumEnemyShape"];
            TransformGroup mediumEnemyShape2_1Transform = new TransformGroup();
            mediumEnemyShape2_1Transform.Children.Add(new TranslateTransform(440, -225));
            mediumEnemyShape2_1.Transform = mediumEnemyShape2_1Transform;
            mediumEnemyShape2_1 = mediumEnemyShape2_1.GetFlattenedPathGeometry();

            Geometry mediumEnemyShape2_2 = GameShapes.gameShapes["mediumEnemyShape"];
            TransformGroup mediumEnemyShape2_2Transform = new TransformGroup();
            mediumEnemyShape2_2Transform.Children.Add(new TranslateTransform(800, -225));
            mediumEnemyShape2_2.Transform = mediumEnemyShape2_2Transform;
            mediumEnemyShape2_2 = mediumEnemyShape2_2.GetFlattenedPathGeometry();

            enemies2.Add(new SmallEnemy(smallEnemyShape_2_1));
            enemies2.Add(new MediumEnemy(mediumEnemyShape2_1));
            enemies2.Add(new MediumEnemy(mediumEnemyShape2_2));


            Geometry doorNextScreenShape2 = new LineGeometry(new Point(0, 0), new Point(0, -160))
                .GetWidenedPathGeometry(new Pen(Brushes.Black, 2));
            TransformGroup doorNextScreenShape2Transform = new TransformGroup();
            doorNextScreenShape2Transform.Children.Add(new TranslateTransform(1263,  140));
            doorNextScreenShape2.Transform = doorNextScreenShape2Transform;
            doorNextScreenShape2 = doorNextScreenShape2.GetFlattenedPathGeometry();
            DoorNextScreen doorNextScreen2 = new DoorNextScreen("screen_3", Brushes.Black, new Pen(Brushes.Black, 5), doorNextScreenShape2);

            screens.Add("screen_2", new Screen(new GroundLine(grounds2), doorNextScreen2, specialItems2, enemies2));


            // third screen
            Point[] oneSlice3 = new Point[]{
                new Point(0, 0),
                new Point(100, 0),
                new Point(200, -30),
                new Point(300, -30),
                new Point(380, -160),
                new Point(490, -140),
                new Point(750, 140),
                new Point(950, 140),              
                new Point(1150, 10),
                new Point(1280, 10),

            };
            Point[] secondSlice3 = new Point[]{
                new Point(720, -200),
                new Point(880, -210),
                new Point(960, -110),
            };
            Point[] thirdSlice3 = new Point[]{
                new Point(241, 100),
                new Point(400, 100),
            };
            Point[][] grounds3 = new Point[][] { oneSlice3, secondSlice3, thirdSlice3 };

            List<SpecialItem> specialItems3 = new List<SpecialItem>();
            Geometry spikesShape_3_1 = GameShapes.gameShapes["spikesShape"];
            TransformGroup spikesShape_3_1_Tranform = new TransformGroup();
            spikesShape_3_1_Tranform.Children.Add(new TranslateTransform(665, 50));
            spikesShape_3_1_Tranform.Children.Add(new RotateTransform(50, 665, 50));
            spikesShape_3_1.Transform = spikesShape_3_1_Tranform;
            spikesShape_3_1 = spikesShape_3_1.GetFlattenedPathGeometry();

            Geometry spikesShape_3_2 = GameShapes.gameShapes["spikesShape"];
            TransformGroup spikesShape_3_2_Tranform = new TransformGroup();
            spikesShape_3_2_Tranform.Children.Add(new TranslateTransform(355, -125));
            spikesShape_3_2_Tranform.Children.Add(new RotateTransform(55, 355, -125));
            spikesShape_3_2_Tranform.Children.Add(new ScaleTransform(1, -1, 355, -125));
            spikesShape_3_2.Transform = spikesShape_3_2_Tranform;
            spikesShape_3_2 = spikesShape_3_2.GetFlattenedPathGeometry();

            Geometry wallShape3 = GameShapes.gameShapes["wallShape"];
            TransformGroup wallShape3Tranform = new TransformGroup();
            wallShape3Tranform.Children.Add(new TranslateTransform(275, -110));
            wallShape3.Transform = wallShape3Tranform;
            wallShape3 = wallShape3.GetFlattenedPathGeometry();

            Geometry plusOneLiveShape_3_1 = GameShapes.gameShapes["plusOneLiveShape"];
            TransformGroup plusOneLiveShape_3_1Transform = new TransformGroup();
            plusOneLiveShape_3_1Transform.Children.Add(new TranslateTransform(285, -70));   
            plusOneLiveShape_3_1.Transform = plusOneLiveShape_3_1Transform;
            plusOneLiveShape_3_1 = plusOneLiveShape_3_1.GetFlattenedPathGeometry();

            Geometry plusScoresShape3_1 = GameShapes.gameShapes["plusScoresShape"];
            TransformGroup plusScoresShape3_1Transform = new TransformGroup();
            plusScoresShape3_1Transform.Children.Add(new TranslateTransform(260, 110));
            plusScoresShape3_1.Transform = plusScoresShape3_1Transform;
            plusScoresShape3_1 = plusScoresShape3_1.GetFlattenedPathGeometry();

            Geometry plusScoresShape3_2 = GameShapes.gameShapes["plusScoresShape"];
            TransformGroup plusScoresShape3_2Transform = new TransformGroup();
            plusScoresShape3_2Transform.Children.Add(new TranslateTransform(750, -225));
            plusScoresShape3_2.Transform = plusScoresShape3_2Transform;
            plusScoresShape3_2 = plusScoresShape3_2.GetFlattenedPathGeometry();

            specialItems3.Add(new DecreaseHealthItem(1, Brushes.Red, new Pen(Brushes.Black, 2), spikesShape_3_1));
            specialItems3.Add(new DecreaseHealthItem(1, Brushes.Red, new Pen(Brushes.Black, 2), spikesShape_3_2));
            specialItems3.Add(new WallItem(Brushes.DarkKhaki, new Pen(Brushes.DarkGray, 2), wallShape3));
            specialItems3.Add(new IncreaseHealthItem(1, Brushes.BlueViolet, new Pen(Brushes.Black, 2), plusOneLiveShape_3_1));
            specialItems3.Add(new IncreasePlayerScoreItem(Brushes.Gold, new Pen(Brushes.Red, 2), plusScoresShape3_1));
            specialItems3.Add(new IncreasePlayerScoreItem(Brushes.Gold, new Pen(Brushes.Red, 2), plusScoresShape3_2));


            List<Enemy> enemies3 = new List<Enemy>();

            Geometry smallEnemyShape_3_1 = GameShapes.gameShapes["smallEnemyShape"];
            TransformGroup smallEnemyShape_3_1Transform = new TransformGroup();
            smallEnemyShape_3_1Transform.Children.Add(new TranslateTransform(465, -140));
            smallEnemyShape_3_1.Transform = smallEnemyShape_3_1Transform;
            smallEnemyShape_3_1 = smallEnemyShape_3_1.GetFlattenedPathGeometry();

            Geometry smallEnemyShape_3_2 = GameShapes.gameShapes["smallEnemyShape"];
            TransformGroup smallEnemyShape_3_2Transform = new TransformGroup();
            smallEnemyShape_3_2Transform.Children.Add(new TranslateTransform(1020, -250));
            smallEnemyShape_3_2.Transform = smallEnemyShape_3_2Transform;
            smallEnemyShape_3_2 = smallEnemyShape_3_2.GetFlattenedPathGeometry();

            Geometry mediumEnemyShape3_1 = GameShapes.gameShapes["mediumEnemyShape"];
            TransformGroup mediumEnemyShape3_1Transform = new TransformGroup();
            mediumEnemyShape3_1Transform.Children.Add(new TranslateTransform(1070, 10));
            mediumEnemyShape3_1.Transform = mediumEnemyShape3_1Transform;
            mediumEnemyShape3_1 = mediumEnemyShape3_1.GetFlattenedPathGeometry();

            Geometry mediumEnemyShape3_2 = GameShapes.gameShapes["mediumEnemyShape"];
            TransformGroup mediumEnemyShape3_2Transform = new TransformGroup();
            mediumEnemyShape3_2Transform.Children.Add(new TranslateTransform(100, 100));
            mediumEnemyShape3_2.Transform = mediumEnemyShape3_2Transform;
            mediumEnemyShape3_2 = mediumEnemyShape3_2.GetFlattenedPathGeometry();


            enemies3.Add(new SmallEnemy(smallEnemyShape_3_1));
            enemies3.Add(new SmallEnemy(smallEnemyShape_3_2));
            enemies3.Add(new MediumEnemy(mediumEnemyShape3_1));
            enemies3.Add(new MediumEnemy(mediumEnemyShape3_2));


            Geometry doorNextScreenShape3 = new LineGeometry(new Point(0, 0), new Point(0, -160))
              .GetWidenedPathGeometry(new Pen(Brushes.Black, 2));
            TransformGroup doorNextScreenShape3Transform = new TransformGroup();
            doorNextScreenShape3Transform.Children.Add(new TranslateTransform(1263, 100));
            doorNextScreenShape3.Transform = doorNextScreenShape3Transform;
            doorNextScreenShape3 = doorNextScreenShape3.GetFlattenedPathGeometry();
            DoorNextScreen doorNextScreen3 = new DoorNextScreen("screen_4", Brushes.Black, new Pen(Brushes.Black, 5), doorNextScreenShape3);

            screens.Add("screen_3", new Screen(new GroundLine(grounds3), doorNextScreen3, specialItems3, enemies3));


            // fourth screen
            Point[] oneSlice4 = new Point[]{
                new Point(0, 0),
                new Point(150, 0),

            };
            Point[][] grounds4 = new Point[][] { oneSlice4 };

            screens.Add("screen_4", new Screen(new GroundLine(grounds4)));

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

            GeometryGroup smallEnemyShape = new GeometryGroup();
            smallEnemyShape.Children.Add(new EllipseGeometry(new Rect(0, 0, 10, 50)));
            gameShapes.Add("smallEnemyShape", smallEnemyShape);


            Geometry mediumEnemyShape =  Geometry.Combine(new EllipseGeometry(new Rect(0, 0, 30, 30)), new EllipseGeometry(new Rect(-1, 5, 20, 20)),
                GeometryCombineMode.Exclude, null).GetFlattenedPathGeometry();

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
