using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C
{
    class SceneManager
    {
        ConsoleKey key;
        bool doUpDate = false;

        public SceneManager()
        {
            MapLoader.MapStartUp();
            EnemySpawner.EnemySpawn(5);
            MapLoader.MapUpDate();
            GameUpDate();
        }

        void GetPlayerInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            key = keyInfo.Key;
            doUpDate = true;
        }

        void GameUpDate()
        {
            while (true)
            {
                GetPlayerInput();
                Player.Move(key);

                
                if (doUpDate)
                {
                    MapLoader.MapUpDate();
                    doUpDate = false;
                }

                if (Player.Collider() == EnemySpawner.enemy)
                {
                    Combat combat = new Combat();
                }

            }
        }
    }
}
