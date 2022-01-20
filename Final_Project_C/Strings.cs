using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C
{
    static class Strings
    {
        public static string roomEdgeSide = "|";
        public static string mapEdgeSide = "|";
        public static string mapEdgeTopAndBottom = "-";
        public static string player = "☺";
        public static string exit = "$";
        public static string space = " ";
        public static string rommSpace = " ";
        public static string enemy = "☼";
        public static string weaponUi = "*";
        public static string hpUi = "+";
        public static string chastUi = "⌂";
        public static string potion = "&";

        public static string[] stringArr = new string[] { roomEdgeSide, mapEdgeSide, mapEdgeTopAndBottom, player, enemy, exit, space, weaponUi, hpUi, potion, chastUi};
    }
}
