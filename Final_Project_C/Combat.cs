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
        int cont = 0;

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
            Console.WriteLine("You encountered a {0} {1} named {2}", enemy.title, enemy.character, enemy.name + "\n");
            CombatScreenPrint();
        }


        void CombatUpDate()
        {
            while (!Player.IsDead() && !enemy.IsDead())
            {
                Console.WriteLine("Your turn...");
                PlayerTurn();
                Console.WriteLine("Enemy turn...\n");
                EnemyTurn();
                Console.WriteLine("\nPrees any key to Continue...");
                Console.ReadKey();
                CombatScreenPrint();
            }

            Console.Clear();
            Console.WriteLine("\nYou {0} {1}", EndScreenText(), enemy.name);
            Console.WriteLine($"You received {ScoreAdd()} Point");
            Console.WriteLine("\nPrees any key to Continue...");
            Console.ReadKey();
            MapLoader.MapUpDate();
        }

        void PlayerTurn()
        {
            Player.Attack(enemy);
        }

        void EnemyTurn()
        {
            enemy.EnemyAI();
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
            if (cont > 0)
            {
                Console.Clear();
            }
            cont++;
            Console.Write("Player Stats:\n" + "HP: " + Player.hp + "\nShield:" + Player.shield + "\n");
            Console.Write("Enemy Stats:\n" + "HP: " + enemy.hp + "\nMore stats\n");
        }

        string EndScreenText()
        {
            string[] text = new string[] { "murdered ", "slaughter", "tear", "humiliation", "crashed" };

            Random rand = new Random();

            return text[rand.Next(0, text.Length)];
        }

        int ScoreAdd()
        {
            Random random = new Random();
            int score = random.Next(10, 35);

            Player.AddPoint(score);

            return score;


        }
    }
}
