using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class Tracker : Enemy
    {
        private int trackingY;
        private int trackingX;
        public new char avatar = 'T';

        public void CalculateMovement(Map map, Player player)
        {

            
            if (turnCount == 2)
            {
                SaveLastPosition();
                playerHit = false;
                canMoveThere = true;

                //logic used to move toward the player
                if (trackingX > x && blockedX == false)
                {
                    deltaX = 1;
                    GetFuturePosition();
                    CheckBlockedX();
                }
                else if (trackingX < x && blockedX == false)
                {
                    deltaX = -1;
                    GetFuturePosition();
                    CheckBlockedX();
                }
                else if (trackingY > y && blockedY == false)
                {
                    deltaY = 1;
                    GetFuturePosition();
                    CheckBlockedY();
                }
                else if (trackingY < y && blockedY == false)
                {
                    deltaY = -1;
                    GetFuturePosition();
                    CheckBlockedY();
                }

                //detecting collision with solid objects
                if (map.IsObjectSolid(futureX, futureY))
                {
                    canMoveThere = false;
                }

                //detecting collision with player
                if (IsGameCharacter(player, this))
                {
                    Console.Beep(200, 33);
                    Console.Beep(100, 33);
                    player.TakeDamage();
                    canMoveThere = false;
                    playerHit = true;
                }

                Move();
                turnCount = 0;
            }

            //updating turn count and tracking info
            turnCount++;
            trackingY = player.y;
            trackingX = player.x;
        }
    }
}
