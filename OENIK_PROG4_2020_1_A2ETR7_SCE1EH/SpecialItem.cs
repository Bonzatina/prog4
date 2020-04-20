using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace OENIK_PROG4_2020_1_A2ETR7_SCE1EH
{
    class SpecialItem : GameItem
    {
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
    }
}
