using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class Sentinel : Enemy
    {
        public Sentinel()
        {
            damage = 2;
            avatar = 'S';
            health = 3;
            maxHealth = health;
            x = 15;
            y = 5;
        }
        public void CalculateMovement(Map map, Player player, Enemy enemy, Enemy enemy1)
        {
            SaveLastPosition();
            canMoveThere = true;
            if (Math.Abs(player.x - this.x) <= 3 && Math.Abs(player.y - this.y) <= 3)
            {
                if (Math.Abs(player.x - this.x) > Math.Abs(player.y - this.y) || Math.Abs(player.y - this.y) == 0)
                {
                    if (player.x > this.x)
                    {
                        deltaX = 1;
                    }
                    else
                    {
                        deltaX = -1;
                    }
                }
                else
                {
                    if (player.y > this.y)
                    {
                        deltaY = 1;
                    }
                    else
                    {
                        deltaY = -1;
                    }
                }
            }
            GetFuturePosition();

            if (map.IsObjectSolid(futureX, futureY))
            {
                canMoveThere = false;
            }

            if (IsGameCharacter(this, player))
            {
                Console.Beep(200, 33);
                Console.Beep(100, 33);
                player.TakeDamage(damage);
                canMoveThere = false;
                this.ShowStats(avatar);
            }

            if (IsGameCharacter(this, enemy) == true || IsGameCharacter(this, enemy1) == true)
            {
                canMoveThere = false;
            }
            Move();
        }
    }
}
