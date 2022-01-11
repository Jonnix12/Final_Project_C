using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C
{
    class Combat
    {
        Enemy enemy;
        

        public Combat()
        {
            GetEnemy(Player.enemyPosX, Player.enemyPosY);
            CombatStartUp();
            CombatUpDate();
        }
        void CombatStartUp()
        {
            Console.Clear();
            Console.WriteLine("A Battle as began!\n");
            CombatScreenPrint();
        }


        void CombatUpDate()
        {
            while (!Player.IsDead() && !enemy.IsDead())
            {
                PlayerTurn();

                EnemyTurn();
                CombatScreenPrint();
            }
        }

        void PlayerTurn()
        {
            Player.Attack(enemy);
        }
        void GetEnemy(int X, int Y)
        {
            for (int i = 0; i < EnemyManager.enemies.Count; i++)
            {
                if (EnemyManager.enemies[i].posX == X && EnemyManager.enemies[i].posY == Y)
                {
                    enemy = EnemyManager.enemies[i];
                }
            }
        }

        void CombatScreenPrint()
        {

            Console.Write("Player Stats:\n" + "HP: " + Player.hp + "\nmore stats\n");
            Console.Write("Enemy Stats:\n" + "HP: " + enemy.hp + "\nMore stats\n");
        }

        void EnemyTurn()
        {
            enemy.EnemyAI();
        }
    }
}
