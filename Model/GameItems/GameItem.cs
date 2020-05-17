using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Model
{
    public abstract class GameItem
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
                area.Transform = tg;
                return area.GetFlattenedPathGeometry();
            }
        }
        public PathGeometry CombinedGeos(GameItem other)
        {
            return Geometry.Combine(this.RealArea, other.RealArea, GeometryCombineMode.Intersect, null).GetFlattenedPathGeometry();
        }
    }
}
