using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Bullets
{
    public class MiniBullet : Bullet
    {
        public MiniBullet(double cx, double cy, double dx, double dy) : base(cx, cy, dx, dy, 7)
        {

        }
    }
}
