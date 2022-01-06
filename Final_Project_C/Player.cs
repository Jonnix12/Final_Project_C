using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C
{
    static class Player
    {
        static int hp = 100;
        static int movePoint = 5;
        public static int playerCurrentY = Vector2.Y;
        public static int playerCurrentX = Vector2.X;
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

        static void Attack()
        {

        }

        static void HitChance()
        {

        }

        static void TakeDamage()
        {

        }


    }
}
