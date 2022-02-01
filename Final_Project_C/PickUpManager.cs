using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C
{
    class PickUpManager
    {

        int spawnX;
        int spawnY;

        List<int> xPos = new List<int>();
        List<int> yPos = new List<int>();

        public WeaponPickUp weaponPickUp;
        public HpPickUp hpPickUp;
        public Chast chastPickUp;
        public Potion potion;



        public void GetSpawnLocation(int minX, int maxX, int minY, int maxY)//Finds a spawning point inside one of the rooms
        {
            List<int> X = new List<int>();
            List<int> Y = new List<int>();
            int _spawnX;
            int _spawnY;

            for (int i = minX + 1; i <= maxX - 1; i++)
            {
                X.Add(i);
            }

            for (int i = minY + 1; i < maxY - 1; i++)
            {
                Y.Add(i);
            }

            int index_X;
            int index_Y;

            Random random = new Random();

            invalidPoint:
            index_X = random.Next(0, X.Count);
            index_Y = random.Next(0, Y.Count);

            _spawnX = X[index_X];
            _spawnY = Y[index_Y];

            if (MapLoader.mapGride[_spawnX, _spawnY] != Strings.rommSpace)
                goto invalidPoint;

            xPos.Add(_spawnX);
            yPos.Add(_spawnY);
        }

        void SetSpawnLocation()//Determines the spawning point
        {
            Random random = new Random();
            int index = random.Next(0, xPos.Count);

            spawnX = xPos[index];
            spawnY = yPos[index];
        }

        public void SpawnWeapon()
        {
            bool isSwordIn = false;
            bool isAxein = false;
            bool isFireBullIn = false;

            if (Player.inventory.weapons.ContainsKey("sword"))
                isSwordIn = true;
            if (Player.inventory.weapons.ContainsKey("axe"))
                isAxein = true;
            if (Player.inventory.weapons.ContainsKey("firebull"))
                isFireBullIn = true;

            if (!isFireBullIn || !isAxein || !isSwordIn)
            {
                SetSpawnLocation();
                weaponPickUp = new WeaponPickUp(Strings.weaponUi, spawnX, spawnY);
            }
            

        }

        public void SpawnHp()
        {
            SetSpawnLocation();
            Random random = new Random();

            int hpPlus = random.Next(10, 26);

            hpPickUp = new HpPickUp(Strings.hpUi, hpPlus, spawnX, spawnY);

        }

        public void SpawnChast()
        {
            SetSpawnLocation();
            Random random = new Random();
            int ScorePlus = random.Next(5, 16);

            chastPickUp = new Chast(Strings.chastUi, ScorePlus, spawnX, spawnY);

        }

        public void SpawnPotion()
        {
            SetSpawnLocation();
            Random random = new Random();
            int temp = random.Next(0, 2);
            bool tempBool = true;

            if (temp == 0)
            {
                tempBool = true;
            }
            else if (temp == 1)
            {
                tempBool = false;
            }
            potion = new Potion(Strings.potion, spawnX, spawnY, tempBool);

        }

    }
}
