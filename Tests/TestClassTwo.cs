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

        [Test]
        public void GivenPlayerHasNotPickedUpItem_AndPlayerPicksUpItem_PickedUpItemAffectsPlayer()
        {
            GameModel model = new GameModel(1, 1);
            GameLogic logic = new GameLogic(model);
            int livesBefore = model.player.Lives;
            logic.OnPlayerPickUpItem(new IncreaseHealthItem(0, Brushes.Black, new Pen(), model.screen.groundLine.RealArea));
            int livesAfter = model.player.Lives;
            Assert.That(livesBefore != livesAfter);
        }

        [Test]
        public void GivenPlayerScoreHasNotChangedYet_AndPlayerScoreIsIncremented_ItIsIncremented()
        {
            GameModel model = new GameModel(1, 1);
            GameLogic logic = new GameLogic(model);
            int scoreBefore = model.player.score;
            logic.AddAmountToPlayerScore(1);
            int scoreAfter = model.player.score;
            Assert.That(scoreBefore < scoreAfter);
        }
    }
}
