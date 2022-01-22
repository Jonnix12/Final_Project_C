using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C
{
    class Chast
    {
       
        int X;
        int Y;
        int scorePlus;

        public Chast(string Ui,int amontOfCoins , int X, int Y)
        {
            MapLoader.mapGride[X, Y] = Ui;
            this.X = X;
            this.Y = Y;
            scorePlus = amontOfCoins;

        }

        public void activation()
        {
            MapLoader.mapGride[X, Y] = Strings.space;
            Player.AddPoint(scorePlus);
        }

        public int GetPoints()
        {
            return scorePlus;
        }
    }
}
