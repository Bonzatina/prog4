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
        private DispatcherTimer playerStaminaTimer;

        public Control()
        {
            this.Loaded += this.Control_Loaded;
            this.Unloaded += Control_Unloaded;
        }

        private void Control_Unloaded(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            bulletsTimer.Stop();
            playerStaminaTimer.Stop();
            this.timer = null;
            this.bulletsTimer = null;
            this.playerStaminaTimer = null;
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

                this.playerStaminaTimer = new DispatcherTimer();
                this.playerStaminaTimer.Interval = TimeSpan.FromMilliseconds(500);
                this.playerStaminaTimer.Tick += PlayerStaminaTimer_Tick;
                this.playerStaminaTimer.Start();               
            }

            this.InvalidateVisual();
        }

        private void PlayerStaminaTimer_Tick(object sender, EventArgs e)
        {
            model.player.CantShoot = false;
        }

        private void Bullets_timer_Tick(object sender, EventArgs e)
        {
            Bullet toRemovePlayerBullet = null;
            Enemy toRemoveEnemy = null;
            this.model.screen.playerBullets?.ForEach(playerBullet => {
                playerBullet.Move();
      
                model.screen.enemies?.ForEach(enemy =>
                {
                    PathGeometry combGeoBulletVSEnemy = playerBullet.CombinedGeos(enemy);
                    if (combGeoBulletVSEnemy != null && combGeoBulletVSEnemy.GetArea() > 0)
                    {                 
                        toRemoveEnemy = enemy;
                        toRemovePlayerBullet = playerBullet;
                        logic.RemoveEnemyBullet(toRemoveEnemy.bullet);
                        playerBullet = null;
                    }
                });
                if (playerBullet != null)
                {
                    PathGeometry combGeoBulletVSGround = playerBullet?.CombinedGeos(this.model.screen.groundLine);
                    double bulletCx = (playerBullet.RealArea.Bounds.Right + playerBullet.RealArea.Bounds.Left) / 2;
                    if (combGeoBulletVSGround != null && combGeoBulletVSGround.GetArea() > 0 ||
                    bulletCx < 0 || playerBullet.CY < 0 ||
                    playerBullet.CY > this.model.GameHeight || bulletCx > this.model.GameWidth)
                    {
                        toRemovePlayerBullet = playerBullet;
                        //enemyBullet = null;
                    }
                }
            });
            logic.RemoveEnemy(toRemoveEnemy);
            logic.RemovePlayerBullet(toRemovePlayerBullet);     
     
            this.model.screen.enemies?.ForEach(enemy =>
            {
                if (enemy.bullet == null)
                {
                    // TODO continue with bullets
                    enemy.EnemyShoot();
                    logic.AddEnemyBullet(enemy.bullet);
                    return;
                }
                Bullet toRemoveEnemyBullet = null;

                enemy.bullet.Move();
                PathGeometry combGeoBulletVSGround = enemy.bullet.CombinedGeos(this.model.screen.groundLine);
                double bulletCx = (enemy.bullet.RealArea.Bounds.Right + enemy.bullet.RealArea.Bounds.Left) / 2;
                if (combGeoBulletVSGround.GetArea() > 0 ||
                    bulletCx < 0 || enemy.bullet.CY < 0 ||
                    enemy.bullet.CY > this.model.GameHeight || bulletCx > this.model.GameWidth)
                    {
                        toRemoveEnemyBullet = enemy.bullet;
                        enemy.bullet = null;
                    }

                PathGeometry combGeoBulletVSPlayer = enemy.bullet?.CombinedGeos(model.player);
                if (combGeoBulletVSPlayer != null && combGeoBulletVSPlayer.GetArea() > 0)
                    {
                        toRemoveEnemyBullet = enemy.bullet;
                        enemy.bullet = null;
                        logic.DecreasePlayerLife();
                        logic.RespawnPlayer();
                    }
                logic.RemoveEnemyBullet(toRemoveEnemyBullet);
            });            
          
            this.InvalidateVisual();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            PathGeometry combGeoPlayerVSGround = this.model.screen.groundLine.CombinedGeos(this.model.player);
            if (combGeoPlayerVSGround.GetArea() == 0)
            {
                logic.MovePlayer(Direction.Down);
            }
            else if (combGeoPlayerVSGround.GetArea() > 0)
            {    
                logic.SetPlayerPosition(model.player.CX, combGeoPlayerVSGround.Bounds.Top - 48);
            }

            // can't moove props used in WallItem
            logic.ResetCantPlayerMoove();
            SpecialItem toRemove = null;
            model.screen.specialItems?.ForEach(item =>
            {
                PathGeometry combGeoPlayerVSSpecialItem = item.CombinedGeos(this.model.player);
                if (combGeoPlayerVSSpecialItem.GetArea() > 10)
                {
                    logic.OnPlayerPickUpItem(item);
                    toRemove = item.toRemove ? item : null;
                }
            });
            model.screen.specialItems?.Remove(toRemove);

            model.screen.enemies?.ForEach(enemy =>
            {
                // enemy.CY += 10;
                PathGeometry combGeoPlayerVSSpecialItem = enemy.CombinedGeos(model.player);
                if (combGeoPlayerVSSpecialItem.GetArea() > 0)
                {         
                    logic.DecreasePlayerLife();
                    logic.RespawnPlayer();
                }
            });

            if (model.screen.doorNextScreen != null)
            {
                PathGeometry combGeoPlayerVSDoorNextScreen = this.model.screen.doorNextScreen.CombinedGeos(this.model.player);
                if (combGeoPlayerVSDoorNextScreen.GetArea() > 0)
                {
                    logic.ChangeScreen();
                }
            }

            if (model.player.CY > model.GameHeight)
            {
                MessageBox.Show("Fail!");
                logic.DecreasePlayerLife();
                logic.RespawnPlayer();
      
            }
            if (model.player.Lives < 0)
            {      
                MessageBox.Show("You loose :( ");

                
                Window saveResultWindow = new SaveResultWindow(((FinalScoreViewModel)Window.GetWindow(this).DataContext), model.player.score.ToString());
                Window.GetWindow(this).Close();
                saveResultWindow.ShowDialog();
            }
            InvalidateVisual();
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

            InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (this.renderer != null) renderer.BuildDisplay(drawingContext);
        }
    }
}
