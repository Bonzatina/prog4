using System;
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

        public int Lives
        {
            get { return lives; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player's lives can not be less than zero.", nameof(Lives));
                }
                else 
                { 
                    lives = value; 
                }
            }
        }



        public Player(double cx, double cy)
        {
            this.CX = cx;
            this.CY = cy;
            GeometryGroup g = new GeometryGroup();
            area = new RectangleGeometry(new Rect(0, 0, 10, 50));
        }
    }
}
