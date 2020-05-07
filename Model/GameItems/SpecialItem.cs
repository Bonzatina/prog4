using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Model
{
    public class SpecialItem : GameItem, ISpecialItem
    {
        public bool toRemove = false;
        public Brush brush;
        public Pen pen;

        public SpecialItem(double cx, double cy, Brush brush, Pen pen, Geometry area)
        {
            this.CX = cx;
            this.CY = cy;

            this.brush = brush;
            this.pen = pen;
            this.area = area;
        }

        public virtual void OnPlayerPickUp(GameModel model)
        {

        }
    }
}
