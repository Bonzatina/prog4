﻿namespace Renderer
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using Model;

    public class GameRenderer
    {
        GameModel model;
        public Rect bgRect;
        public int livesCounter;
        FormattedText scoresCounter;

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
            DrawText(ctx);
        }

        private void DrawText(DrawingContext ctx)
        {
            scoresCounter = new FormattedText(
                  model.player.score.ToString(),
                  System.Globalization.CultureInfo.CurrentCulture,
                  FlowDirection.LeftToRight,
                   new Typeface("Arial"),
                  16,
                  Brushes.Black);
            ctx.DrawText(scoresCounter, new Point(1200, 10));
        }

        private void DrawLevel(DrawingContext ctx)
        {
            ctx.DrawGeometry(Brushes.Black, new Pen(Brushes.Black, 2), model.screen.groundLine.RealArea);
            model.screen.specialItems?.ForEach(item => ctx.DrawGeometry(item.brush, item.pen, item.RealArea));
            model.screen.enemies?.ForEach(item => ctx.DrawGeometry(Brushes.Red, new Pen(Brushes.Black, 2), item.RealArea));
            model.screen.playerBullets?.ForEach(bulet => ctx.DrawGeometry(Brushes.Brown, new Pen(Brushes.Black, 2), bulet.RealArea));
            model.screen.enemiesBullets?.ForEach(bulet => ctx.DrawGeometry(Brushes.Brown, new Pen(Brushes.Black, 2), bulet.RealArea));
            for (int i = 0; i < model.player.Lives; i++)
            {
                // draw lives counter
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
