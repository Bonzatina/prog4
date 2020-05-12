namespace OENIK_PROG4_2020_1_A2ETR7_SCE1EH
{
    using System;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Threading;
    using Logic;
    using Model;
    using Renderer;

    class Control : FrameworkElement
    {
        private GameModel model;
        private GameLogic logic;
        private GameRenderer renderer;
        private DispatcherTimer timer;
        private DispatcherTimer bulletsTimer;

        public Control()
        {
            this.Loaded += this.Control_Loaded;
        }

        private void Control_Loaded(object sender, RoutedEventArgs e)
        {
            this.model = new GameModel(this.ActualWidth, this.ActualHeight);
            this.logic = new GameLogic(this.model);
            this.renderer = new GameRenderer(this.model);
            Window win = Window.GetWindow(this);
            if (win != null)
            {
                win.KeyDown += this.Win_KeyDown;
                this.timer = new DispatcherTimer();
                this.timer.Interval = TimeSpan.FromMilliseconds(50);
                this.timer.Tick += this.Timer_Tick;
                this.timer.Start();

                this.bulletsTimer = new DispatcherTimer();
                this.bulletsTimer.Interval = TimeSpan.FromMilliseconds(50);
                this.bulletsTimer.Tick += this.Bullets_timer_Tick;
                this.bulletsTimer.Start();
            }

            this.InvalidateVisual();
        }

        private void Bullets_timer_Tick(object sender, EventArgs e)
        {
            this.model.screen.playerBullets?.ForEach(bulet => bulet.Move());
            this.model.screen.enemies?.ForEach(enemy =>
            {
                if (enemy.bullet == null)
                {
                    // TODO continue with bullets
                    enemy.EnemyShoot();
                    model.screen.bullets.Add(enemy.bullet);
                    return;
                }
                else
                {
                    enemy.bullet.Move();
                    PathGeometry combGeoBulletVSGround = enemy.bullet.CombinedGeos(this.model.screen.groundLine);
                    if (combGeoBulletVSGround.GetArea() > 0 ||
                    enemy.bullet.CX < 0 || enemy.bullet.CY < 0 ||
                    enemy.bullet.CY > this.model.GameHeight || enemy.bullet.CX > this.model.GameWidth)
                    {
                        // TODO rework it, issue to remove bullet both from List and from enemy. or totally rework
                        model.screen.bullets.RemoveAt(model.screen.enemies.IndexOf(enemy));
                        enemy.bullet = null;
                    }

                    PathGeometry combGeoBulletVSPlayer = enemy.bullet?.CombinedGeos(model.player);
                    if (combGeoBulletVSPlayer != null && combGeoBulletVSPlayer.GetArea() > 0)
                    {
                        model.screen.bullets.RemoveAt(model.screen.enemies.IndexOf(enemy));
                        enemy.bullet = null;
                        logic.DecreasePlayerLife();
                        // TODO impement respawn method in GameLogic
                        this.model.player.CX = 10;
                        this.model.player.CY = 10;
                    }
                }

            });
            this.InvalidateVisual();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            PathGeometry combGeoPlayerVSGround = this.model.screen.groundLine.CombinedGeos(this.model.player);
            if (combGeoPlayerVSGround.GetArea() == 0)
            {
                this.logic.MovePlayer(Direction.Down);
            }
            else if (combGeoPlayerVSGround.GetArea() > 0)
            {
                // TODO use logic not model here
                this.model.player.CY = combGeoPlayerVSGround.Bounds.Top - 48;
            }

            // can't moove props used in WallItem
            this.model.player.CantMoveRight = false;
            this.model.player.CantMoveLeft = false;
            SpecialItem toRemove = null;
            this.model.screen.specialItems?.ForEach(item =>
            {
                PathGeometry combGeoPlayerVSSpecialItem = item.CombinedGeos(this.model.player);
                if (combGeoPlayerVSSpecialItem.GetArea() > 10)
                {
                    this.logic.OnPlayerPickUpItem(item);
                    toRemove = item.toRemove ? item : null;
                }
            });
            this.model.screen.specialItems?.Remove(toRemove);

            this.model.screen.enemies?.ForEach(enemy =>
            {
                // enemy.CY += 10;
                PathGeometry combGeoPlayerVSSpecialItem = enemy.CombinedGeos(model.player);
                if (combGeoPlayerVSSpecialItem.GetArea() > 0)
                {
                    // TODO impement respawn method in GameLogic
                    this.logic.DecreasePlayerLife();
                    this.model.player.CX = 10;
                    this.model.player.CY = 10;
                }
            });

            if (this.model.screen.doorNextScreen != null)
            {
                PathGeometry combGeoPlayerVSDoorNextScreen = this.model.screen.doorNextScreen.CombinedGeos(this.model.player);
                if (combGeoPlayerVSDoorNextScreen.GetArea() > 0)
                {
                    this.logic.ChangeScreen();
                }
            }

            if (this.model.player.CY > this.model.GameHeight)
            {
                MessageBox.Show("Fail!");

                // TODO impement respawn method in GameLogic
                this.model.player.CX = 10;
                this.model.player.CY = 10;
                this.logic.DecreasePlayerLife();
            }

            this.InvalidateVisual();
        }

        private void Win_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Right: this.logic.MovePlayer(Direction.Right); break;
                case Key.Left: this.logic.MovePlayer(Direction.Left); break;
                // case Key.Down: this.logic.PlayerShoot(); break;
                case Key.Space: this.logic.RotateSreen(); break;
                case Key.D: double cy = this.model.player.CY - GameModel.ZeroAxios;
                    MessageBox.Show(this.model.player.CX.ToString(), cy.ToString()); break; // dev
            }

            this.InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (this.renderer != null) renderer.BuildDisplay(drawingContext);
        }
    }
}
