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
        MapLoader map;

        public Combat(MapLoader map)
        {
            this.map = map;
            GetEnemy(Player.enemyPosX, Player.enemyPosY);
            CombatStartUp();
            CombatUpDate();
        }
        void CombatStartUp()
        {
            Console.Clear();
            Console.WriteLine("A Battle as began!\n");
            Console.WriteLine("You encountered a {0} {1} named {2}", enemy.title, enemy.character, enemy.name + "\n");
            Console.WriteLine("Actions:\n1.Attack.\n2.Defense(raises the shield, adds some stamina).\n3.Life potion(adds 20 life points).\n4.Stamina potion(adds 40 stamina).\n");
            CombatScreenPrint();
        }


        void CombatUpDate()
        {
            while (!Player.IsDead() && !enemy.IsDead())
            {
                PlayerTurn();
                Console.WriteLine("Enemy turn...");
                EnemyTurn();
                Console.WriteLine("Prees any key to Continue...");
                Console.ReadKey();
                CombatScreenPrint();
            }

            Console.Clear();
            Console.WriteLine("\nYou {0} {1}", EndScreenText(), enemy.name);
            Console.WriteLine($"You received {ScoreAdd()} Point");
            Console.WriteLine("\nPrees any key to Continue...");
            Console.ReadKey();
            map.MapUpDate();
        }

        void PlayerTurn()
        {
            bool isAction = false;

            ConsoleKeyInfo keyInfo;

            while (!isAction)
            {
                keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        Player.Attack(enemy);
                        isAction = true;
                        break;
                    case ConsoleKey.D2:
                        Player.Defense();
                        isAction = true;
                        break;
                    case ConsoleKey.D3:
                        Player.Heal();
                        isAction = true;
                        break;
                    case ConsoleKey.D4:
                        Player.StaminaUp();
                        isAction = true;
                        break;
                    case ConsoleKey.Escape:;
                        MainMenu menu = new MainMenu(true);
                        Console.Clear();
                        CombatScreenPrint();
                        break;
                    default:
                        Console.WriteLine("Invald action try agine...");
                        break;
                }
            }
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
            Console.Write("Player stats:\nHP: {0}\nStamina: {1}\nShield: {2}\nHP potion: {3}\nStamina potion: {4}\n\n",Player.hp,Player.stamina,Player.shield,Player.inventory.hpPotion.Count,Player.inventory.staminaPotion.Count);
            Console.WriteLine("Choose your ACTION:\n1.Attack\n2.Defense\n3.Life potion\n4.Stamina potion\n");
            Console.Write("Enemy Stats:\n" + "HP: " + enemy.hp + "\n\n");
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
