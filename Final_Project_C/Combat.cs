﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_C
{
    class Combat
    {
        Enemy enemy;
        string action;

        public Combat()
        {
            
            CombatStartUp();
            GetEnemy(Player.enemyPosX, Player.enemyPosY);
            CombatUpDate();
        }
        void CombatStartUp()
        {
            
        }

        void GetEnemy(int X , int Y)
        {
            for (int i = 0; i < EnemyManager.enemies.Count; i++)
            {
                if (EnemyManager.enemies[i].posX == X && EnemyManager.enemies[i].posY == Y)
                {
                    enemy = EnemyManager.enemies[i];
                }
            }
        }

        void CombatUpDate()
        {
            while (!Player.IsDead() && !enemy.IsDead())
            {
                PlayerTurn();
                EnemyTurn();
            }
        }

        void PlayerTurn()
        {

            Console.WriteLine("What do you want to do?...");
            action = Console.ReadLine();

            switch (action)
            {
                case "1":
                    Player.Attack(enemy);
                    break;
                default:
                    break;
            }

        }

        void EnemyTurn()
        {
            enemy.Attack();
        }
    }
}