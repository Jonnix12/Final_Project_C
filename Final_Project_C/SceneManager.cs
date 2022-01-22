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

        int NumOfRooms = 4;
        static int numOfEnemy = 0;
        static int enemyDifficulty = 1;
        static bool randDifficulty = false;
        public static int levelCount = 0;
        PickUpManager pickUpManager;
        MapLoader Map;

        public SceneManager(int entryY)
        {
            levelCount++;
            Map = new MapLoader();
            pickUpManager = new PickUpManager();
            Map.MapStartUp(entryY , NumOfRooms,pickUpManager);
            EnemyManager enemyManager = new EnemyManager();
            enemyManager.EnemySpawn(numOfEnemy, enemyDifficulty, randDifficulty);
            PickUpSpawn();
            Map.MapUpDate();
            GameUpDate();
        }

        public static void SetDiifficulty(int difficulty, bool setRandDifficulty)
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
            int cunt = 0;

            while (true)
            {
                GetPlayerInput();
                Player.Move(key);
                Map.PlayerPosisonUpDate(Vector2.X, Vector2.Y);

                if (key == ConsoleKey.Escape)
                {
                    MainMenu puseMenu = new MainMenu(true);
                    Map.MapUpDate();
                }

                if (cunt > 50)
                {
                    Map.MapUpDate();
                    cunt = 0;
                }

                collideChack();
                cunt++;

            }
        }

        void collideChack()
        {
            string temp = Player.Collider();

            if (temp == Strings.enemy)
            {
                Combat combat = new Combat(Map);
                Map.MapUpDate();
            }

            if (temp == Strings.weaponUi)
            {
                pickUpManager.weaponPickUp.activation();
                Map.MapUpDate();
                Log("Pick up a Weapon");
            }

            if (temp == Strings.hpUi)
            {
                pickUpManager.hpPickUp.activation();
                Map.MapUpDate();
                Log("Pick up HP");
            }

            if (temp == Strings.chastUi)
            {
                pickUpManager.chastPickUp.activation();
                Map.MapUpDate();
                Log("Open a Chast");
            }

            if (temp == Strings.potion)
            {
                pickUpManager.potion.activationPickUp();
                Map.MapUpDate();
                Log("Add potion");
            }

            if (temp == Strings.exit && EnemyManager.enemies.Count == 0)
            {
                Shop shop = new Shop();
                MoveToNextScene(Vector2.Y);
            }

        }

        void PickUpSpawn()
        {
            Random random = new Random();

            if (random.Next(0, 11) < 7)
            {
                pickUpManager.SpawnChast();
            }

            if (random.Next(0, 11) < 6)
            {
                pickUpManager.SpawnHp();
            }

            if (random.Next(0, 11) < 1)
            {
                pickUpManager.SpawnWeapon();
            }

            if (random.Next(0, 11) < 9)
            {
                pickUpManager.SpawnPotion();
            }

        }

        void MoveToNextScene(int entryY)
        {
            Console.Clear();
            SceneManager newScene = new SceneManager(entryY);
        }

        void Log(string Log)
        {
            Console.WriteLine(Log);
        }


    }
}
