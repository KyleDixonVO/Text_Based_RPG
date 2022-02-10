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
        public int x = 5;
        public int y = 5;
        public char avatar = '!';
        private int trackingY;
        private int trackingX;
        private int prevY;
        private int prevX;
        private bool blockedX = false;
        private bool blockedY = false;
        public void Move(int playerX, int playerY, Map map)
        {
            
            if (turnCount == 2)
            {
                if (trackingX > x && blockedX == false)
                {
                    x++;
                    if (map.isObjectSolid(x, y))
                    {
                        x++;
                    }
                    CheckBlockedX();
                    trackingX = playerX;
                }
                else if (trackingX < x && blockedX == false)
                {
                    x--;
                    if (map.isObjectSolid(x, y))
                    {
                        x--;
                    }
                    CheckBlockedX();
                    trackingX = playerX;
                }
                else if (trackingY > y && blockedY == false)
                {
                    y++;
                    if (map.isObjectSolid(x, y))
                    {
                        y--;
                    }
                    CheckBlockedY();
                    trackingY = playerY;
                }
                else if (trackingY < y && blockedY == false)
                {
                    y--;
                    if (map.isObjectSolid(x, y))
                    {
                        y++;
                    }
                    CheckBlockedY();
                    trackingY = playerY;
                }
                turnCount = 0;
            }
            turnCount++;
            prevX = x;
            prevY = y;
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
