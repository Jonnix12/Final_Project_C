using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C
{
   
    class MainMenu
    {
        public static bool inMenu = false;

        ConsoleKeyInfo KeyInfo;
        int selectIndex = 0;
        bool isPuseMenu;

        int maxIndexForPointer;
        int originalCursorPos;
        int cursorTop;

        public MainMenu(bool isPuseMenu)
        {
            inMenu = true;
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
                        inMenu = false;
                        OptionsMenu();
                        break;
                    case 2:
                        inMenu = false;
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
            
            bool inMenu = true;
            string[] mainMenu = new string[] { "Play", "Options", "Tutorial", "Exit" };
            MenuPrint(mainMenu);

            while (inMenu)
            {
                switch (MenuInput(mainMenu))
                {
                    case 0:
                        SceneManager sceneManager = new SceneManager( 3);
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
           
            bool inMenu = true;
            string[] optionsMenu = new string[] { "Change color", "Change difficulty", "Back" };
            MenuPrint(optionsMenu);

            while (inMenu)
            {
                switch (MenuInput(optionsMenu))
                {
                    case 0:
                        inMenu = false;
                        ColorChangeMenu();
                        break;
                    case 1:
                        inMenu = false;
                        ChangeDifficulty();
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
            Console.WriteLine("Kill all enemies to advance to the next level\n");
            Console.WriteLine("Player: " + Strings.player);
            Console.WriteLine("Enemy: " + Strings.enemy);
            Console.WriteLine("Chast: " + Strings.chastUi);
            Console.WriteLine("Hp pick up: " + Strings.hpUi);
            Console.WriteLine("Weapon: " + Strings.weaponUi);
            Console.WriteLine("Exit: " + Strings.exit);
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            if (isPuseMenu)
            {
                PuseMenu();
            }
            else
                StartMenu();
        }

        void ColorChangeMenu()
        {
            
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

        void ChangeDifficulty()
        {
            
            bool inMenu = true;
            string[] difficultyMenu = new string[] { "Easy", "Medium", "Hard", "Do not come crying to me", "Back" };
            MenuPrint(difficultyMenu);

            while (inMenu)
            {
                switch (MenuInput(difficultyMenu))
                {
                    case 0:
                        SceneManager.SetDiifficulty(1, false);
                        MenuPrint(difficultyMenu);
                        Log("Diffiulty set to : Easy");
                        //Console.WriteLine("Change We were updated on the loading of the next scene");
                        break;
                    case 1:
                        SceneManager.SetDiifficulty(2, false);
                        MenuPrint(difficultyMenu);
                        Log("Diffiulty set to : Medium");
                        //Console.WriteLine("Change We were updated on the loading of the next scene");
                        break;
                    case 2:
                        SceneManager.SetDiifficulty(3, false);
                        MenuPrint(difficultyMenu);
                        Log("Diffiulty set to : Hard");
                        //Log("Change We were updated on the loading of the next scene");
                        break;
                    case 3:
                        SceneManager.SetDiifficulty(4, false);
                        MenuPrint(difficultyMenu);
                        Log("Diffiulty set to : Do not come crying to me");
                        //Console.WriteLine("Change We were updated on the loading of the next scene");
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

        void Log(string message)
        {
            Console.SetCursorPosition(0, maxIndexForPointer + 2);
            Console.WriteLine(message);
            Console.SetCursorPosition(0, originalCursorPos);
        }

        int MenuInput(string[] menu)
        {
            selectIndex = 0;
            maxIndexForPointer = cursorTop + menu.Length -1;
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
            
            cursorTop = Console.GetCursorPosition().Top;

            for (int i = 0; i < menu.Length; i++)
            {
                Console.WriteLine($"  {menu[i]}");
            }
            MenuUpdate(cursorTop);
        }

        void MenuUpdate(int nextPos)
        {
            Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
            Console.Write(" ");
            Console.SetCursorPosition(0, nextPos);
            Console.Write(">");
        }


    }
}
