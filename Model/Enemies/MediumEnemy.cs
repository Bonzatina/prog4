using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Model.Enemies
{
    public class MediumEnemy : Enemy
    {

        public MediumEnemy(Geometry area) : base(150, area)
        {
        }

        public override void EnemyShoot(double playerCX)
        {
            double bulletDirection = this.RealArea.Bounds.Left > playerCX ? -5 : 5;
            this.bullet = new StandardBullet(this.RealArea.Bounds.Left,
           (this.RealArea.Bounds.Top + this.RealArea.Bounds.Bottom) / 2 - GameModel.ZeroAxios,
           bulletDirection, 0);

        }
    }
}
