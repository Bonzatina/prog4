using Model.Bullets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Model
{
    public class Screen 
    {
        public GroundLine groundLine;
        public List<SpecialItem> specialItems;
        public List<Enemy> enemies;
        public List<Bullet> bullets = new List<Bullet>();
        public DoorNextScreen doorNextScreen;
        public Screen(GroundLine groundLine, List<SpecialItem> specialItems = null, List<Enemy> enemies = null, DoorNextScreen doorNextScreen = null)
        {
            this.specialItems = specialItems;
            this.groundLine = groundLine;
            this.enemies = enemies;
            this.doorNextScreen = doorNextScreen;
        }
    }
}
