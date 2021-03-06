﻿namespace Model
{
    public interface IEnemy
    {
        Bullet bullet { get; set; }
        int Health { get; set; }

        void EnemyShoot(double playerCX);
        void Move(int dx, int dy);
    }
}