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
            PathGeometry combGeoPlayerVSGround = model.level.groundLine.CombinedGeos(model.player);
            SpecialItem toRemove = null;
            model.level.specialItems?.ForEach(item =>
            {
                PathGeometry combGeoPlayerVSSpecialItem = item.CombinedGeos(model.player);
                if (combGeoPlayerVSSpecialItem.GetArea() > 0)
                {
                    toRemove = item;
                }
            });
            model.level.specialItems?.Remove(toRemove);

            if (combGeoPlayerVSGround.GetArea() == 0)
            {
                model.player.CY += 10;
            }
            else if (combGeoPlayerVSGround.GetArea() > 0)
            {
                model.player.CY = combGeoPlayerVSGround.Bounds.Top - 48;

            }
            if (model.player.CY > model.GameHeight)
            {
                MessageBox.Show("Fail!");
                model.player.CX = 10;
                model.player.CY = 10;
            }
            InvalidateVisual();
        }

        private void Win_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Right: logic.MovePlayer(Direction.Right) ; break;
                case Key.Left: logic.MovePlayer(Direction.Left); break;
                case Key.Space: logic.RotateLevel(); break;
            }
            InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (renderer != null) renderer.BuildDisplay(drawingContext);
        }
    }
}
