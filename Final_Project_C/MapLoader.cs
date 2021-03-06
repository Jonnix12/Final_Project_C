using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C
{
     class MapLoader
    {
        public static string[,] mapGride = new string[40, 20];
         PickUpManager PickUpManager;


        public  void MapStartUp(int entryY, int NumOfRooms , PickUpManager pickUpManager)
        {
            PickUpManager = pickUpManager;

            for (int Y = 0; Y < 20; Y++)
            {
                for (int X = 0; X < 40; X++)
                {
                    mapGride[X, Y] = Strings.space;

                    if (X == 0 || X == 39)
                        mapGride[X, Y] = Strings.mapEdgeSide;

                    if (Y == 0 || Y == 19)
                        mapGride[X, Y] = Strings.mapEdgeTopAndBottom;

                }
            }
            Random random = new Random();

            int Exit = random.Next(1, 18);

            mapGride[39, Exit] = Strings.exit;

            for (int i = 0; i < NumOfRooms; i++)
            {
                RoomSetUp();
            }
            
            
            Vector2.X = 1;
            PlayerPosisonUpDate(Vector2.X, entryY);
            MapPrint(mapGride);
        }

        public  void MapUpDate()
        {
            Console.Clear();
            PlayerPosisonUpDate(Vector2.X, Vector2.Y);
            MapPrint(mapGride);
        }


         void RoomSetUp()
        {
            int maxX;
            int minX;
            int maxY;
            int minY;


            bool isRoomBuild = false;

            Random random = new Random();

            while (!isRoomBuild)
            {
                bool buildRoom = true;

                minY = random.Next(2, 10);
                maxY = random.Next(minY + 4, minY + 8);

                minX = random.Next(2, 30);
                maxX = random.Next(minX + 4, minX + 8);

                for (int X = minX; X < maxX; X++)
                {
                    for (int Y = minY; Y < maxY; Y++)
                    {
                        if (!(mapGride[X, Y] == Strings.space))
                        {
                            buildRoom = false;
                        }
                    }
                }

                if (buildRoom)
                {

                    for (int X = minX; X < maxX; X++)
                    {
                        for (int Y = minY; Y < maxY; Y++)
                        {
                            mapGride[X, Y] = Strings.rommSpace;
                        }
                    }

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


                    invalidPoint:
                    int[] doorChoose = new int[] { minX, maxX, minY, maxY };
                    int doorWall = random.Next(0, 4);

                    if (doorWall <= 1)
                    {
                        int posY = random.Next(minY + 1, maxY - 1);
                        if (mapGride[doorChoose[doorWall] + 1, posY] == Strings.space && mapGride[doorChoose[doorWall] - 1, posY] == Strings.space)
                            mapGride[doorChoose[doorWall], posY] = Strings.space;
                        else
                            goto invalidPoint;



                    }
                    else if (doorWall >= 2)
                    {
                        int posX = random.Next(minX + 1, maxX - 1);

                        if (mapGride[posX, doorChoose[doorWall] + 1] == Strings.space && mapGride[posX, doorChoose[doorWall] - 1] == Strings.space)
                            mapGride[posX, doorChoose[doorWall]] = Strings.space;
                        else
                            goto invalidPoint;

                        

                    }

                    isRoomBuild = true;

                    PickUpManager.GetSpawnLocation(minX, maxX, minY, maxY);
                }
            }

        }

        public  void MapPrint(string[,] map)
        {
            for (int Y = 0; Y < 20; Y++)
            {
                for (int X = 0; X < 40; X++)
                {
                    Console.Write(map[X, Y]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Level {0}\n", SceneManager.levelCount);
            Console.WriteLine("HP:{0}", Player.hp);
            Console.WriteLine("Score:{0}", Player.point);
            Console.WriteLine("shield:{0}", Player.shield);
           // Console.WriteLine("HP Potion:{0}", Player.inventory.hpPotion.Count);
           // Console.WriteLine("Stamina Potion:{0}", Player.inventory.staminaPotion.Count);
            Console.WriteLine("Logs:");

        }


        public  void PlayerPosisonUpDate(int x, int y)
        {
            mapGride[Player.playerCurrentX, Player.playerCurrentY] = Strings.space;
            mapGride[x, y] = Strings.player;

            int left = Console.GetCursorPosition().Left;
            int top = Console.GetCursorPosition().Top;

            Console.SetCursorPosition(Player.playerCurrentX, Player.playerCurrentY);
            Console.Write(Strings.space);
            Console.SetCursorPosition(x, y);
            Console.Write(Strings.player);

            Player.playerCurrentY = y;
            Player.playerCurrentX = x;
            Console.SetCursorPosition(left,top);
        }
    }
}
