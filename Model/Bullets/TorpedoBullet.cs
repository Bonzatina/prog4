using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Bullets
{
    public class TorpedoBullet : Bullet
    {
        public TorpedoBullet(double cx, double cy, double dx, double dy) : base(cx, cy, dx, dy, 100)
        {

        }
    }
}
