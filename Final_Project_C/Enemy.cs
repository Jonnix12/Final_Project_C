using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C
{
    class Enemy
    {
        public int hp;
        int attackDamage;
        public int posX;
        public int posY;
       

        public Enemy(int X , int Y)
        {
            MapLoader.mapGride[X, Y] = "*";
            hp = 30;
            attackDamage = 5;
            posX = X;
            posY = Y;
        }

        public void Attack()
        {
            Console.WriteLine("Enemy as attack");
        }

        void TakeDamage()
        {

        }

        public bool IsDead()
        {
            if (hp <= 0)
            {
                return true;
            }
            EnemyManager.enemies.Remove(this);
            MapLoader.mapGride[Player.enemyPosX, Player.enemyPosY] = MapLoader.empty;
            return false;


        }
    }
}
