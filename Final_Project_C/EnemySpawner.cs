using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C
{
    static class EnemySpawner
    {
        static int spawnX;
        static int spawnY;
        public static string enemy = "*";

        public static void EnemySpawn(int numberOfEnemy)
        {
            Random random = new Random();

            invalidPoint:
            for (int i = 0; i < numberOfEnemy; i++)
            {
                spawnX = random.Next(1, 39);
                spawnY = random.Next(1, 19);

                if (MapLoader.mapGride[spawnX, spawnY] != MapLoader.empty)
                    goto invalidPoint;

                for (int j = 0; j < numberOfEnemy; j++)
                {
                    EnemyManager.enemies.Add(new Enemy(spawnX, spawnY));
                }
                
            }




        }

    }
}
