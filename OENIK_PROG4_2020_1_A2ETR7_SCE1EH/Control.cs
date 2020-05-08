using Logic;
using Model;
using Renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace OENIK_PROG4_2020_1_A2ETR7_SCE1EH
{
    class Control : FrameworkElement
    {
        GameModel model;
        GameLogic logic;
        GameRenderer renderer;
        DispatcherTimer timer;

        public Control()
        {
            Loaded += Control_Loaded;
        }

        private void Control_Loaded(object sender, RoutedEventArgs e)
        {
            model = new GameModel(ActualWidth, ActualHeight);
            logic = new GameLogic(model);
            renderer = new GameRenderer(model);
            Window win = Window.GetWindow(this);
            if (win != null)
            {
                win.KeyDown += Win_KeyDown;                
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(50);
                timer.Tick += Timer_Tick;
                timer.Start();
            }

            InvalidateVisual();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            PathGeometry combGeoPlayerVSGround = model.screen.groundLine.CombinedGeos(model.player); 
            if (combGeoPlayerVSGround.GetArea() == 0)
            {
                logic.MovePlayer(Direction.Down);
            }
            else if (combGeoPlayerVSGround.GetArea() > 0)
            {
                //TODO use logic not model here
                model.player.CY = combGeoPlayerVSGround.Bounds.Top - 48;

            }
            
            // can't moove props used in WallItem
            model.player.CantMoveRight = false;
            model.player.CantMoveRight = false;
            SpecialItem toRemove = null;
            model.screen.specialItems?.ForEach(item =>
            {
                PathGeometry combGeoPlayerVSSpecialItem = item.CombinedGeos(model.player);
                if (combGeoPlayerVSSpecialItem.GetArea() > 10)
                {
                    logic.OnPlayerPickUpItem(item);
                    toRemove = item.toRemove ? item : null;
                }
            });
            model.screen.specialItems?.Remove(toRemove);

            model.screen.enemies?.ForEach(enemy =>
            {
                //enemy.CY += 10;
                PathGeometry combGeoPlayerVSSpecialItem = enemy.CombinedGeos(model.player);
                if (combGeoPlayerVSSpecialItem.GetArea() > 0)
                {
                    // TODO move CX, CY asignments to logic
                    logic.DecreasePlayerLife();
                    model.player.CX = 10;
                    model.player.CY = 10;
                }
            });

            if (model.screen.doorNextScreen != null)
            {
                PathGeometry combGeoPlayerVSDoorNextScreen = model.screen.doorNextScreen.CombinedGeos(model.player);
                if (combGeoPlayerVSDoorNextScreen.GetArea() > 0)
                {
                    logic.ChangeScreen();
                }
            }
        
            if (model.player.CY > model.GameHeight)
            {
                MessageBox.Show("Fail!");
                //TODO impement respawn method in GameLogic
                model.player.CX = 10;
                model.player.CY = 10;
                logic.DecreasePlayerLife();
            }
            InvalidateVisual();
        }

        private void Win_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Right: logic.MovePlayer(Direction.Right) ; break;
                case Key.Left: logic.MovePlayer(Direction.Left); break;
                case Key.Space: logic.RotateSreen(); break;
                case Key.D: MessageBox.Show(model.player.CX.ToString(), model.player.CY.ToString()); break; // dev 
            }
            InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (renderer != null) renderer.BuildDisplay(drawingContext);
        }
    }
}
