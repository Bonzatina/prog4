using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Model.Bullets
{
    public abstract class Bullet : GameItem
    {
        private int damage;

        public int Damage
        {
            get { return damage; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Bullet's damage can not be less than zero.", nameof(Damage));
                }
                else
                {
                    damage = value;
                }
            }
        }


        public Bullet(double cx, double cy, int damage)
        {
            this.CX = cx;
            this.CY = cy;
            this.Damage = damage;
            GeometryGroup g = new GeometryGroup();
            area = new RectangleGeometry(new Rect(0, 0, 10, 50));
        }

        public void Move(int dx, int dy)
        {
            this.CX += dx;
            this.CY += dy;
        }
    }
}
