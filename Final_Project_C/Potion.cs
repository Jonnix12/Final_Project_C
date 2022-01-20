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

        public void activation()
        {
            if (isHp)
            {
                activationHp();
            }
            else
                activationStamina();
        }

        public void activationHp()
        {
            MapLoader.mapGride[X, Y] = Strings.space;
            Player.inventory.AddHpPotion(this);

        }

        public void activationStamina()
        {
            MapLoader.mapGride[X, Y] = Strings.space;
            Player.inventory.AddStaminaPotion(this);

        }
    }
}
