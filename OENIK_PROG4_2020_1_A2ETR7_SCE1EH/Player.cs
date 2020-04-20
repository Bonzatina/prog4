using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace OENIK_PROG4_2020_1_A2ETR7_SCE1EH
{
    class Player : GameItem
    {        
        public Player(double cx, double cy)
        {
            this.CX = cx;
            this.CY = cy;
            GeometryGroup g = new GeometryGroup();
            area = new RectangleGeometry(new Rect(0, 0, 10, 50));
        }
    }
}
