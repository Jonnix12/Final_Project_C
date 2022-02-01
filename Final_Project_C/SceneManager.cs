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

        public static bool inCombat = false;
        public static int levelCount = 0;
        static int numOfEnemy = 4;
        static int enemyDifficulty = 1;
        static int amontOfTraps = 2;
        int NumOfRooms = 4;
        int trapCount = 0;


        static bool randDifficulty = false;

        PickUpManager pickUpManager;
        MapLoader Map;
        EnemyManager enemyManager;

        public SceneManager(int entryY)//Creates a new scene
        {
            levelCount++;
            Map = new MapLoader();
            pickUpManager = new PickUpManager();
            Map.MapStartUp(entryY, NumOfRooms, pickUpManager);
            enemyManager = new EnemyManager(Map);

            if (randDifficulty)
            {
                enemyManager.EnemySpawn(numOfEnemy, randDifficulty);
            }
            else
            {
                enemyManager.EnemySpawn(numOfEnemy, enemyDifficulty);
            }
            PickUpSpawn();
            Map.MapUpDate();
            GameUpDate();
        }

        public static void SetDiifficulty(int difficulty)//Function for changing the difficulty level of enemies
        {
            switch (difficulty)
            {
                case 1:
                    amontOfTraps = 0;
                    numOfEnemy = 2;
                    enemyDifficulty = 0;

                    break;
                case 2:
                    amontOfTraps = 2;
                    numOfEnemy = 4;
                    enemyDifficulty = 1;

                    break;
                case 3:
                    amontOfTraps = 4;
                    numOfEnemy = 6;
                    enemyDifficulty = 2;

                    break;
                case 4:
                    amontOfTraps = 8;
                    numOfEnemy = 8;
                    enemyDifficulty = 2;
                    break;
                default:
                    break;
            }
        }

        public static void SetDiifficulty(bool setRandDifficulty)
        {
            randDifficulty = setRandDifficulty;
            Random random = new Random();
            numOfEnemy = random.Next(3, 9);
        }

        void GetPlayerInput()//Receives input from the user
        {

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            key = keyInfo.Key;
            keyInfo = default(ConsoleKeyInfo);
        }

        void GameUpDate()//Loop of the game
        {
            int cunt = 0;

            while (true)
            {
                System.Threading.Thread.Sleep(150);
                GetPlayerInput();

                if (key == ConsoleKey.W || key == ConsoleKey.S || key == ConsoleKey.A || key == ConsoleKey.D)
                {
                    Player.Move(key);
                    Map.PlayerPosisonUpDate(Vector2.X, Vector2.Y);
                    TrapCollider();


                    if (cunt > 50)
                    {
                        Map.MapUpDate();
                        cunt = 0;
                    }

                    collideChack();
                    cunt++;

                }

                if (key == ConsoleKey.Escape)
                {
                    MainMenu puseMenu = new MainMenu(true);
                    Map.MapUpDate();
                }
            }
        }

        void TrapCollider()//Checks if you landed on a trap
        {
            Random random = new Random();

            if (random.Next(0, 301) < 5 && trapCount < amontOfTraps)
            {
                Trap trap = new Trap();
                Map.MapUpDate();
                Log("landed on a TRAP!");
                Player.TakeDamage(random.Next(5, 10));
                trapCount++;
            }
        }

        void collideChack()//Checks if approached with an object
        {
            string temp = Player.Collider();

            if (temp == Strings.enemy)
            {
                bool toContinue = true;
                inCombat = true;
                while (toContinue)
                {
                    if (!EnemyManager.enemyMove)
                    {
                        toContinue = false;
                    }
                }
                Player.Collider();
                Combat combat = new Combat(Map);
                inCombat = false;
                Task.Run(() => enemyManager.EnemyMove());
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

        void PickUpSpawn()//At the beginning of a stage spawns objects on the map
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

        void MoveToNextScene(int entryY)//Moves level
        {
            Console.Clear();
            SceneManager newScene = new SceneManager(entryY);
        }

        void Log(string Log)//Log message
        {
            Console.WriteLine(Log);
        }
        

    }
}
