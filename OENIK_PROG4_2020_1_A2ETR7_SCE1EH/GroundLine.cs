using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace OENIK_PROG4_2020_1_A2ETR7_SCE1EH
{
    class GroundLine : GameItem
    {
        public GroundLine(double cx, double cy)
        {
            this.CX = cx;
            this.CY = cy;

            Point p1 = new Point(0, 0);
            Point p2 = new Point(150, 0);
            Point p3 = new Point(200, 100);
            Point p4 = new Point(650, -80);
            Point p5 = new Point(850, -80);

            Point p6 = new Point(200, -100);
            Point p7 = new Point(250, -100);

            GeometryGroup g = new GeometryGroup();
            g.Children.Add(new LineGeometry(p1, p2));
            g.Children.Add(new LineGeometry(p2, p3));
            g.Children.Add(new LineGeometry(p3, p4));
            g.Children.Add(new LineGeometry(p4, p5));
            g.Children.Add(new LineGeometry(p6, p7));
            area = g.GetWidenedPathGeometry(new Pen(Brushes.Yellow, 2));

  
            
        }

        public void Rotate()
        {
            //area.Transform = new RotateTransform(50, CX, CY);
        }
    }
}
