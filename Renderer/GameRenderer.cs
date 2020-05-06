﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Renderer
{
    public class GameRenderer
    {
        GameModel model;
        public Rect bgRect;
        public int livesCounter;

        public GameRenderer(GameModel model)
        {
            this.model = model;
            bgRect = new Rect(0, 0, model.GameWidth, model.GameHeight);
        }

        public void BuildDisplay(DrawingContext ctx)
        {
            DrawBackground(ctx);
            DrawLevel(ctx);
            DrawPlayer(ctx);
        }

        private void DrawLevel(DrawingContext ctx)
        {
            ctx.DrawGeometry(Brushes.Black, new Pen(Brushes.Black, 2), model.screen.groundLine.RealArea);
            model.screen.specialItems?.ForEach(item => ctx.DrawGeometry(item.brush, item.pen, item.RealArea));
            model.screen.enemies?.ForEach(item => ctx.DrawGeometry(Brushes.Red, new Pen(Brushes.Black, 2), item.RealArea));
            //Console.WriteLine(model.player.Lives);
            for (int i = 0; i < model.player.Lives; i++)
            {
                ctx.DrawGeometry(Brushes.BlueViolet, new Pen(Brushes.Brown, 2), new EllipseGeometry(new Rect(i* 25, 7, 20, 20)));
            }
            if (model.screen.doorNextScreen != null)
            {
                  ctx.DrawGeometry(model.screen.doorNextScreen.brush, model.screen.doorNextScreen.pen, model.screen.doorNextScreen.RealArea);
            }
           
            
        }

        private void DrawPlayer(DrawingContext ctx)
        {
            ctx.DrawGeometry(null, new Pen(Brushes.Black, 3), model.player.RealArea);
        }

        private void DrawBackground(DrawingContext ctx)
        {
            ctx.DrawRectangle(Brushes.White, null, bgRect);
        }
    }
}
