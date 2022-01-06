using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C
{
    static class MapLoader
    {
        public static string[,] mapGride = new string[40, 20];
        static string[,] mapGrideUpDate = new string[20, 20];

        public static string empty = " ";
        static string roomEdgeSide = "|";
        
        static string mapEdgeSide = "|";
        static string mapEdgeTopAndBottom = "-";
        static string player = "+";



        public static void MapStartUp()
        {
            for (int Y = 0; Y < 20; Y++)
            {
                for (int X = 0; X < 40; X++)
                {
                    mapGride[X, Y] = empty;

                    if (X == 0 || X == 39)
                        mapGride[X, Y] = mapEdgeSide;

                    if (Y == 0 || Y == 19)
                        mapGride[X, Y] = mapEdgeTopAndBottom;

                }
            }
            RoomSetUp();
            PlayerPosisonUpDate(Vector2.Y, Vector2.X);
            mapGrideUpDate = mapGride;
        }

        public static void MapUpDate()
        {
            Console.Clear();
            PlayerPosisonUpDate(Vector2.X, Vector2.Y);
            MapPrint(mapGride);
        }

        static void RoomSetUp()
        {
            int maxX;
            int minX;
            int maxY;
            int minY;

            Random random = new Random();

            minY = random.Next(1, 12);
            maxY = random.Next(minY + 4, minY + 10);

            minX = random.Next(1, 32);
            maxX = random.Next(minX + 4, minX + 13);

            for (int X = minX; X < maxX + 1; X++)
            {
                if (X == minX || X == maxX)
                {

                    for (int Y = minY; Y < maxY + 1; Y++)
                    {
                        mapGride[X, Y] = roomEdgeSide;
                    }
                }
                mapGride[X, minY] = mapEdgeTopAndBottom;
                mapGride[X, maxY] = mapEdgeTopAndBottom;

            }

        }

        static void MapPrint(string[,] map)
        {
            for (int Y = 0; Y < 20; Y++)
            {
                for (int X = 0; X < 40; X++)
                {
                    Console.Write(map[X, Y]);
                }
                Console.WriteLine();
            }
            Console.WriteLine(Player.playerCurrentX + "," + Player.playerCurrentY);
        }


        public static void PlayerPosisonUpDate(int x, int y)
        {
            mapGride[Player.playerCurrentX, Player.playerCurrentY] = empty;
            mapGride[x, y] = player;

            Player.playerCurrentY = y;
            Player.playerCurrentX = x;

        }
    }
}
