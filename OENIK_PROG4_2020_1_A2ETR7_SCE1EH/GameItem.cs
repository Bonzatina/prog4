using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace OENIK_PROG4_2020_1_A2ETR7_SCE1EH
{
    abstract class GameItem
    {
        public Geometry area;

        public double CX { get; set; }
        public double CY { get; set; }

        public Geometry RealArea
        {
            get
            {
                TransformGroup tg = new TransformGroup();
                tg.Children.Add(new TranslateTransform(CX, CY));
                //tg.Children.Add(new MatrixTransform(new Matrix(-1, 0, 0, 1, 0, CY)));
                area.Transform = tg;
                return area.GetFlattenedPathGeometry();
            }
        }
        public PathGeometry CombinedGeos(GameItem other)
        {
            //Geometry geo = Geometry.Combine(this.RealArea, other.RealArea, GeometryCombineMode.Intersect, null);
            //Console.WriteLine(geo.GetFlattenedPathGeometry());
            return Geometry.Combine(this.RealArea, other.RealArea, GeometryCombineMode.Intersect, null).GetFlattenedPathGeometry();
        }
    }
}
