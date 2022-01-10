using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C
{
    static class Player
    {
        public static int hp = 100;
        static int movePoint = 5;
        public static int playerCurrentY = Vector2.Y;
        public static int playerCurrentX = Vector2.X;

        static bool CollEnemy = false;

        public static int enemyPosX;
        public static int enemyPosY;
        static void PlayerStartUp()
        {

        }

        public static void Move(ConsoleKey moveTo)
        {
            switch (moveTo)
            {
                case ConsoleKey.A:
                    MoveLeft();
                    break;
                case ConsoleKey.D:
                    MoveRight();
                    break;
                case ConsoleKey.W:
                    MoveUp();
                    break;
                case ConsoleKey.S:
                    MoveDown();
                    break;
                default:
                    break;
            }
            static void MoveLeft()
            {
                if (!(MapLoader.mapGride[playerCurrentX - 1, playerCurrentY] == MapLoader.empty))
                {
                    return;
                }
                if (Vector2.X > 1)
                    Vector2.X -= 1;
                else
                    Console.WriteLine("OutOfIndex");
            }

            static void MoveRight()
            {
                if (!(MapLoader.mapGride[playerCurrentX + 1, playerCurrentY] == MapLoader.empty))
                    return;

                if (Vector2.X < 38)
                    Vector2.X += 1;
                else
                    Console.WriteLine("OutOfIndex");
            }

            static void MoveUp()
            {
                if (!(MapLoader.mapGride[playerCurrentX, playerCurrentY - 1] == MapLoader.empty))
                    return;

                if (Vector2.Y > 1)
                    Vector2.Y -= 1;
                else
                    Console.WriteLine("OutOfIndex");
            }

            static void MoveDown()
            {
                if (!(MapLoader.mapGride[playerCurrentX, playerCurrentY + 1] == MapLoader.empty))
                    return;

                if (Vector2.Y < 18)
                    Vector2.Y += 1;
                else
                    Console.WriteLine("OutOfIndex");
            }

        }

        public static void StrongAttack(Enemy enemy)
        {

            if (HitChance(5))
            {
                enemy.TakeDamage(10);
            }
        }

        public static void FastAttack(Enemy enemy)
        {
            if (HitChance(7))
            {
                enemy.TakeDamage(5);
            }
        }

        static bool HitChance(int chance)
        {
            Random random = new Random();
            int hit = random.Next(1, 11);

            if (hit < chance)
            {
                Console.WriteLine("You Hit!");
                return true;
            }
            else
            {
                Console.WriteLine("Miss");
            }
            return false;

        }

        public static void TakeDamage(int damage)
        {
            hp -= damage;
        }

        public static string Collider()
        {
            
            for (int X = -1; X <= 1; X++)
            {
                for (int Y = -1; Y <= 1; Y++)
                {
                    if (MapLoader.mapGride[playerCurrentX + X, playerCurrentY + Y] != MapLoader.empty)
                    {
                        string coll = MapLoader.mapGride[playerCurrentX + X, playerCurrentY + Y];

                        if (coll == EnemySpawner.enemy)
                        {

                            enemyPosX = playerCurrentX + X;
                            enemyPosY = playerCurrentY + Y;
                            CollEnemy = true;
                            return EnemySpawner.enemy;
                        }

                        if (true)
                        {
                            //add more colliders 
                        }
                    }

                }
            }

            return null;
        }

        public static bool IsDead()
        {
            if (hp <= 0)
            {
                return true;
            }
            return false;
        }



    }
}
