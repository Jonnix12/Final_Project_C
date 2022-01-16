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

        public string title;
        public string character;
        public string name;

        int attackDamage;



        public Enemy(string enemyUi, int X, int Y)
        {
            MapLoader.mapGride[X, Y] = enemyUi;
            hp = 30;
            attackDamage = 5;
            posX = X;
            posY = Y;
            RnadName();
        }

        void Attack()
        {
            if (HitChance(6))
            {
                Player.TakeDamage(attackDamage);
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
                EnemyManager.enemies.Remove(this);
                MapLoader.mapGride[Player.enemyPosX, Player.enemyPosY] = Strings.space;
                return true;
            }
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

        bool HitChance(int chance)
        {
            Random random = new Random();
            int hit = random.Next(1, 11);

            if (hit < chance)
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

        void RnadName()
        {
            string[] title = new string[] { "strong", "mighty", "threatening", "crazy", "huge"};
            string[] character = new string[] { "Orc", "vampire","Demon", "Cyclops","werewolf"};
            string[] name = new string[] { "Dave", "Jeremy", "Philip", "Ronen", "Shalom","Motty"};

            Random rand = new Random();

            this.title = title[rand.Next(0, title.Length)];
            this.character = character[rand.Next(0, character.Length)];
            this.name = name[rand.Next(0, name.Length)];

        }
    }
}
