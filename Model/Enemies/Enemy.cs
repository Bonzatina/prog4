using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Model
{
    public abstract class Enemy : GameItem
    {
        private int health;

        public int Health
        {
            get { return health; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Enemy's health can not be less than zero.", nameof(Health)); // maybe its OK to have negative health, as the enemy will be removed anyways?
                }
                else
                {
                    health = value;
                }
            }
        }

        public Enemy(double cx, double cy, int health) // different shapes & colors for enemies? (bossEnemy, mediumEnemy, smallEnemy)
        {
            this.CX = cx;
            this.CY = cy;
            this.Health = health;
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

