﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C
{
    class SceneManager
    {
        ConsoleKey key;
        bool doUpDate = false;

        public SceneManager(int entryX, int entryY)
        {
            MapLoader.MapStartUp(entryX, entryY);
            EnemyManager enemyManager = new EnemyManager();
            enemyManager.EnemySpawn(2);
            PickUpSpawn();
            MapLoader.MapUpDate();
            GameUpDate();
        }

        void GetPlayerInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            key = keyInfo.Key;
        }

        void GameUpDate()
        {
            while (true)
            {
                GetPlayerInput();
                Player.Move(key);
                MapLoader.PlayerPosisonUpDate(Vector2.X, Vector2.Y);
                if (key == ConsoleKey.Escape)
                {
                    MainMenu puseMenu = new MainMenu(true); 
                }

                if (doUpDate)
                {
                    MapLoader.MapUpDate();
                    doUpDate = false;
                }

                collideChack();

            }
        }

        void collideChack()
        {
            if (Player.Collider() == Strings.enemy)
            {
                Combat combat = new Combat();
                doUpDate = true;
            }

            if (Player.Collider() == Strings.weaponUi)
            {
                PickUpManager.weaponPickUp.activation();
                doUpDate = true;
            }

            if (Player.Collider() == Strings.hpUi)
            {
                PickUpManager.hpPickUp.activation();
                doUpDate = true;
            }

            if (Player.Collider() == Strings.chastUi)
            {
                PickUpManager.chastPickUp.activation();
                doUpDate = true;
            }

            if (Player.Collider() == Strings.exit && EnemyManager.enemies.Count == 0)
            {
                Shop.ShopMainMenu();
                MoveToNextScene(Vector2.X, Vector2.Y);
            }

        }

        void PickUpSpawn()
        {
            Random random = new Random();

            if (random.Next(0, 11) < 6)
            {
                PickUpManager.SpawnChast();
            }

            if (random.Next(0, 11) < 6)
            {
                PickUpManager.SpawnHp();
            }

            if (random.Next(0, 11) < 2)
            {
                PickUpManager.SpawnWeapon();
            }
        }

        void MoveToNextScene(int entryX, int entryY)
        {
            Console.Clear();
            SceneManager newScene = new SceneManager(entryX, entryY);
        }

        
    }
}
