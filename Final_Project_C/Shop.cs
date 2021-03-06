using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C
{
    class Shop
    {
        public static bool inShop = false;
        ConsoleKeyInfo KeyInfo;
        int selectIndex = 0;

        int maxIndexForPointer;
        int originalCursorPos;
        int cursorTop;

        public Shop()//A store built from several different menus
        {
            inShop = true;
            ShopMainMenu();
        }

        public void ShopMainMenu()
        {
            selectIndex = 0;
            string[] screenOptions = new string[] { "Buy shield", "Buy Weapon", "Buy Hp", "Buy Potion", "Upgrades", "Continue" };
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
                    PotionMenu();
                    break;
                case 4:
                    UpgradesMenu();
                    break;
                case 5:
                    inShop = false;
                    break;
                default:
                    break;
            }

        }

        void MenuPrint(string[] menu)//Prints the menu I put in the command
        {
            Console.Clear();

            Console.WriteLine(@" _       __     __                             __           __  __                 __              
| |     / /__  / /________  ____ ___  ___     / /_____     / /_/ /_  ___     _____/ /_  ____  ____ 
| | /| / / _ \/ / ___/ __ \/ __ `__ \/ _ \   / __/ __ \   / __/ __ \/ _ \   / ___/ __ \/ __ \/ __ \
| |/ |/ /  __/ / /__/ /_/ / / / / / /  __/  / /_/ /_/ /  / /_/ / / /  __/  (__  ) / / / /_/ / /_/ /
|__/|__/\___/_/\___/\____/_/ /_/ /_/\___/   \__/\____/   \__/_/ /_/\___/  /____/_/ /_/\____/ .___/ 
                                                                                          /_/      

");
            Console.WriteLine($"Points: {Player.point}");
            cursorTop = Console.GetCursorPosition().Top;

            for (int i = 0; i < menu.Length; i++)
            {
                Console.WriteLine($"  {menu[i]}");
            }
            MenuUpdate(cursorTop);
        }

        void MenuUpdate(int nextPos)//Updates the position of the marker
        {
            Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
            Console.Write(" ");
            Console.SetCursorPosition(0, nextPos);
            Console.Write(">");
        }

        int MenuInput(string[] menu)//Receives input from the user
        {
            selectIndex = 0;
            maxIndexForPointer = cursorTop + menu.Length - 1;
            originalCursorPos = cursorTop;
            Console.SetCursorPosition(0, originalCursorPos);

            do
            {
                KeyInfo = Console.ReadKey(true);

                if (KeyInfo.Key == ConsoleKey.W)
                {
                    cursorTop--;
                    selectIndex--;
                    if (selectIndex == -1 || cursorTop < originalCursorPos)
                    {
                        cursorTop = maxIndexForPointer;
                        selectIndex = menu.Length - 1;
                    }
                }
                else if (KeyInfo.Key == ConsoleKey.S)
                {
                    cursorTop++;
                    selectIndex++;
                    if (selectIndex == menu.Length || cursorTop > maxIndexForPointer)
                    {
                        cursorTop = originalCursorPos;
                        selectIndex = 0;
                    }
                }
                MenuUpdate(cursorTop);


            } while (KeyInfo.Key != ConsoleKey.Enter);

            Console.SetCursorPosition(0, originalCursorPos);
            return selectIndex;

        }

        void Log(string message)//Prints messages to the screen
        {
            Console.SetCursorPosition(0, maxIndexForPointer + 2);
            Console.WriteLine(message);
            Console.SetCursorPosition(0, originalCursorPos);
        }

        void PotionMenu()
        {
            selectIndex = 0;
            bool inMenu = true;
            Console.Clear();
            string[] screenOptionsPotion = new string[] { "But 1 HP potion = 10 points", "But 1 stamina potion = 10 points", "Back" };
            MenuPrint(screenOptionsPotion);

            while (inMenu)
            {
                switch (MenuInput(screenOptionsPotion))
                {
                    case 0:
                        if (Player.RemovePoints(10))
                        {
                            Potion potion = new Potion(true);
                            MenuPrint(screenOptionsPotion);
                            Log("Add 1 Hp potion");
                        }
                        else
                        {
                            MenuPrint(screenOptionsPotion);
                            Log("Not enough point");
                        }
                        break;
                    case 1:
                        if (Player.RemovePoints(10))
                        {
                            Potion potion = new Potion(false);
                            MenuPrint(screenOptionsPotion);
                            Log("Add 1 Stamina potion");
                        }
                        else
                        {
                            MenuPrint(screenOptionsPotion);
                            Log("Not enough point");
                        }
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

        void UpgradesMenu()
        {
            selectIndex = 0;
            bool inMenu = true;
            Console.Clear();
            string[] upgradesMenu = new string[] { "Increase the max HP by 10 = 20 Point", "Increase the max HP by 15 = 30 Point", "Increase the max HP by 20 = 40 Point", "Increase the max Stamina by 10 = 20 Point", "Increase the max Stamina by 15 = 30 Point", "Increase the max Stamina by 20 = 40 Point", "Back" };
            MenuPrint(upgradesMenu);

            while (inMenu)
            {
                switch (MenuInput(upgradesMenu))
                {
                    case 0:
                        if (Player.RemovePoints(20))
                        {
                            Player.AddMaxHp(10);
                            MenuPrint(upgradesMenu);
                            Log("Add 10 to max HP");
                        }
                        else
                        {
                            MenuPrint(upgradesMenu);
                            Log("Not enough point");
                        }
                        break;
                    case 1:
                        if (Player.RemovePoints(30))
                        {
                            Player.AddMaxHp(15);
                            MenuPrint(upgradesMenu);
                            Log("Add 15 to max HP");
                        }
                        else
                        {
                            MenuPrint(upgradesMenu);
                            Log("Not enough point");
                        }
                        break;
                    case 2:
                        if (Player.RemovePoints(40))
                        {
                            Player.AddMaxHp(20);
                            MenuPrint(upgradesMenu);
                            Log("Add 20 to max HP");
                        }
                        else
                        {
                            MenuPrint(upgradesMenu);
                            Log("Not enough point");
                        }
                        break;
                    case 3:
                        if (Player.RemovePoints(20))
                        {
                            Player.AddMaxStamina(10);
                            MenuPrint(upgradesMenu);
                            Log("Add 10 to max Stamina");
                        }
                        else
                        {
                            MenuPrint(upgradesMenu);
                            Log("Not enough point");
                        }
                        break;
                    case 4:
                        if (Player.RemovePoints(30))
                        {
                            Player.AddMaxStamina(15);
                            MenuPrint(upgradesMenu);
                            Log("Add 15 to max Stamina");
                        }
                        else
                        {
                            MenuPrint(upgradesMenu);
                            Log("Not enough point");
                        }
                        break;
                    case 5:
                        if (Player.RemovePoints(40))
                        {
                            Player.AddMaxStamina(20);
                            MenuPrint(upgradesMenu);
                            Log("Add 20 to max Stamina");
                        }
                        else
                        {
                            MenuPrint(upgradesMenu);
                            Log("Not enough point");
                        }
                        break;
                    case 6:
                        inMenu = false;
                        ShopMainMenu();
                        break;
                    default:
                        break;
                }
            }
        }

        void shieldMenu()
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
                            Log("Add 15 shield");
                        }
                        else
                        {
                            MenuPrint(screenOptionsShield);
                            Log("Not enough point");
                        }
                        break;
                    case 1:
                        if (Player.RemovePoints(25))
                        {
                            Player.AddShield(20);
                            MenuPrint(screenOptionsShield);
                            Log("Add 20 shield");
                        }
                        else
                        {
                            MenuPrint(screenOptionsShield);
                            Log("Not enough point");
                        }
                        break;
                    case 2:
                        if (Player.RemovePoints(30))
                        {
                            Player.AddShield(30);
                            MenuPrint(screenOptionsShield);
                            Log("Add 30 shield");
                        }
                        else
                        {
                            MenuPrint(screenOptionsShield);
                            Log("Not enough point");
                        }
                        break;
                    case 3:
                        if (Player.RemovePoints(35))
                        {
                            Player.AddShield(45);
                            MenuPrint(screenOptionsShield);
                            Log("Add 45 shield");
                        }
                        else
                        {
                            MenuPrint(screenOptionsShield);
                            Log("Not enough point");
                        }
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

        void WeaponMenu()
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
                        {
                            Player.inventory.AddAxe();
                            MenuPrint(screenOptionsWeapon);
                            Log("Add Axe");
                        }
                        else
                        {
                            MenuPrint(screenOptionsWeapon);
                            Log("Not enough point");
                        }
                        break;
                    case 1:
                        if (Player.RemovePoints(70))
                        {
                            Player.inventory.AddFireBull();
                            MenuPrint(screenOptionsWeapon);
                            Log("Add Fire Bull");
                        }
                        else
                        {
                            MenuPrint(screenOptionsWeapon);
                            Log("Not enough point");
                        }
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

        void HpMenu()
        {
            selectIndex = 0;
            bool inMenu = true;
            Console.Clear();
            string[] screenOptionsHp = new string[] { "Buy 15 HP = 5 Points", "Buy 20 HP = 10 Points", "Buy 30 HP = 15 Points", "Buy 45 HP = 20 Point",  "Back" };
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
                            Log("Add 15 HP");
                        }
                        else
                        {
                            MenuPrint(screenOptionsHp);
                            Log("Not enough point");
                        }
                        break;
                    case 1:
                        if (Player.RemovePoints(10))
                        {
                            Player.AddHp(20);
                            MenuPrint(screenOptionsHp);
                            Log("Add 20 HP");
                        }
                        else
                        {
                            MenuPrint(screenOptionsHp);
                            Log("Not enough point");
                        }
                        break;
                    case 2:
                        if (Player.RemovePoints(15))
                        {
                            Player.AddHp(30);
                            MenuPrint(screenOptionsHp);
                            Log("Add 30 HP");
                        }
                        else
                        {
                            MenuPrint(screenOptionsHp);
                            Log("Not enough point");
                        }
                        break;
                    case 3:
                        if (Player.RemovePoints(20))
                        {
                            Player.AddHp(45);
                            MenuPrint(screenOptionsHp);
                            Log("Add 45 HP");
                        }
                        else
                        {
                            MenuPrint(screenOptionsHp);
                            Log("Not enough point");
                        }
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
    }

}
