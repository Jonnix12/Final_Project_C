using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C
{
    class EndScreen
    {
        public static bool isDead = false;
        bool toContinue = true;
        public EndScreen()
        {
            isDead = true;

            while (toContinue)
            {
                if (!EnemyManager.enemyMove)
                {
                    toContinue = false;
                }
            }
            Console.Clear();
            PrintEndScreen();
        }

        void PrintEndScreen()
        {
            Console.WriteLine(@"▓█████▄ ▓█████ ▄▄▄      ▓█████▄ 
▒██▀ ██▌▓█   ▀▒████▄    ▒██▀ ██▌
░██   █▌▒███  ▒██  ▀█▄  ░██   █▌
░▓█▄   ▌▒▓█  ▄░██▄▄▄▄██ ░▓█▄   ▌
░▒████▓ ░▒████▒▓█   ▓██▒░▒████▓ 
 ▒▒▓  ▒ ░░ ▒░ ░▒▒   ▓▒█░ ▒▒▓  ▒ 
 ░ ▒  ▒  ░ ░  ░ ▒   ▒▒ ░ ░ ▒  ▒ 
 ░ ░  ░    ░    ░   ▒    ░ ░  ░ 
   ░       ░  ░     ░  ░   ░    
 ░                       ░      

");

            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("\nPrees any key to continue");
            Console.ReadKey(true);
            Player.PlayerStartUp();
            MainMenu mainMenu = new MainMenu(false);
        }


    }
}
