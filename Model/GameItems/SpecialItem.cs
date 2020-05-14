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
        public bool toRespawn = false;
        public Brush brush;
        public Pen pen;

        public SpecialItem(Brush brush, Pen pen, Geometry area)
        {
            this.CX = 0;
            this.CY = GameModel.ZeroAxios;

            this.brush = brush;
            this.pen = pen;
            this.area = area;
        }

        public virtual void OnPlayerPickUp(GameModel model)
        {

        }
    }
}
