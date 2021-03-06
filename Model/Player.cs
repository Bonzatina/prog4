﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Model
{
    public class Player : GameItem
    {
        private int lives;
        public int score { get; set; }
        public double PreviosCX { get; set; }
        public bool CantMoveRight { get; set; } = false;
        public bool CantMoveLeft { get; set; } = false;
        public bool CantShoot { get; set; } = false;
        public List<Bullet> bullets { get; set; }

        public int Lives
        {
            get { return lives; }
            set 
            {
                lives = value;
            }
        }



        public Player(double cx, double cy)
        {
            this.CX = cx;
            this.CY = cy;
            area = new RectangleGeometry(new Rect(0, 0, 10, 50));
            this.bullets = new List<Bullet>();
        }

        public Bullet PlayerShoot()
        {
            CantShoot = true;
            int dir = this.PreviosCX < this.CX ? 5 : -5;
            Bullet bullet = new StandardBullet(this.RealArea.Bounds.Left,
           (this.RealArea.Bounds.Top + this.RealArea.Bounds.Bottom) / 2 - GameModel.ZeroAxios,
           dir, 0);
            this.bullets.Add(bullet);
            return bullet;

        }
    }
}
