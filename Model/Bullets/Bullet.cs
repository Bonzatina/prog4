using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Model
{
    public abstract class Bullet : GameItem
    {
        private int damage;
        private double DX;
        private double DY;

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


        public Bullet(double cx, double cy, double dx, double dy, int damage)
        {
            this.CX = 0;
            this.CY = GameModel.ZeroAxios;
            this.DX = dx;
            this.DY = dy;
            this.Damage = damage;
            GeometryGroup g = new GeometryGroup();
            area = new RectangleGeometry(new Rect(cx, cy, 10, 3));
        }

        public void Move()
        {
            this.CX += this.DX;
            this.CY += this.DY;
        }
    }
}
