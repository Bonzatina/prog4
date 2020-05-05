using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Model.Enemies
{
    public class BossEnemy : Enemy
    {
        public BossEnemy(double cx, double cy, Geometry area) : base(cx, cy, 500, area)
        {

        }
    }
}
