using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class Enemy : GameCharacter
    {
        protected int turnCount;
        protected bool blockedX = false;
        protected bool blockedY = false;
        protected bool playerHit = false;



        protected void CheckBlockedX()
        {
            if (futureX == lastX && playerHit == false)
            {
                blockedX = true;
            }
            else
            {
                blockedX = false;
            }
        }

        protected void CheckBlockedY()
        {
            if (futureY == lastY && playerHit == false)
            {
                blockedY = true;
            }
            else
            {
                blockedY = false;
            }
        }

        public new void ShowStats()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(1, 14);
            Console.Write(avatar + " health: " + health + "/" + maxHealth + " ");
            Console.ResetColor();
        }
    }
}
