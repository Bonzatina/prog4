using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Model.Enemies
{
    public class MediumEnemy : Enemy
    {
        public MediumEnemy(double cx, double cy, Geometry area) : base(cx, cy, 150, area)
        {

        }
    }
}
