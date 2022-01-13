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



        public static void MapStartUp(int entryX, int entryY)
        {
            for (int Y = 0; Y < 20; Y++)
            {
                for (int X = 0; X < 40; X++)
                {
                    mapGride[X, Y] = Strings.empty;

                    if (X == 0 || X == 39)
                        mapGride[X, Y] = Strings.mapEdgeSide;

                    if (Y == 0 || Y == 19)
                        mapGride[X, Y] = Strings.mapEdgeTopAndBottom;

                }
            }
            Random random = new Random();

            int Exit = random.Next(1, 18);

            mapGride[39, Exit] = Strings.exit;

            RoomSetUp();
            
            Vector2.X = 1;
            PlayerPosisonUpDate(Vector2.X, entryY);
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
                        mapGride[X, Y] = Strings.roomEdgeSide;
                    }
                }
                mapGride[X, minY] = Strings.mapEdgeTopAndBottom;
                mapGride[X, maxY] = Strings.mapEdgeTopAndBottom;

            }

        }

        public static void MapPrint(string[,] map)
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
            Console.WriteLine(EnemyManager.enemies.Count);
        }


        public static void PlayerPosisonUpDate(int x, int y)
        {
            mapGride[Player.playerCurrentX, Player.playerCurrentY] = Strings.empty;
            mapGride[x, y] = Strings.player;

            Player.playerCurrentY = y;
            Player.playerCurrentX = x;
            Player.Collider();

        }
    }
}
