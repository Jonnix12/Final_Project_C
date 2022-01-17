using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C
{
    class Shop
    {
        static string[] screenOptions = new string[] { "Buy shield", "Buy Weapon", "Buy Hp", "Exit" };
        static string select;
        static ConsoleKeyInfo KeyInfo;
        static int selectIndex = 0;

        public static void ShopMainMenu()
        {
            Console.Clear();
            ShopPrint(screenOptions);

            switch (MenuInput(screenOptions))
            {
                case 0:
                    shieldMenu();
                    break;
                case 1:
                    WeaponMenu();
                    break;
                case 2:
                    HpMenu();
                    break;
                case 3:

                    break;
                default:
                    break;
            }

        }

        static void ShopPrint(string[] menu)
        {
            Console.WriteLine(@" _       __     __                             __           __  __                 __              
| |     / /__  / /________  ____ ___  ___     / /_____     / /_/ /_  ___     _____/ /_  ____  ____ 
| | /| / / _ \/ / ___/ __ \/ __ `__ \/ _ \   / __/ __ \   / __/ __ \/ _ \   / ___/ __ \/ __ \/ __ \
| |/ |/ /  __/ / /__/ /_/ / / / / / /  __/  / /_/ /_/ /  / /_/ / / /  __/  (__  ) / / / /_/ / /_/ /
|__/|__/\___/_/\___/\____/_/ /_/ /_/\___/   \__/\____/   \__/_/ /_/\___/  /____/_/ /_/\____/ .___/ 
                                                                                          /_/      

");
            for (int i = 0; i < menu.Length; i++)
            {
                if (i == selectIndex)
                {
                    select = ">";
                }
                else
                {
                    select = " ";
                }
                Console.WriteLine($"{select} {menu[i]}");
            }

        }

        static int MenuInput(string[] menu)
        {
            selectIndex = 0;

            do
            {
                KeyInfo = Console.ReadKey(true);

                if (KeyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectIndex--;
                    if (selectIndex == -1)
                    {
                        selectIndex = menu.Length - 1;
                    }
                }
                else if (KeyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectIndex++;
                    if (selectIndex == menu.Length)
                    {
                        selectIndex = 0;
                    }
                }
                Console.Clear();
                ShopPrint(menu);


            } while (KeyInfo.Key != ConsoleKey.Enter);

            return selectIndex;

        }

        static void shieldMenu()
        {
            Console.Clear();
            string[] screenOptionsShield = new string[] { "Buy 15 shield = 20 Points", "Buy 20 shield = 25 Points", "Buy 30 shield = 30 Points", "Buy 45 shield = 35 Points","Back" };
            ShopPrint(screenOptionsShield);
            
            switch (MenuInput(screenOptionsShield))
            {
                case 0:
                    Player.AddShield(15);
                    break;
                case 1:
                    Player.AddShield(20);
                    break;
                case 2:
                    Player.AddShield(30);
                    break;
                case 3:
                    Player.AddShield(45);
                    break;
                case 4:
                    ShopMainMenu();
                    break;
                default:
                    
                    break;
            }

        }

        static void WeaponMenu()
        {
            Console.Clear();
            string[] screenOptionsWeapon = new string[] { "Buy Axe = 50 Points", "Buy Fire Bull = 70 Points", "Back" };
            ShopPrint(screenOptionsWeapon);

            switch (MenuInput(screenOptionsWeapon))
            {
                case 0:
                    Player.inventory.AddAxe();
                    break;
                case 1:
                    Player.inventory.AddFireBull();
                    break;
                case 2:
                    ShopMainMenu();
                    break;
                default:
                    break;
            }
        }

        static void HpMenu()
        {
            Console.Clear();
            string[] screenOptionsHp = new string[] { "Buy 15 HP = 5 Points", "Buy 20 HP = 10 Points", "Buy 30 HP = 15 Points", "Buy 45 HP = 20 Point", "Back" };
            ShopPrint(screenOptionsHp);

            switch (MenuInput(screenOptionsHp))
            {
                case 0:
                    Player.AddHp(15);
                    break;
                case 1:
                    Player.AddHp(20);
                    break;
                case 2:
                    Player.AddHp(30);
                    break;
                case 3:
                    Player.AddHp(45);
                    break;
                case 4:
                    ShopMainMenu();
                    break;
                default:

                    break;
            }
        }
    }

}
