﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Logic
{
    public enum Direction { Left, Right }
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
            else model.player.CX -= 10;
        }

        public void RotateLevel()
        {
            TransformGroup tg = new TransformGroup();
            tg.Children.Add(new MatrixTransform(new Matrix(1, 0, 0, -1, 0, 0)));
            model.level.groundLine.area.Transform = tg;
            model.level.groundLine.area = model.level.groundLine.area.GetFlattenedPathGeometry();

            model.level.specialItems?.ForEach(item => {
                item.area.Transform = tg;
                item.area = item.area.GetFlattenedPathGeometry();
            });
        }
    }
}