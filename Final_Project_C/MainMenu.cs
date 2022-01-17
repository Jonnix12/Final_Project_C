using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C
{
    class MainMenu
    {
        string[] screenOptions = new string[] { "Play", "Options", "Tutorial", "Exit" };
        string select;
        ConsoleKeyInfo KeyInfo;
        int selectIndex = 0;

        public MainMenu()
        {
            StartMenu();
        }

        void StartMenu()
        {
            PrintScreen();

            do
            {
                KeyInfo = Console.ReadKey(true);

                if (KeyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectIndex--;
                    if (selectIndex == -1)
                    {
                        selectIndex = screenOptions.Length - 1;
                    }
                }
                else if (KeyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectIndex++;
                    if (selectIndex == screenOptions.Length )
                    {
                        selectIndex = 0;
                    }
                }
                Console.Clear();
                PrintScreen();


            } while (KeyInfo.Key != ConsoleKey.Enter);

            if (selectIndex == 0)
            {
                SceneManager sceneManager = new SceneManager(3, 3);
            }
            else if (selectIndex == 1)
            {

            }
            else if (selectIndex == 2)
            {

            }
            else if (selectIndex == 3)
            {
                System.Environment.Exit(0);
            }



        }

        void PrintScreen()
        {

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
            for (int i = 0; i < screenOptions.Length; i++)
            {
                if (i == selectIndex)
                {
                    select = ">";
                }
                else
                {
                    select = " ";
                }
                Console.WriteLine($"{select} {screenOptions[i]}");
            }
        }
    }
}
