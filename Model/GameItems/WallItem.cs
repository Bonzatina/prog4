using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Model.GameItems
{
    class WallItem : SpecialItem
    {
        public WallItem(Brush brush, Pen pen, Geometry area) : base(brush, pen, area)
        {

        }

        public override void OnPlayerPickUp(GameModel model)
        {
            if (model.player.PreviosCX < model.player.CX)
            {
                model.player.CX = this.area.Bounds.Left - 10;
                model.player.CantMoveRight = true;

            }
            else
            {
                model.player.CX = this.area.Bounds.Right + 10;
                model.player.CantMoveLeft = true;
            }  
      
        }
    }
}
