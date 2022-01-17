using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C
{
    class PickUpManager
    {

        static int spawnX;
        static int spawnY;


        static List<int> minXL = new List<int>();
        static List<int> maxXL = new List<int>();
        static List<int> minYL = new List<int>();
        static List<int> maxYL = new List<int>();

        public static WeaponPickUp weaponPickUp;
        public static HpPickUp hpPickUp;
        public static Chast chastPickUp;

        public static void GetSpawnLocation(int minX, int maxX, int minY, int maxY)
        {
            int conut = 0;

            minXL.Add(minX);
            maxXL.Add(maxX);
            minYL.Add(minY);
            maxYL.Add(maxY);

            conut++;
        }

        static void SetSpawnLocation()
        {
            int index;

            Random random = new Random();

            invalidPoint:
            index = random.Next(0, minXL.Count);

            spawnX = random.Next(minXL[index], maxXL[index]);
            spawnY = random.Next(minYL[index], maxYL[index]);

            if (MapLoader.mapGride[spawnX, spawnY] != Strings.rommSpace)
                goto invalidPoint;
        }

        public static void SpawnWeapon()
        {
            SetSpawnLocation();
            weaponPickUp = new WeaponPickUp(Strings.weaponUi, spawnX, spawnY);

        }

        public static void SpawnHp()
        {
            SetSpawnLocation();
            Random random = new Random();

            int hpPlus = random.Next(10, 26);

            hpPickUp = new HpPickUp(Strings.hpUi, hpPlus, spawnX, spawnY);

        }

        public static void SpawnChast()
        {
            SetSpawnLocation();
            Random random = new Random();
            int ScorePlus = random.Next(5, 16);

            chastPickUp = new Chast(Strings.chastUi, ScorePlus, spawnX, spawnY);

        }
    }
}
