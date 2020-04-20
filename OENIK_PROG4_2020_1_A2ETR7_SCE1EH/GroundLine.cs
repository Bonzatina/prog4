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
            area = g.GetWidenedPathGeometry(new Pen(Brushes.Black, 2));
        }
    }
}
