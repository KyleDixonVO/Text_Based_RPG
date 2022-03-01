﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    abstract class GameCharacter : GameObject
    {
        public int deltaX;
        public int deltaY;
        public int futureX;
        public int futureY;
        public int lastX;
        public int lastY;
        public int health = 5;
        public int maxHealth = 5;
        public bool dead = false;
        public bool canMoveThere;

        public void Initialize(int setHealth, int setX, int setY, char setAvatar)
        {
            maxHealth = setHealth;
            health = maxHealth;
            x = setX;
            y = setY;
            avatar = setAvatar;
        }

        public void TakeDamage()
        {
            health--;

            if (health <= 0)
            {
                health = 0;
                dead = true;
            }
        }

        public void ShowStats()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(1, 13);
            Console.Write(avatar + " health: " + health + "/" + maxHealth + " ");
            Console.ResetColor();
        }

        protected bool IsGameCharacter(Player player, Enemy enemy)
        {
            if (enemy == null) return false; 
            
            if ((player.futureX == enemy.x && player.futureY == enemy.y) || (player.x == enemy.futureX && player.y == enemy.futureY))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void GetFuturePosition()
        {
            futureX = x + deltaX;
            futureY = y + deltaY;
        }

        protected void SaveLastPosition()
        {
            lastX = x;
            lastY = y;
        }

        public void Move()
        {
            if (canMoveThere == true)
            {
                y = futureY;
                x = futureX;
            }

            deltaX = 0;
            deltaY = 0;
        }
    }
}