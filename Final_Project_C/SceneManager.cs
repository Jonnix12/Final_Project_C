using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C
{
    class SceneManager
    {
        public SceneManager()
        {
            MapLoader.MapStartUp();
            GameUpDate();
        }

        void GameUpDate()
        {
            while (true)
            {
                Player.Move(Console.ReadLine());
                MapLoader.MapUpDate();

                if (Player.EnemyCoill())
                {
                    Combat combat = new Combat();
                }


            }
        }
    }
}
