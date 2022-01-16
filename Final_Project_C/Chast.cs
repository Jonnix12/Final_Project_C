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

        public Chast(string Ui,int amontOfCoins , bool PowerUp, int X, int Y)
        {
            MapLoader.mapGride[X, Y] = Ui;
            this.X = X;
            this.Y = Y;

        }

        public void activation()
        {
            MapLoader.mapGride[X, Y] = Strings.space;
            Player.score += 10;
        }
    }
}
