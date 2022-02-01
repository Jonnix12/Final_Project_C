using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C
{
    class WeaponPickUp
    {
        int X;
        int Y;

        public WeaponPickUp(string Ui, int X, int Y)
        {
            MapLoader.mapGride[X, Y] = Ui;
            this.X = X;
            this.Y = Y;
        }

        public void activation() //Creates a weapon and activates a spawning action
        {
            MapLoader.mapGride[X, Y] = Strings.space;
            WeaponSpawn();
        }

        void WeaponSpawn()//Checks what weapons the player has and then spawns random weapons
        {
            bool isSwordIn = false;
            bool isAxein = false;
            bool isFireBullIn = false;
            bool isSpawn = false;

            int[] vs = new int[] { 1, 2, 3 };

            if (Player.inventory.weapons.ContainsKey("sword"))
                isSwordIn = true;
            if (Player.inventory.weapons.ContainsKey("axe"))
                isAxein = true;
            if (Player.inventory.weapons.ContainsKey("firebull"))
                isFireBullIn = true;

            Random random = new Random();


            DidNotSpawn:
            int chance = random.Next(1, 4);

            if (chance == 1 && !isSwordIn)
            {
                Player.inventory.AddSword();
                isSpawn = true;
            }
            else if (chance == 2 && !isAxein)
            {
                Player.inventory.AddAxe();
                isSpawn = true;
            }
            else if (chance == 3 && !isFireBullIn)
            {
                Player.inventory.AddFireBull();
                isSpawn = true;
            }
            else if (isAxein && isFireBullIn && isSpawn)
            {
                isSpawn = true;
            }
            else
            {
                if (!isSpawn)
                {
                    goto DidNotSpawn;
                }
            }
        }
    }
}
