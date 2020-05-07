using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Model
{
    public class GroundLine : GameItem
    {
        public GroundLine(Point[][] grounds)
        {
            this.CX = 0;
            this.CY = GameModel.ZeroAxios;
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
