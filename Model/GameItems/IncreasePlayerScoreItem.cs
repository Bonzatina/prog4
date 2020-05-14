using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Model.GameItems
{
    class IncreasePlayerScoreItem : SpecialItem
    {
        public int Score { get; set; }


        public IncreasePlayerScoreItem(Brush brush, Pen pen, Geometry area) : base(brush, pen, area)
        {
            Random r = new Random();
            this.Score = r.Next(12, 48);
        }

        public override void OnPlayerPickUp(GameModel model)
        {
            this.toRemove = true;
            model.player.score += this.Score;
        }
    }
}
