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
        static int numOfEnemy;
        static int enemyDifficulty;
        static bool randDifficulty;

        public SceneManager(int entryX, int entryY)
        {
            MapLoader.MapStartUp(entryX, entryY);
            EnemyManager enemyManager = new EnemyManager();
            enemyManager.EnemySpawn(numOfEnemy, enemyDifficulty, randDifficulty);
            PickUpSpawn();
            MapLoader.MapUpDate();
            GameUpDate();
        }

        public static void SetDiifficulty(int difficulty,bool setRandDifficulty)
        {
            switch (difficulty)
            {
                case 1:
                    numOfEnemy = 2;
                    enemyDifficulty = 0;
                    if (randDifficulty)
                    {
                        randDifficulty = setRandDifficulty;
                    }
                    break;
                case 2:
                    numOfEnemy = 4;
                    enemyDifficulty = 1;
                    if (randDifficulty)
                    {
                        randDifficulty = setRandDifficulty;
                    }
                    break;
                case 3:
                    numOfEnemy = 6;
                    enemyDifficulty = 2;
                    if (randDifficulty)
                    {
                        randDifficulty = setRandDifficulty;
                    }
                    break;
                case 4:
                    numOfEnemy = 8;
                    enemyDifficulty = 2;
                    randDifficulty = false;
                    break;
                default:
                    break;
            }
        }

        void GetPlayerInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            key = keyInfo.Key;
        }

        void GameUpDate()
        {
            while (true)
            {
                GetPlayerInput();
                Player.Move(key);
                MapLoader.PlayerPosisonUpDate(Vector2.X, Vector2.Y);
                if (key == ConsoleKey.Escape)
                {
                    MainMenu puseMenu = new MainMenu(true);
                    MapLoader.MapUpDate();
                }

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
            string temp = Player.Collider();

            if (temp == Strings.enemy)
            {
                Combat combat = new Combat();
                doUpDate = true;
            }

            if (temp == Strings.weaponUi)
            {
                PickUpManager.weaponPickUp.activation();
                doUpDate = true;
            }

            if (temp == Strings.hpUi)
            {
                PickUpManager.hpPickUp.activation();
                doUpDate = true;
            }

            if (temp == Strings.chastUi)
            {
                PickUpManager.chastPickUp.activation();
                doUpDate = true;
            }

            if (temp == Strings.potion)
            {
                
            }

            if (temp == Strings.exit && EnemyManager.enemies.Count == 0)
            {
                Shop shop = new Shop();
                MoveToNextScene(Vector2.X, Vector2.Y);
            }

        }

        void PickUpSpawn()
        {
            Random random = new Random();

            if (random.Next(0, 11) < 6)
            {
                PickUpManager.SpawnChast();
            }

            if (random.Next(0, 11) < 6)
            {
                PickUpManager.SpawnHp();
            }

            if (random.Next(0, 11) < 2)
            {
                PickUpManager.SpawnWeapon();
            }

            if (random.Next(0,11)< 7)
            {
                PickUpManager.SpawnHpPotion();
            }

            if (random.Next(0, 11) < 7)
            {
                PickUpManager.SpawnStaminaPotion();
            }
        }

        void MoveToNextScene(int entryX, int entryY)
        {
            Console.Clear();
            SceneManager newScene = new SceneManager(entryX, entryY);
        }


    }
}
