namespace Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Media;
    using Model;
    using Model.Bullets;

    public enum Direction { Left, Right, Up, Down }

    public class GameLogic : IGameLogic
    {
        private GameModel model;

        public GameLogic(GameModel model)
        {
            this.model = model;
        }

        public void MovePlayer(Direction dir)
        {
            if (dir == Direction.Right)
            {
                if (model.player.CantMoveRight)
                {
                    return;
                }
                this.model.player.PreviosCX = model.player.CX;
                model.player.CX += 7;
            }
            if (dir == Direction.Left)
            {
                if (model.player.CantMoveLeft)
                {
                    return;
                }
                this.model.player.PreviosCX = model.player.CX;
                model.player.CX -= 7;
            }
            if (dir == Direction.Up)
            {

            }
            if (dir == Direction.Down)
            {
                model.player.CY += 10;
            }
        }
        public void SetPlayerPosition(double cx, double cy)
        {
            model.player.CX = cx;
            model.player.CY = cy;
        }

        public void ResetCantPlayerMoove()
        {
            model.player.CantMoveRight = false;
            model.player.CantMoveLeft = false;
        }

        public void PlayerShoot()
        {
            if (model.player.CantShoot)
            {
                return;
            }
            Bullet bullet = this.model.player.PlayerShoot();
            model.screen.playerBullets.Add(bullet);
        }
         public bool RemovePlayerBullet(Bullet bullet)
        {
            if (model.screen.playerBullets.Contains(bullet))
            {
                // TODO 
                model.screen.playerBullets.Remove(bullet);
                return true;
            }
            return false;
        }

        public void RotateSreen()
        {
            TransformGroup tg = new TransformGroup();
            tg.Children.Add(new MatrixTransform(new Matrix(1, 0, 0, -1, 0, 0)));
            model.screen.groundLine.area.Transform = tg;
            model.screen.groundLine.area = model.screen.groundLine.area.GetFlattenedPathGeometry();

            model.screen.specialItems?.ForEach(item =>
            {
                item.area.Transform = tg;
                item.area = item.area.GetFlattenedPathGeometry();
            });
            model.screen.enemies?.ForEach(enemy =>
            {
                enemy.area.Transform = tg;
                enemy.area = enemy.area.GetFlattenedPathGeometry();
            });
            model.screen.enemiesBullets?.ForEach(bullet =>
            {
                bullet.area.Transform = tg;
                bullet.area = bullet.area.GetFlattenedPathGeometry();
            });
            if (model.screen.doorNextScreen != null)
            {
                model.screen.doorNextScreen.area.Transform = tg;
                model.screen.doorNextScreen.area = model.screen.doorNextScreen.area.GetFlattenedPathGeometry();
            }

        }

        public void ChangeScreen()
        {
            model.screen.doorNextScreen.OnPlayerPickUp(model);
            RespawnPlayer();
        }

        public void IncreasePlayerLife()
        {
            model.player.Lives++;
        }

        public void DecreasePlayerLife()
        {
            //if (model.player.Lives > 0)
            //{
                model.player.Lives--;
                RespawnPlayer();
            //}
        }

        public void SetLivesOfPlayerTo(int numberOfLives)
        {
            if (numberOfLives >= 0)
            {
                model.player.Lives = numberOfLives;
            }
        }

        public void OnPlayerPickUpItem(SpecialItem item)
        {
            item.OnPlayerPickUp(this.model);
            if (item.toRespawn)
            {
                RespawnPlayer();
            }
        }

        public List<Enemy> GetAllEnemies()
        {
            return model.screen.enemies;
        }

        public void AddEnemy(Enemy enemy)
        {
            model.screen.enemies.ToList().Add(enemy);
        }

        public void AddEnemies(List<Enemy> enemies)
        {
            foreach (Enemy item in enemies)
            {
                this.AddEnemy(item);
            }
        }

        public bool RemoveEnemy(Enemy enemy) // returns false if enemy was not found.
        {
            if (model.screen.enemies != null && model.screen.enemies.Contains(enemy))
            {
                model.screen.enemies.Remove(enemy);
                return true;
            }
            return false;
        }

        public bool RemoveEnemies(List<Enemy> enemies) // if ANY of the enemies was not found, at the end of the process, output will be false;
        {
            bool output = false;
            foreach (Enemy item in enemies)
            {
                output = false;
                if (this.RemoveEnemy(item))
                {
                    output = true;
                }
            }
            return output;
        }

        public void RemoveAllEnemies()
        {
            model.screen.enemies.Clear();
        }

        public List<Bullet> GetAllBullets()
        {
            return model.screen.enemiesBullets;
        }

        public void AddEnemyBullet(Bullet bullet)
        {
            model.screen.enemiesBullets.Add(bullet);
        }

        public void AddBullets(List<Bullet> bullets)
        {
            foreach (Bullet item in bullets)
            {
                this.AddEnemyBullet(item);
            }
        }

        public bool RemoveEnemyBullet(Bullet bullet) // returns false if bullet was not found.
        {
            if (model.screen.enemiesBullets.Contains(bullet))
            {
                model.screen.enemiesBullets.Remove(bullet);
                return true;
            }
            return false;
        }

        public bool RemoveBullets(List<Bullet> bullets) // if ANY of the bullets was not found, at the end of the process, output will be false;
        {
            bool output = false;
            foreach (Bullet item in bullets)
            {
                output = false;
                if (this.RemoveEnemyBullet(item))
                {
                    output = true;
                }
            }
            return output;
        }

        public void RemoveAllBullets()
        {
            model.screen.enemiesBullets.Clear();
        }

        public void SetPlayerScoreTo(int amount)
        {
            model.player.score = amount;
        }

        public void AddAmountToPlayerScore(int amount)
        {
            model.player.score += amount;
        }

        public void SetRespawnPoint(int CX, int CY)
        {
            if (CX < 0 || CY < 0)
            {
                throw new ArgumentException("Coordinates of respawn point cannot be set as negative.");
            }
            else
            {
                model.RespawnCX = CX;
                model.RespawnCY = CY;
            }
        }

        public void RespawnPlayer()
        {
            if (model.player.Lives >= 0)
            {
                model.player.CX = model.RespawnCX;
                model.player.CY = model.RespawnCY;
            }
            return;
        }
    }
}
