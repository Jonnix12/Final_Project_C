using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C
{
    class Weapon
    {
        string name;
        int damage;
        int weight;
        int hitChance;

        public Weapon(string name, int damage, int weight, int hitChance)
        {
            this.name = name;
            this.damage = damage;
            this.weight = weight;
            this.hitChance = hitChance;
        }

        public void ShortAttack(Enemy enemy)
        {
            if (Player.RemoveStamina(weight))
            {
                if (Player.StrikeChance(hitChance))
                {
                    enemy.TakeDamage(damage);
                }
            }

        }

        public void LongAttack(Enemy enemy)
        {
            if (Player.RemoveStamina(weight + 4))
            {
                if (Player.StrikeChance(hitChance - 2))
                {
                    enemy.TakeDamage(damage + 5);
                }
            }

        }

        public string GetWeaponName()
        {
            return this.name;
        }
    }
}
