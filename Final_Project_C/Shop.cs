using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C
{
    class Shop
    {
        static string select;
        static ConsoleKeyInfo KeyInfo;
        static int selectIndex = 0;

        public static void ShopMainMenu()
        {
            selectIndex = 0;
            string[] screenOptions = new string[] { "Buy shield", "Buy Weapon", "Buy Hp", "Exit" };
            Console.Clear();
            MenuPrint(screenOptions);

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

        static void MenuPrint(string[] menu)
        {
            Console.Clear();
            Console.WriteLine(@" _       __     __                             __           __  __                 __              
| |     / /__  / /________  ____ ___  ___     / /_____     / /_/ /_  ___     _____/ /_  ____  ____ 
| | /| / / _ \/ / ___/ __ \/ __ `__ \/ _ \   / __/ __ \   / __/ __ \/ _ \   / ___/ __ \/ __ \/ __ \
| |/ |/ /  __/ / /__/ /_/ / / / / / /  __/  / /_/ /_/ /  / /_/ / / /  __/  (__  ) / / / /_/ / /_/ /
|__/|__/\___/_/\___/\____/_/ /_/ /_/\___/   \__/\____/   \__/_/ /_/\___/  /____/_/ /_/\____/ .___/ 
                                                                                          /_/      

");
            Console.WriteLine($"Points: {Player.point}\n");
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
            

            do
            {
                KeyInfo = Console.ReadKey(true);

                if (KeyInfo.Key == ConsoleKey.W)
                {
                    selectIndex--;
                    if (selectIndex == -1)
                    {
                        selectIndex = menu.Length - 1;
                    }
                }
                else if (KeyInfo.Key == ConsoleKey.S)
                {
                    selectIndex++;
                    if (selectIndex == menu.Length)
                    {
                        selectIndex = 0;
                    }
                }
                Console.Clear();
                MenuPrint(menu);


            } while (KeyInfo.Key != ConsoleKey.Enter);

            return selectIndex;

        }

        static void shieldMenu()
        {
            selectIndex = 0;
            bool inMenu = true;
            Console.Clear();
            string[] screenOptionsShield = new string[] { "Buy 15 shield = 20 Points", "Buy 20 shield = 25 Points", "Buy 30 shield = 30 Points", "Buy 45 shield = 35 Points", "Back" };
            MenuPrint(screenOptionsShield);

            while (inMenu)
            {
                switch (MenuInput(screenOptionsShield))
                {
                    case 0:
                        if (Player.RemovePoints(20))
                        {
                            Player.AddShield(15);
                            MenuPrint(screenOptionsShield);
                            Console.WriteLine("Add 15 shield");
                        }
                        else
                            Console.WriteLine("Not enough point");
                        break;
                    case 1:
                        if (Player.RemovePoints(25))
                        {
                            Player.AddShield(20);
                            MenuPrint(screenOptionsShield);
                            Console.WriteLine("Add 20 shield");
                        }
                        else
                            Console.WriteLine("Not enough point");
                        break;
                    case 2:
                        if (Player.RemovePoints(30))
                        {
                            Player.AddShield(30);
                            MenuPrint(screenOptionsShield);
                            Console.WriteLine("Add 30 shield");
                        }
                        else
                            Console.WriteLine("Not enough point");
                        break;
                    case 3:
                        if (Player.RemovePoints(35))
                        {
                            Player.AddShield(45);
                            MenuPrint(screenOptionsShield);
                            Console.WriteLine("Add 45 shield");
                        }
                        else
                            Console.WriteLine("Not enough point");
                        break;
                    case 4:
                        inMenu = false;
                        ShopMainMenu();
                        break;
                    default:

                        break;
                }
            }

        }

        static void WeaponMenu()
        {
            selectIndex = 0;
            bool inMenu = true;
            Console.Clear();
            string[] screenOptionsWeapon = new string[] { "Buy Axe = 50 Points", "Buy Fire Bull = 70 Points", "Back" };
            MenuPrint(screenOptionsWeapon);

            while (inMenu)
            {
                switch (MenuInput(screenOptionsWeapon))
                {
                    case 0:
                        if (Player.RemovePoints(50))
                            Player.inventory.AddAxe();
                        else
                            Console.WriteLine("Not enough point");
                        break;
                    case 1:
                        if (Player.RemovePoints(70))
                            Player.inventory.AddFireBull();
                        else
                            Console.WriteLine("Not enough point");
                        break;
                    case 2:
                        inMenu = false;
                        ShopMainMenu();
                        break;
                    default:
                        break;
                }
            }
        }

        static void HpMenu()
        {
            selectIndex = 0;
            bool inMenu = true;
            Console.Clear();
            string[] screenOptionsHp = new string[] { "Buy 15 HP = 5 Points", "Buy 20 HP = 10 Points", "Buy 30 HP = 15 Points", "Buy 45 HP = 20 Point","Increase the max HP by 10 = 20 Point" , "Increase the max HP by 15 = 30 Point", "Increase the max HP by 20 = 40 Point", "Back" };
            MenuPrint(screenOptionsHp);

            while (inMenu)
            {
                switch (MenuInput(screenOptionsHp))
                {
                    case 0:
                        if (Player.RemovePoints(5))
                        {
                            Player.AddHp(15);
                            MenuPrint(screenOptionsHp);
                            Console.WriteLine("Add 15 HP");
                        }
                        else
                            Console.WriteLine("Not enough point");
                        break;
                    case 1:
                        if (Player.RemovePoints(10))
                        {
                            Player.AddHp(20);
                            MenuPrint(screenOptionsHp);
                            Console.WriteLine("Add 20 HP");
                        }
                        else
                            Console.WriteLine("Not enough point");
                        break;
                    case 2:
                        if (Player.RemovePoints(15))
                        {
                            Player.AddHp(30);
                            MenuPrint(screenOptionsHp);
                            Console.WriteLine("Add 30 HP");
                        }
                        else
                            Console.WriteLine("Not enough point");
                        break;
                    case 3:
                        if (Player.RemovePoints(20))
                        {
                            Player.AddHp(45);
                            MenuPrint(screenOptionsHp);
                            Console.WriteLine("Add 45 HP");
                        }
                        else
                            Console.WriteLine("Not enough point");
                        break;
                    case 4:
                        if (Player.RemovePoints(20))
                        {
                            Player.AddMaxHp(10);
                            MenuPrint(screenOptionsHp);
                            Console.WriteLine("Add 10 to max HP");
                        }
                        else
                            Console.WriteLine("Not enough point");
                        break;
                    case 5:
                        if (Player.RemovePoints(30))
                        {
                            Player.AddMaxHp(15);
                            MenuPrint(screenOptionsHp);
                            Console.WriteLine("Add 15 to max HP");
                        }
                        else
                            Console.WriteLine("Not enough point");
                        break;
                    case 6:
                        if (Player.RemovePoints(40))
                        {
                            Player.AddMaxHp(20);
                            MenuPrint(screenOptionsHp);
                            Console.WriteLine("Add 20 to max HP");
                        }
                        else
                            Console.WriteLine("Not enough point");
                        break;
                    case 7:
                        inMenu = false;
                        ShopMainMenu();
                        break;
                    default:
                        break;
                }
            }
        }
    }

}
