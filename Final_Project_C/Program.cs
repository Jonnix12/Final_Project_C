using System;

namespace Final_Project_C
{
    class Program
    {
        static void Main(string[] args)
        {
            MapLoader.MapStartUp();

            while (true)
            {
                Player.Move(Console.ReadLine());
                MapLoader.MapUpDate();

            }

        }
    }
}
