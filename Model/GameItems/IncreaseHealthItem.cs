using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Model
{
    public class IncreaseHealthItem : SpecialItem
    {
        private int lives;

        public int Lives
        {
            get { return lives; }
            set 
            {
                if (value < 0) throw new ArgumentException("Increasing health pickup item cannot be negative.", nameof(Lives));
                else lives = value; 
            }
        }


        public IncreaseHealthItem(int lives, Brush brush, Pen pen, Geometry area) : base(brush, pen, area)
        {
            this.Lives = lives;
        }

        public override void OnPlayerPickUp(GameModel model)
        {
            this.toRemove = true;
            model.player.Lives += this.Lives;
        }
    }
}
