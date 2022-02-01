using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C
{
    class Trap
    {
        int playerPosX;
        int playerPosY;
        int originCursorPosX;
        int originCursorPosY;

        public Trap()
        {
            playerPosX = Player.playerCurrentX;
            playerPosY = Player.playerCurrentY;
            originCursorPosX = Console.GetCursorPosition().Left;
            originCursorPosY = Console.GetCursorPosition().Top;
            Start();
        }

        void Start()//Writes the trap effect on the screen
        {
            int startX = playerPosX - 1;
            int startY = playerPosY - 1;
            int xRange = 3;
            int yRange = 3;
            int count = 0;
            bool isChange = false;

            while (count < 2)
            {

                for (int i = startX; i < startX + xRange; i++)
                {
                    for (int j = startY; j < startY + yRange; j++)
                    {
                        if (MapLoader.mapGride[i, j] == "#")
                        {
                            MapLoader.mapGride[i, j] = Strings.space;
                            Console.SetCursorPosition(i, j);
                            Console.Write(Strings.space);
                            isChange = true;
                        }
                        if (MapLoader.mapGride[i, j] == Strings.space && !isChange)
                        {
                            MapLoader.mapGride[i, j] = "#";
                            Console.SetCursorPosition(i, j);
                            Console.Write("#");
                        }
                        isChange = false;
                    }
                }
                System.Threading.Thread.Sleep(250);
                startX--;
                startY--;
                xRange += 2;
                yRange += 2;

                if (startX < 0)
                    startX = 0;
                if (startY < 0)
                    startY = 0;
                if (startX + xRange > 40)
                    xRange -= 1;
                if (startY + yRange > 20)
                    yRange -= 1;

                count++;
            }
            Console.SetCursorPosition(originCursorPosX, originCursorPosY);
            for (int i = startX; i < startX + xRange; i++)//Clears the screen from the effect
            {
                for (int j = startY; j < startY + yRange; j++)
                {
                    if (MapLoader.mapGride[i, j] == "#")
                    {
                        MapLoader.mapGride[i, j] = Strings.space;

                    }
                    
                }
            }
            
        }
    }
}






