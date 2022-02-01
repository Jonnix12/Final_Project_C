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
        float precision;
        int stamina;
        int hpUp;




        public Enemy(string enemyUi, int X, int Y, int difficulty)
        {
            MapLoader.mapGride[X, Y] = enemyUi;
            hp = 30;
            attackDamage = 5;
            posX = X;
            posY = Y;
            RnadName();

            if (true)
            {

            }
            Random random = new Random();

            switch (difficulty)
            {
                case 0:
                    hpUp = 0;
                    stamina = 25;
                    precision = 50;
                    break;
                case 1:
                    hpUp = 1;
                    precision = 65;
                    stamina = 45;
                    break;
                case 2:
                    hpUp = 2;
                    stamina = 65;
                    precision = 75;
                    break;
                default:
                    break;
            }
        }


        public Enemy(string enemyUi, int X, int Y, bool randDifficulty)
        {

            MapLoader.mapGride[X, Y] = enemyUi;
            hp = 30;
            attackDamage = 5;
            posX = X;
            posY = Y;
            RnadName();
            Random random = new Random();


            switch (random.Next(0, 3))
            {
                case 0:
                    hpUp = 0;
                    stamina = 25;
                    precision = 50;
                    break;
                case 1:
                    hpUp = 1;
                    precision = 65;
                    stamina = 45;
                    break;
                case 2:
                    hpUp = 2;
                    stamina = 65;
                    precision = 75;
                    break;
                default:
                    break;
            }
        }

        void Attack()
        {
            Console.WriteLine("Enemy Attacked");
            Player.HitChance(attackDamage, precision);
        }

        bool RemoveStamina(int amont)
        {
            if ((stamina -= amont) >= 0)
            {
                stamina -= amont;
                return true;
            }
            else
            {
                return false;
            }
        }

        void HpUp(int amont)
        {
            if (hpUp > 0)
            {
                hp += amont;
                hpUp--;
                Console.WriteLine("Enemy Heal Up");
            }
        }

        void staminaUp(int amont)
        {
            stamina += amont;
            Console.WriteLine("\nEnemy Rested");
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
                MapLoader.mapGride[this.posX, this.posY] = Strings.space;
                return true;
            }
            return false;
        }

        public void EnemyAI()
        {
            if (((hp > 10 || hpUp == 0) || Player.hp < 30) && RemoveStamina(5))
            {
                Attack();
            }
            else if (hp < 10 && hpUp > 0)
            {
                HpUp(5);
            }
            else if (stamina < 5)
            {
                staminaUp(10);
            }
        }

        void RnadName()
        {
            string[] title = new string[] { "strong", "mighty", "threatening", "crazy", "huge" };
            string[] character = new string[] { "Orc", "vampire", "Demon", "Cyclops", "werewolf" };
            string[] name = new string[] { "Dave", "Jeremy", "Philip", "Ronen", "Shalom", "Motty" };

            Random rand = new Random();

            this.title = title[rand.Next(0, title.Length)];
            this.character = character[rand.Next(0, character.Length)];
            this.name = name[rand.Next(0, name.Length)];

        }
    }
}
