using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StandardBullet : Bullet
    {
        public StandardBullet(double cx, double cy, double dx, double dy) : base(cx, cy, dx, dy, 20)
        {

        }
    }
}
