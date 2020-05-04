using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Model
{
    public class Level 
    {
        public GroundLine groundLine;
        public List<SpecialItem> specialItems;
        public List<Enemy> enemies;
        public Level(GroundLine groundLine, List<SpecialItem> specialItems = null)
        {
            this.specialItems = specialItems;
            this.groundLine = groundLine;
        }
    }
}
