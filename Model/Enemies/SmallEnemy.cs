using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Model.Enemies
{
    public class SmallEnemy : Enemy
    {
        public SmallEnemy(double cx, double cy, Geometry area) : base(cx, cy, 75, area)
        {

        }
    }
}
