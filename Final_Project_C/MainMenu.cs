using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C
{
    class MainMenu
    {
        string select;
        ConsoleKeyInfo KeyInfo;
        int selectIndex = 0;
        bool isPuseMenu;

        int cursorLeft;
        int cursorTop;

        public MainMenu(bool isPuseMenu)
        {
            if (isPuseMenu)
            {
                this.isPuseMenu = isPuseMenu;
                PuseMenu();
            }
            else
                StartMenu();

        }

        void PuseMenu()
        {
            selectIndex = 0;
            bool inMenu = true;
            string[] mainMenu = new string[] { "Resume", "Options", "Tutorial", "Exit" };
            MenuPrint(mainMenu);

            while (inMenu)
            {
                switch (MenuInput(mainMenu))
                {
                    case 0:
                        inMenu = false;
                        break;
                    case 1:
                        OptionsMenu();
                        break;
                    case 2:
                        TutorialMenu();
                        break;
                    case 3:
                        System.Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }

        void StartMenu()
        {
            selectIndex = 0;
            bool inMenu = true;
            string[] mainMenu = new string[] { "Play", "Options", "Tutorial", "Exit" };
            MenuPrint(mainMenu);

            while (inMenu)
            {
                switch (MenuInput(mainMenu))
                {
                    case 0:
                        SceneManager sceneManager = new SceneManager(3, 3);
                        break;
                    case 1:
                        OptionsMenu();
                        break;
                    case 2:
                        TutorialMenu();
                        break;
                    case 3:
                        System.Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }

        void OptionsMenu()
        {
            selectIndex = 0;
            bool inMenu = true;
            string[] optionsMenu = new string[] { "Change color", "Change difficulty", "Back" };
            MenuPrint(optionsMenu);

            while (inMenu)
            {
                switch (MenuInput(optionsMenu))
                {
                    case 0:
                        ColorChangeMenu();
                        break;
                    case 1:
                        break;
                    case 2:
                        if (isPuseMenu)
                        {
                            inMenu = false;
                            PuseMenu();
                        }
                        else
                        {
                            inMenu = false;
                            StartMenu();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        void TutorialMenu()
        {
            MapLoader.MapStartUp(3, 3);
            MapLoader.MapUpDate();
        }

        void ColorChangeMenu()
        {
            selectIndex = 0;
            bool inMenu = true;
            string[] ColorMenu = new string[] { "Red", "Blue", "Yellow", "Reset", "Back" };
            MenuPrint(ColorMenu);

            while (inMenu)
            {
                switch (MenuInput(ColorMenu))
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Red;
                        MenuPrint(ColorMenu);
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        MenuPrint(ColorMenu);
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        MenuPrint(ColorMenu);
                        break;
                    case 3:
                        Console.ResetColor();
                        MenuPrint(ColorMenu);
                        break;
                    case 4:
                        inMenu = false;
                        OptionsMenu();
                        break;
                    default:
                        break;
                }
            }
        }

        int MenuInput(string[] menu)
        {
            int temp = cursorTop;
            do
            {
                KeyInfo = Console.ReadKey(true);

                if (KeyInfo.Key == ConsoleKey.W)
                {
                    cursorTop--;
                    selectIndex--;
                    if (selectIndex == -1)
                    {
                        selectIndex = menu.Length - 1;
                    }
                }
                else if (KeyInfo.Key == ConsoleKey.S)
                {
                    cursorTop++;
                    selectIndex++;
                    if (selectIndex == menu.Length)
                    {
                        selectIndex = 0;
                    }
                }
                //Console.Clear();
                MenuUpdate();


            } while (KeyInfo.Key != ConsoleKey.Enter);

            return selectIndex;

        }

        void MenuPrint(string[] menu)
        {
            Console.Clear();

            Console.WriteLine(@" ██▀███   ▒█████   ▄▄▄▄    ▄▄▄       ██▓       ▓█████▄  █    ██  ███▄    █   ▄████ ▓█████  ▒█████   ███▄    █ 
▓██ ▒ ██▒▒██▒  ██▒▓█████▄ ▒████▄    ▓██▒       ▒██▀ ██▌ ██  ▓██▒ ██ ▀█   █  ██▒ ▀█▒▓█   ▀ ▒██▒  ██▒ ██ ▀█   █ 
▓██ ░▄█ ▒▒██░  ██▒▒██▒ ▄██▒██  ▀█▄  ▒██░       ░██   █▌▓██  ▒██░▓██  ▀█ ██▒▒██░▄▄▄░▒███   ▒██░  ██▒▓██  ▀█ ██▒
▒██▀▀█▄  ▒██   ██░▒██░█▀  ░██▄▄▄▄██ ▒██░       ░▓█▄   ▌▓▓█  ░██░▓██▒  ▐▌██▒░▓█  ██▓▒▓█  ▄ ▒██   ██░▓██▒  ▐▌██▒
░██▓ ▒██▒░ ████▓▒░░▓█  ▀█▓ ▓█   ▓██▒░██████▒   ░▒████▓ ▒▒█████▓ ▒██░   ▓██░░▒▓███▀▒░▒████▒░ ████▓▒░▒██░   ▓██░
░ ▒▓ ░▒▓░░ ▒░▒░▒░ ░▒▓███▀▒ ▒▒   ▓▒█░░ ▒░▓  ░    ▒▒▓  ▒ ░▒▓▒ ▒ ▒ ░ ▒░   ▒ ▒  ░▒   ▒ ░░ ▒░ ░░ ▒░▒░▒░ ░ ▒░   ▒ ▒ 
  ░▒ ░ ▒░  ░ ▒ ▒░ ▒░▒   ░   ▒   ▒▒ ░░ ░ ▒  ░    ░ ▒  ▒ ░░▒░ ░ ░ ░ ░░   ░ ▒░  ░   ░  ░ ░  ░  ░ ▒ ▒░ ░ ░░   ░ ▒░
  ░░   ░ ░ ░ ░ ▒   ░    ░   ░   ▒     ░ ░       ░ ░  ░  ░░░ ░ ░    ░   ░ ░ ░ ░   ░    ░   ░ ░ ░ ▒     ░   ░ ░ 
   ░         ░ ░   ░            ░  ░    ░  ░      ░       ░              ░       ░    ░  ░    ░ ░           ░ 
                        ░                       ░                                                             

");
            cursorLeft = Console.GetCursorPosition().Left;
            cursorTop = Console.GetCursorPosition().Top;
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

        void MenuUpdate(int nextPos , int prevPos)
        {
            Console.SetCursorPosition(cursorLeft, prevPos);
            Console.Write(" ")
        }


    }
}
