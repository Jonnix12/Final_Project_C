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

        public static int score = 0;

        public static int playerCurrentY = Vector2.Y;
        public static int playerCurrentX = Vector2.X;

        public static int enemyPosX;
        public static int enemyPosY;

        public static inventory inventory;

        public static void PlayerStartUp()
        {
            inventory = new inventory();
            inventory.AddSword();
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
                if (!(MapLoader.mapGride[playerCurrentX - 1, playerCurrentY] == Strings.space))
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
                if (!(MapLoader.mapGride[playerCurrentX + 1, playerCurrentY] == Strings.space))
                    return;

                if (Vector2.X < 38)
                    Vector2.X += 1;
                else
                    Console.WriteLine("OutOfIndex");
            }

            static void MoveUp()
            {
                if (!(MapLoader.mapGride[playerCurrentX, playerCurrentY - 1] == Strings.space))
                    return;

                if (Vector2.Y > 1)
                    Vector2.Y -= 1;
                else
                    Console.WriteLine("OutOfIndex");
            }

            static void MoveDown()
            {
                if (!(MapLoader.mapGride[playerCurrentX, playerCurrentY + 1] == Strings.space))
                    return;

                if (Vector2.Y < 18)
                    Vector2.Y += 1;
                else
                    Console.WriteLine("OutOfIndex");
            }

        }

        public static void Attack(Enemy enemy)
        {
            bool isAttack = false;

            while (!isAttack)
            {

                Console.WriteLine(@"Choose Weapon:
1.Sword
2.Axe
3.Fire Bull");

                switch (Console.ReadKey(true).Key)
                {

                    case ConsoleKey.D1: //sword

                        if (!inventory.weapons.ContainsKey("sword"))
                        {
                            Console.WriteLine("No Sword in inventory");
                            break;
                        }

                        Console.WriteLine(@"What attack do you want to do?
1.Short Attack
2.Long Attack");

                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.D1:
                                inventory.weapons["sword"].ShortAttack(enemy);
                                isAttack = true;
                                break;
                            case ConsoleKey.D2:
                                inventory.weapons["sword"].LongAttack(enemy);
                                isAttack = true;
                                break;
                            default:
                                break;
                        }
                        break;

                    case ConsoleKey.D2://axe

                        if (!inventory.weapons.ContainsKey("axe"))
                        {
                            Console.WriteLine("No Axe in inventory");
                            break;
                        }

                        Console.WriteLine(@"What attack do you want to do?
1.Short Attack
2. Long Attack");

                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.D1:
                                inventory.weapons["axe"].ShortAttack(enemy);
                                isAttack = true;
                                break;
                            case ConsoleKey.D2:
                                inventory.weapons["axe"].LongAttack(enemy);
                                isAttack = true;
                                break;
                            default:
                                break;
                        }

                        break;

                    case ConsoleKey.D3://firebull

                        if (!inventory.weapons.ContainsKey("firebull"))
                        {
                            Console.WriteLine("No firebull in inventory");
                            break;
                        }

                        Console.WriteLine(@"What attack do you want to do?
1.Short Attack
2. Long Attack");

                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.D1:
                                inventory.weapons["firebull"].ShortAttack(enemy);
                                isAttack = true;
                                break;
                            case ConsoleKey.D2:
                                inventory.weapons["firebull"].LongAttack(enemy);
                                isAttack = true;
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
        }


        public static bool HitChance(int chance)
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
                Console.WriteLine("You MISS!!!");
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
                    if (MapLoader.mapGride[playerCurrentX + X, playerCurrentY + Y] != Strings.space)
                    {
                        string coll = MapLoader.mapGride[playerCurrentX + X, playerCurrentY + Y];

                        if (coll == Strings.enemy)
                        {
                            enemyPosX = playerCurrentX + X;
                            enemyPosY = playerCurrentY + Y;

                            return Strings.enemy;
                        }

                        if (coll == Strings.chastUi)
                        {
                            return Strings.chastUi;
                        }

                        if (coll == Strings.hpUi)
                        {
                            return Strings.hpUi;
                        }

                        if (coll == Strings.weaponUi)
                        {
                            return Strings.weaponUi;
                        }

                        if (coll == Strings.exit)
                        {
                            return Strings.exit;
                        }
                    }

                }
            }

            return null;
        }

        public static void AddHp(int hpAdd)
        {
            hp += hpAdd;
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
