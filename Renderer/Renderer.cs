using Model;
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
            ctx.DrawGeometry(Brushes.Black, new Pen(Brushes.Black, 2), model.level.groundLine.RealArea);
            model.level.specialItems?.ForEach(item => ctx.DrawGeometry(item.brush, item.pen, item.RealArea));
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
