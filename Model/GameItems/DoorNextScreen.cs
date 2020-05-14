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
        public string NextScreen { get; set; }
        public DoorNextScreen(string nextScreen, Brush brush, Pen pen, Geometry area) : base(brush, pen, area)
        {
            this.NextScreen = nextScreen;
        }

        public override void OnPlayerPickUp(GameModel model)
        {
            model.screen = model.levelsResourses.screens[this.NextScreen];
        }
    }
}
