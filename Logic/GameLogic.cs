﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Logic
{
    public enum Direction { Left, Right, Up, Down }
    public class GameLogic
    {
        GameModel model;
        public GameLogic(GameModel model)
        {
            this.model = model;
        }

        public void MovePlayer(Direction dir)
        {
            if (dir == Direction.Right)
            {
                model.player.CX += 10;
            }
            if (dir == Direction.Left)
            {
                model.player.CX -= 10;
            }
            if (dir == Direction.Up)
            {

            }
            if (dir == Direction.Down)
            {
                model.player.CY += 10;
            }
        }

        public void RotateSreen()
        {
            TransformGroup tg = new TransformGroup();
            tg.Children.Add(new MatrixTransform(new Matrix(1, 0, 0, -1, 0, 0)));
            model.screen.groundLine.area.Transform = tg;
            model.screen.groundLine.area = model.screen.groundLine.area.GetFlattenedPathGeometry();

            model.screen.specialItems?.ForEach(item => {
                item.area.Transform = tg;
                item.area = item.area.GetFlattenedPathGeometry();
            });
            model.screen.enemies?.ForEach(enemy => {
                enemy.area.Transform = tg;
                enemy.area = enemy.area.GetFlattenedPathGeometry();
            });
            if (model.screen.doorNextScreen != null)
            {
                model.screen.doorNextScreen.area.Transform = tg;
                model.screen.doorNextScreen.area = model.screen.doorNextScreen.area.GetFlattenedPathGeometry();
            }
     
        }

        public void ChangeScreen()
        {
            model.screen.doorNextScreen.OnPlayerPickUp(model.player);
            model.screen = LevelsResourses.screens["screen_2"];      
        }

        public void IncreasePlayerLife()
        {
            model.player.Lives++;
        }

        public void DecreasePlayerLife()
        {
            if (model.player.Lives > 0)
            {
                model.player.Lives--;
            }
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
            item.OnPlayerPickUp(model.player);
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
            foreach(Enemy item in enemies)
            {
                this.AddEnemy(item);
            }
        }

        public bool RemoveEnemy(Enemy enemy) // returns false if enemy was not found.
        {
            if (model.screen.enemies.Contains(enemy))
            {
                model.screen.enemies.ToList().Remove(enemy);
                return true;
            }
            return false;
        }

        public bool RemoveEnemies(List<Enemy> enemies) // if ANY of the enemies was not found, at the end of the process, output will be false;
        {
            bool output = false;
            foreach(Enemy item in enemies)
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
    }
}
