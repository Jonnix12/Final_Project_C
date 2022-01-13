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


        public static List<Enemy> enemies = new List<Enemy>();

        public void EnemySpawn(int numOfEnemy)
        {
            Random random = new Random();

            for (int i = 0; i < numOfEnemy; i++)
            {
                invalidPoint:

                spawnX = random.Next(1, 39);
                spawnY = random.Next(1, 19);

                if (MapLoader.mapGride[spawnX, spawnY] != Strings.empty)
                    goto invalidPoint;

                enemies.Add(new Enemy(Strings.enemy, spawnX, spawnY));


            }
        }

    }
}
