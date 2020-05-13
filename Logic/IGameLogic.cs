using Model;
using System.Collections.Generic;

namespace Logic
{
    public interface IGameLogic
    {
        void AddAmountToPlayerScore(int amount);
        void AddBullets(List<Bullet> bullets);
        void AddEnemies(List<Enemy> enemies);
        void AddEnemy(Enemy enemy);
        void AddEnemyBullet(Bullet bullet);
        void ChangeScreen();
        void DecreasePlayerLife();
        List<Bullet> GetAllBullets();
        List<Enemy> GetAllEnemies();
        void IncreasePlayerLife();
        void MovePlayer(Direction dir);
        void OnPlayerPickUpItem(SpecialItem item);
        void PlayerShoot();
        void RemoveAllBullets();
        void RemoveAllEnemies();
        bool RemoveBullets(List<Bullet> bullets);
        bool RemoveEnemies(List<Enemy> enemies);
        bool RemoveEnemy(Enemy enemy);
        bool RemoveEnemyBullet(Bullet bullet);
        void ResetCantPlayerMoove();
        void RespawnPlayer();
        void RotateSreen();
        void SetLivesOfPlayerTo(int numberOfLives);
        void SetPlayerPosition(double cx, double cy);
        void SetPlayerScoreTo(int amount);
        void SetRespawnPoint(int CX, int CY);
    }
}