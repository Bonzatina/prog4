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

        [Test]
        public void GivenPlayerLivesHaveNotBeenModified_WhenIncreasingPlayerLives_ItIsIncreased()
        {
            GameModel model = new GameModel(1, 1);
            GameLogic logic = new GameLogic(model);
            int playerLivesBefore = model.player.Lives;
            logic.IncreasePlayerLife();
            int playerLivesAfter = model.player.Lives;
            Assert.That(playerLivesBefore < playerLivesAfter);
        }

        [Test]
        public void GivenPlayerPositionWasNotModified_WhenModifyingPlayerPosition_ItIsModifiedCorrectly()
        {
            GameModel model = new GameModel(1, 1);
            GameLogic logic = new GameLogic(model);
            logic.SetPlayerPosition(5, 5);
            Assert.That(model.player.CX == 5 & model.player.CY == 5);
        }

        [Test]
        public void GivenPlayerHasNotDied_AndPlayerDies_PlayerPositionIsSetToRespawnPosition()
        {
            GameModel model = new GameModel(1, 1);
            GameLogic logic = new GameLogic(model);
            model.player.Lives = 0;
            logic.DecreasePlayerLife();
            Assert.That(model.player.CX == model.RespawnCX && model.player.CY == model.RespawnCY);
        }
    }
}
