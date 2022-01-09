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

        public static int enemyPosX;
        public static int enemyPosY;
        static void PlayerStartUp()
        {

        }

        public static void Move(string moveTo)
        {
            switch (moveTo)
            {
                case "a":
                    MoveLeft();
                    break;
                case "d":
                    MoveRight();
                    break;
                case "w":
                    MoveUp();
                    break;
                case "s":
                    MoveDown();
                    break;
                case "A":
                    MoveLeft();
                    break;
                case "D":
                    MoveRight();
                    break;
                case "W":
                    MoveUp();
                    break;
                case "S":
                    MoveDown();
                    break;
                default:
                    Console.WriteLine("Wrong input ... Please enter again");
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

        public static void Attack(Enemy enemy)
        {
            
            if (HitChance())
            {
            enemy.TakeDamage(10);

            }
        }

        static bool HitChance()
        {
            Random random = new Random();
            int hitChance = random.Next(5, 9);
            int hit = random.Next(1, 11);

            if (hit < hitChance)
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

        public static bool EnemyCoill()
        {
            for (int X = -1; X <= 1; X++)
            {
                for (int Y = -1; Y <= 1; Y++)
                {
                    if (MapLoader.mapGride[playerCurrentX + X, playerCurrentY + Y] == EnemySpawner.enemy)
                    {
                        enemyPosX = playerCurrentX + X;
                        enemyPosY = playerCurrentY + Y;
                        Console.WriteLine("Combat");
                        return true;
                    }

                }
            }
            return false;
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
