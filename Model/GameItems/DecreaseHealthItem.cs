using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Model
{
    public class DecreaseHealthItem : SpecialItem
    {

        private int lives;

        public int Lives
        {
            get { return lives; }
            set
            {
                if (value > 0) throw new ArgumentException("Decreasing health pickup item cannot be negative.", nameof(Lives));
                else lives = value;
            }
        }


        public DecreaseHealthItem(int lives, double cx, double cy, Brush brush, Pen pen, Geometry area) : base(cx, cy, brush, pen, area)
        {
            this.Lives = lives;
        }

        public override void OnPlayerPickUp(Player player)
        {
            player.Lives += this.Lives;
        }
    }
}
