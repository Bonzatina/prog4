using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Model
{
    public class DoorNextScreen : SpecialItem
    {
        public DoorNextScreen(Brush brush, Pen pen, Geometry area) : base(brush, pen, area)
        {

        }

        public override void OnPlayerPickUp(GameModel model)
        {
            model.player.CX = 10;
            model.player.CY = 10;
        }
    }
}
