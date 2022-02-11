using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class Enemy : GameCharacter
    {
        private int turnCount;
        private int trackingY;
        private int trackingX;
        private bool blockedX = false;
        private bool blockedY = false;
        private bool playerHit = false;

        public void Move(Map map, Player player)
        {
            SaveLastPosition();
            if (turnCount == 2)
            {
                playerHit = false;

                //logic used to move toward the player
                if (trackingX > x && blockedX == false)
                {
                    x++;
                    CheckBlockedX();
                }
                else if (trackingX < x && blockedX == false)
                {
                    x--;
                    CheckBlockedX();
                }
                else if (trackingY > y && blockedY == false)
                {
                    y++;
                    CheckBlockedY();
                }
                else if (trackingY < y && blockedY == false)
                {
                    y--;
                    CheckBlockedY();
                }

                //detecting collision with solid objects
                if (map.isObjectSolid(x,y))
                {
                    RecallLastPosition();
                }

                //detecting collision with player
                if (IsGameCharacter(player, this))
                {
                    player.TakeDamage();
                    RecallLastPosition();
                    playerHit = true;
                }

                turnCount = 0;
            }

            //updating turn count and tracking info
            turnCount++;
            trackingY = player.y;
            trackingX = player.x;
        }

        private void CheckBlockedX()
        {
            if (x == LastX && playerHit == false)
            {
                blockedX = true;
            }
            else
            {
                blockedX = false;
            }
        }

        private void CheckBlockedY()
        {
            if (y == LastY && playerHit == false)
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
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(1, 14);
            Console.Write(avatar + " health: " + health + "/" + maxHealth + " ");
            Console.ResetColor();
        }
    }
}
