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
        public GroundLine(double cx, double cy, Point[][] grounds)
        {
            this.CX = cx;
            this.CY = cy;
            GeometryGroup g = new GeometryGroup();          

            foreach (var slice in grounds)
            {
                for (int i = 0; i < slice.Length - 1; i++)
                {
                    g.Children.Add(new LineGeometry(slice[i], slice[i + 1]));
                }
            }
            
          

           

            
            //g.Children.Add(new LineGeometry(p1, p2));
            //g.Children.Add(new LineGeometry(p2, p3));
            //g.Children.Add(new LineGeometry(p3, p4));
            //g.Children.Add(new LineGeometry(p4, p5));
            //g.Children.Add(new LineGeometry(p6, p7));
            area = g.GetWidenedPathGeometry(new Pen(Brushes.Black, 2));

  
            
        }

        public void Rotate()
        {
            //area.Transform = new RotateTransform(50, CX, CY);
        }
    }
}
