using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C
{
    class PickUpManager
    {
        public static string weaponUi = "*";
        public static string hpUi = "+";
        public static string chastUi = "⌂";
        static int spawnX;
        static int spawnY;

        public static WeaponPickUp weaponPickUp;
        public static HpPickUp hpPickUp;
        public static Chast chastPickUp;

        static void GetSpawnLocation()
        {
            Random random = new Random();

            invalidPoint:

            spawnX = random.Next(1, 39);
            spawnY = random.Next(1, 19);

            if (MapLoader.mapGride[spawnX, spawnY] != MapLoader.empty)
                goto invalidPoint;
        }

        public static void SpawnWeapon()
        {
            GetSpawnLocation();
            weaponPickUp = new WeaponPickUp(weaponUi, spawnX, spawnY);

        }

        public static void SpawnHp()
        {
            GetSpawnLocation();
            hpPickUp = new HpPickUp(hpUi, 10, spawnX, spawnY);

        }

        public static void SpawnChast()
        {
            GetSpawnLocation();
            chastPickUp = new Chast(chastUi, 5, false, spawnX, spawnY);

        }
    }
}
