using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C
{

    class EnemyManager
    {
        int spawnX;
        int spawnY;
        public static bool enemyMove;
        MapLoader map;
        public static List<Enemy> enemies = new List<Enemy>();

        public EnemyManager(MapLoader map)
        {
            this.map = map;
        }
        public void EnemySpawn(int numOfEnemy, int difficulty)
        {
            Random random = new Random();

            for (int i = 0; i < numOfEnemy; i++)
            {
                invalidPoint:

                spawnX = random.Next(1, 39);
                spawnY = random.Next(1, 19);

                if (MapLoader.mapGride[spawnX, spawnY] != Strings.space)
                    goto invalidPoint;

                enemies.Add(new Enemy(Strings.enemy, spawnX, spawnY, difficulty));


            }

            Task.Run(() => EnemyMove());
            enemyMove = true;

        }
        public void EnemySpawn(int numOfEnemy, bool randDifficulty)
        {
            Random random = new Random();

            for (int i = 0; i < numOfEnemy; i++)
            {
                invalidPoint:

                spawnX = random.Next(1, 39);
                spawnY = random.Next(1, 19);

                if (MapLoader.mapGride[spawnX, spawnY] != Strings.space)
                    goto invalidPoint;

                enemies.Add(new Enemy(Strings.enemy, spawnX, spawnY, randDifficulty));


            }

            Task.Run(() => EnemyMove());
            enemyMove = true;

        }

        public Task EnemyMove()
        {
            Random random = new Random();
            enemyMove = true;

            while (enemyMove)
            {

                if (!SceneManager.inCombat && !Shop.inShop)
                {

                    
                    foreach (var enemy in enemies)
                    {
                        System.Threading.Thread.Sleep(500);
                        Console.SetCursorPosition(enemy.posX, enemy.posY);
                        Console.Write(Strings.space);
                        MapLoader.mapGride[enemy.posX, enemy.posY] = Strings.space;

                        switch (random.Next(0, 4))
                        {
                            case 0:
                                enemy.posX++;

                                if (MapLoader.mapGride[enemy.posX, enemy.posY] == Strings.space)
                                {
                                    break;
                                }
                                else
                                {
                                    enemy.posX--;
                                }
                                break;
                            case 1:
                                enemy.posX--;

                                if (MapLoader.mapGride[enemy.posX, enemy.posY] == Strings.space)
                                {
                                    break;
                                }
                                else
                                {
                                    enemy.posX++;
                                }
                                break;
                            case 2:
                                enemy.posY++;

                                if (MapLoader.mapGride[enemy.posX, enemy.posY] == Strings.space)
                                {
                                    break;
                                }
                                else
                                {
                                    enemy.posY--;
                                }
                                break;
                            case 3:
                                enemy.posY--;

                                if (MapLoader.mapGride[enemy.posX, enemy.posY] == Strings.space)
                                {
                                    break;
                                }
                                else
                                {
                                    enemy.posY++;
                                }
                                break;
                            default:
                                break;
                        }

                        Console.SetCursorPosition(enemy.posX, enemy.posY);
                        Console.Write(Strings.enemy);
                        MapLoader.mapGride[enemy.posX, enemy.posY] = Strings.enemy;

                    }
                }
                else
                    enemyMove = false;
            }
            return null;
        }





    }
}
