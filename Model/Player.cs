using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Model
{
    public class Player : GameItem
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
