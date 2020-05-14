using Logic;
using Model;
using Model.Enemies;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Tests
{

    public class TestClassTwo
    {
        
        [Test]
        public void GivenNoEnemiesExist_AndAddingAnEnemy_ListIsLargerThanZero()
        {
            GameModel model = new GameModel(1, 1);
            GameLogic logic = new GameLogic(model);
            logic.AddEnemy(new BossEnemy(Geometry.Empty));
            Assert.That(logic.GetAllEnemies().Count>0, Is.True);
        }
    }
}
