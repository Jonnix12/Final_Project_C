using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C
{
    class HpPickUp
    {
        int X;
        int Y;
        int hpAdd;
        public HpPickUp(string Ui, int amontOfHp, int X, int Y)
        {
            MapLoader.mapGride[X, Y] = Ui;
            this.X = X;
            this.Y = Y;
            hpAdd = amontOfHp;
        }

        public void activation()
        {
            MapLoader.mapGride[X, Y] = Strings.space;
            Player.AddHp(hpAdd);
        }

        public int HpPlus()
        {
            return hpAdd;
        }
    }
}
