using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C
{
    class Potion
    {
        int X;
        int Y;
        bool isHp;
        public Potion(string Ui, int X, int Y, bool isHp)
        {
            MapLoader.mapGride[X, Y] = Ui;
            this.X = X;
            this.Y = Y;
            this.isHp = isHp;
        }

        public   Potion (bool isHp)
        {
            
            activation(isHp);
        }

        public void activationPickUp()
        {
            if (isHp)
            {
                activationHp();
            }
            else
                activationStamina();
        }

        void activation(bool isHp)
        {
            if (isHp)
            {
                Player.inventory.AddHpPotion(this);
            }
            else
                Player.inventory.AddStaminaPotion(this);
        }

        void activationHp()
        {
            MapLoader.mapGride[X, Y] = Strings.space;
            Player.inventory.AddHpPotion(this);
            

        }

        void activationStamina()
        {
            MapLoader.mapGride[X, Y] = Strings.space;
            Player.inventory.AddStaminaPotion(this);
           

        }

    }
}
