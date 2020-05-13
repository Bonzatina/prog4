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
            // TODO check if it is ok that we use model here, may be better move somehow to logic
            model.player.Lives -= this.Lives;
            model.player.CX = model.RespawnCX;
            model.player.CY = model.RespawnCY;
        }
    }
}
