using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class Spaz : Enemy
    {
        private Random rd = new Random();

        public Spaz()
        {
            damage = 3;
            avatar = 'Z';
            health = 2;
            maxHealth = health;
            x = 5;
            y = 7;
        }

        public void CalculateMovement(Map map, Player player, Enemy enemy, Enemy enemy1)
        {
            SaveLastPosition();
            canMoveThere = true;
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

            if (IsGameCharacter(this, player) == true)
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
