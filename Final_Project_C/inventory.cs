using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C
{
    class inventory
    {
        bool isSwordIn = false;
        bool isAxeIn = false;
        bool isFireBullIn = false;
        public Dictionary<string, Weapon> weapons = new Dictionary<string, Weapon>();

        public void AddSword()
        {
            if (!isSwordIn)
            {
                weapons.Add("sword", new Weapon("Sword", 10, 15, 7));

                isSwordIn = true;
            }
        }

        public void AddAxe()
        {
            if (!isAxeIn)
            {
                weapons.Add("axe", new Weapon("Axe", 10, 15, 5));
                Console.WriteLine("Add Axe");
                isAxeIn = true;
            }
        }

        public void AddFireBull()
        {
            if (!isFireBullIn)
            {
                weapons.Add("firebull", new Weapon("Firebull", 10, 15, 4));

                isFireBullIn = true;
            }
        }
    }

}
