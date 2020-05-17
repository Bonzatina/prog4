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
    public abstract class Enemy : GameItem, IEnemy
    {
        private int health;
        public Bullet bullet { get; set; }
        protected double prevBulletDirection { get; set; } = -5;

        public int Health
        {
            get { return health; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Enemy's health can not be less than zero.", nameof(Health));
                }
                else
                {
                    health = value;
                }
            }
        }

        public Enemy(int health, Geometry area) // different shapes & colors for enemies? (bossEnemy, mediumEnemy, smallEnemy)
        {
            this.CX = 0;
            this.CY = GameModel.ZeroAxios;
            this.Health = health;
            this.area = area;
        }

        public void Move(int dx, int dy)
        {
            this.CX += dx;
            this.CY += dy;
        }

        public virtual void EnemyShoot(double playerCX)
        {

        }
    }
}

