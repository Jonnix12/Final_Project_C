using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C
{
    static class inventory
    {
        public static Dictionary<string, Weapon> weaponInventory = new Dictionary<string, Weapon>();

        public static void AddSword()
        {
            weaponInventory.Add("sword", new Weapon("Sword", 10, 15, 7));
            Console.WriteLine("1");
        }

        public static void AddAxe()
        {
            weaponInventory.Add("axe", new Weapon("Axe", 10, 15, 5));
        }

        public static void AddFireBull()
        {
            weaponInventory.Add("firebull", new Weapon("Firebull", 10, 15, 4));

        }
    }

}
