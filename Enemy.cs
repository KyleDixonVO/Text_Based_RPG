using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class Enemy
    {
        private int turnCount;
        public int x;
        public int y;
        public char avatar = '!';
        private int trackingY;
        private int trackingX;
        private int prevY;
        private int prevX;
        private bool blockedX;
        private bool blockedY;
        public void Move(int playerX, int playerY)
        {
            
            if (turnCount == 2)
            {
                if (trackingX > playerX && blockedX == false)
                {
                    x--;
                    CheckBlockedX();
                }
                else if (trackingX < playerX && blockedX == false)
                {
                    x++;
                    CheckBlockedX();
                }
                else if (trackingY > playerY && blockedY == false)
                {
                    y--;
                    CheckBlockedY();
                }
                else if (trackingY < playerY && blockedY == false)
                {
                    y++;
                    CheckBlockedY();
                }
                turnCount = 0;
            }
            turnCount++;
        }

        private void CheckBlockedX()
        {
            if (x == prevX)
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
            if (y == prevY)
            {
                blockedY = true;
            }
            else
            {
                blockedY = false;
            }
        }
    }
}
