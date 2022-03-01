using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class Spaz : Enemy
    {
        public void CalculateMovement(Map map, Player player)
        {
            SaveLastPosition();
            canMoveThere = true;
            Random rd = new Random();
            int moveDirection = rd.Next(0,3);
            if (moveDirection == 0)
            {
                deltaX = 1;
            }
            else if (moveDirection == 1)
            {
                deltaX = -1;
            }
            else if (moveDirection == 2)
            {
                deltaY = 1;
            }
            else if (moveDirection == 3)
            {
                deltaY = -1;
            }

            GetFuturePosition();

            if (map.IsObjectSolid(futureX, futureY) == true)
            {
                canMoveThere = false;
            }

            if (IsGameCharacter(player, this) == true)
            {
                Console.Beep(200, 33);
                Console.Beep(100, 33);
                player.TakeDamage();
                canMoveThere = false;
            }

            Move();
            
        }
    }
}
