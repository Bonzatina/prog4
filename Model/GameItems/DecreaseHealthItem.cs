using System;
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
                if (value < 0) throw new ArgumentException("Decreasing health pickup item cannot be negative.", nameof(Lives));
                else lives = value;
            }
        }


        public DecreaseHealthItem(int lives, Brush brush, Pen pen, Geometry area) : base(brush, pen, area)
        {
            this.Lives = lives;
        }

        public override void OnPlayerPickUp(GameModel model)
        {
            model.player.Lives -= this.Lives;
            model.player.CX = 10;
            model.player.CY = 10;
        }
    }
}
