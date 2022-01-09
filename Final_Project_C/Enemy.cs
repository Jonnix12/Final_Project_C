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
        public int posX;
        public int posY;

        int attackDamage;



        public Enemy(int X, int Y)
        {
            MapLoader.mapGride[X, Y] = "*";
            hp = 30;
            attackDamage = 5;
            posX = X;
            posY = Y;
        }

        void Attack()
        {
            if (HitChance())
            {
                Player.TakeDamage(attackDamage);
                Console.WriteLine("Enemy as attack");
            }
        }

        public void TakeDamage(int damage)
        {
            hp -= damage;
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

        public void EnemyAI()
        {
            Random random = new Random();


            bool isAttack = false;

            if (hp > 20)
            {
                isAttack = true;
            }
            else if (hp > 10)
            {
                isAttack = true;
            }
            else if (hp < 11)
            {
                isAttack = true;
            } 
            

            if (isAttack)//Attack
            {
                Attack();
            }
            else if (!isAttack && hp < 10)//life potion
            {
                hp += 10;
            }
        }

        bool HitChance()
        {
            Random random = new Random();
            int hitChance = random.Next(5, 9);
            int hit = random.Next(1, 11);

            if (hit < hitChance)
            {
                Console.WriteLine("Enemy Hit!");
                return true;
            }
            else
            {
                Console.WriteLine("Enemy Miss");
            }
            return false;

        }
    }
}
