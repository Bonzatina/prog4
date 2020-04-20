using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace OENIK_PROG4_2020_1_A2ETR7_SCE1EH
{
    class Level 
    {
        public GroundLine groundLine;
        public List<SpecialItem> specialItems;
        public Level(GroundLine groundLine, List<SpecialItem> specialItems = null)
        {
            this.specialItems = specialItems;
            this.groundLine = groundLine;
        }
    }
}
