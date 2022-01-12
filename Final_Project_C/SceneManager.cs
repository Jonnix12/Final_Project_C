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
            EnemyManager.EnemySpawn(5);
            PickUpSpawn();
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

                collideChack();

            }
        }

        void collideChack()
        {
            if (Player.Collider() == EnemyManager.enemy)
            {
                Combat combat = new Combat();
            }

            if (Player.Collider() == PickUpManager.weaponUi)
            {
                PickUpManager.weaponPickUp.activation();
            }

            if (Player.Collider() == PickUpManager.hpUi)
            {
                PickUpManager.hpPickUp.activation();
            }

            if (Player.Collider() == PickUpManager.chastUi)
            {
                PickUpManager.chastPickUp.activation();
            }

        }

        void PickUpSpawn()
        {
            Random random = new Random();

            if (random.Next(0, 11) < 4)
            {
                PickUpManager.SpawnChast();
            }

            if (random.Next(0,11) < 6)
            {
                PickUpManager.SpawnHp();
            }
        }
    }
}
